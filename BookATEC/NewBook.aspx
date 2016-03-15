<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageGestor.master" AutoEventWireup="true" CodeFile="NewBook.aspx.cs" Inherits="NewBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!--<link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">-->
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" integrity="sha384-1q8mTJOASx8j1Au+a5WDVnPi2lkFfwwEAa8hDDdjZlpLegxhjVME1fgjWPGmkzs7" crossorigin="anonymous">

    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap-theme.min.css" integrity="sha384-fLW2N01lMqjakBkx3l/M9EahuwpSfeNvV63J5ezn3uZzapT0u7EYsXMjQV+0En5r" crossorigin="anonymous">

    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js" integrity="sha384-0mSbJDEHialfmuBBQP6A4Qrprq5OVfW37PRR3j5ELqxss1yVqOtnepnHVP9aJ7xS" crossorigin="anonymous"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Label">Título:</asp:Label></br>
    <input class="send" type="text" id="txtTitle"><br>
        <asp:Label ID="Label2" runat="server" Text="Label">Categoria:</asp:Label></br>
    <div id="oldCategoria">
        <asp:Literal ID="literalType" runat="server"></asp:Literal>
        <button type="button" id="btnCategoria">Adicionar</button></br>
    </div>
    <div id="newCategoria">
        <input type="text" id="txtNewCategoria" />
        <button type="button" id="btnOkCategoria">OK</button></br>
    </div>
    <div class="ui-widget">
        <label>Autor: </label>
        </br>
        Pesquisar:<input id="tags">
        <button type="button" id="addAuthor">Adicionar</button>
        <button type="button" id="addAuthorNew">Novo Registo</button>
    </div>
    <div id="newRegistoAutor">
        <div>
            Primeiro Nome:</br>
            <input id="fnameAuthor" type="text" /></br>
            Ultimo Nome:</br>
            <input id="lnameAuthor" type="text" /></br>
            Telefone:</br>
            <input id="telefoneAuthor" type="text" /></br>
            Cidade:</br>
            <input id="cidadeAuthor" type="text" /></br>
            <button id="btnOkAuthor" type="button">Ok</button>
            <button id="btnCancelAuthor" type="button">Cancelar</button>
        </div>
    </div>
    <div id="showAuthor"></div>
    <asp:Label ID="Label4" runat="server" Text="Label">Editora:</asp:Label></br>
    <div id="oldPub">
        <asp:Literal ID="literalPublisher" runat="server"></asp:Literal>
        <button type="button" id="btnPublisher">Adicionar</button>
    </div>
    <div id="newPub">
        Nome:<input type="text" id="txtNewPName"></input>
        City:<input type="text" id="txtNewPCity"></input>
        Country:<input type="text" id="txtNewPCountry"></input>
        <button id="btnOkPublisher" type="button">Ok</button>
        <button id="btnCancelPublisher" type="button">Cancelar</button>
    </div>
    <asp:Label ID="Label5" runat="server" Text="Label">Preço:</asp:Label></br>
    <input class="send" type="text" ID="txtPreco"></input></br>
    <asp:Label ID="Label6" runat="server" Text="Label">Data:</asp:Label></br>
    <input class="send" type="date" ID="txtDate"></input></br>
    <label id="lblRes"></label></br>
    <button ID="btnNewBook" type="button">Enviar</button>
    <asp:Button ID="btnCancel" runat="server" Text="Cancelar" OnClick="btnCancel_Click" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <script type="text/javascript" src="js/new.js"></script>
    <script src="http://ajax.cdnjs.com/ajax/libs/json2/20110223/json2.js"></script>
</asp:Content>

