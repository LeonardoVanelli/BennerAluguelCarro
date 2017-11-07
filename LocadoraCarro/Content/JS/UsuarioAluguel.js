var FormCadastro = $(".cliente");
var formLogin = $(".clienteLogar");
var formConfirmacao = $("#confirmacao");

var IdDoCliente;

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
            if (result.id != 0){
                IdDoCliente = result.id
                preencheConfirmacao(result.id);
            }else
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
            IdDoCliente = result.id
            preencheConfirmacao(result.id);
        }
    })
})

function AdicionaAluguel() {
    $.ajax({
        dataType: "json",
        type: "POST",
        url: "/Aluguel/Adiciona",
        data: {
            dTRetirada: dataHoraRetirada,
            dTDevolucao: dataHoraDevolucao,
            IdCliente: IdDoCliente,
            IdCarro: idCarro,
            IdProtecao: idProtecao
        },     
        success: function (result) {
            $('#cadastro-sucesso').modal({
                escapeClose: false,
                clickClose: false,
                showClose: false
            })
            console.log("Aluguel adicionado com sucesso");
        },
        error: function (result) {
            console.log("Falha ao cadastrar aluguel");
        }
    })
}

function preencheConfirmacao(idCliente) {
    console.log(idCliente);
    $.ajax({
        dataType: "json",
        type: "POST",
        url: "/Aluguel/RetornaConfirmacao",
        data: {
            IdCliente: idCliente,
            IdCarro: idCarro,
            IdProtecao: idProtecao
        },
        always(){
            $("#loading").toggle();
        },
        success: function (aluguel) {
            $("#cModelo-car").text("Modelo: " + aluguel.Modelo);
            $("#cMarca-car").text("Marca " + aluguel.Marca);
            $("#cPreco-car").text(aluguel.PrecoCar + ",00R$");

            $("#cRetirada").text(dataHoraRetirada);
            $("#cDevolucao").text(dataHoraDevolucao);
            $("#cProtecao").text(aluguel.Protecao);
            $("#cPreco-protecao").text(aluguel.PrecoProtecao + ",00R$");
            $("#cTotal").text(aluguel.PrecoProtecao + aluguel.PrecoCar + ",00R$");

            formLogin.addClass("invisivel");
            formConfirmacao.removeClass("invisivel");
        },
        erro: function () {
            console.log("erro")
        }
    })
}

$("#btnConfirmar").click(function () {
    console.log("Id  do cliente: " + IdDoCliente);
    AdicionaAluguel()
})

$("#VoltaHome").click(function () {
    window.location.replace("/home");
})