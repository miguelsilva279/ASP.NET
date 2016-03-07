<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WEBSERVERcarros.aspx.cs" Inherits="WEBSERVERcarros" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.12.0.min.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Como utilizar um web service</h3>
            <br />
            <input id="txtPedido" type="text" />
            <input id="btnPreco" type="button" value="Obter Preço" />
            <input id="btnModelo" type="button" value="Obter Modelo" />
            <label id="lblResultado"></label>
            <br />
            <br />
            <select id="select1"></select>
            <select id="select2"></select>
            <input id="btn3" type="button" value="Obter Preço" />
            <label id="lblRes"></label>
            <br />
            <br />
        </div>
    </form>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnModelo").click(function () {
                PedirModelo($("#txtPedido").val());
            });
        });

        $(document).ready(function () {
            $("#btnPreco").click(function () {
                PedirPreco($("#txtPedido").val());
            });
        });

        $("#select2").hide();

        $("#btn3").click(function () {
            PedirPreco2($("#select1").val(), $("#select2").val());
        });

        $("#select1").on("change", function () {
            CarregaModelos($(this).val());
        });

        $("#select2").on("change", function () {
            $("#lblResultado").text("");
        });

        CarregaMarcas();

        function PedirModelo(valor) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "WebService.asmx/getModelo",
                data: "{ marca: '" + valor + "'}",
                dataType: "json",
                success: function (data) {
                    $("#lblResultado").text(data.d);
                },
                error: function (data, status, error) {
                    $("#lblResultado").text("error: " + error);
                }
            });
        }

        function PedirPreco(valor) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "WebService.asmx/getValor",
                data: "{ marca: '" + valor + "'}",
                dataType: "json",
                success: function (data) {
                    $("#lblResultado").text(data.d);
                },
                error: function (data, status, error) {
                    $("#lblResultado").text("error: " + error);
                }
            });
        }

        function CarregaMarcas() {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "WebService.asmx/getMarcas",
                data: "",
                dataType: "json",
                success: function (data) {
                    $("#select1").append("<option>--</option>");
                    $("#select1").append(data.d);
                },
                error: function (data, status, error) {
                    $("#lblRes").text("error: " + error);
                }
            });
        }

        function CarregaModelos(marca) {
            $("lblResultado").text("");
            $("#lbl").text("");
            $("#select2").children().remove();
            $("#select2").hide();
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "WebService.asmx/getModelos",
                data: "{ marca: '" + marca + "'}",
                dataType: "json",
                success: function (data) {
                    if (data.d != "") {
                        $("#select2").append("<option>--</option>");
                        $("#select2").append(data.d);
                        $("#select2").show();
                    }
                },
                error: function (data, status, error) {
                    $("#lblRes").text("error: " + error);
                }
            });
        }

        function PedirPreco2(marca, modelo){
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "WebService.asmx/getPreco2",
                data: "{ marca: '" + marca + "', modelo: '" + modelo + "'}",
                dataType: "json",
                success: function (data) {
                    $("#lblRes").text(data.d);
                },
                error: function (data, status, error) {
                    $("#lblRes").text("error: " + error);
                }
            });
        }

    </script>
</body>
</html>
