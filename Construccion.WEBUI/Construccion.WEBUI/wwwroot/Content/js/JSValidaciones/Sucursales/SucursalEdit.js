function AbrirModalEditar() {
    $("#ModalSucursalEditar").modal("show");
}

function CerrarModalEditar() {
    $("#ModalSucursalEditar").modal("hide");
}

function CargarDatos(sucu_Id) {
    $("#LabelSucuEditar").attr("hidden", true);
    $("#LabelDireccionEditar").attr("hidden", true);
    var Var = sucu_Id;
    $.ajax({
        type: "POST",
        url: "/Sucursales/CargarDatosSucursale",
        data: { sucu_Id: Var },
        success: function (data) {
            var depto = data[0].dept_Id;
            var muni = data[0].muni_Id;
            var nombre = data[0].sucu_Nombre;
            var direccion = data[0].sucu_DireccionExacta;
            $("#sucu_NombreEditar").val(nombre);
            $("#sucu_DireccionExactaEditar").val(direccion);
            $("#ddlDepartamentoEditar").val(depto);
            $("#txtsucu_Id").val(Var);
            $.ajax({
                type: "GET",
                url: "/Sucursales/CargarMunicipios",
                data: { dept_Id: depto },
                success: function (dataMuni) {
                    var s;
                    for (var i = 0; i < dataMuni.length; i++) {
                        s += '<option value="' + dataMuni[i].muni_Id + '" >' + dataMuni[i].muni_Municipios + '</option>';
                    }
                    $("#ddlMunicipiosEditar").html(s);
                    $("#ddlMunicipiosEditar").val(muni);
                }
            });

        }
    });
    AbrirModalEditar()
}

function Editar() {
    var canInsert = true;

    if ($("#ddlDepartamentoEditar").val() == "") {
        $("#LabelDeptoEditar").attr("hidden", false);
        canInsert = false;
    }

    if ($("#ddlDepartamentoEditar").val() != "") {
        $("#LabelDeptoEditar").attr("hidden", true);
    }

    if ($("#ddlMunicipiosEditar").val() == "") {
        $("#LabelMuniEditar").attr("hidden", false);
        canInsert = false;
    }

    if ($("#ddlMunicipiosEditar").val() != "") {
        $("#LabelMuniEditar").attr("hidden", true);
    }

    if ($("#sucu_NombreEditar").val() == "") {
        $("#LabelSucuEditar").attr("hidden", false);
        canInsert = false;
    }

    if ($("#sucu_NombreEditar").val() != "") {
        $("#LabelSucuEditar").attr("hidden", true);
    }

    if ($("#sucu_DireccionExactaEditar").val() == "") {
        $("#LabelDireccionEditar").attr("hidden", false);
        canInsert = false;
    }

    if ($("#sucu_DireccionExactaEditar").val() != "") {
        $("#LabelDireccionEditar").attr("hidden", true);
    }

    if (canInsert) {
        var sucu_Id = $("#txtsucu_Id").val();
        var municipio = $("#ddlMunicipiosEditar").val();
        var Sucursal = $("#sucu_NombreEditar").val();
        var DireccionExacta = $("#sucu_DireccionExactaEditar").val();
        $.ajax({
            type: "Post",
            url: "/Sucursales/Edit",
            data: { sucu_Id: sucu_Id, muni_ID: municipio, sucu_Nombre: Sucursal, DireccionExacta: DireccionExacta },
            success: function (data) {
                if (data == 1) {
                    MostrarMensajeSuccess("Registro actualizado con exito");
                    setTimeout(function () {
                        window.location.reload();
                    }, 5000);
                }
                else {
                    MostrarMensajeWarning("La sucursal ya existe en el municipio seleccionado");
                }
            }
        });
    }
}




function CerrarEditar() {
    $("#LabelSucuEditar").attr("hidden", true);
    $("#LabelDireccionEditar").attr("hidden", true);
};