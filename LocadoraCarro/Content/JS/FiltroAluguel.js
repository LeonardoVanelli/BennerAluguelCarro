var campoFiltro = document.querySelector("#filtro");

campoFiltro.addEventListener("input", function () {

    var pacientes = $(".Campo-doCliente");

    if (this.value.length > 0) {
        for (var i = 0; i < pacientes.length; i++) {
            var nome = $(pacientes[i]).text();

            var expressao = new RegExp(this.value, "i");
            if (!expressao.test(nome)) {
                $(pacientes[i]).addClass("invisivel");
            } else {
                $(pacientes[i]).removeClass("invisivel");
            }
        }
    } else {
        for (var i = 0; i < pacientes.length; i++) {            
            $(pacientes[i]).removeClass("invisivel");
        }
    }
});

//btn cancelar
$(".btnCancelPedido").click(function () {

    $.ajax({
        dataType: "json",
        type: "POST",
        url: "/Aluguel/Remove",
        data: {
            Id: $(this).val()
        },
        success: function (carros) {
            var tr = $(".btnCancelPedido").parent().parent();
            tr.fadeOut(400, function () {
                tr.remove();
            })
        },
        error: function (result) {
            console.log("Algo deu errado tente novamente")
        }
    })
});