function AgregarRegisro() {
    $("#btnGuardar").removeAttr("disabled");
    apagarlb();
    var EmpleadoId = $("#empl_Id").val();
    var NombreUsuario = $("#txtUserCrear").val();
    var Clave = $("#txtClaveCrear").val();
    var Usua_EsAdmin;
    if ($('#CkAdmin').prop('checked')) {
        Usua_EsAdmin = true;
    }
    else {
        Usua_EsAdmin = false;
    }
    $.ajax({
        url: "/Usuarios/InsertarUsuario",
        type: 'POST',
        data: { empl_Id: EmpleadoId, usua_Nombre: NombreUsuario, usua_Clave: Clave, usua_EsAdmin: Usua_EsAdmin },
        success: function (result) {
            if (result.success && result.correcto) {
                MostrarMensajeSuccess("El registro ingresado con exito");
                setTimeout(function () {
                    window.location.reload();
                }, 5000);
            } if (result == 1) {
                $('#lb1').removeAttr("hidden");
                $('#lb2').removeAttr("hidden");
                $('#lb4').removeAttr("hidden");
                $('#lb5').removeAttr("hidden");
            } if (result == 2) {
                $('#lb4').removeAttr("hidden");
                $('#lb1').removeAttr("hidden");
                $('#lb6').removeAttr("hidden");
            } if (result == 3) {
                $('#lb1').removeAttr("hidden");
                $('#lb7').removeAttr("hidden");
            } if (result == 4) {
                $('#lb4').removeAttr("hidden");
                $('#lb8').removeAttr("hidden");
            } if (result == 5) {
                $('#lb1').removeAttr("hidden");
                $('#lb2').removeAttr("hidden");
                $('#lb9').removeAttr("hidden");
            } if (result == 6) {
                $('#lb1').removeAttr("hidden");
                $('#lb7').removeAttr("hidden");
            } if (result == 7) {
                $('#lb2').removeAttr("hidden");
                $('#lb10').removeAttr("hidden");
            } if (result == 8) {
                $('#lb2').removeAttr("hidden");
                $('#lb4').removeAttr("hidden");
                $('#lb11').removeAttr("hidden");
            } if (result == 9) {
                $('#lb2').removeAttr("hidden");
                $('#lb10').removeAttr("hidden");
            } if (result == 10) {
                $('#lb4').removeAttr("hidden");
                $('#lb8').removeAttr("hidden");
            }
        }
    });
}


function apagarlb() {
    $('#lb1').attr("hidden", "");
    $('#lb2').attr("hidden", "");
    $('#lb3').attr("hidden", "");
    $('#lb4').attr("hidden", "");
    $('#lb5').attr("hidden", "");
    $('#lb6').attr("hidden", "");
    $('#lb7').attr("hidden", "");
    $('#lb8').attr("hidden", "");
    $('#lb9').attr("hidden", "");
    $('#lb10').attr("hidden", "");
    $('#lb11').attr("hidden", "");
    $('#lb13').attr("hidden", "");
    $('#lb14').attr("hidden", "");
    $("#lbUserGen").attr("hidden", "");
    $("#btnGuardar").removeAttr("disabled");
}


function Limpiar() {
    $("#txtUserCrear").val("");
    $("#txtClaveCrear").val("");
    $("#CkAdmin").prop('checked', false);
    $("#txtUsuario").val("");
    $("#ckAdministrador").prop('checked', false);
    apagarlb();
    $("#lblErrorIdEmp").attr("hidden", "");
    $("#BtnEditar").attr("disabled", false);
    $("#lblErrorIdEmp").attr("hidden", "");
    $("#BtnGuardar").attr("disabled", false);
}