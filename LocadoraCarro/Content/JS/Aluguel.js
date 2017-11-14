var FormCarro = $(".carro");
var FormProtecao = $(".protecao");
var FormCliente = $(".cliente");
var FormUsuario = $(".escolhaCliente");

var dataHoraRetirada;
var dataHoraDevolucao;
var diasAlugado;
var idCarro;
var idProtecao;
var idCliente;
var PerguntarSeQuerSair = true;

$("#btn-proximo").click(function () {
    event.preventDefault();    
    var FormData = $(".data-hora"); 
    RetiraValorDataHora();
    if (ValidaCamposDatas()) {
        FormData.addClass("invisivel");
        FormCarro.removeClass("invisivel");
        retornaCarros();
    }
})

function ValidaCamposDatas() {
    var patternData = /^[0-9]{2}\/[0-9]{2}\/[0-9]{4}$/;
    if (!patternData.test($("#data_retirada").val())) {
        alert("Digite a data no formato Dia/Mês/Ano");
        return false;
    }
    return true
}

function RetiraValorDataHora() {

    var dataRetirada = $("#data_retirada").val();
    
    var horaRetirada  = $("#hora_retirada") .val();
    var dataDevolucao = $("#data_devolucao").val();
    var horaDevolucao = $("#hora_devolucao").val();
    var DataIdade     = $("#data_idade")    .val();
    
    dataHoraRetirada = dataRetirada + " " + horaRetirada;
    dataHoraDevolucao = dataDevolucao + " " + horaDevolucao;
    diasAlugado = dataHoraDevolucao.substring(0, 2) - dataRetirada.substring(0, 2) + 1;
}
function SelecionaCarro() {
    event.preventDefault();
    FormCarro.addClass("invisivel");
    FormProtecao.removeClass("invisivel");

    idCarro = $(this).parent().find("p")[0].innerHTML; 
}

$(".btn-protecao").click(function (event) {
    event.preventDefault();
    var td = $(this).parent().parent();
    idProtecao = td.find("td")[0].innerHTML;
    FormProtecao.addClass("invisivel");
    if ($("#cliente-logado").text() != 0) {
        IdDoCliente = $("#cliente-logado").text()
        preencheConfirmacao( $("#cliente-logado").text() );
    } else {
        formLogin.removeClass("invisivel");
    }        
})

function retornaCarros() {
    $("#loading").toggle();
    var carros = $.get("http://localhost:50806/aluguel/BuscaCarros", function (carros) {        
        for (var i = 0; i < carros.length; i++) {
            MontaCarro(carros[i].Id, carros[i].Modelo, carros[i].Marca, carros[i].Preco, carros[i].Imagem);
            
        }
    })
    .always(function () { 
        $("#loading").toggle();
    })
    .fail(function () {
        $("#loading").toggle();
    });
}

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


window.onbeforeunload = confirmExit;
function confirmExit() {
    if (PerguntarSeQuerSair == true) {
        return "Deseja realmente sair desta página?"
    }else{return}
}
