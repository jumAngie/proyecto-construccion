function AbrirModalCrearUsuario() {
    $("#CrearUsuario").modal("show");
    Cargarddls();
}

function Cargarddls() {
    $.ajax({
        type: "GET",
        url: "/Usuario/CargarEmpleados",
        data: "{}",
        success: function (data) {
            var s = '<option value="" selected hidden >selecciona un Empleado</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].empl_Id + '" >' + data[i].empl_Nombre + '</option>';
            }
            $("#empl_Id").html(s);
        }
    });

    $.ajax({
        type: "GET",
        url: "/Usuario/CargarRoles",
        data: "{}",
        success: function (data) {
            var s = '<option value="" selected hidden >selecciona un Rol</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].role_Id + '" >' + data[i].role_Nombre + '</option>';
            }
            $("#role_Idu").html(s);
        }
    });
}
$("#CkAdmin").click(function () {
    if (document.getElementById("CkAdmin").checked) {
        $('#role_Idu').prop("disabled", true)
        $("#lb5").attr("hidden", "");
    }
    else {
        $('#role_Idu').prop("disabled", false);
        $("#lb5").removeAttr("hidden");
    }
});

function Limpiar() {
    $("#lb1").attr("hidden","");
    $("#lb2").attr("hidden","");
    $("#lb5").attr("hidden","");
    $("#lb4").attr("hidden","");
    $('#role_Idu').prop("disabled", false);
    $('#txtClaveCrear').val("");
    $('#txtUserCrear').val("");
    $('#CkAdmin').prop("disabled", false);
}

function Editar(e) {
    var user_Id = e;
    console.log(user_Id);
    $.ajax({
        type: "POST",
        url: "/Usuario/CargarDatosUsuarios",
        data: { user_Id: user_Id},
        success: function (data) {
            var empl_Id = data[0].empe_Id;
            var empl_Nombre = data[0].empl_Nombre;

            $.ajax({
                type: "GET",
                url: "/Usuario/CargarEmpleados",
                data: "{}",
                success: function (data) {
                    var s = '<option value="" selected hidden >selecciona un Empleado</option>';
                    for (var i = 0; i < data.length; i++) {
                        s += '<option value="' + data[i].empl_Id + '" >' + data[i].empl_Nombre + '</option>';
                    }
                    $("#ddlEmpleadosEditar").html(s);
                    $("#ddlEmpleadosEditar").append("<option value='" + empl_Id + "' hidden selected >" + empl_Nombre + "</option>");
                }
            });

            $.ajax({
                type: "GET",
                url: "/Usuario/CargarRoles",
                data: "{}",
                success: function (data) {
                    var s = '<option value="" selected hidden >selecciona un Rol</option>';
                    for (var i = 0; i < data.length; i++) {
                        s += '<option value="' + data[i].role_Id + '" >' + data[i].role_Nombre + '</option>';
                    }
                    $("#ddlRoles").html(s);
                    $("#ddlRoles").val(data[0].role_Id);
                }
            });

            if (data[0].user_EsAdmin == true) {
                $("#CkAdminEditar").prop("checked", true);
            }
            else {
                $("#CkAdminEditar").prop("checked", false);
            }

            $("#txtUserEditar").val(data[0].user_NombreUsuario);
            $("#txtIdUserEdit").val(data[0].user_Id);
            $("#EditarUsuario").modal("show");
        }
    });
}

$("#CkAdminEditar").click(function () {
    if (document.getElementById("CkAdminEditar").checked) {
        $('#ddlRoles').prop("disabled", true)
        $("#LB4").attr("hidden", "");
    }
    else {
        $('#ddlRoles').prop("disabled", false);
        $("#LB4").removeAttr("hidden");
    }
});


$("#ddlRoles").on("focus", function () {
    $("#CkAdminEditar").prop("disabled", true);
});


//$("#txtUserEditar").focusout(function () {
//    $.ajax({
//        type: "POST",
//        url: "/Usuario/ExisteUsuario",
//        data: { user_NombreUsuario: $("#txtUserEditar").val() },
//        success: function (data) {
//            if (data == 1) {
//                $("#btnEditarUser").prop("disabled", true);
//                mostrarErrorToast("Ya existe el username digitado");
//            } else {
//                ("#btnEditarUser").prop("disabled", false);
//            }
//        }
//    });
//});

function LimpiarEditar() {
    $("#LB1").attr("hidden", "");
    $("#LB2").attr("hidden", "");
    $("#LB3").attr("hidden", "");
    $("#LB4").attr("hidden", "");
    $('#ddlRoles').prop("disabled", false);
    $('#txtUserEditar').val("");
    $('#txtIdUserEdit').val("");
}

function Preliminar(e) {
    $("#txtUsuarioIdEliminar").val(e);
}

function EliminarUsuario() {
    $.ajax({
        type: "POST",
        url: "/Usuario/EliminarUsuario",
        data: { user_Id: $("#txtUsuarioIdEliminar").val()},
        success: function (data) {
            if (data == 1) {
                window.location.reload();
            } else {
                mostrarErrorToast("Error al eliminar el registro");
            }
        }
    });
}