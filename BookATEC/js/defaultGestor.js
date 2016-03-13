$(document).ready(function() {
    CarregaBooks();
});

function CarregaBooks() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService.asmx/getBooks2",
        data: "",
        dataType: "json",
        success: function (data) {
            $("#tabelaResultado").append(data.d);
        },
        error: function (data, status, error) {
            $("#lblResultado").text("error: " + error);
        }
    });
};

$(".editar").unbind().click(function () {
    var id = $(this).parents('tr').find('td:eq(0)').html();
    editBook(id);
});

function editBook(id) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService.asmx/EditBook",
        data: "{id: '" + id + "'}",
        dataType: "json",
        success: function (data) {
            $("#tab").hide();
            $("#formulario").show();
            $("#id") = data.d[0];
            $("#title") = data.d(1);
            $("#type") = data.d(2);
            $("#pub") = data.d(3);
            $("#price") = data.d(4);
            $("#date") = data.d(5);
        },
        error: function (data, status, error) {
            $("#lblResultado");
        }
    });
};

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
};