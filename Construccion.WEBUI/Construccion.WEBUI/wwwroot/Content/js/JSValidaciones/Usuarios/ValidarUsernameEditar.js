$("#txtUserEditar").focusout(function () {
    var NombreUsuario = $("#txtUserEditar").val();
    var Usuario = $("#usua_Id").val();
    $.ajax({
        url: "/Usuarios/ValidarUserNameExisteEditar",
        type: 'POST',
        data: { usua_Nombre: NombreUsuario, usua_Id: Usuario },
        success: function (result) {
            if (result == 1) {
                $("#LB2").removeAttr("hidden");
                $("#LBUserGen").removeAttr("hidden");
                $("#btnEditar").attr("disabled", "");
            }
            else {
                $("#btnEditar").removeAttr("disabled");
                $("#LB2").attr("hidden", "");
                $("#LBUserGen").attr("hidden", "");
            }
        }
    });

});
