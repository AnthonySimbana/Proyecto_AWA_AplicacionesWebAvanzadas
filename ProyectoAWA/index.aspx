<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ProyectoAWA.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-content">
        <h2>Latest News</h2>
        <div class="news">
            <article>
                <h3>New Expansion Announced!</h3>
                <p>Exciting news for Warcraft fans as a new expansion is revealed.</p>
            </article>
            <article>
                <h3>Community Spotlight</h3>
                <p>Discover amazing stories from the Warcraft community.</p>
            </article>
        </div>
    </div>
</asp:Content>
