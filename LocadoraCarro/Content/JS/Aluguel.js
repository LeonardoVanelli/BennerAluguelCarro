var FormCarro = $(".carro");
var FormProtecao = $(".protecao");
var FormCliente = $(".cliente");
var FormUsuario = $(".escolhaCliente");

var dataHoraRetirada;
var dataHoraDevolucao;
var diasAlugado = 0;
var idCarro;
var idProtecao;
var idCliente;
var PerguntarSeQuerSair = true;

$("#btn-proximo").click(function () {
    event.preventDefault();    
    RetiraValorDataHora();
    if (ValidaCamposDatas()) {        
        retornaCarros()            
    }
})

function RetiraValorDataHora() {

    var dataRetirada = $("#data_retirada").val();
    
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
    $.ajax({
        dataType: "json",
        type: "POST",
        url: "/Aluguel/BuscaCarros",
        data: {
            dataRetirada: dataHoraRetirada,
            dataDevolucao: dataHoraDevolucao
        },
        success: function (carros) {                       
            $("#loading").toggle();
            var FormData = $(".data-hora");
            if (diasAlugado <= 30) {
                if (carros.length > 0) {
                    for (var i = 0; i < carros.length; i++) {
                        MontaCarro(carros[i].Id, carros[i].Modelo, carros[i].Marca, carros[i].Classe, carros[i].Preco, carros[i].Imagem);
                    }
                    diasAlugado = carros[0].DiasTotal;
                    FormData.addClass("invisivel");
                    FormCarro.removeClass("invisivel");
                } else {
                    console.log("Não tem carros para essa data");
                }
            } else {
                alert("Não pode ser alugado por mais de 30 dias");      
            }
        }
    })
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
    if ($("#data_retirada").val() == "") {
        if (PerguntarSeQuerSair == true) {
            return "Deseja realmente sair desta página?"
        }
    }
    else{return}
}
