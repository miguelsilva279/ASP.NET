<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageGestor.master" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="tab">

        <table id="tblSearch" style="width:80%; margin-left:auto; margin-right:auto; margin-top:10px;" class="mdl-data-table mdl-js-data-table mdl-shadow--2dp">
          <thead>
            <tr>
              <th class="tabHide">ID</th>
              <th class='mdl-data-table__cell--non-numeric'>Nome</th>
              <th class='mdl-data-table__cell--non-numeric'>Cidade</th>
              <th class='mdl-data-table__cell--non-numeric'>Pais</th>
              <th></th>
            </tr>
          </thead>
          <tbody id="tabelaResultadoPublisher" runat="server">
          </tbody>
        </table>
        <a href="NewBook.aspx"<button class="mdl-button mdl-js-button mdl-button--fab mdl-js-ripple-effect mdl-button--primary" style="position:fixed; right: 30px; bottom:24px;">
              <i class="material-icons">add</i>
            </button></a>
    <label  id ="lblResultado" runat="server"></label>
    </div>
    <div id="formulario" style="width:400px; margin-left:auto; margin-right:auto; margin-top:10%;">
  </div>
    </div>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <!--<script type="text/javascript" src="js/new.js"></script>-->
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <script type="text/javascript" src="js/defaultGestor.js"></script>
</asp:Content>

