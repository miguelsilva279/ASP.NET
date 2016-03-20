$(document).ready(function () {
    $("#newPub").hide();
    $("#newCategoria").hide();
    $("#newRegistoAutor").hide();
});

$(document).on('click', '#btnCategoria', function () {
    $("#oldCategoria").hide();
    $("#newCategoria").show();
});

$(document).on('click', '.eliminarAutor', function () {
    $(this).parent('div').remove('div');
});

function verificaTextBox() {
    var allFilled = true;

    $('.send').each(function (index, element) {
        if (element.value === '') {
            allFilled = false;
        }
    });
    return allFilled;
};

function verificaInsertAuthor() {
    var allFilled = true;

    if ($("#showAuthor > div").length <= 0) {
        allFilled = false;
    }
    return allFilled;
};

function verificaDropDown() {
    var allFilled = true;
    if ($("#selType option:selected").index() <= 0) {
        allFilled = false;
    }
    if ($("#selPub option:selected").index() <= 0) {
        allFilled = false;
    }

    return allFilled;
};



$(document).on('click', '#btnNewBook', function () {
    var arr1 = [];
    var arr2 = [];
    if (!verificaDropDown() || !verificaTextBox() || !verificaInsertAuthor()) {
        $("#lblRes").html("Preencha todos os campos.");
    } else {
        arr1 = [
        $("#txtTitle").val(),
        $("#selType option:selected").text(),
        $("#selPub option:selected").text(),
        $("#txtPreco").val(),
        $("#txtDate").val()
        ];


        $("#showAuthor").children().each(function () {

            arr2.push($(this).children('input').val());
        });

    }
    addBook(arr1, arr2);

});

$(document).on('click', '#btnEditarBook', function () {
    var arr1 = [];
    var arr2 = [];
    if (!verificaDropDown() || !verificaTextBox() || !verificaInsertAuthor()) {
        $("#lblRes").html("Preencha todos os campos.");
    } else {
        arr1 = [
        $("#txtID").val(),
        $("#txtTitle").val(),
        $("#selType option:selected").text(),
        $("#selPub option:selected").text(),
        $("#txtPreco").val(),
        $("#txtDate").val()
        ];

        $("#showAuthor > div").each(function (index, element) {

            arr2.push($(".novoAutor").val());
            alert($(".novoAutor").val());
        });

    }
    editBook(arr1, arr2);

});

$(document).on('click', '#addAuthor', function () {
    $("#showAuthor").append("<div><input class='novoAutor' type='text' value='" + $("#tags").val() + "' readonly/><button class='eliminarAutor' type='button'>Eliminar</button></div>");
    $("#tags").val("");
});

$(document).on('click', '#addAuthorNew', function () {
    $("#newRegistoAutor").show();
});

$(document).on('click', '#btnPublisher', function () {
    $("#newPub").show();
});
$(document).on('click', '#btnCancel', function () {
    window.location.href = "Default.aspx";
});

$(document).on('click', '#btnOkAuthor', function () {
    var arr = [
    $("#fnameAuthor").val(),
    $("#lnameAuthor").val(),
    $("#telefoneAuthor").val(),
    $("#cidadeAuthor").val()
    ];
    addAuthor(arr);
});

$(document).on('click', '#btnCancelAuthor', function () {
    $("#fnameAuthor").val("");
    $("#lnameAuthor").val("");
    $("#telefoneAuthor").val("");
    $("#cidadeAuthor").val("");
    $("#newRegistoAutor").hide();

});

$(document).on('click', '#btnOkPublisher', function () {
    var arr = [
    $("#txtNewPName").val(),
    $("#txtNewPCity").val(),
    $("#txtNewPCountry").val(),
    ];
    addPublisher(arr);
});

$(document).on('click', '#btnCancelPublisher', function () {
    $("#txtNewPName").val("");
    $("#txtNewPCity").val("");
    $("#txtNewPCountry").val("");
    $("#newPub").hide();
});
$(document).on('click', '#btnOkCategoria', function () {
    var txtNew = $("#txtNewCategoria").val();
    $('#selType').append("<option selected>" + txtNew + "</option>");
    $("#btnCategoria").hide();
    $("#oldCategoria").show();
    $("#newCategoria").hide();

});

var availableTags = [];

$(document).ready(function () {
    pesquisaAuthor();
    $(function () {
        availableTags;
        $("#tags").autocomplete({
            source: availableTags,
        });
    });
});

function pesquisaAuthor() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService.asmx/PesquisaAuthor",
        data: "",
        dataType: "json",
        success: function (data) {
            var SplitData = data.d.split(',');
            for (var i = 0; i < SplitData.length ; i++) {
                availableTags[i] = SplitData[i];
            }

        },
        error: function (data, status, error) {
            $("#lblResultado");
        }
    });
};

function addBook(arr1, arr2) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService.asmx/AddBook",
        data: JSON.stringify({ arr1: arr1, arr2: arr2 }),
        dataType: "json",
        success: function (data) {
            if (data.d) {
                alert("Inserido com Sucesso")
            }
            else {
                alert("Erro ao inserir");
            }

        },
        error: function (data, status, error) {
            $("#lblResultado");
        }
    });
};

function addAuthor(arr) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService.asmx/AddAuthor",
        data: JSON.stringify({ arr: arr }),
        dataType: "json",
        success: function (data) {
            if (data.d) {
                alert("Inserido com sucesso");
                $("#showAuthor").append("<div><input class='novoAutor' type='text' value='" + $("#fnameAuthor").val() + " " + $("#lnameAuthor").val() + "' readonly/><button class='eliminarAutor' type='button'>Eliminar</button></div>");
                $("#fnameAuthor").val("");
                $("#lnameAuthor").val("");
                $("#telefoneAuthor").val("");
                $("#cidadeAuthor").val("");
                $("#newRegistoAutor").hide();
            }
            else {
                alert("Erro ao inserir");
            }

        },
        error: function (data, status, error) {
            $("#lblResultado");
        }
    });
};

function addPublisher(arr) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService.asmx/AddPublisher",
        data: JSON.stringify({ arr: arr }),
        dataType: "json",
        success: function (data) {
            if (data.d) {
                alert("Inserido com sucesso");
                $("#selPub").append("<option value='" + $("#txtNewPName").val() + "'selected >" + $("#txtNewPName").val() + "</option>");
                $("#txtNewPName").val("");
                $("#txtNewPCity").val("");
                $("#txtNewPCountry").val("");
                $("#newPub").hide();
            }
            else {
                alert("Erro ao inserir");
            }

        },
        error: function (data, status, error) {
            $("#lblResultado");
        }
    });
};

function editBook(arr1, arr2) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService.asmx/editBook",
        data: JSON.stringify({ arr1: arr1, arr2: arr2 }),
        dataType: "json",
        success: function (data) {
            if (data.d) {
                alert("Inserido com Sucesso")
            }
            else {
                alert("Erro ao inserir");
            }

        },
        error: function (data, status, error) {
            $("#lblResultado");
        }
    });
}
