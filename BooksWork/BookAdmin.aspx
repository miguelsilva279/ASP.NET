<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="BookAdmin.aspx.cs" Inherits="BookAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id='tabelabotoes'> 
    <table  id="tabela" style='width:100%' class='mdl-data-table mdl-js-data-table mdl-shadow--2dp'>            
    </table>
        <div id="formulario">
    <!-- Tabela de editar -->
        <div id="idaddtabela" class="addtabela z-depth-3" style="background: white">
        <h4 style="text-align:center">Editar</h4>
        <asp:Label ID="lbl" runat="server" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
        

            <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
                    <label for="txtId">Id</label>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtType"  runat="server"></asp:TextBox>
                    <label for="txtType">txtType</label>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="TextBox1"  runat="server"></asp:TextBox>
                    <label for="txtTitle">txtTitle</label>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtPubId" runat="server"></asp:TextBox>
                    <label for="txtPubId">txtPubId</label>
                </div>
            </div>
             <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                    <label for="txtPrice">txtPrice</label>
                </div>
            </div>
             <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtPubDate" runat="server"></asp:TextBox>
                    <label for="txtPubDate">txtPubDate</label>
                </div>
            </div>
            <div style="padding-top: 10px; padding-bottom: 10px">
                
            <button class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-button--primary" style="top: 0px; left: 104px" onServerClick="BotaoLogin_Click" runat="server">Entrar</button>
            <button class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-button--primary" style="top: 0px; left: 229px" onServerClick="BotaoLogin_Click" runat="server">Cancelar</button>
          </div>
    </div>
    <label id="lblRes"></label>


    <script type="text/javascript">
        $("#formulario").hide();
        CarregaBooks();

        $(".delete").unbind().click(function () {

            var id = $(this).parents('tr').find('td:eq(0)').html();
            deleteBook(id);
        });
        /*
        $(".edit").unbind().click(function (e) {
            console.log("emtrei");
            var id = $(this).parents('tr').find('td:eq(0)').html();
            editBook(id);
            alert(id);
        });
        
        $(".edit").on("click", "td:nth-child(0)", function (e) {
            alert($(this).prev().html());
            editBook($(this).prev().html());  //Get the previous sibling's HTML without inline JS
        });
        */
        $("#tabela .edit").click(function () {
            alert("entrei");
            alert($(this).parentNode.children[0].innerText);
        });
        function editBook(id) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "WebService.asmx/EditBook",
                data: "{id: '" + id + "'}",
                dataType: "json",
                success: function (data) {
                    $("#tabela").hide();
                    $("#formulario").show();
                    $("#txtId") = data.d(0);
                    $("#txtTitle") = data.d(1);
                    $("#txtType") = data.d(2);
                    $("#txtpubId") = data.d(3);
                    $("#txtPrice") = data.d(4);
                    $("#txtPubDate") = data.d(5);
                },
                error: function (data, status, error) {
                    $("#lblResultado");
                }
            });
        }

        function deleteBook(id) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "WebService.asmx/DeleteBook",
                data: "{id: '" + id + "'}",
                dataType: "json",
                success: function (data) {
                    if (!data.d) {
                        alert("Erro ao eliminar livro!");
                    }
                    else {
                        alert("Livro elinminado com Sucesso!");
                        CarregaBooks();
                    }
                    
                },
                error: function (data, status, error) {
                    $("#lblResultado");
                }
            });
        }

        function CarregaBooks() {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "WebService.asmx/getBooks2",
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

