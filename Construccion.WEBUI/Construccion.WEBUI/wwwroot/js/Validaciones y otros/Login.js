function AbrirModal() {
    $("#ModalCambiarContra").modal("show");
}


function CambiarPassword() {
    var contra = $("#txtpasswordModal").val();
    var user = $("#txtUsuarioModal").val();
    var res = true;

    if (contra == "" && user == "") {
        $("#Lb1").removeAttr("hidden");
        $("#Lb2").removeAttr("hidden");
        $("#LbGeneral").text("Los campos son requeridos");
        res = false;
    }
    else {
        
        if (contra == "") {
            $("#Lb2").removeAttr("hidden");
            $("#LbGeneral").text("Contraseña requerida");
            $("#Lb1").attr("hidden", "");
            res = false;
        }
        else {
            
            if (user == "") {
                $("#Lb1").removeAttr("hidden");
                $("#LbGeneral").text("Usuario requerido");
                $("#Lb2").attr("hidden", "");
                res = false;
            }
            else {
                $("#Lb2").attr("hidden", "");
                $("#Lb1").attr("hidden", "");
                $("#LbGeneral").text("");
                if (res) {
                    $.ajax({
                        url: '/Login/Cambiar',
                        type: 'POST',
                        data: { user_NombreUsuario: user, user_Contrasena: contra },
                        success: function (data) {
                            if (data == 1) {
                                window.location.reload();
                            }
                            if (data == 2) {
                                MostrarMensajeDanger("Error al realizar la operación");
                            }
                            if (data == 3) {
                                MostrarMensajeWarning("Usuario incorrecto");
                                $("#Lb1").removeAttr("hidden");
                                $("#LbGeneral").text("Usuario incorrecto");
                            }
                            if (data == 4) {
                                MostrarMensajeDanger("Error al realizar la operación");
                            }
                        }
                    });
                }
            }
        }
    }
   
}


function CerrarModal() {
    $("#Lb2").attr("hidden", "");
    $("#Lb1").attr("hidden", "");
    $("#LbGeneral").text("");
}
