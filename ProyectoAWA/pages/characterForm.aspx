<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="characterForm.aspx.cs" Inherits="WebAppWarcraftFriends.pages.characterForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Add Character</h2>

    <form action="/agregar-personaje" method="POST">
        <label for="region">Región:</label>
        <select id="region" name="region" required>
            <option value="us">US</option>
            <option value="eu">EU</option>
        </select>
        <br>

        <label for="realm">Reino:</label>
        <select id="realm" name="realm" required>
            <option value="quelthalas">Quel'Thalas</option>
            <option value="ragnaros">Ragnaros</option>
        </select>
        <br>

        <label for="name">Nombre del Personaje:</label>
        <input type="text" id="name" name="name" placeholder="Ingrese el nombre del personaje" required>
        <br>

        <button type="submit">Agregar Personaje</button>
    </form>
</asp:Content>
