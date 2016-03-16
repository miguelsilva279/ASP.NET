<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageGestor.master" AutoEventWireup="true" CodeFile="NewBook.aspx.cs" Inherits="NewBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="js/jquery-1.12.0.min.js"></script>
    <link rel="stylesheet" href="css/material.min.css">
    <script src="js/material.min.js"></script>
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
    <script type="text/javascript" src="js/jquery-1.12.0.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div style="width:1000px; margin-left:auto; margin-right:auto; margin-top: 10px;" class="demo-card-wide mdl-card mdl-shadow--2dp">
      <div class="mdl-card__title">
        <h2 class="mdl-card__title-text">Criar Livro</h2>
      </div>
      <div class="mdl-card__supporting-text">
         <asp:Label ID="Label3" runat="server" Text="Label">Título:</asp:Label></br>
    <input class="send" type="text" id="txtTitle"><br>
        <asp:Label ID="Label7" runat="server" Text="Label">Categoria:</asp:Label></br>
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
    <asp:Label ID="Label8" runat="server" Text="Label">Editora:</asp:Label></br>
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
    <asp:Label ID="Label9" runat="server" Text="Label">Preço:</asp:Label></br>
    <input class="send" type="text" ID="txtPreco"></input></br>
    <asp:Label ID="Label10" runat="server" Text="Label">Data:</asp:Label></br>
    <input class="send" type="date" ID="txtDate"></input></br>
    <label id="lblRes" style="color:red;"></label></br>
        
      <div class="mdl-card__actions mdl-card--border">
        <a ID="btnNewBook" class="mdl-button mdl-button--colored mdl-js-button mdl-js-ripple-effect">
          Criar
        </a>
        <a id="btnCancel" OnServerClick="btnCancel_Click" runat="server" class="mdl-button mdl-button--colored mdl-js-button mdl-js-ripple-effect">
          Cancelar
        </a>
      </div>
      <div class="mdl-card__menu">
        <button class="mdl-button mdl-button--icon mdl-js-button mdl-js-ripple-effect">
          <i class="material-icons">share</i>
        </button>
      </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <script type="text/javascript" src="js/new.js"></script>
    <script src="http://ajax.cdnjs.com/ajax/libs/json2/20110223/json2.js"></script>
</asp:Content>

