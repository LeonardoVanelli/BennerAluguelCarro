var campoFiltro = document.querySelector("#filtro");

campoFiltro.addEventListener("input", function () {
    console.log(this.value);

    var pacientes = $(".Campo-Cliente");
    for (var i = 0; i < pacientes.length; i++) {
        var paciente = pacientes[i];
        console.log(paciente.Val())
    }
});