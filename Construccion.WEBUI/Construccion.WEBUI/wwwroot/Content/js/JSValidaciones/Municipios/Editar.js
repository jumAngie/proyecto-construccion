function AbrirModalEditar() {
    $("#ModalMunicipioEditar").modal("show");
}

function CerrarModalEditar() {
    $("#ModalMunicipioEditar").modal("hide");
}

function CargarDatos(muni_Id) {
    $.ajax({
        type: "GET",
        url: "/Municipios/CargarDatosMunicipio",
        data: { muni_Id: muni_Id },
        success: function (data) {
            $("#txtIdMunicipioEditar").val(data.muni_Id);
            $("#txtMunicipioEditar").val(data.muni_Municipios);
            var deptoId = data.dept_Id;
            $.ajax({
                type: "GET",
                url: "/Municipios/GetDepartment",
                data: "{}",
                success: function (data) {
                    var s;
                    for (var i = 0; i < data.length; i++) {
                        s += '<option value="' + data[i].dept_Id + '" >' + data[i].dept_Departamento + '</option>';
                    }
                    $("#Depto_Id").html(s);
                    $("#Depto_Id").val(deptoId);
                }
            });
            AbrirModalEditar();
        }
    });
}


function Editar() {
    var muni_Id = $("#txtIdMunicipioEditar").val();
    var muni_Municipios = $("#txtMunicipioEditar").val();
    var dept_Id = $("#Depto_Id").val();s
    if ($("#txtMunicipioEditar").val() == "" || $("#txtMunicipioEditar").val() == null) {
        $("#lbMuni").removeAttr("hidden");
        $("#lbGeneralEditar").text("Nombre municipio requerido");
    }
    if (muni_Id != "" && muni_Municipios != "")
    {
        $.ajax({
            url: '/Municipios/Edit',
            type: 'POST',
            data: { muni_Id: muni_Id, muni_Municipios: muni_Municipios, dept_Id: dept_Id},
            success: function (data) {
                if (data.data == 1) {
                    MostrarMensajeSuccess("Registro actualizado con exito");
                    setTimeout(function () {
                        window.location.reload();
                    }, 5000);
                }
                if (data.data == 0) {
                    MostrarMensajeWarning("El municipio digitado ya existe en el departamento seleccionado");
                }
            }
        });
    }
}