$("#btnAgregarProyecto").click(function () {
    $("#pills-iconprofile-tab").removeAttr("disabled");
    if ($("#pills-iconhome-tab").hasClass("nav-link active")) {
        $("#pills-iconhome-tab").removeClass("nav-link active").addClass("nav-link");
        $("#pills-iconprofile").removeClass("tab-pane fade");
        $("#pills-iconprofile").addClass("tab-pane fade active show");
        $("#pills-iconhome").removeClass("tab-pane fade active show");
        $("#pills-iconhome").addClass("tab-pane fade");
        $("#pills-iconhome-tab").attr("disabled", "");
    }
    if ($("#pills-iconprofile-tab").hasClass("nav-link")) {
        $("#pills-iconprofile-tab").removeClass("nav-link").addClass("nav-link active");
        $("#pills-iconprofile").addClass("tab-pane fade active show");
    }
});


$("#btnCancelarAgregarObra").click(function () {
    
    $("#pills-iconhome-tab").removeAttr("disabled");
    if ($("#pills-iconprofile-tab").hasClass("nav-link active")) {
        $("#pills-iconprofile-tab").removeClass("nav-link active").addClass("nav-link");
        $("#pills-iconhome").removeClass("tab-pane fade");
        $("#pills-iconhome").addClass("tab-pane fade active show");
        $("#pills-iconprofile").removeClass("tab-pane fade active show");
        $("#pills-iconprofile").addClass("tab-pane fade");
        $("#pills-iconprofile-tab").attr("disabled", "");
    }   
    if ($("#pills-iconhome-tab").hasClass("nav-link")) {
        $("#pills-iconhome-tab").removeClass("nav-link").addClass("nav-link active");
        $("#pills-iconhome").addClass("tab-pane fade active show");
    }
    Limpiar();
});



$("#btnAgregarObra").click(function () {

});

$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "/Construcciones/ListarDepartamentos",
        data: "{}",
        success: function (data) {
            var s = '<option value="" selected hidden >Por favor selecciona un departamento</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].depa_Id + '" >' + data[i].depa_Nombre + '</option>';
            }
            $("#ddlDepto").html(s);
        }
    });


    //// Establecer la fecha mínima para el datepicker de la fecha de inicio
    //var fechaMinima = new Date();
    //$('#dateInicio').datepicker({
    //    dateFormat: 'yyyy-MM-dd',
    //    minDate: fechaMinima
    //});

    //// Establecer la fecha mínima y máxima para el datepicker de la fecha final
    //$('#dateFin').datepicker({
    //    dateFormat: 'yyyy-MM-dd',
    //    minDate: fechaMinima,
    //    maxDate: "+1y" // Fecha máxima un año a partir de la fecha actual
    //});

    //// Validar la fecha final al seleccionar una fecha
    //$('#dateFin').change(function () {
    //    var fechaInicio = $('#dateInicio').datepicker("getDate");
    //    var fechaFinal = $(this).datepicker("getDate");

    //    // Validar que la fecha final no sea igual a la fecha actual
    //    if (fechaFinal.getTime() === fechaMinima.getTime()) {
    //        alert("La fecha final no puede ser igual a la fecha actual");
    //        $(this).val("");
    //    }

    //    // Validar que la fecha final no sea menor a la fecha de inicio
    //    if (fechaFinal < fechaInicio) {
    //        alert("La fecha final no puede ser menor que la fecha de inicio");
    //        $(this).val("");
    //    }
    //});



});


$('#ddlDepto').change(function () {
    $.ajax({
        type: "POST",
        url: "/Construcciones/ListarMunicipiosPorIdDepartamento",
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

function Limpiar() {
    $("#ProyectName").val("");
    $("#dateInicio").val("");
    $("#dateFin").val("");
    $("#ddlDepto").val("");
    $("#txtAreaProyecDes").val("");
    $("#txtAreaDireccionProy").val("");
    $("#ddlMunicipio").prop("disabled", true);
    $.ajax({
        type: "POST",
        url: "/Construcciones/ListarMunicipiosPorIdDepartamento",
        data: { depa_Id: $('#ddlDepto').val() },
        success: function (data) {
            var s = '<option value="-1" selected hidden >Por favor selecciona un municipio</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].muni_id + '" >' + data[i].muni_Nombre + '</option>';
            }
            $("#ddlMunicipio").html(s);           
        }
    });
}


$("#btnAgregarObra").click(function () {
    var x1 = $("#ProyectName").val("");
    var x2 = $("#dateInicio").val("");
    var x3 = $("#dateFin").val("");
    var x4 = $("#ddlMunicipio").val("");
    var x5 = $("#txtAreaProyecDes").val("");
    var x6 = $("#txtAreaDireccionProy").val("");
    $.ajax({
        type: "POST",
        url: "/Construcciones/InsertarConstruccion",
        data: { cons_Proyecto: x1, cons_ProyectoDescripcion: x5, muni_id: x4, cons_Direccion: x6, cons_FechaInicio: x2, cons_FechaFin: x3 },
        success: function (data) {
            $("#txtCons_id").val(data);
        }
    });

});