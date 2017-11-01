var FormCarro = $(".carro");
var FormProtecao = $(".protecao");
var FormCliente = $(".cliente");

$("#btn-proximo").click(function () {
    event.preventDefault();    
    var FormData = $(".data-hora");

FormData.addClass("invisivel");
FormCarro.removeClass("invisivel");

})

$("#btnSlcCarro").click(function () {
    event.preventDefault();
    FormCarro.addClass("invisivel");
    FormProtecao.removeClass("invisivel");
})

$("#btnSlcProtecao").click(function () {
    event.preventDefault();
    FormProtecao.addClass("invisivel");
    FormCliente.removeClass("invisivel");
})