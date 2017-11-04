var FormCarro = $(".carro");
var FormProtecao = $(".protecao");
var FormCliente = $(".cliente");

var DataHoraRetirada;

$("#btn-proximo").click(function () {
    event.preventDefault();    
    var FormData = $(".data-hora");
    console.log(RetiraValorDataHora());

    FormData.addClass("invisivel");
    FormCarro.removeClass("invisivel");
    retornaCarros();
    console.log(DataHoraRetirada);
})

function RetiraValorDataHora() {
    var dataRetirada  = $("#data_retirada") .val();
    
    var horaRetirada  = $("#hora_retirada") .val();
    var dataDevolucao = $("#data_devolucao").val();
    var horaDevolucao = $("#hora_devolucao").val();
    var DataIdade     = $("#data_idade")    .val();
    
    DataHoraRetirada = [{
        DataRetirada: dataRetirada,
        HoraRetirada: horaRetirada,
        DataDevolucao: dataDevolucao,
        horaDevolucao: horaDevolucao
    }]
}
function SelecionaCarro() {
    event.preventDefault();
    FormCarro.addClass("invisivel");
    FormProtecao.removeClass("invisivel");

    var btn = $(this).parent().find("p")[0].innerHTML;
    console.log(btn);
}

$(".btn-protecao").click(function (event) {
    event.preventDefault();
    FormProtecao.addClass("invisivel");
    FormCliente.removeClass("invisivel");
    var td = $(this).parent().parent();
    
    console.log(td.find("td")[0].innerHTML);
})

function retornaCarros() {
    var carros = $.get("http://localhost:50806/aluguel/BuscaCarros", function (carros) {
 
        for (var i = 0; i < carros.length; i++) {
            MontaCarro(carros[i].Id, carros[i].Modelo, carros[i].Marca, carros[i].Preco);
        }
    })
    
}

$("#btn-cadastrar").click(function () {
    event.preventDefault();
    adicionaUsuario();

    $.ajax({
        dataType: "json",
        type: "POST",
        url: "/Aluguel/Adiciona",
        data: {
            DataHoraRetirada: DataHoraRetirada.dataRetirada,
            DataHoraDevolucao: $("#cpf").val(),
            IdCliente: $("#email").val(),
            IdCarro: $("#telefone").val(),
            IdProtecao: $("#login").val()
        },
    })
})

function adicionaUsuario() {
    var idUsuario = $.ajax({
        dataType: "json",
        type: "POST",
        url: "/Aluguel/AdicionaUsuario",
        data: {
            Nome    : $("#nome").val(),
            Cpf     : $("#cpf").val(),
            Email   : $("#email").val(),
            Telefone: $("#telefone").val(),
            Login   : $("#login").val(),
            Senha   : $("#senha").val()
        },
    })
    return idUsuario;
}