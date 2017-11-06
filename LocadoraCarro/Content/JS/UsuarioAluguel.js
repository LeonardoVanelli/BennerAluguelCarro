var FormCadastro = $(".cliente");
var formLogin = $(".clienteLogar");

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
            $('#cadastro-sucesso').modal({
                escapeClose: false,
                clickClose: false,
                showClose: false
            });

            console.log("entrei");
        },
        error: function (result) {
            // Como requisitar $resposta e mostrar ela aqui
        }
        })
}
