function EliminarSucursal(sucu_Id) {
    $('#ModalEliminarSucursal').modal('show');
    $("#botonEliminar").click(function () {        
        var Algo = sucu_Id;
        $.ajax({
            url: "/Sucursales/Delete",
            type: "POST",
            data: { sucu_Id: Algo },
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

function AbrirModalEliminarSucursal() {
    $("#ModalEliminarSucursal").modal('show');
}

function CerrarModalEliminarSucursal() {
    $("#ModalEliminarSucursal").modal('hide');
}