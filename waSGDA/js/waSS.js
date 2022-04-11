// SCALDERON

function notiSOL() {    
    var pImg = document.getElementById("hfLogoMsj");
    var pMsj = document.getElementById("hfMensaje");
    var pTipo = document.getElementById("hfTipoMsj");
    
    if (pImg.value != "" && pMsj.value != "" && pTipo.value != "") {
        $.notify({
            icon: "../img/icon/" + pImg.value,
            title: "<strong>Mensaje:</strong> ",
            message: pMsj.value
        }, {
                type: pTipo.value,
            icon_type: 'img'
        });
    }   
}