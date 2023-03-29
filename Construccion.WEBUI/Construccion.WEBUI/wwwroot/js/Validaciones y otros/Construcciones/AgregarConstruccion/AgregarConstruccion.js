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
    //$.ajax({
    //    type: "GET",
    //    url: "/Construcciones/ListarDepartamentos",
    //    data: "{}",
    //    success: function (data) {
    //        var s = '<option value="" selected hidden >Por favor selecciona un departamento</option>';
    //        for (var i = 0; i < data.length; i++) {
    //            s += '<option value="' + data[i].depa_Id + '" >' + data[i].depa_Nombre + '</option>';
    //        }
    //        $("#ddlDepto").html(s);
    //    }
    //});
    $("#contentHidden").attr("hidden","");
    Limpiar();
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


    // Establecer la fecha mínima para el datepicker de la fecha de inicio
    var fechaMinima = new Date();
    $('#dateInicio').datepicker({
        minDate: fechaMinima
    });

    // Establecer la fecha mínima y máxima para el datepicker de la fecha final
    $('#dateFin').datepicker({
        minDate: fechaMinima,
        maxDate: "+1y" // Fecha máxima un año a partir de la fecha actual
    });

    // Validar la fecha final al seleccionar una fecha
    $('#dateFin').change(function () {
        var fechaInicio = $('#dateInicio').datepicker("getDate");
        var fechaFinal = $(this).datepicker("getDate");


        // Validar que la fecha final no sea menor a la fecha de inicio
        if (fechaFinal < fechaInicio) {
            mostrarErrorToast("La fecha final no puede ser menor que la fecha de inicio");
            $(this).val("");
        }
    });



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
    var can = true;
    var x1 = $("#ProyectName").val();
    var x2 = $("#dateInicio").val();
    var x3 = $("#dateFin").val();
    var x4 = $("#ddlMunicipio").val();
    var x5 = $("#txtAreaProyecDes").val();
    var x6 = $("#txtAreaDireccionProy").val();

    if (x1 == "" || x1 == null) {
        $("#Error1").removeAttr("hidden");
    }

    if (x1 != "" || x1 != null) {
        $("#Error1").attr("hidden","");
    }

    if (x2 == "" || x2 == null) {
        $("#Error2").removeAttr("hidden");
        can = false;
    }
    if (x2 != "" || x2 != null) {
        $("#Error2").attr("hidden", "");
    }

    if (x3 == "" || x3 == null) {
        $("#Error3").removeAttr("hidden");
    }
    if (x3 != "" || x3 != null) {
        $("#Error3").attr("hidden", "");
    }

    if ((x1 != "" && x1 != null) && (x2 != "" && x2 != null) && (x3 != "" && x3 != null) && (x4 != "" && x4 != "-1") && (x5 != "" && x5 != null) && (x6 != "" && x6 != null)) {
        $.ajax({
            type: "POST",
            url: "/Construcciones/InsertarConstruccion",
            data: { cons_Proyecto: x1, cons_ProyectoDescripcion: x5, muni_id: x4, cons_Direccion: x6, cons_FechaInicio: x2, cons_FechaFin: x3 },
            success: function (data) {
                if (data.success) {
                    console.log(data.resultado[0].cons_Id);
                    $("#txtCons_id").val(data.resultado[0].cons_Id);
                    $("#contentHidden").removeAttr("hidden");
                    $("#ProyectName").prop("disable",true);
                    $("#dateInicio").prop("disable", true);
                    $("#dateFin").prop("disable", true);
                    $("#ddlMunicipio").prop("disable", true);
                    $("#txtAreaProyecDes").prop("disable", true);
                    $("#txtAreaDireccionProy").prop("disable", true);
                }
            }
        });
    }
});