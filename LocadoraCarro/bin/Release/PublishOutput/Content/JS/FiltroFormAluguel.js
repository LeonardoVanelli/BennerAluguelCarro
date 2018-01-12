$("#SlcClasseCarro").change(function () {
    var cliente = $(".classe-car");
    var trDosClientes = $(".lbl-carros");
    console.log(this.value);
    if (this.value != "Nenhum") {
        for (var i = 0; i < cliente.length; i++) {
            var nome = $(cliente[i]).text();
            console.log($(cliente[i]).text());
            if ("Classe: " + $(this).val() != nome) {
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