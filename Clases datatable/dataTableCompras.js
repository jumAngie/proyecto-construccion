/* Formatting function for row details - modify as you need */
function format(d) {
    // `d` is the original data object for the row
    return (
        '<table cellpadding="8" cellspacing="0" border="0" class="col-12" >' +
        '<thead>' +
            '<tr>' +
                '<th> Detalle compra Id </th>' +
                '<th> Compra Id </th>' +
                '<th> Codigo del producto </th>' +
                '<th> Producto  </th>' +
                '<th> Cantidad del producto  </th>' +
                '<th> Precio de compra </th>' +
            '</tr>'+
        '</thead>' +
        '<tbody>' +
            d +
        '</tbody>'
    );
}


//var fechaActual = new Date().toISOString().substring(0, 10);
//document.getElementById("cita_FechaReservada").value = fechaActual;
//$("#cita_FechaReservada").attr("min", fechaActual);
//$("#cita_FechaReservadaEditar").attr("min", fechaActual);

$(document).ready(function () {
    var table = $('#TableCompras').DataTable({
        destroy: true,
        ajax: ({
            url: "/Compras/Listado",
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
                data: 'comp_Id'
            },
            {
                data: 'comp_Fecha'
            },
            {
                data: 'prov_Nombre'
            },
            {
                data: null,
                defaultContent: '<a class="btn btn-warning" style="color:white;"><div class="d-flex align-items-center"><span class="nav-link-icon"><span><i data-feather="edit"></i></span></span><span class="nav-link-text ps-1">Editar</span></div></a>',
            },
            {
                data: null,
                defaultContent: '<a class="btn btn-info" style="color:white;"><div class="d-flex align-items-center"><span class="nav-link-icon"><span><i data-feather="info"></i></span></span><span class="nav-link-text ps-1">Detalles</span></div></a>',
            },
            {
                data: null,
                defaultContent: '<a class="btn btn-danger" style="color:white;"><div class="d-flex align-items-center"><span class="nav-link-icon"><span><i data-feather="trash"></i></span></span><span class="nav-link-text ps-1">Eliminar</span></div></a>',
            },
            {
                data: null,
                defaultContent: '<a class="btn btn-primary"><div class="d-flex align-items-center"><span class="nav-link-icon"><span> <i data-feather="plus"></i></span></span><span class="nav-link-text ps-1">Nuevo</span></div></a>',
            }
        ],
        order: [[1, 'asc']],
        language: {
            url: '//cdn.datatables.net/plug-ins/1.13.2/i18n/es-MX.json'
        }
    });

    // Add event listener for opening and closing details
    $('#TableCompras tbody').on('click', 'td.dt-control', function () {
        var tr = $(this).closest('tr');
        var row = table.row(tr);

        if (row.child.isShown()) {
            // This row is already open - close it
            row.child.hide();
            tr.removeClass('shown');
        } else {

            var listado = "";

            $.ajax({
                url: "/DetallesCompras/ListarDetallesComprasPorIdCompra",
                method: "POST",
                data: { comp_Id: row.data().comp_Id },
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
    $('#TableCompras tbody').on('click', 'a.btn.btn-gradient-warning', function () {
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
    $('#TableCompras tbody').on('click', 'a.btn.btn-gradient-success', function () {
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
    $('#TableCompras tbody').on('click', 'a.btn.btn-gradient-info', function () {
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
    $('#TableCompras tbody').on('click', 'a.btn.btn-gradient-danger', function () {
        var tr = $(this).closest('tr');
        var row = table.row(tr);

        $("#cita_IdEliminar").val(row.data().cita_Id);
        MostrarModalEliminarCita();
    });
});

setTimeout(function () {
    cargarIconos();
}, 50)