function ValidaCamposDatas() {
    if (validaData($("#data_retirada" )) &
        validaData($("#data_devolucao")) &
        validaHora($("#hora_retirada" )) &
        validaHora($("#hora_devolucao")) &
        validaIdad($("#data_idade"    )) ) {
        return true;
    } else {
        return false;
    }
}


function validaData(CampoData) {
    var patternData = /^[0-9]{2}\/[0-9]{2}\/[0-9]{4}$/;
    if (!patternData.test(CampoData.val())) {
        CampoData.addClass("campoInvalido")
        return false;
    }
    CampoData.removeClass("campoInvalido")
    return true
}

function validaHora(CampoHora) {
    var patternData = /^[0-9]{2}\:[0-9]{2}$/;
    if (!patternData.test(CampoHora.val())) {
        CampoHora.addClass("campoInvalido")
        return false;
    }
    CampoHora.removeClass("campoInvalido")
    return true
}

function validaIdad(CampoIdade) {
    var patternData = /^[2-9]{1}[0-9]{1}$/;
    if (!patternData.test(CampoIdade.val())) {
        CampoIdade.addClass("campoInvalido")
        return false;
    }
    CampoIdade.removeClass("campoInvalido")
    return true
}

//Masks