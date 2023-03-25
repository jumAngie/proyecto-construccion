$("#btnSave").click(function () {
    $.ajax({
        url: 'Roles/Create',
        type: 'POST',
        data: { rol: $("#txtRol").val() },
        success: function (data) {
            if (data.mensaje != "") {
                MostrarMensajeSuccess("Registro ingresado con exito");
                setTimeout(function () {
                    window.location.reload();
                }, 5000);
            }
        }
    });

});

function CargarDatos(e) {

}