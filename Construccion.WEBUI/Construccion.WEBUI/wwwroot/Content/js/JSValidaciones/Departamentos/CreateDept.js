function AgregarRegistro() {
    var Input_Departamento = $('#txtDepartamentos').val();
    if (Input_Departamento == "") {
        $("#LbGeneral2").text("El campo es requerido");
        $("#Lb1").removeAttr("hidden");
    }

    if (Input_Departamento != "") {
        $("#LbGenera2").text("");
        $("#Lb1").attr("hidden", "");
        $("#formcrea").submit();

        $.ajax({
            url: '/Departamentos/Create',
            type: 'POST',
            data: { dept_Departamento: Input_Departamento },
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


//Funcion Cerrar
function Cerrar() {
    $("#LbGeneral").text("");
    $("#LbGenera2").text("");
    $("#Lb1").attr("hidden", "");
    $('#txtDepartamentos').val("");
}

function AbriCrear() {
    $("#error-modal").modal('show');
}


//funcion abrir modal
function showModalEditar() {
    $('#mymodaleditar').modal('show');
};