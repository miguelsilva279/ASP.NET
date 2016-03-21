$(document).ready(function() {
    CarregaBooks();
    CarregaAuthors();
    CarregaPublishers();
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

function CarregaAuthors() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService.asmx/getAuthors2",
        data: "",
        dataType: "json",
        success: function (data) {
            $("#tabelaResultadoAuthor").append(data.d);
        },
        error: function (data, status, error) {
            $("#lblResultado").text("error: " + error);
        }
    });
};

function CarregaPublishers() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService.asmx/getPublishers2",
        data: "",
        dataType: "json",
        success: function (data) {
            $("#tabelaResultadoPublisher").append(data.d);
        },
        error: function (data, status, error) {
            $("#lblResultado").text("error: " + error);
        }
    });
};