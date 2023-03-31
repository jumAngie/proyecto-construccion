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
    alert($("#txtCons_id").val());
    $.ajax({
        type: "POST",
        url: "/Construcciones/EliminarConstruccion",
        data: { cons_Id: $("#txtCons_id").val() },
        success: function (data) {
            if (data == 1) {
                $("#contentHidden").attr("hidden", "");              
                window.location.reload();
                Limpiar();
            }
            else {
                mostrarErrorToast("Error al realizar la operacion");
            }
        }
    });
    
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
                    mostrarInfoToast("Construccion agregada con exito");
                    console.log(data.resultado[0].cons_Id);
                    $("#txtCons_id").val(data.resultado[0].cons_Id);                    
                    $("#contentHidden").removeAttr("hidden");
                    $("#ProyectName").prop("disabled",true);
                    $("#dateInicio").prop("disabled", true);
                    $("#dateFin").prop("disabled", true);
                    $("#ddlMunicipio").prop("disabled", true);
                    $("#ddlDepto").prop("disabled", true);
                    $("#txtAreaProyecDes").prop("disabled", true);
                    $("#txtAreaDireccionProy").prop("disabled", true);
                    $("#btnCancelarAgregarObra").attr("hidden", "");
                    $("#btnAgregarObra").attr("hidden", "");
                    $.ajax({
                        type: "GET",
                        url: "/Construcciones/ListarEmpleados",
                        data: "{}",
                        success: function (data){
                            var s = '<option value="" selected hidden >selecciona un Empleado</option>';
                            for (var i = 0; i < data.length; i++) {
                                s += '<option value="' + data[i].empl_Id + '" >' + data[i].empl_Nombre + '</option>';
                            }
                            $("#ddlEmpleado").html(s);
                        }
                    });

                    $.ajax({
                        type: "GET",
                        url: "/Construcciones/CargarInsumos",
                        data: "{}",
                        success: function (data) {
                            var s = '<option value="" selected hidden >selecciona un Insumo</option>';
                            for (var i = 0; i < data.length; i++) {
                                s += '<option value="' + data[i].insm_Id + '" >' + data[i].insm_Descripcion + '</option>';
                            }
                            $("#ddlInsumos").html(s);
                        }
                    });

                }
            }
        });
    }
});


CargarDataTableEmpleados(0);
var table1;
function CargarDataTableEmpleados(e) {
    table1 = $('#TableEmpleados').DataTable({
        destroy: true,
        ajax: ({
            url: "/Construcciones/EmpleadosListarPorIdConstruccion",
            method: "POST",
            data: { cons_Id: e },
            dataSrc: ""
        }),
        columns: [
            {
                className: 'dt-control',
                orderable: false,
                data: null,
                defaultContent: '',
            },
            {
                data: 'empl_Id'
            },
            {
                data: 'empl_Nombre'
            },
            {
                data: 'carg_Cargo'
            },
            {
                data: null,
                defaultContent: '<a class="btn btn-outline-danger" style="color:black;">Eliminar<svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="black" class="bi bi-trash3" viewBox="0 0 16 16"><path d="M6.5 1h3a.5.5 0 0 1 .5.5v1H6v-1a.5.5 0 0 1 .5-.5ZM11 2.5v-1A1.5 1.5 0 0 0 9.5 0h-3A1.5 1.5 0 0 0 5 1.5v1H2.506a.58.58 0 0 0-.01 0H1.5a.5.5 0 0 0 0 1h.538l.853 10.66A2 2 0 0 0 4.885 16h6.23a2 2 0 0 0 1.994-1.84l.853-10.66h.538a.5.5 0 0 0 0-1h-.995a.59.59 0 0 0-.01 0H11Zm1.958 1-.846 10.58a1 1 0 0 1-.997.92h-6.23a1 1 0 0 1-.997-.92L3.042 3.5h9.916Zm-7.487 1a.5.5 0 0 1 .528.47l.5 8.5a.5.5 0 0 1-.998.06L5 5.03a.5.5 0 0 1 .47-.53Zm5.058 0a.5.5 0 0 1 .47.53l-.5 8.5a.5.5 0 1 1-.998-.06l.5-8.5a.5.5 0 0 1 .528-.47ZM8 4.5a.5.5 0 0 1 .5.5v8.5a.5.5 0 0 1-1 0V5a.5.5 0 0 1 .5-.5Z" /></svg></a>',
            },
        ],
        order: [[1, 'asc']],
        language: {
            url: '//cdn.datatables.net/plug-ins/1.13.2/i18n/es-MX.json'
        }
    });
}





CargarDataTableInsumos(0);
var table2;
function CargarDataTableInsumos(i) {
    table2 = $('#TableInsumos3').DataTable({
        destroy: true,
        ajax: ({
            url: "/Construcciones/ListarInsumosPorIdConstruccionTable",
            method: "POST",
            data: { cons_Id: i },
            dataSrc: ""
        }),
        columns: [
            {
                className: 'dt-control',
                orderable: false,
                data: null,
                defaultContent: '',
            },
            {
                data: 'insm_Id'
            },
            {
                data: 'insm_Descripcion'
            },
            {
                data: null,
                defaultContent: '<a class="btn btn-outline-danger" style="color:black;">Eliminar<svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="black" class="bi bi-trash3" viewBox="0 0 16 16"><path d="M6.5 1h3a.5.5 0 0 1 .5.5v1H6v-1a.5.5 0 0 1 .5-.5ZM11 2.5v-1A1.5 1.5 0 0 0 9.5 0h-3A1.5 1.5 0 0 0 5 1.5v1H2.506a.58.58 0 0 0-.01 0H1.5a.5.5 0 0 0 0 1h.538l.853 10.66A2 2 0 0 0 4.885 16h6.23a2 2 0 0 0 1.994-1.84l.853-10.66h.538a.5.5 0 0 0 0-1h-.995a.59.59 0 0 0-.01 0H11Zm1.958 1-.846 10.58a1 1 0 0 1-.997.92h-6.23a1 1 0 0 1-.997-.92L3.042 3.5h9.916Zm-7.487 1a.5.5 0 0 1 .528.47l.5 8.5a.5.5 0 0 1-.998.06L5 5.03a.5.5 0 0 1 .47-.53Zm5.058 0a.5.5 0 0 1 .47.53l-.5 8.5a.5.5 0 1 1-.998-.06l.5-8.5a.5.5 0 0 1 .528-.47ZM8 4.5a.5.5 0 0 1 .5.5v8.5a.5.5 0 0 1-1 0V5a.5.5 0 0 1 .5-.5Z" /></svg></a>',
            },
        ],
        order: [[1, 'asc']],
        language: {
            url: '//cdn.datatables.net/plug-ins/1.13.2/i18n/es-MX.json'
        }
    });
}