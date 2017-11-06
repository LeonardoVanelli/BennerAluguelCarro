var FormCarro = $(".carro");
var FormProtecao = $(".protecao");
var FormCliente = $(".cliente");
var FormUsuario = $(".escolhaCliente");

var dataHoraRetirada;
var dataHoraDevolucao;
var idCarro;
var idProtecao;
var idCliente;

$("#btn-proximo").click(function () {
    event.preventDefault();    
    var FormData = $(".data-hora");
    RetiraValorDataHora()

    FormData.addClass("invisivel");
    FormCarro.removeClass("invisivel");
    retornaCarros();
})

function RetiraValorDataHora() {
    var dataRetirada  = $("#data_retirada") .val();
    
    var horaRetirada  = $("#hora_retirada") .val();
    var dataDevolucao = $("#data_devolucao").val();
    var horaDevolucao = $("#hora_devolucao").val();
    var DataIdade     = $("#data_idade")    .val();
    
    dataHoraRetirada = dataRetirada + " " + horaRetirada;
    dataHoraDevolucao = dataDevolucao + " " + horaDevolucao;
}
function SelecionaCarro() {
    event.preventDefault();
    FormCarro.addClass("invisivel");
    FormProtecao.removeClass("invisivel");

    idCarro = $(this).parent().find("p")[0].innerHTML; 
}

$(".btn-protecao").click(function (event) {
    event.preventDefault();
    FormProtecao.addClass("invisivel");
    FormUsuario.removeClass("invisivel");
    var td = $(this).parent().parent();
    
    idProtecao = td.find("td")[0].innerHTML;
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
        
    $.ajax({
        dataType: "json",
        type: "POST",
        url: "/Aluguel/AdicionaUsuario",
        data: {
            Nome: $("#nome").val(),
            Cpf: $("#cpf").val(),
            Email: $("#email").val(),
            Telefone: $("#telefone").val(),
            Login: $("#login").val(),
            Senha: $("#senha").val()
        },
        success: function (result) {            
            $.ajax({
                dataType: "json",
                type: "POST",
                url: "/Aluguel/Adiciona",
                data: {
                    dTRetirada: dataHoraRetirada,
                    dTDevolucao: dataHoraDevolucao,
                    IdCliente: result.id,
                    IdCarro: idCarro,
                    IdProtecao: idProtecao
                }
            })
        }
    })
})

function adicionaUsuario() {
    $.ajax({
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
        success: function (result) {
            idCliente = result.id;
        }
    })
}

function testesss() {
    console.log(dataHoraRetirada);
    console.log(dataHoraDevolucao);
    console.log(idCliente);
}