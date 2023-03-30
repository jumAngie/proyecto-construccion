function AbrirModalAccesos() {
    $("#ModalAcceso").modal("show");
    $.ajax({
        url: "/Roles/RolesPantalla",
        method: "POST",
        data: { role_Id: $("#txtIdRol").val() },
        success: function (data) {
            $.each(data.res, function (i, value) {
                if (value.pant_Id == 1) {
                    $("#1").prop("checked", true);
                }
                if (value.pant_Id == 2) {
                    $("#2").prop("checked", true);
                }
                if (value.pant_Id == 3) {
                    $("#3").prop("checked", true);
                }
                if (value.pant_Id == 4) {
                    $("#4").prop("checked", true);
                }
                if (value.pant_Id == 5) {
                    $("#5").prop("checked", true);
                }
                if (value.pant_Id == 6) {
                    $("#6").prop("checked", true);
                }
                if (value.pant_Id == 7) {
                    $("#7").prop("checked", true);
                }
                if (value.pant_Id == 8) {
                    $("#8").prop("checked", true);
                }
            });
        }
    });
}


function recargar(){
    window.location.reload();
}
function CerrarModalAccesos() {
    $("#ModalAcceso").modal("hide");
}

function LimpiarAcceso() {
    $("#1").prop("checked", false);
    $("#2").prop("checked", false);
    $("#3").prop("checked", false);
    $("#4").prop("checked", false);
    $("#5").prop("checked", false);
    $("#6").prop("checked", false);
    $("#7").prop("checked", false);
    $("#8").prop("checked", false);
}
