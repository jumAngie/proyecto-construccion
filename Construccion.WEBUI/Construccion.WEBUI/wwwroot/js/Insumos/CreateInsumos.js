function AbrirModalCrearInsumos() {
    $("#CreateInsumos").modal("show");
    Cargarddls();
}

function Cargarddls() {
    $.ajax({
        type: "GET",
        url: "/Insumos/CargarUnidadesMedida",
        data: "{}",
        success: function (data) {
            var s = '<option value="" selected hidden >Selecciona una Medida</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].unim_Id + '" >' + data[i].unim_Descripcion + '</option>';
            }
            $("#unim_Id").html(s);
        }
    })
}