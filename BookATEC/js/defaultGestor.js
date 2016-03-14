$(document).ready(function () {
    CarregaBooks();
});

$(document).ready(function () {
    $("#data").datepicker({
        format: "dd-mm-yyyy",
        language: "pt"
    });
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

$(".apagar").unbind().click(function () {
    var id = $(this).parents('tr').find('td:eq(0)').html();
    deleteBook(id);
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
            $("#formulario").append(data.d);
            $("#newType").hide();

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
}

    $(document).on('click', '#addType', function () {

        $("#oldType").hide();
        $("#newType").show();

    });


