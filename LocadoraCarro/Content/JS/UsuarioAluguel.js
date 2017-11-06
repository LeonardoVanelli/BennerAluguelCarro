var FormCadastro = $(".cliente");
var formLogin = $(".clienteLogar");
var formConfirmacao = $("#confirmacao");

$("#btn-cadastro").click(function () {
    event.preventDefault();


})

$("#btn-login").click(function () {
    event.preventDefault();

    FormUsuario.addClass("invisivel");
    formLogin.removeClass("invisivel");
})

$("#btn-logar").click(function () {
    event.preventDefault();

    $.ajax({
        dataType: "json",
        type: "POST",
        url: "/Login/autenticaAluguel",
        data: {
            Login: $("#login_autentica").val(),
            Senha: $("#senha_autentica").val()
        },
        success: function (result) {
            if (result.id != 0)
                AdicionaAluguel(result.id);
            else
                console.log("Cliete errrrro");
        }
    })
})

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
            AdicionaAluguel(result.id);
        }
    })
})

function AdicionaAluguel(idCliente) {
    $.ajax({
        dataType: "json",
        type: "POST",
        url: "/Aluguel/Adiciona",
        data: {
            dTRetirada: dataHoraRetirada,
            dTDevolucao: dataHoraDevolucao,
            IdCliente: idCliente,
            IdCarro: idCarro,
            IdProtecao: idProtecao
        },     
        success: function (result) {
            preencheConfirmacao(result);
            formLogin.addClass("invisivel");
            formConfirmacao.removeClass("invisivel");

            console.log("entrei");
        },
        error: function (result) {
            $('#cadastro-sucesso').modal({
                escapeClose: false,
                clickClose: false,
                showClose: false
            })
        }
    })
}

function preencheConfirmacao(aluguel) {
    $("#cModelo-car").text("Modelo: "+aluguel.Modelo);
    $("#cMarca-car").text("Marca "+aluguel.Marca);
    $("#cPreco-car").text(aluguel.PrecoCar + ",00R$");

    $("#cRetirada").text(aluguel.Retirada);
    $("#cDevolucao").text(aluguel.Devolucao);
    $("#cProtecao").text(aluguel.Protecao);
    $("#cPreco-protecao").text(aluguel.PrecoProtecao + ",00R$");
    $("#cTotal").text(aluguel.PrecoProtecao + aluguel.PrecoCar + ",00R$");
}

$("#btnConfirmar").click(function(){
    $('#cadastro-sucesso').modal({
        escapeClose: false,
        clickClose: false,
        showClose: false
    })
})

$("#VoltaHome").click(function () {
    window.location.replace("/home");
})