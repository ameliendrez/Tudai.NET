<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TUDAI.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>MiNombre</h1>
    <asp:Label CssClass="" Text="Minombre" runat="server"></asp:Label>
    <h2>Noticias</h2>

    <asp:GridView ID="gvNoticias" runat="server" CssClass="table table-hover" GridLines="None" BorderStyle="None"
        AutoGenerateColumns="false" OnRowCommand="gvNoticias_RowCommand" DataKeyNames="id">
            <Columns>
                <asp:BoundField DataField="id" visible="false"/>
                <asp:BoundField DataField="titulo" HeaderText="Titulo" />
                <asp:BoundField DataField="fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="cuerpo" HeaderText="Cuerpo" />
                <asp:BoundField DataField="id_categoria" HeaderText="ID_Categoria" />
                <asp:BoundField DataField="autor" HeaderText="Autor" />
               <asp:ButtonField Text="Editar" ButtonType="Link" CommandName="editar"/>
               <asp:ButtonField Text="Mostrar" ButtonType="Link" CommandName="mostrar"/>

            </Columns>

    </asp:GridView>

</asp:Content>
