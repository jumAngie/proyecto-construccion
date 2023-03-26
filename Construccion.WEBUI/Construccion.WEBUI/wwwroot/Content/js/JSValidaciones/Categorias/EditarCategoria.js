

function AbrirEditar() {
    $("#edit-modal").modal('show');
}
function CerrarEditar() {
    $("#edit-modal").modal('hide');
}

function Chargedate(cate_Id) {
    var id = cate_Id;
    console.log(id);

    $.ajax({
        type: 'GET',
        url: "/Categorias/Find/" + id,
        dataType: 'json',
        contentType: "aplication/json; charset=utf-8",
        success: function (data) {
            $("#txtId").val(data["cate_Id"]);
            $("#txtcata").val(data["cate_categoria"]);
            $("#edit-modal").modal('show');
        },
    });
}

function Edit() {
    var Input_Id = $('#txtId').val();
    var Input_Categoria = $('#txtcata').val();
    if (Input_Categoria == "") {
        $("#LbGeneral2").text("El campo es requerido");

    }
    if (Input_Id != "" && Input_Categoria != "") {
        $("#LbGeneral2").text("");

        $.ajax({
            url: '/Categorias/Edit',
            type: 'POST',
            data: { cate_Id: Input_Id, cate_categoria: Input_Categoria },
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