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
}