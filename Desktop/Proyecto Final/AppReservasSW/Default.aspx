<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/adentro.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AppReservasSW._Default" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-left: auto; margin-right: auto; text-align: center;">
    <asp:Label ID="Label3" runat="server" Text="Bienvenido al mantenimiento del Sistema de Vuelos, por favor seleccione una opción en la parte superior derecha" Font-Bold="true" Font-Size="X-Large"
        CssClass="StrongText"></asp:Label>
    </div>
    <br/>
    <br/>
    <div style="margin-left: auto; margin-right: auto; text-align: center;">
        <img src="images/mantenimiento.png" width="300" height="250"/>
    </div>
</asp:Content>