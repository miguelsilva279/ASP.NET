<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <script type="text/javascript" src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.12.0.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <thead>
            <tr>
                <td>ID</td>
                <td>TITLE</td>
                <td>TYPE</td>
                <td>PUB</td>
                <td>PRICE</td>
                <td>DATE</td>
            </tr>
        </thead>
        <tbody id="tabela">
            
            
        </tbody>
    </table>
    <label id="lblRes"></label>
</asp:Content>

<script type="text/javascript">
CarregaBooks();

function CarregaMarcas() {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "WebService.asmx/getBooks",
                data: "",
                dataType: "json",
                success: function (data) {
                    $("#tabela").append(data.d);
                },
                error: function (data, status, error) {
                    $("#lblRes").text("error: " + error);
                }
            });
        }

<script>