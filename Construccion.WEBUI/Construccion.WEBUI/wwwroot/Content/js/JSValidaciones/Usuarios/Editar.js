function CargarDatos(usua_Id) {
    var UsuarioId = usua_Id
    $("#usua_Id").val(UsuarioId);
    $.ajax({
        url: "/Usuarios/CargarDatosUsuario",
        type: 'POST',
        data: { usua_Id: UsuarioId },
        success: function (result) {
            var empleado = result[0].empl_Id;
            var NombreEmpleado = result[0].empl_Nombre;
            var Username = result[0].usua_Nombre;
            var Admin = result[0].usua_EsAdmin;
            console.log(Admin);
            $("#txtUserEditar").val(Username);
            $("#ddlEmpleadosEditar").append("<option value='" + empleado + "' hidden selected >" + NombreEmpleado + "</option>");

            if (Admin == true)
                $('#CkAdminEditar').prop('checked', true);
            else
                $('#CkAdminEditar').prop('checked', false);
        }
    });
    $("#ModalEditarUsuario").modal("show");
}


function EditarUsuario() {
    var Empleado = $("#ddlEmpleadosEditar").val();
    var UsuarioNombre = $("#txtUserEditar").val();
    var usua_Id = $("#usua_Id").val();
    var admin;
    if ($("#CkAdminEditar").prop("checked") == true) {
        admin = "true";
    } else {
        admin = "false";
    }
    if (UsuarioNombre == "") {
        $("#LB2").removeAttr("hidden");
        $("#LB10").removeAttr("hidden");
    }
    else {
        $("#LB2").attr("hidden","");
        $("#LB10").attr("hidden","");
        $.ajax({
            url: "/Usuarios/Edit",
            type: 'POST',
            data: { usua_Id: usua_Id, usua_Nombre: UsuarioNombre, usua_Admin: admin, empl_Id: Empleado},
            success: function (result) {
                if (result == 1) {
                    MostrarMensajeSuccess("Registro actualizado con exito");
                    setTimeout(function () {
                        window.location.reload();
                    }, 5000);
                } else {

                }
            }
        });
    }
}

function CerrarEditar() {
        $('#LB1').attr("hidden", "");
        $('#LB2').attr("hidden", "");
        $('#LB3').attr("hidden", "");
        $('#LB4').attr("hidden", "");
        $('#LB5').attr("hidden", "");
        $('#LB6').attr("hidden", "");
        $('#LB7').attr("hidden", "");
        $('#LB8').attr("hidden", "");
        $('#LB9').attr("hidden", "");
        $('#LB10').attr("hidden", "");
        $('#LB11').attr("hidden", "");
        $('#LB13').attr("hidden", "");
        $('#LB14').attr("hidden", "");
        $("#LBUserGen").attr("hidden", "");
        $("#btnEditar").removeAttr("disabled"); 
};
