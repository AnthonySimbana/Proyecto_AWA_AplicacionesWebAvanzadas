﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppWarcraftFriends.pages
{
    public partial class resetPwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetBodyBackground();
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {

            string correoElectronico = email.Text;
            Response.Redirect("SolicitudEnviada.aspx");
        }

        private void SetBodyBackground()
        {
            string imageUrl = ResolveUrl("~/images/resetpwdwallpaper.jpg");

            Page.ClientScript.RegisterStartupScript(this.GetType(), "SetBackground",
                $"document.body.style.backgroundImage = 'url(\"{imageUrl}\")';" +
                "document.body.style.backgroundSize = 'cover';" +
                "document.body.style.backgroundRepeat = 'no-repeat';" +
                "document.body.style.backgroundPosition = 'center';", true);
        }
    }
}