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
    var PId = $("<p>").addClass("ul-carro").addClass("invisivel").attr("id", "modelo-car").text(id);
    //cria p modelo
    var PModelo = $("<p>").addClass("ul-carro").attr("id", "modelo-car").text("Modelo: " + modelo);
    //cria p marca
    var PMarca = $("<p>").addClass("ul-carro").attr("id", "marca-car").text("Marca: " + marca);
    //cria p preço
    var PPreco = $("<p>").addClass("ul-carro").attr("id", "preco-car").text("Preço por X dias: " + preco + ",00R$");
    //Coloca p na div principal
    DCarroPrincipal.append(PId).append(PModelo).append(PMarca).append(PPreco);
    //cria botão
    var botao = $("<button>").addClass("CarroSelecionado").attr("id", "btnSlcCarro").text("Selecionar").addClass("btn btn-success")
    //Insere evento click no botao
    botao.click(SelecionaCarro)
    //Inasere botão na div principal
    DCarroPrincipal.append(botao);
    //insere div principal no formulario
    var carros = $("#lista-carro");
    carros.append(DCarroPrincipal);
}

function MontaProtecao(id, nome, descricao, preco) {
    var linha = $("<tr>");

    var id = $("<td>").addClass("invisivel").text(id);
    var nome = $("<td>").text(nome);
    var desc = $("<td>").text(descricao);
    var preco = $("<td>").text(preco+"R$");
    
    var btn = $("<td>");
    var link = $("<a>").addClass("btn-protecao").attr("href", "#").text("Selecionar");

    btn.append(link)

    linha.append(id).append(nome).append(desc).append(preco).append(btn);

    $("#tbl-protecao").append(linha);
}