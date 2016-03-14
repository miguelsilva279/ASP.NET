<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageGestor.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="tab">
    <table id="tabela">
        <thead>
            <tr>
                <td id="tabHide"></td>
                <td>Título</td>
                <td>Categoria</td>
                <td>Autor</td>
                <td>Editora</td>
                <td>Preço</td>
                <td>Data</td>
                <td></td>
            </tr>
        </thead>
        <tbody id ="tabelaResultado" runat="server">
        </tbody>
    </table>
    <label  id ="lblResultado" runat="server"></label>
    </div>
    <div id="formulario"></div>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <script type="text/javascript" src="js/defaultGestor.js"></script>
</asp:Content>

