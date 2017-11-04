var FormCarro = $(".carro");
var FormProtecao = $(".protecao");
var FormCliente = $(".cliente");

$("#btn-proximo").click(function () {
    event.preventDefault();    
    var FormData = $(".data-hora");
    RetiraValorDataHora();

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
    
    return data = [{
        DataRetirada: dataRetirada,
        HoraRetirada: horaRetirada,
        DataDevolucao: dataDevolucao,
        horaDevolucao: horaDevolucao
    }]
}

$(".CarroSelecionado").click(function () {
    event.preventDefault();
    FormCarro.addClass("invisivel");
    FormProtecao.removeClass("invisivel");

    var btn = $(this).parent().find("p")[0].innerHTML;
    console.log(btn);
})

$(".btn-protecao").click(function (event) {
    event.preventDefault();
    FormProtecao.addClass("invisivel");
    FormCliente.removeClass("invisivel");
    var td = $(this).parent().parent();
    
    console.log(td.find("td")[0].innerHTML);
})

function MontaCarro(id, modelo, marca, preco) {
    //Cria Div principal
    var DCarroPrincipal = $("<div>").addClass("lbl-carros");
    //cria div imagem e adiciona img
    var DCarroImagem = $("<div>").addClass("Img_car1");
    var IImgCarro = $("<img>").attr("src", "/Content/CarrosImg/FordFocus.jpg").addClass("img-carro");
    //Junta img com div imagem
    DCarroImagem.append(IImgCarro);
    //junta div principal com div img
    DCarroPrincipal.append(DCarroImagem);
    //cria p Id invisivel
    var PId     = $("<p>").addClass("ul-carro").addClass("invisivel").attr("id", "modelo-car").text(id);
    //cria p modelo
    var PModelo = $("<p>").addClass("ul-carro").attr("id", "modelo-car").text("Modelo: "+modelo);
    //cria p marca
    var PMarca  = $("<p>").addClass("ul-carro").attr("id", "marca-car") .text("Marca: "+marca);
    //cria p preço
    var PPreco  = $("<p>").addClass("ul-carro").attr("id", "preco-car") .text("Preço por X dias: " + preco + ",00R$");
    //Coloca p na div principal
    DCarroPrincipal.append(PId).append(PModelo).append(PMarca).append(PPreco);
    //cria botão
    var botao = $("<button>").addClass("CarroSelecionado").attr("id", "btnSlcCarro").text("Selecionar")
    DCarroPrincipal.append(botao);
    //insere no formulario
    var carros = $("#lista-carro");
    carros.append(DCarroPrincipal);
}

function retornaCarros() {
    var carros = $.get("http://localhost:50806/aluguel/BuscaCarros", function (carros) {
 
        for (var i = 0; i < carros.length; i++) {
            MontaCarro(carros[i].Id, carros[i].Modelo, carros[i].Marca, carros[i].Preco);
        }
    })
    
}