<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageGestor.master" AutoEventWireup="true" CodeFile="NewBook.aspx.cs" Inherits="NewBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="js/new.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Label">Título:</asp:Label></br>
    <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox></br>
    <asp:Label ID="Label2" runat="server" Text="Label">Categoria:</asp:Label></br>
    <div id="oldCategoria">
        <asp:DropDownList ID="ddlType" runat="server"></asp:DropDownList>
        <button type="button" ID="btnCategoria">Adicionar Categoria</button></br>
    </div>
    <div id="newCategoria">
         <asp:TextBox ID="txtNewCategoria" runat="server"></asp:TextBox>
        <button type="button" ID="btnOkCategoria">OK</button></br>
    </div>  
    <asp:Label ID="Label3" runat="server" Text="Label">Autor:</asp:Label></br>
    <asp:TextBox ID="txtPesAuther" runat="server"></asp:TextBox><button type="button" ID="btnPesquisaAutor">Pesquisar</button></br>
    <asp:Literal ID="Author1" runat="server"></asp:Literal>
    <asp:Literal ID="Author2" runat="server"></asp:Literal>
    <asp:Literal ID="Author3" runat="server"></asp:Literal>
    <asp:Literal ID="Author4" runat="server"></asp:Literal>
    <asp:Literal ID="Author5" runat="server"></asp:Literal>
    <asp:Button ID="btnAuther" runat="server" Text="Button" /></br>
    <asp:Label ID="Label4" runat="server" Text="Label">Editora:</asp:Label></br>
    <div id="oldPub">
        <asp:DropDownList ID="ddlPublisher" runat="server"></asp:DropDownList>
        <button type="button" ID="btnPublisher">Adicionar Editora</button>
    </div>
    <div id="newPub">
        Nome:<asp:TextBox ID="txtNewPName" runat="server"></asp:TextBox>
        City:<asp:TextBox ID="txtNewPCity" runat="server"></asp:TextBox>
        Country:<asp:TextBox ID="txtNewPCountry" runat="server"></asp:TextBox>
    </div>
    <asp:Label ID="Label5" runat="server" Text="Label">Preço:</asp:Label></br>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></br>
    <asp:Label ID="Label6" runat="server" Text="Label">Data:</asp:Label></br>
    <asp:TextBox ID="txtDate" runat="server"></asp:TextBox></br>
    <asp:Button ID="btnOk" runat="server" Text="Enviar" OnClick="btnOk_Click" />
    <asp:Button ID="btnCancel" runat="server" Text="Cancelar" OnClick="btnCancel_Click" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <script type="text/javascript" src="js/new.js"></script>
</asp:Content>

