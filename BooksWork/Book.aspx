<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Book.aspx.cs" Inherits="Book" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <table>
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
        <tbody id="tabela">
        </tbody>
    </table>
    <label id="lblRes"></label>


    <script type="text/javascript">
        CarregaBooks();

        function CarregaBooks() {
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
        </script>
</asp:Content>

