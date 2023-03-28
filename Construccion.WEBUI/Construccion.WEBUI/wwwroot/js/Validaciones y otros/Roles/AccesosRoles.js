function AbrirModalAccesos() {
    $("#ModalAcceso").modal("show");
    $.ajax({
        url: "/Roles/RolesPantalla",
        method: "POST",
        data: { role_Id: $("#txtIdRol").val() },
        success: function (data) {
            if (data.success) {
                var html = '';
                $.each(data.res, function (index, item) {
                    html += '<div>';
                    html += '<input type="checkbox" id="pantalla_' + item.pant_Id + '" name="pantallas" value="' + item.pant_Id + '"';
                    if (item.Activo) {
                        html += ' checked';
                    }
                    html += '>';
                    html += '<label for="pantalla_' + item.pant_Id + '">' + item.pant_Nombre + '</label>';
                    html += '</div>';
                })
                $('#contenedor-pantallas').html(html);
            } 
        }
    });
}



$(function () {
    var idRol = 1; // El ID del rol que quieres cargar los checkboxes

    $.getJSON("/MiControlador/ObtenerPantallas", { idRol: idRol }, function (data) {
        var html = '';

        $.each(data, function (i, pantalla) {
            html += '<div>';
            html += '<input type="checkbox" id="pantalla_' + pantalla.Id + '" name="pantallas" value="' + pantalla.Id + '"';
            if (pantalla.Activo) {
                html += ' checked';
            }
            html += '>';
            html += '<label for="pantalla_' + pantalla.Id + '">' + pantalla.Nombre + '</label>';
            html += '</div>';
        });

        $('#contenedor-pantallas').html(html);
    });
});

function CerrarModalAccesos() {
    $("#ModalAcceso").modal("hide");
}

