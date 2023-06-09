﻿/* Formatting function for row details - modify as you need */
function format(d) {
    // `d` is the original data object for the row
    return (
        '<table cellpadding="8" cellspacing="0" border="0" class="col-12" >' +
        '<thead>' +
            '<tr>' +
                '<th> Id </th>' +
                '<th> Id Servicio </th>' +
                '<th> Servicio </th>' +
                '<th> Id Empleado </th>' +
                '<th> Empleado </th>' +
            '</tr>'+
        '</thead>' +
        '<tbody>' +
            d +
        '</tbody>'
    );
}


var fechaActual = new Date().toISOString().substring(0, 10);
document.getElementById("cita_FechaReservada").value = fechaActual;
$("#cita_FechaReservada").attr("min", fechaActual);
$("#cita_FechaReservadaEditar").attr("min", fechaActual);

$(document).ready(function () {
    var table = $('#tbCitas').DataTable({
        destroy: true,
        ajax: ({
            url: "/Citas/Listado",
            method: "POST",
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
                data: 'cita_Id'
            },
            {
                data: 'cita_FechaReservada'
            },
            {
                data: 'cita_HoraCita'
            },
            {
                data: 'clie_Id'
            },
            {
                data: 'clie_Nombre'
            },
            {
                data: null,
                defaultContent: '<a class=\"btn btn-gradient-warning\" style=\"color: white;\" ><i data-feather=\'edit-2\'></i></a>',
            },
            {
                data: null,
                defaultContent: '<a class=\"btn btn-gradient-info\" style=\"color: white;\"><i data-feather=\'list\'></i></a>',
            },
            {
                data: null,
                defaultContent: '<a class=\"btn btn-gradient-danger\" style=\"color: white;\"><i data-feather=\'trash-2\'></i></a>',
            },
            {
                data: null,
                defaultContent: '<a class=\"btn btn-gradient-success\" style=\"color: white;\"><i data-feather=\'plus\'></i></a>',
            }
        ],
        order: [[1, 'asc']],
        language: {
            url: '//cdn.datatables.net/plug-ins/1.13.2/i18n/es-MX.json'
        }
    });

    // Add event listener for opening and closing details
    $('#tbCitas tbody').on('click', 'td.dt-control', function () {
        var tr = $(this).closest('tr');
        var row = table.row(tr);

        if (row.child.isShown()) {
            // This row is already open - close it
            row.child.hide();
            tr.removeClass('shown');
        } else {

            var listado = "";

            $.ajax({
                url: "/CitaServicios/ServiciosCita",
                method: "POST",
                data: { cita_Id: row.data().cita_Id },
                success: function (data) {
                    if (data.success) {
                        $.each(data.listado, function (index, item) {
                            listado += "<tr>";
                            $.each(item, function (i, value) {
                                if (value != 0 && value != null) {
                                    listado += "<td>" + value + "</td>";
                                }
                            })
                            listado += "</tr>";
                        })

                        // Open this row
                        row.child(format(listado)).show();
                        tr.addClass('shown');
                    } else if (!data.success) {
                        listado += '<tr><td valign="top" colspan="8" class="dataTables_empty">';
                        listado += 'No hay datos disponibles en la tabla';
                        listado += '<td></tr>';
                        // Open this row
                        row.child(format(listado)).show();
                        tr.addClass('shown');
                    }
                    cargarIconos();
                }
            });
        }
    });

    // Add event listener for opening and closing details
    $('#tbCitas tbody').on('click', 'a.btn.btn-gradient-warning', function () {
        var tr = $(this).closest('tr');
        var row = table.row(tr);

        $.ajax({
            url: "/Citas/preEdit",
            method: "POST",
            data: { cita_Id: row.data().cita_Id },
            success: function (data) {
                if (data.success) {
                    $("#cita_Id").val(data.cita.cita_Id);
                    $("#cita_HoraCita").val(data.cita.cita_HoraCita);
                    document.getElementById("cita_FechaReservada").value = data.cita.cita_FechaReservada.substring(0, 10);
                    document.getElementById("clie_Id").value = data.cita.clie_Id;
                    document.getElementById("sucu_Id").value = data.cita.sucu_Id;

                    preEdit();
                    CargarTablaServiciosCita();

                } else {
                    MostrarMensajeDanger("Error al cargar los datos para editar");
                }
            }
        });
    });

    // Add event listener for opening and closing details
    $('#tbCitas tbody').on('click', 'a.btn.btn-gradient-success', function () {
        var tr = $(this).closest('tr');
        var row = table.row(tr);

        $.ajax({
            url: "/Citas/preEdit",
            method: "POST",
            data: { cita_Id: row.data().cita_Id },
            success: function (data) {
                if (data.success) {

                    Limpiar();

                    $("#cita_Id").val(data.cita.cita_Id);
                    $("#cita_HoraCita").val(data.cita.cita_HoraCita);
                    document.getElementById("cita_FechaReservada").value = data.cita.cita_FechaReservada.substring(0, 10);
                    document.getElementById("clie_Id").value = data.cita.clie_Id;
                    document.getElementById("sucu_Id").value = data.cita.sucu_Id;

                    if ($("#step-listado").hasClass("content active dstepper-block")) {
                        $("#step-listado").removeClass("content active dstepper-block").addClass("content");
                        $("#btn1").removeClass("step active").addClass("step");
                    }

                    if ($("#step-agregar-servicios-cita").hasClass("content")) {
                        $("#step-agregar-servicios-cita").removeClass("content").addClass("content active dstepper-block");
                        $("#btn3").removeClass("step").addClass("step active");
                    }

                    $("#divbtnGuardar").attr("hidden", "");
                    $("#btnGuardar").attr("hidden", "");

                    $("#divbtnEditar").removeAttr("hidden");
                    $("#btnEditar").removeAttr("hidden");

                    CargarTablaServiciosCita();
                } else {
                    MostrarMensajeDanger("Error al cargar los datos");
                }
            }
        });
    });

    // Add event listener for opening and closing details
    $('#tbCitas tbody').on('click', 'a.btn.btn-gradient-info', function () {
        var tr = $(this).closest('tr');
        var row = table.row(tr);

        window.location.href = "/Citas/Details/" + row.data().cita_Id;
        //$.ajax({
        //    url: "/Citas/Details",
        //    method: "POST",
        //    data: { cita_Id: row.data().cita_Id },
        //    success: function (data) {
        //        if (data.success) {
                   
        //        }
        //    }
        //});
    });

    // Add event listener for opening and closing details
    $('#tbCitas tbody').on('click', 'a.btn.btn-gradient-danger', function () {
        var tr = $(this).closest('tr');
        var row = table.row(tr);

        $("#cita_IdEliminar").val(row.data().cita_Id);
        MostrarModalEliminarCita();
    });
});

setTimeout(function () {
    cargarIconos();
}, 50)