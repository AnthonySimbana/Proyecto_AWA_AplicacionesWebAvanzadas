using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebAppWarcraftFriends.pages
{
    public partial class characterForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregarPersonaje_Click(object sender, EventArgs e)
        {
            // Obtener los valores del formulario
            string region = ddlRegion.Value;
            string realm = ddlRealm.Value;
            string name = txtName.Name;

            // Crear una instancia del cliente del servicio web
            var serviceClient = new ServiceReferenceCharacter.MicroServiceCharacterSoapClient();

            // Llamar al método del servicio web
            Character character = serviceClient.GetCharacterDetails(region, realm, name);

            // Verificar si se produjo un error
            if (!string.IsNullOrEmpty(character.Error))
            {
                // Manejar el error, por ejemplo, mostrar un mensaje al usuario
                lblMensaje.Text = $"Error: {character.Error}";
            }
            else
            {
                // Mostrar la información del personaje, puedes hacer lo que desees aquí
                lblMensaje.Text = $"Personaje agregado: {character.Name}, Clase: {character.Class}, Región: {character.Region}";
            }
        }

    }
}