using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using WebAppWarcraftFriends.ServiceReferenceCharacter;

namespace WebAppWarcraftFriends.pages
{
    public partial class characterForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregarPersonaje_Click(object sender, EventArgs e)
        {
            try
            {
                string region = ddlRegion.SelectedValue;
                string realm = ddlRealm.SelectedValue;
                string name = txtName.Text;
                MicroServiceCharacterSoapClient client = new MicroServiceCharacterSoapClient();
                CharacterInfo character = client.GetCharacterDetails(region, realm, name);
                Console.WriteLine("HolA");
            }
            catch (Exception ex)
            {

            }
        }

    }
}