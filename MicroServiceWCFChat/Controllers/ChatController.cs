using Google.Cloud.Firestore;
using MicroServiceWCFChat.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace MicroServiceUsuarios.Controllers
{
    public class ChatController : Controller
    {
        private readonly FirestoreDb _firestoreDb;

        public ChatController(FirestoreDb firestoreDb)
        {
            _firestoreDb = firestoreDb;
        }

        [HttpGet("/ws")]
        public async Task GetWebSocket()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                await HandleWebSocket(webSocket);
            }
            else
            {
                HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
        }

        private async Task HandleWebSocket(WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            var receiveResult = await webSocket.ReceiveAsync(
                new ArraySegment<byte>(buffer), CancellationToken.None);

            while (!receiveResult.CloseStatus.HasValue)
            {
                await webSocket.SendAsync(
                    new ArraySegment<byte>(buffer, 0, receiveResult.Count),
                    receiveResult.MessageType,
                    receiveResult.EndOfMessage,
                    CancellationToken.None);

                receiveResult = await webSocket.ReceiveAsync(
                    new ArraySegment<byte>(buffer), CancellationToken.None);
            }

            await webSocket.CloseAsync(
                receiveResult.CloseStatus.Value,
                receiveResult.CloseStatusDescription,
                CancellationToken.None);
        }


        [HttpGet("getAllChats")]
        public async Task<IActionResult> GetAllDevices()
        {
            var collection = _firestoreDb.Collection("chat");
            var documents = await collection.GetSnapshotAsync();

            var chatList = new List<Dictionary<string, object>>();

            // Itera sobre los documentos y agrega los datos al listado de dispositivos
            foreach (var document in documents)
            {
                var chatData = document.ToDictionary();
                chatList.Add(chatData);
            }

            // Devuelve la lista de dispositivos en el cuerpo de la respuesta
            return Ok(chatList);
        }

        [HttpPost("createChat")]
        public async Task<IActionResult> CreateChat([FromBody] Chat chat)
        {
            try
            {
                // Validar modelo de dispositivo
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Obtener una referencia a la colección de dispositivos en Firestore
                var collection = _firestoreDb.Collection("chat");

                // Convertir el objeto del modelo a un diccionario
                var chatData = new Dictionary<string, object>
        {

                    { "Id", chat.ID_CHAT},
                    { "Id_user", chat.ID_USER},
                    {"Timestamp", chat.DATETIME },
                    { "Message", chat.MESSAGE}

                
        // Agrega aquí otros campos si es necesario
    };

                // Agregar el nuevo dispositivo a Firestore
                await collection.AddAsync(chatData);

                // Devolver el código 201 Created con la respuesta
                return StatusCode(201, "Chat creado exitosamente.");
            }
            catch (Exception ex)
            {
                // En caso de error, devolver un error interno del servidor
                return StatusCode(500, $"Ocurrio un error en la creacion: {ex.Message}");
            }
        }

        [HttpDelete("deleteChat/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
            {
                // Obtener una referencia a la colección de dispositivos en Firestore
                var collection = _firestoreDb.Collection("chat");

                // Realizar una consulta para obtener el dispositivo por su ID
                var query = collection.WhereEqualTo("Id", id);
                var querySnapshot = await query.GetSnapshotAsync();

                // Verificar si se encontró un dispositivo con la ID especificada
                if (querySnapshot.Count > 0)
                {
                    // Eliminar el dispositivo encontrado (asumiendo que la ID es única)
                    var document = querySnapshot.Documents[0].Reference;
                    await document.DeleteAsync();

                    // Devolver un mensaje de éxito
                    return Ok("Chat eliminado con exito.");
                }
                else
                {
                    // Si no se encuentra ningún dispositivo con la ID especificada, devolver un error 404 Not Found
                    return NotFound("No se encontraron resultados para eliminar.");
                }
            }
            catch (Exception ex)
            {
                // En caso de error, devolver un error interno del servidor
                return StatusCode(500, $"Ocurrio un error en la eliminacion: {ex.Message}");
            }
        }



    }
}

