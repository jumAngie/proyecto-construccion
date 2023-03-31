$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "/Empleados/ListarEstadosCiviles",
        data: "{}",
        success: function (data) {
            var s = '<option value="" selected hidden >Selecciona una Estado Civil</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].esta_ID + '" >' + data[i].esta_Descripcion + '</option>';
            }
            $("#esta_ID").html(s);
        }
    })
});


$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "/Empleados/ListarCargos",
        data: "{}",
        success: function (data) {
            var s = '<option value="" selected hidden >Selecciona un Cargo</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].carg_Id + '" >' + data[i].carg_Cargo + '</option>';
            }
            $("#carg_Id").html(s);
        }
    })
});


$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "/Clientes/ListarDepartamentos",
        data: "{}",
        success: function (data) {
            var s = '<option value="" selected hidden >Por favor selecciona un departamento</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].depa_Id + '" >' + data[i].depa_Nombre + '</option>';
            }
            $("#ddlDepto").html(s);
        }
    });
});

$('#ddlDepto').change(function () {
    $.ajax({
        type: "POST",
        url: "/Clientes/ListarMunicipiosPorIdDepartamento",
        data: { depa_Id: $('#ddlDepto').val() },
        success: function (data) {
            var s = '<option value="-1" selected hidden >Por favor selecciona un municipio</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].muni_id + '" >' + data[i].muni_Nombre + '</option>';
            }
            $("#ddlMunicipio").html(s);
            $("#ddlMunicipio").prop("disabled", false);
        }
    });
});