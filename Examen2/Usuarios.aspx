<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="Examen2.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="text-center">
    <h1> USUARIOS </h1>
</div>

         <div>
     <br />
     <asp:GridView runat="server" ID="datagrid" PageSize="10" HorizontalAlign="Center"
         CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
         RowStyle-CssClass="rows" AllowPaging="True"    />
    <br />
</div>
    <div class="container text-center">
      ID:
        <asp:TextBox ID="TIdUsuario" CssClass="form-control" runat="server"></asp:TextBox>
      Nombre:
        <asp:TextBox ID="TNombre" CssClass="form-control" runat="server"></asp:TextBox>
      Correo:
        <asp:TextBox ID="TCorreo" CssClass="form-control" runat="server"></asp:TextBox>
      Telefono:
        <asp:TextBox ID="Ttelefono" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

<div class="container text-center">
     <asp:Button ID="Button1" runat="server"  class="btn btn-outline-primary" Text="Agregar" OnClick="Button1_Click" />
 <asp:Button ID="Button2" runat="server"  class="btn btn-outline-primary" Text="Borrar" OnClick="Button2_Click" />
 <asp:Button ID="Button3" runat="server"  class="btn btn-outline-primary" Text="Modificar" OnClick="Button3_Click" />
 <asp:Button ID="Button4" runat="server"  class="btn btn-outline-primary" Text="Consultar" OnClick="Button4_Click" />

</div>

</asp:Content>
