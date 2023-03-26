function AgregarRegistro() {
    InputId = $("#txtCodigo").val();
    InputEstado = $("#txtEstadoCivil").val();
    if (InputId == "" && InputEstado == "") {
        $("#LbGeneral").text("Los campos son requeridos");
        $("#Lb1").removeAttr("hidden");
        $("#Lb2").removeAttr("hidden");
    }
    if (InputId != "" && InputEstado == "") {
        $("#LbGeneral").text("Campo Estado Civil requerido");
        $("#Lb2").removeAttr("hidden");
        $("#Lb1").attr("hidden", "");
    }
    if (InputId == "" && InputEstado != "") {
        $("#LbGeneral").text("Campo Codigo requerido");
        $("#Lb1").removeAttr("hidden");
        $("#Lb2").attr("hidden", "");
    }
    if (InputId != "" && InputEstado != "") {
        $("#LbGeneral").text("");
        $("#Lb1").attr("hidden", "");
        $("#Lb2").attr("hidden", "");


        $.ajax({
            url: '/EstadosCiviles/Create',
            type: 'POST',
            data: { esci_Id: InputId, esci_EstadoCivil: InputEstado },
            success: function (data) {
                if (data.nombre == 0) {
                    MostrarMensajeWarning("El Registro ya Existe");
                }
                if (data.nombre == 1) {
                    MostrarMensajeWarning("El Codigo del Registro ya Existe");
                }
                if (data.nombre == 2) {
                    MostrarMensajeWarning("La Descripcion del Registro ya Existe");
                }
                if (data.nombre == 3) {
                    MostrarMensajeSuccess("El registro ingresado con exito");
                    setTimeout(function () {
                        window.location.reload();
                    }, 5000);
                }
            }
        });

    }
}

function Cerrar() {
    $("#txtCodigo").val("");
    $("#txtEstadoCivil").val("");
    $("#LbGeneral").text("");
    $("#Lb1").attr("hidden", "");
    $("#Lb2").attr("hidden", "");
}