//Funciones Ajax para el manejo del boton de Detalles
function ChargeDate(dept_Id) {
    var id = dept_Id;
    console.log(id);

    $.ajax({
        url: "/Departamentos/Find/" + id,
        type: "GET",
        dataType: "json",
        contentType: "aplication/json; charset=utf-8",

        success: function (result) {
            console.log(result)
            $('#txtCodigo').val(result["dept_Id"]);
            $('#txtDepartamento').val(result["dept_Departamento"]);
            $('#mymodaleditar').modal('show');
        }
    });
}

function Edit() {
    var Input_Id = $('#txtCodigo').val();
    var Input_Departamento = $('#txtDepartamento').val();
    if (Input_Departamento == "") {
        $("#LbGeneral").text("El campo de Departamento es requerido");
        $("#Lb1").removeAttr("hidden");
    }

    if (Input_Id != "" && Input_Departamento != "") {
        $("#LbGeneral").text("");
        $("#Lb1").attr("hidden", "");

        $.ajax({
            url: '/Departamentos/Editar',
            type: 'POST',
            data: { dept_Id: Input_Id, dept_Departamento: Input_Departamento },
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

