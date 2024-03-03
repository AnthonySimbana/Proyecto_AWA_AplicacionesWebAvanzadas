<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="characterForm.aspx.cs" Inherits="WebAppWarcraftFriends.pages.characterForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Add Character</h2>

    <form id="formAgregarPersonaje" runat="server">
        <div>
            <label for="ddlRegion">Región:</label>
            <asp:DropDownList ID="ddlRegion" runat="server" ClientIDMode="Static">
                <asp:ListItem Value="us">US</asp:ListItem>
                <asp:ListItem Value="eu">EU</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div>
            <label for="ddlRealm">Reino:</label>
            <asp:DropDownList ID="ddlRealm" runat="server" ClientIDMode="Static">
                <asp:ListItem Value="quelthalas">Quel'Thalas</asp:ListItem>
                <asp:ListItem Value="ragnaros">Ragnaros</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div>
            <label for="txtName">Nombre del personaje:</label>
            <asp:TextBox ID="txtName" runat="server" ClientIDMode="Static" placeholder="Ingrese el nombre del personaje" required></asp:TextBox>
        </div>

        <div>
            <asp:Button ID="btnAgregarPersonaje" runat="server" Text="Agregar Personaje" OnClick="btnAgregarPersonaje_Click" UseSubmitBehavior="false" />
        </div>
    </form>
</asp:Content>
