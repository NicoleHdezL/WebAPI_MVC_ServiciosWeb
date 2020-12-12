<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/adentro.Master" AutoEventWireup="true" CodeBehind="Equipaje.aspx.cs" Inherits="AppReservasSW.Views.Equipaje" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server" >
    <div style="margin-left: auto; margin-right: auto; text-align: center;">
        <br />
    <asp:Label ID="Label3" runat="server" Text="Mantenimiento de Equipajes" Font-Bold="true" Font-Size="X-Large"
        CssClass="StrongText"></asp:Label>
    </div>
    <br/>
    <br/>
    <form runat="server" id="f1">
        <div runat="server" id="d">
    <asp:GridView ID="grdEquipajes" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
            <br />
            Código:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
            <br />
            Tipo:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
            <asp:TextBox ID="txtTipo" runat="server"></asp:TextBox>
            <br />
            Precio:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
            <br />
            Descripcion:
            <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblStatus" runat="server" ForeColor="#00CC66" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnModificar" runat="server" OnClick="btnModificar_Click" Text="Modificar" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" />
            <br />
            <br />
        </div>
        </form>
</asp:Content>
