function Abrir() {
    $("#agregarModal").modal('show');
}

function Cerrar() {
    $("#agregarModal").modal('hide');
}

function AgregarRegistro() {
    var Input_Categoria = $('#txtcategoria').val();
    if (Input_Categoria == "") {
        $("#LbGeneral2").text("El campo es requerido");
    }
    if (Input_Categoria != "") {
        $("#LbGenera2").text("");
        $.ajax({
            url: '/Categorias/Create',
            type: 'POST',
            data: { cate_categoria: Input_Categoria },
            success: function (data) {
                if (data.nombre == 0) {
                    MostrarMensajeWarning("La Descripcion del Registro ya Existe");
                }
                if (data.nombre == 1) {
                    MostrarMensajeSuccess("El registro ingresado con exito");
                    setTimeout(function () {
                        window.location.reload();
                    }, 5000);
                }
            }
        });
    }
}