<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signUp.aspx.cs" Inherits="ProyectoAWA.pages.singUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registrarse</title>
    <link href="~/styles/styles.css" rel="stylesheet" />
</head>
<body>
    <form runat="server">
        <img src="<%= ResolveUrl("~/images/WarCraft.png") %>" alt="logo" width="100" />
        <h2>Registrarse</h2>
        <label for="signup-username">Usuario:</label>
        <asp:TextBox ID="txtUsername" runat="server" ClientIDMode="Static" Required="true"></asp:TextBox>
        <label for="signup-email">Correo electrónico:</label>
        <asp:TextBox ID="txtEmail" runat="server" ClientIDMode="Static" TextMode="Email" Required="true"></asp:TextBox>
        <label for="signup-password">Contraseña:</label>
        <asp:TextBox ID="txtPassword" runat="server" ClientIDMode="Static" TextMode="Password" Required="true"></asp:TextBox>
        <label for="signup-confirmPassword">Confirmar contraseña:</label>
        <asp:TextBox ID="txtConfirmPassword" runat="server" ClientIDMode="Static" TextMode="Password" Required="true"></asp:TextBox>
        <asp:Button ID="btnRegistrarse" runat="server" CssClass="button" Text="Registrarse" OnClick="btnRegistrarse_Click" />
        <div class="login-container">
            <hr class="login-divider" />
            <p>¿Ya tienes una cuenta? <a href="logIn.aspx">Iniciar sesión</a></p>
        </div>
    </form>
</body>
</html>
