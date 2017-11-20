var campoFiltroCliente = document.querySelector("#filtroCliente");
var campoFiltroStatus = $("#filtroStatus");

campoFiltroStatus.change(function () {
    var cliente = $(".Campo-doStatus");
    var trDosClientes = $(".TrAluguelDosClientes");

    if (this.value != "Nenhum") {
        for (var i = 0; i < cliente.length; i++) {
            var nome = $(cliente[i]).text();

            if ($(this).val() != nome) {
                $(trDosClientes[i]).addClass("invisivel");
            } else {
                $(trDosClientes[i]).removeClass("invisivel");
            }
        }
    } else {
        for (var i = 0; i < trDosClientes.length; i++) {
            $(trDosClientes[i]).removeClass("invisivel");
        }
    }

});

campoFiltroCliente.addEventListener("input", function () {
    var cliente = $(".Campo-doCliente");
    var trDosClientes = $(".TrAluguelDosClientes");
    campoFiltroStatus.val("Nenhum");
    Filtra(this, cliente, trDosClientes);
});

function Filtra(CampoDeDigitacao, CampoTabela, CampoAEsconder) {
    if (CampoDeDigitacao.value.length > 0) {
        for (var i = 0; i < CampoTabela.length; i++) {
            var nome = $(CampoTabela[i]).text();

            var expressao = new RegExp(CampoDeDigitacao.value, "i");
            if (!expressao.test(nome)) {
                $(CampoAEsconder[i]).addClass("invisivel");
            } else {
                $(CampoAEsconder[i]).removeClass("invisivel");
            }
        }
    } else {
        for (var i = 0; i < CampoAEsconder.length; i++) {
            $(CampoAEsconder[i]).removeClass("invisivel");
        }
    }
}

//btn cancelar
$(".btnCancelPedido").click(function () {
    $.ajax({
        dataType: "json",
        type: "POST",
        url: "/Aluguel/StatusCancela",
        data: {
            Id: $(this).val()
        },
        success: function (carros) {
            var tr = $(".btnCancelPedido").parent().parent();
            var status = tr.find(".Campo-doStatus")[0];
            $(status).text("Cancelado");
            location.reload();
        },
        error: function (result) {
            console.log("Algo deu errado tente novamente")
        }
    })
});


$(".btnFianlizaPedido").click(function () {

    $.ajax({
        dataType: "json",
        type: "POST",
        url: "/Aluguel/StatusFinaliza",
        data: {
            Id: $(this).val()
        },
        success: function (carros) {
            var tr = $(".btnCancelPedido").parent().parent();
            var status = tr.find(".Campo-doStatus")[0];
            $(status).text("Finalizado");
            location.reload();
        },
        error: function (result) {
            console.log("Algo deu errado tente novamente")
        }
    })
});

$(".btnIniciarPedido").click(function () {
    console.log($(this).val());
    $.ajax({
        dataType: "json",
        type: "POST",
        url: "/Aluguel/StatusIniciar",
        data: {
            Id: $(this).val()
        },
        success: function (carros) {
            var tr = $(".btnCancelPedido").parent().parent();
            var status = tr.find(".Campo-doStatus")[0];
            $(status).text("Retirado");
            location.reload();
        },
        error: function (result) {
            console.log("Algo deu errado tente novamente")
        }
    })
});