using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAWA.pages
{
    public partial class singUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetBodyBackground();
            }
        }
        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
        }
        private void SetBodyBackground()
        {
            string imageUrl = ResolveUrl("~/images/signupwallpaper.jpg");

            Page.ClientScript.RegisterStartupScript(this.GetType(), "SetBackground",
                $"document.body.style.backgroundImage = 'url(\"{imageUrl}\")';" +
                "document.body.style.backgroundSize = 'cover';" +
                "document.body.style.backgroundRepeat = 'no-repeat';" +
                "document.body.style.backgroundPosition = 'center';", true);
        }
    }
}