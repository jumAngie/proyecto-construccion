function EliminarUsuario(usua_Id) {
    $('#ModalEliminarUsuario').modal('show');
    $("#botonEliminar").click(function () {
        var Algo = usua_Id;
        $.ajax({
            url: "/Usuarios/Delete",
            type: "POST",
            data: { usua_Id: Algo },
            success: function (data) {
                if (data == 1) {
                    MostrarMensajeSuccess("Registro eliminado con exito");
                    setTimeout(function () {
                        window.location.reload();
                    }, 5000);
                }
            },
        });
    });
};

function AbrirModalEliminarUsuario() {
    $("#ModalEliminarUsuario").modal('show');
}

function CerrarModalEliminarUsuario() {
    $("#ModalEliminarUsuario").modal('hide');
}