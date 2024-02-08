<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="logIn.aspx.cs" Inherits="ProyectoAWA.pages.logIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Iniciar sesión</title>
    <link href="~/styles/styles.css" rel="stylesheet" />
</head>
<body>

    <form runat="server">
        <img src="<%= ResolveUrl("~/images/WarCraft.png") %>" alt="logo" width="100" />
        <h2>Iniciar sesión</h2>
        <label for="login-email">Correo:</label>
        <asp:TextBox ID="TextBox1" runat="server" Required="true"></asp:TextBox>
        <label for="login-password">Contraseña:</label>
        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" Required="true"></asp:TextBox>
        <p class="error-message" id="P1" runat="server"></p>
        <p class="forgot-password"><a href="resetPwd.aspx">¿Olvidó su contraseña?</a></p>
        <asp:Button ID="btnIniciarSesion" runat="server" CssClass="button" Text="Iniciar sesión" OnClientClick="signInWithEmailAndPassword(); return false;" />
        <div class="login-container">
            <hr class="login-divider" />
            <p>¿Necesitas una cuenta? <a href="signUp.aspx">Regístrate</a></p>
        </div>
    </form>
</body>
</html>
