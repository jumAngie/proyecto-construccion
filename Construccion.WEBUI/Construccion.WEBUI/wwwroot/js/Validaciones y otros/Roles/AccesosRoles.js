﻿function AbrirModalAccesos() {
    LimpiarAcceso();
    $("#ModalAcceso").modal("show");
    $.ajax({
        url: "/Roles/RolesPantalla",
        method: "POST",
        data: { role_Id: $("#txtIdRol").val() },
        success: function (data) {
            console.log(data);
            $.each(data.res, function (i, value) {
                if (value.pant_Id == 1) {
                    document.getElementById("1").setAttribute('checked', 'true');
                }
                if (value.pant_Id == 2) {
                    document.getElementById("2").setAttribute('checked', 'true');
                }
                if (value.pant_Id == 3) {
                    document.getElementById("3").setAttribute('checked', 'true');
                }
                if (value.pant_Id == 4) {
                    document.getElementById("4").setAttribute('checked', 'true');
                }
                if (value.pant_Id == 5) {
                    document.getElementById("5").setAttribute('checked', 'true');
                }
                if (value.pant_Id == 6) {
                    document.getElementById("6").setAttribute('checked', 'true');
                }
                if (value.pant_Id == 7) {
                    document.getElementById("7").setAttribute('checked', 'true');
                }
                if (value.pant_Id == 8) {
                    document.getElementById("8").setAttribute('checked', 'true');
                }
            });
        }
    });
}

$("#btnAplicar").click(function () {
    window.localtion.reload();
})

function CerrarModalAccesos() {
    $("#ModalAcceso").modal("hide");
}

function LimpiarAcceso() {
    const $miCheckbox = document.querySelector("#1");
    const $miCheckbox2 = document.querySelector("#2");
    const $miCheckbox3 = document.querySelector("#3");
    const $miCheckbox4 = document.querySelector("#4");
    const $miCheckbox5 = document.querySelector("#5");
    const $miCheckbox6 = document.querySelector("#6");
    const $miCheckbox7 = document.querySelector("#7");
    const $miCheckbox8 = document.querySelector("#8");
    $miCheckbox.checked = false;
    $miCheckbox2.checked = false;
    $miCheckbox3.checked = false;
    $miCheckbox4.checked = false;
    $miCheckbox5.checked = false;
    $miCheckbox6.checked = false;
    $miCheckbox7.checked = false;
    $miCheckbox8.checked = false;
}

