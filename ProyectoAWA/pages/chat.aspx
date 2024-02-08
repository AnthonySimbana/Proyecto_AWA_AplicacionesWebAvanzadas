<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="chat.aspx.cs" Inherits="WebAppWarcraftFriends.pages.chat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Chat Example</h2>
    <div class="chat-container">
        <div class="chat-body" id="chatBody">
            <div class="message user-message">
                <div class="user-message">Hola, ¿cómo estás?</div>
                <img id="useravatar" class="user-avatar" src="" alt="User Avatar">
            </div>
            <div class="message other-message">
                <img id="otheravatar" class="other-avatar" src="" alt="Other Avatar">
                <div class="other-message">¡Hola! Estoy bien, gracias.</div>
            </div>
        </div>
        <div class="chat-input">
            <input type="text" id="messageInput" placeholder="Escribe un mensaje">
            <input type="button" value="Enviar" id="sendButton" onclick="sendMessage()">
        </div>
    </div>
</asp:Content>
