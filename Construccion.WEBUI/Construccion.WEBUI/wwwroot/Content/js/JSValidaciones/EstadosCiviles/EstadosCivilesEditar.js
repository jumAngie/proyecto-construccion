function showModalEditar() {
    $('#mymodaleditar').modal('show');
};

//Funciones Ajax para el manejo del boton de Detalles
function ChargeDate(esci_Id) {
    var id = esci_Id;
    console.log(id);

    $.ajax({
        url: "/EstadosCiviles/Find/" + id,
        type: "GET",
        dataType: "json",
        contentType: "aplication/json; charset=utf-8",
        success: function (result) {
            console.log(result)
            $('#txtCodigos').val(result["esci_Id"]);
            $('#txtEstadoCiviles').val(result["esci_EstadoCivil"]);
            $('#mymodaleditar').modal('show');
        }
    });
}

function Edit() {
    InputId = $("#txtCodigos").val();
    InputEstado = $("#txtEstadoCiviles").val();
    if (InputEstado == "" && InputId != "") {
        $("#LbGeneral1").text("Campo Estado Civil requerido");
        $("#Lb2").removeAttr("hidden");
        $("#Lb1").attr("hidden", "");
    }
    if (InputEstado != "" && InputId != "") {
        $("#LbGeneral1").text("");
        $("#Lb1").attr("hidden", "");
        $("#Lb2").attr("hidden", "");
        $.ajax({
            url: '/EstadosCiviles/Editar',
            type: 'POST',
            data: { esci_Id: InputId, esci_EstadoCivil: InputEstado },
            success: function (data) {
                if (data.nombre == 0) {
                    MostrarMensajeWarning("La Descripcion del registro ya Existe");
                }
                if (data.nombre == 1) {
                    MostrarMensajeSuccess("El registro actualizado con exito");
                    setTimeout(function () {
                        window.location.reload();
                    }, 5000);
                }
            }
        });
    }
}

function Cerrar() {
    $("#LbGeneral").text("");
    $("#LbGeneral1").text("");
    $("#Lb1").attr("hidden", "");
    $("#Lb2").attr("hidden", "");
    $('#txtDepartamentos').val("");
}