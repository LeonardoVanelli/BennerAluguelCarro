
var imagem;

function getBase64(file) {
    var reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = function () {
        imagem = reader.result;
    };
    reader.onerror = function (error) {
        console.log('Error: ', error);
    }; 
}

$('input[type=file]').on("change", function () {
    var files = document.getElementById('imagem').files;
    if (files.length > 0) {
        getBase64(files[0]);
    }
    $("#imagem-string").val(imagem);
});

$("#btn-selecionar-carro").click(function () {
    var files = document.getElementById('imagem').files;
    if (files.length > 0) {
        getBase64(files[0]);
    }
    $("#imagem-string").val(imagem);
})