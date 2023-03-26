$("#txtUserCrear").focusout(function () {
    var NombreUsuario = $("#txtUserCrear").val();
    $.ajax({
        url: "/Usuarios/ValidarUserNameExiste",
        type: 'POST',
        data: { usua_Nombre: NombreUsuario },
        success: function (result) {
            if (result == 1) {
                $("#lb2").removeAttr("hidden");
                $("#lbUserGen").removeAttr("hidden");
                $("#btnGuardar").attr("disabled", "");
            }
            else {
                $("#btnGuardar").removeAttr("disabled");
                $("#lb2").attr("hidden","");
                $("#lbUserGen").attr("hidden","");
            }
        }
    });

});
