function AbrirModalAccesos() {
    $("#ModalAcceso").modal("show");
    $.ajax({
        url: "/Roles/RolesPantalla",
        method: "POST",
        data: { role_Id: $("#txtIdRol").val() },
        success: function (data) {
            console.log(data);
            $.each(data.res, function (i, value) {
                alert("hola");
                if (value.pant_Id == 1) {
                    console.log("activa1");
                    document.getElementById("1").setAttribute('checked', 'true');
                }
                if (value.pant_Id == 2) {
                    console.log("activa2");
                    document.getElementById("2").setAttribute('checked', 'true');
                }
                if (value.pant_Id == 3) {
                    console.log("activa3");
                    document.getElementById("3").setAttribute('checked', 'true');
                }
                if (value.pant_Id == 4) {
                    console.log("activa4");
                    document.getElementById("4").setAttribute('checked', 'true');
                }
                if (value.pant_Id == 5) {
                    console.log("activa5");
                    document.getElementById("5").setAttribute('checked', 'true');
                }
                if (value.pant_Id == 6) {
                    console.log("activa6");
                    document.getElementById("6").setAttribute('checked', 'true');
                }
                if (value.pant_Id == 7) {
                    console.log("activa7");
                    document.getElementById("7").setAttribute('checked', 'true');
                }
                if (value.pant_Id == 8) {
                    console.log("activa8");
                    document.getElementById("8").setAttribute('checked', 'true');
                }
            });
        }
    });
}

$("#1").click(function () {
    if (document.getElementById("1").checked) {
        alert("activado");
        alert($("#txtIdRol").val());
    }
    else {
        alert("desactivado");
        alert($("#txtIdRol").val());
    }
});


$("#btnAplicar").click(function () {
    window.localtion.reload();
})

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
    alert("Limpia");
}
