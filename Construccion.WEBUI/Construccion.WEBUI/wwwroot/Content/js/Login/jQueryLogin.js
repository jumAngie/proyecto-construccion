
function Restablecer1() {
    $("#txtUser").val("");
    $("#txtpassword").val("");
    $("#txtpasswordconfirm").val("");
};

function Inicio() {
    $("#txtUserSesion").val("");
    $("#txtPasswordSesion").val("");
};


//VALIDACIONES PARA MODAL DE CAMBIAR CONTRASEÑA
function CambiarPassword() {
    InputUser = $("#txtUsuarioModal").val();
    InputPassword = $("#txtpasswordModal").val();
    if (InputUser == "" && InputPassword == "") {
        $("#LbGeneral").text("Los campos son requeridos");
        $("#Lb1").removeAttr("hidden");
        $("#Lb2").removeAttr("hidden");
    }
    if (InputUser != "" && InputPassword == "") {
        $("#LbGeneral").text("Campo Password requerido");
        $("#Lb2").removeAttr("hidden");
        $("#Lb1").attr("hidden", "");
    }
    if (InputUser == "" && InputPassword != "") {
        $("#LbGeneral").text("Campos Usuario requerido");
        $("#Lb1").removeAttr("hidden");
        $("#Lb2").attr("hidden", "");
    }
    if (InputUser != "" && InputPassword != "") {
        $("#LbGeneral").text("");
        $("#Lb1").attr("hidden", "");
        $("#Lb2").attr("hidden", "");

        $.ajax({
            url: '/Login/Cambiar',
            type: 'POST',
            data: { usua_Nombre: InputUser, usua_Clave: InputPassword },
            success: function (data) {
                if (data.data == 0) {
                    MostrarMensajeWarning("El Usuario no existe");
                }
                else {
                    MostrarMensajeSuccess("Contraseña actualizada con exito");
                    setTimeout(function () {
                        window.location.reload();
                    }, 5000);
                }
            }
        });
    }
}

//Funciones para valores de restablcer contraseña
function Restablecer() {
    InputUser = $("#txtUser").val();
    InputPassword = $("#txtpasswordAnterior").val();
    $.ajax({
        url: '/Login/Restablecer',
        type: 'POST',
        data: { usua_Nombre: InputUser, usua_Clave: InputPassword },
        success: function (data) {
            if (data.Error == 0) {
                MostrarMensajeWarning("El Usuario o contraseña incorrectas");
            }
        }
    });
}



// FUNCION PARA BOTON DE CERRRA MODAL
function Cerrar() {
    $("#LbGeneral").text("");
    $("#Lb1").attr("hidden", "");
    $("#Lb2").attr("hidden", "");
    $("#txtUsuarioModal").val("");
    $("#txtpasswordModal").val("");
}

