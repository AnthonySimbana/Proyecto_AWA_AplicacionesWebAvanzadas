<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="characterForm.aspx.cs" Inherits="WebAppWarcraftFriends.pages.characterForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Add Character</h2>

    <form id="formAgregarPersonaje" runat="server" action="/agregar-personaje" method="POST">

        <label for="region">Región:</label>
        <select id="ddlRegion" name="ddlRegion" runat="server" required>
            <option value="us">US</option>
            <option value="eu">EU</option>
        </select>
        <br>

        <select id="ddlRealm" name="ddlRealm" runat="server" required>
            <option value="quelthalas">Quel'Thalas</option>
            <option value="ragnaros">Ragnaros</option>
        </select>
        <br>

        <input type="text" id="txtName" name="txtName" runat="server" placeholder="Ingrese el nombre del personaje" required>
        <br>


        <button type="button" onclick="AgregarPersonaje_Click()">Agregar Personaje</button>

    </form>
</asp:Content>
