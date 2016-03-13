<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageVisitor.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
            </tr>
        </thead>
        <tbody id ="tabelaResultado" runat="server">
        </tbody>
    </table>
    <label  id ="lblResultado" runat="server"></label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <script type="text/javascript" src="js/default.js"></script>
</asp:Content>

