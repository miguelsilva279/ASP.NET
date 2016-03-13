<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageGestor.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="tab">
    <table id="tabela">
        <thead>
            <tr>
                <td>ID</td>
                <td>TITLE</td>
                <td>TYPE</td>
                <td>AUTHOR</td>
                <td>PUB</td>
                <td>PRICE</td>
                <td>DATE</td>
                <td>ACÇAO</td>
            </tr>
        </thead>
        <tbody id ="tabelaResultado" runat="server">
        </tbody>
    </table>
    <label  id ="lblResultado" runat="server"></label>
    </div>
    <div id="formulario">
        <input type="text" id="title">
        <input type="text" id="type">
        <input type="text" id="auther">
        <input type="text" id="pub">
        <input type="text" id="price">
        <input type="text" id="date">
        <button id="submit"></button>
        <button id="cancel"></button>
        <label id="lblResultado"></label>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <script type="text/javascript" src="js/defaultGestor.js"></script>
</asp:Content>

