function ShowModal(cate_Id) {
    $('#ModalElim').modal('show');
    $("#botonEliminar").click(function () {
        var id = cate_Id;
        $.ajax({
            url: "/Categorias/Eliminar",
            type: "POST",
            data: { id: id },
            success: function () {
                window.location.href = "/Categorias/Listado";
            },
            error: function () {
                alert("Error al eliminar el registro.");
            }
        });
    });
};

function AbrirEliminar() {
    $("#ModalElim").modal('show');
}

function CerrarEliminar() {
    $("#ModalElim").modal('hide');
}