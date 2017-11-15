var campoFiltro = document.querySelector("#filtro");

campoFiltro.addEventListener("input", function () {
    console.log(this.value);

    var pacientes = $(".Campo-Cliente");
    for (var i = 0; i < pacientes.length; i++) {
        var paciente = pacientes[i];
        console.log(paciente.Val())
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