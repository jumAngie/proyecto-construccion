$(document).ready(function () {
    $('#TableSucursales').DataTable();
});

$('#TableSucursales').DataTable({
    language: {
        url: '//cdn.datatables.net/plug-ins/1.13.2/i18n/es-MX.json'
    }
});


function AbrirModalCrear() {
    $("#ModalSucursalCrear").modal("show");
}

function Agregar() {
    $("#LabelMuni").attr("hidden", true);
    $("#LabelDepto").attr("hidden", true);
    $("#LabelSucu").attr("hidden", true);
    $("#LabelDireccion").attr("hidden", true);

    var canInsert = true;

    if ($("#ddlDepartamentos").val() == "") {
        $("#LabelDepto").attr("hidden", false);
        canInsert = false;
    }

    if ($("#ddlDepartamentos").val() != "") {
        $("#LabelDepto").attr("hidden", true);
    }

    if ($("#ddlMunicipios").val() == "") {
        $("#LabelMuni").attr("hidden", false);
        canInsert = false;
    }

    if ($("#ddlMunicipios").val() != "") {
        $("#LabelMuni").attr("hidden", true);
    }

    if ($("#sucu_Nombre").val() == "") {
        $("#LabelSucu").attr("hidden", false);
        canInsert = false;
    }

    if ($("#sucu_Nombre").val() != "") {
        $("#LabelSucu").attr("hidden", true);
    }

    if ($("#sucu_DireccionExacta").val() == "") {
        $("#LabelDireccion").attr("hidden", false);
        canInsert = false;
    }

    if ($("#sucu_DireccionExacta").val() != "") {
        $("#LabelDireccion").attr("hidden", true);
    }

    if (canInsert) {
        var municipio = $("#ddlMunicipios").val();
        var Sucursal = $("#sucu_Nombre").val();
        var DireccionExacta = $("#sucu_DireccionExacta").val();
        $.ajax({
            type: "Post",
            url: "/Sucursales/Create",
            data: { muni_ID: municipio, sucu_Nombre: Sucursal, DireccionExacta: DireccionExacta },
            success: function (data) {
                if (data == 1) {
                    MostrarMensajeSuccess("Registro agregado con exito");
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
};

function Cerrar() {
    $("#LabelDepto").attr("hidden", true);
    $("#LabelMuni").attr("hidden", true);
    $("#LabelSucu").attr("hidden", true);
    $("#LabelDireccion").attr("hidden", true);
    $("#ddlDepartamentos").val("");
    $("#ddlMunicipios").val("");
    $("#sucu_Nombre").val("");
    $("#sucu_DireccionExacta").val("");
    $("#ddlMunicipios").prop("disabled", true);
    $('#ddlDepartamentos').change(function () {
        $.ajax({
            type: "GET",
            url: "/Sucursales/CargarMunicipios",
            data: { dept_Id: $('#ddlDepartamentos').val() },
            success: function (data) {
                var s = '<option value="" selected hidden >Por favor selecciona un municipio</option>';
                for (var i = 0; i < data.length; i++) {
                    s += '<option value="' + data[i].muni_Id + '" >' + data[i].muni_Municipios + '</option>';
                }
                $("#ddlMunicipios").html(s);
                $("#ddlMunicipios").prop("disabled", false);
            }
        });
    });
};


$(document).ready(function () {
    $("#ddlMunicipios").prop("disabled", true); 
    $('#ddlDepartamentos').change(function () {
        $.ajax({
            type: "GET",
            url: "/Sucursales/CargarMunicipios",
            data: { dept_Id: $('#ddlDepartamentos').val()},
            success: function (data) {
                var s = '<option value="" selected hidden >Por favor selecciona un municipio</option>';
                for (var i = 0; i < data.length; i++) {
                    s += '<option value="' + data[i].muni_Id + '" >' + data[i].muni_Municipios + '</option>';
                }
                $("#ddlMunicipios").html(s);
                $("#ddlMunicipios").prop("disabled", false);
            }
        });
    });
});