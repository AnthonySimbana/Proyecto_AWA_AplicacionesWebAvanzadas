using System;
using System.Collections.Generic;
using System.Data;
using MicroServiceUsuarios.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace MicroServiceUsuarios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            try
            {
                List<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("BDD_AWA")))
            {
                connection.Open();
                string query = "SELECT ID_USER, USERNAME, PASSWORD, EMAIL, BIRTHDAY, USER_PHOTO, USER_TYPE FROM TBL_USER";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User user = new User
                            {
                                ID_USER = reader.GetInt32(0),
                                USERNAME = reader.GetString(1),
                                PASSWORD = reader.GetString(2),
                                EMAIL = reader.GetString(3),
                                BIRTHDAY = reader.GetDateTime(4),
                                USER_PHOTO = reader.GetString(5),
                                USER_TYPE = reader.GetInt32(6),
                            };

                            users.Add(user);
                        }
                    }
                }
            }
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }

         
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            User user = null;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("BDD_AWA")))
            {
                connection.Open();
                string query = "SELECT ID_USER, USERNAME, PASSWORD, EMAIL, BIRTHDAY, USER_PHOTO, USER_TYPE FROM TBL_USER WHERE ID_USER = @Id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                ID_USER = reader.GetInt32(0),
                                USERNAME = reader.GetString(1),
                                PASSWORD = reader.GetString(2),
                                EMAIL = reader.GetString(3),
                                BIRTHDAY = reader.GetDateTime(4),
                                USER_PHOTO = reader.GetString(5),
                                USER_TYPE = reader.GetInt32(6),
                            };
                        }
                    }
                }
            }

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound(); // Devuelve un 404 si no se encuentra el usuario con el ID especificado
            }
        }

        [HttpPost]
        public ActionResult<int> AddUser(User user)
        {
            try
            {
                int rowsAffected = 0;

                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("BDD_AWA")))
                {
                    connection.Open();
                    string query = "INSERT INTO TBL_USER (USERNAME, PASSWORD, EMAIL, BIRTHDAY, USER_PHOTO, USER_TYPE) VALUES (@Username, @Password, @Email, @Birthday, @UserPhoto, @UserType)";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Username", user.USERNAME);
                        cmd.Parameters.AddWithValue("@Password", user.PASSWORD);
                        cmd.Parameters.AddWithValue("@Email", user.EMAIL);
                        cmd.Parameters.AddWithValue("@Birthday", user.BIRTHDAY);
                        cmd.Parameters.AddWithValue("@UserPhoto", user.USER_PHOTO);
                        cmd.Parameters.AddWithValue("@UserType", user.USER_TYPE);

                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                }

                return Ok(rowsAffected);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public ActionResult<int> UpdateUser(int id, User user)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("BDD_AWA")))
            {
                connection.Open();
                string query = "UPDATE TBL_USER SET USERNAME = @Username, PASSWORD = @Password, EMAIL = @Email, BIRTHDAY = @Birthday, USER_PHOTO = @UserPhoto, USER_TYPE = @UserType WHERE ID_USER = @Id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", user.USERNAME);
                    cmd.Parameters.AddWithValue("@Password", user.PASSWORD);
                    cmd.Parameters.AddWithValue("@Email", user.EMAIL);
                    cmd.Parameters.AddWithValue("@Birthday", user.BIRTHDAY);
                    cmd.Parameters.AddWithValue("@UserPhoto", user.USER_PHOTO);
                    cmd.Parameters.AddWithValue("@UserType", user.USER_TYPE);
                    cmd.Parameters.AddWithValue("@Id", id);

                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }

            return Ok(rowsAffected);
        }

        [HttpDelete("{id}")]
        public ActionResult<int> DeleteUser(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("BDD_AWA")))
                {
                    connection.Open();
                    string query = "DELETE FROM TBL_USER WHERE ID_USER = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return Ok(rowsAffected);
                        }
                        else
                        {
                            return NotFound($"Personaje con ID {id} no encontrado.");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }

        }

        [HttpPost("Login")]
        public ActionResult<User> LoginUser(LoginData loginData)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("BDD_AWA")))
                {
                    connection.Open();
                    string query = "SELECT ID_USER, USERNAME, PASSWORD, EMAIL, BIRTHDAY, USER_PHOTO, USER_TYPE FROM TBL_USER WHERE USERNAME = @Username AND PASSWORD = @Password";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Username", loginData.Username);
                        cmd.Parameters.AddWithValue("@Password", loginData.Password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                User user = new User
                                {
                                    ID_USER = reader.GetInt32(0),
                                    USERNAME = reader.GetString(1),
                                    PASSWORD = reader.GetString(2),
                                    EMAIL = reader.GetString(3),
                                    BIRTHDAY = reader.GetDateTime(4),
                                    USER_PHOTO = reader.IsDBNull(5) ? null : reader.GetString(5),
                                    USER_TYPE = reader.GetInt32(6),
                                };

                                // Autenticación exitosa, puedes devolver más información o un token JWT si es necesario
                                return Ok(user);
                            }
                            else
                            {
                                // Credenciales inválidas
                                return Unauthorized(new { Message = "Invalid credentials" });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }


        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("BDD_AWA"));
        }
    }
}
