function AbrirModalAccesos() {
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
                if (value.pant_Id == 9) {
                    document.getElementById("9").setAttribute('checked', 'true');
                }
                if (value.pant_Id == 10) {
                    document.getElementById("10").setAttribute('checked', 'true');
                }
                if (value.pant_Id == 11) {
                    document.getElementById("11").setAttribute('checked', 'true');
                }
                if (value.pant_Id == 12) {
                    document.getElementById("12").setAttribute('checked', 'true');
                }
            });
        }
    });
}



//$(function () {
//    var idRol = 1; // El ID del rol que quieres cargar los checkboxes

//    $.getJSON("/MiControlador/ObtenerPantallas", { idRol: idRol }, function (data) {
//        var html = '';

//        $.each(data, function (i, pantalla) {
//            html += '<div>';
//            html += '<input type="checkbox" id="pantalla_' + pantalla.Id + '" name="pantallas" value="' + pantalla.Id + '"';
//            if (pantalla.Activo) {
//                html += ' checked';
//            }
//            html += '>';
//            html += '<label for="pantalla_' + pantalla.Id + '">' + pantalla.Nombre + '</label>';
//            html += '</div>';
//        });

//        $('#contenedor-pantallas').html(html);
//    });
//});

function CerrarModalAccesos() {
    $("#ModalAcceso").modal("hide");
}

