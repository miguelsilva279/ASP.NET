$(document).ready(function () {
    $("#newPub").hide();
    $("#newCategoria").hide();
});
$(document).on('click', '#btnCategoria', function () {
    $("#oldCategoria").hide();
    $("#newCategoria").show();
});

$(document).on('click', '#btnOkCategoria', function () {
    $("#oldCategoria").show();
    $("#newCategoria").hide();
});

$("#txtPesAuther").keypress(function () {
    pesquisaAuthor($(this).val());
});

function pesquisaAuthor(str) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService.asmx/PesquisaAuthor",
        data: "{id: '" + str + "'}",
        dataType: "json",
        success: function (data) {
            
            $("#formulario").append(data.d);
            

        },
        error: function (data, status, error) {
            $("#lblResultado");
        }
    });
};