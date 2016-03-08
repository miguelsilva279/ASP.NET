<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Author.aspx.cs" Inherits="Author" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <thead>
            <tr>
                <td>ID</td>
                <td>Name</td>
                <td>phone</td>
                <td>city</td>
            </tr>
        </thead>
        <tbody id="tabela">
        </tbody>
    </table>
    <label id="lblRes"></label>


    <script type="text/javascript">
        CarregaAuthor();

        function CarregaAuthor() {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "WebService.asmx/getAuthors",
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

