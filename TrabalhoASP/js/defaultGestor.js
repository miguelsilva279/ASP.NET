$(document).ready(function () {
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

$(".editarBook").unbind().click(function () {
    var id = $(this).parents('tr').find('td:eq(0)').html();
    
    getBook(id);
});
/* Para modificar ***NUNO
$(".editarAuthor").unbind().click(function () {
    var id = $(this).parents('tr').find('td:eq(0)').html();

    getBook(id);
});

$(".editarPublisher").unbind().click(function () {
    var id = $(this).parents('tr').find('td:eq(0)').html();

    getBook(id);
});*/

$(".apagarBook").unbind().click(function () {
    var id = $(this).parents('tr').find('td:eq(0)').html();
    deleteBook(id);
});
/* ***NUNO
$(".apagarAuthor").unbind().click(function () {
    var id = $(this).parents('tr').find('td:eq(0)').html();
    deleteBook(id);
});

$(".apagarPublisher").unbind().click(function () {
    var id = $(this).parents('tr').find('td:eq(0)').html();
    deleteBook(id);
});
*/
function getBook(id) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService.asmx/getBook",
        data: "{id: '" + id + "'}",
        dataType: "json",
        success: function (data) {
            $("#tab").hide();
            $("#formulario").append(data.d);
            $("#newPub").hide();
            $("#newCategoria").hide();
            $("#newRegistoAutor").hide();

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
                alert("Livro eliminado com Sucesso!");
                window.location.href = "Default.aspx";
            }

        },
        error: function (data, status, error) {
            $("#lblResultado");
        }
    });
}



