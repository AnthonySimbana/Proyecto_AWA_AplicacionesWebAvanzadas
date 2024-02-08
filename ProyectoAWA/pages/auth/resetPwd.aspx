<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resetPwd.aspx.cs" Inherits="ProyectoAWA.pages.resetPwd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Recuperar contraseña</title>
    <link href="~/styles/styles.css" rel="stylesheet" />
</head>
<body>
    <form runat="server">
        <img src="<%= ResolveUrl("~/images/WarCraft.png") %>" alt="logo" width="100" />
        <h2>Recuperar contraseña</h2>
        <p>Ingresa tu dirección de correo electrónico asociada a tu cuenta para recuperar la contraseña.</p>

        <label for="email">Correo electrónico:</label>
        <asp:TextBox ID="email" runat="server" TextMode="Email" Required="true"></asp:TextBox>

        <asp:Button ID="btnEnviar" runat="server" CssClass="button" Text="Enviar solicitud" OnClick="btnEnviar_Click" />
    </form>
</body>
</html>
