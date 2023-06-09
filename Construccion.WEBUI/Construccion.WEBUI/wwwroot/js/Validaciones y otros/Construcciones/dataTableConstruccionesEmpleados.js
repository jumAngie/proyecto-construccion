﻿
CargarDataTable();
var table;
function CargarDataTable() {
    table = $('#TableConstrucciones').DataTable({
        destroy: true,
        ajax: ({
            url: "/Construcciones/Listar",
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
                data: 'cons_Id'
            },
            {
                data: 'cons_Proyecto'
            },
            {
                data: 'cons_ProyectoDescripcion'
            },
            {
                data: 'depa_Nombre'
            },
            {
                data: 'muni_Nombre'
            },
            {
                data: 'cons_Direccion'
            },           
            {
                data: null,
                defaultContent: '<a class="btn btn-outline-secondary" style="color:black;">AgregarEmpleado<svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="black" class="bi bi-pencil-square" viewBox="0 0 16 16"><path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z" /><path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z" /></svg></a>',
            },
            {
                data: null,
                defaultContent: '<a class="btn btn-outline-success" style="color:black;">Insumos<svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="black" class="bi bi-eye-fill" viewBox="0 0 16 16"><path d="M10.5 8a2.5 2.5 0 1 1-5 0 2.5 2.5 0 0 1 5 0z" /><path d="M0 8s3-5.5 8-5.5S16 8 16 8s-3 5.5-8 5.5S0 8 0 8zm8 3.5a3.5 3.5 0 1 0 0-7 3.5 3.5 0 0 0 0 7z" /></svg></a>',
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

var cons_Id;
$('#TableConstrucciones tbody').on('click', 'a.btn.btn-outline-secondary', function () {
    var tr = $(this).closest('tr');
    var row = table.row(tr);
     cons_Id = row.data().cons_Id;
    $("#ModalAgregarEmpleado").modal("show");
    $("#txtIdEmpleados").val(cons_Id);
    $.ajax({
        type: "GET",
        url: "/Construcciones/ListarEmpleados",
        data: "{}",
        success: function (data) {
            var s = '<option value="" selected hidden >selecciona un Empleado</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].empl_Id + '" >' + data[i].empl_Nombre + '</option>';
            }
            $("#ddlEmpleado2").html(s);
        }
    });
});

function AgregarEmpleadosCons(){
    if ($("#ddlEmpleado2").val() == "") {
        mostrarErrorToast("Debe escoger un empleado");
    } else {
        $.ajax({
            type: "POST",
            url: "/Construcciones/InsertarEmpleadosPorConstruccion",
            data: { cons_Id: $("#txtIdEmpleados").val(), empl_Id: $("#ddlEmpleado2").val() },
            success: function (data) {
                if (data == 1) {
                    window.location.reload();
                }
            }
        });

    }
}


$('#TableConstrucciones tbody').on('click', 'a.btn.btn-outline-success', function () {
    var tr = $(this).closest('tr');
    var row = table.row(tr);
    CargarTableInsumos(row.data().cons_Id);
});



$('#TableConstrucciones tbody').on('click', 'a.btn.btn-outline-danger', function () {
    var tr = $(this).closest('tr');
    var row = table.row(tr);

    Eliminar2(row.data().cons_Id);
});

function Eliminar2(e) {
    $("#txtDeleteIdCons").val(e);
    $("#DeleteConstruccion").modal("show");
}

function EliminarCompleto() {
    $.ajax({
        type: "POST",
        url: "/Construcciones/EliminarConstruccion",
        data: { cons_Id: $("#txtDeleteIdCons").val() },
        success: function (data) {
            if (data == 1) {
                window.location.reload();
            }
            else {
                mostrarErrorToast("Error al realizar la operacion");
            }
        }
    });
}


function AbrirModalInsumos(e) {
    $("#ModalInsumosPorConstruccion").modal("show");
    $("#txtCons").val(e);

    $('#TableInsumos tbody').on('click', 'a.btn.btn-danger', function () {
        var tr = $(this).closest('tr');
        var row = table1.row(tr);
        var insms_Id = row.data().insm_Id
        $.ajax({
            type: "POST",
            url: "/Construcciones/EliminarInsumoPorIdConstruccion",
            data: { cons_Id: $("#txtCons").val(), insm_Id: insms_Id },
            success: function (data) {
                if (data == 1) {
                    window.location.reload();
                }
                else {
                    mostrarErrorToast("Error al realizar la operacion");
                }
            }
        });


    });
}

function CerrarModalInsumos() {
    $("#ModalInsumosPorConstruccion").modal("hide");
}

var table1;
var cons_Id;
function CargarTableInsumos(e) {
    cons_Id = e;
    $(document).ready(function () {
        console.log(e);
        table1 = $('#TableInsumos').DataTable({
            destroy: true,
            ajax: ({
                url: "/Construcciones/ListarInsumos",
                method: "POST",
                data: { cons_Id: e },
                dataSrc: ""
            }),
            columns: [
                {
                    data: 'insm_Id'
                },
                {
                    data: 'insm_Descripcion'
                },
                {
                    data: 'unim_Descripcion'
                },
                {
                    data: null,
                    defaultContent: '<a class="btn btn-danger" style="color:black;">Eliminar<svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="black" class="bi bi-trash3" viewBox="0 0 16 16"><path d="M6.5 1h3a.5.5 0 0 1 .5.5v1H6v-1a.5.5 0 0 1 .5-.5ZM11 2.5v-1A1.5 1.5 0 0 0 9.5 0h-3A1.5 1.5 0 0 0 5 1.5v1H2.506a.58.58 0 0 0-.01 0H1.5a.5.5 0 0 0 0 1h.538l.853 10.66A2 2 0 0 0 4.885 16h6.23a2 2 0 0 0 1.994-1.84l.853-10.66h.538a.5.5 0 0 0 0-1h-.995a.59.59 0 0 0-.01 0H11Zm1.958 1-.846 10.58a1 1 0 0 1-.997.92h-6.23a1 1 0 0 1-.997-.92L3.042 3.5h9.916Zm-7.487 1a.5.5 0 0 1 .528.47l.5 8.5a.5.5 0 0 1-.998.06L5 5.03a.5.5 0 0 1 .47-.53Zm5.058 0a.5.5 0 0 1 .47.53l-.5 8.5a.5.5 0 1 1-.998-.06l.5-8.5a.5.5 0 0 1 .528-.47ZM8 4.5a.5.5 0 0 1 .5.5v8.5a.5.5 0 0 1-1 0V5a.5.5 0 0 1 .5-.5Z" /></svg></a>',
                },
            ],
            order: [[1, 'asc']],
            language: {
                url: '//cdn.datatables.net/plug-ins/1.13.2/i18n/es-MX.json'
            }
        });
        AbrirModalInsumos(e);
    });
}







var resultado;
$('#TableConstrucciones tbody').on('click', 'a.btn.btn-outline-primary', function () {
    var tr = $(this).closest('tr');
    var row = table.row(tr);
     resultado = row.data().cons_Id;
});

var resultado2;
$('#TableConstrucciones tbody').on('click', 'td.dt-control', function () {
    var tr = $(this).closest('tr');
    var row = table.row(tr);
    resultado2 = row.data().cons_Id;
    if (row.child.isShown()) {
        // This row is already open - close it
        row.child.hide();
        tr.removeClass('shown');
    } else {

        var listado = "";

        $.ajax({
            url: "/EmpleadosPorConstruccion/EmpleadosListar",
            method: "POST",
            data: { cons_Id: row.data().cons_Id },
            success: function (data) {
                if (data.success) {
                    $.each(data.res, function (index, item) {
                        listado += "<tr>";
                        $.each(item, function (i, value) {
                            if (value != 0 && value != null) {
                                listado += "<td>" + value + "</td>";
                            }
                        })
                        listado += '<td><button class=\"btn btn-danger\" onclick="PostEliminar(' + item.empl_Id + ',' + row.data().cons_Id +')">Eliminar</button></td>'
                        listado += "</tr>";
                    })
                    // Open this row
                    row.child(format(listado)).show();
                    tr.addClass('shown');
                } else if (!data.success) {
                    listado += '<tr><td valign="top" colspan="4" class="dataTables_empty">';
                    listado += 'No hay datos disponibles en la tabla';
                    listado += '<td></tr>';
                    // Open this row
                    row.child(format(listado)).show();
                    tr.addClass('shown');
                }
            }
        });
    }
});

function PostEliminar(i,e) {
    $("#DeleteEmpleado").modal("show");
    $("#txtEliminaEmpl").val(i);
    $("#txtIdCons").val(e);
    alert(i);
}

function CerrarModalEliminar() {
    $("#DeleteEmpleado").modal("hide");
}

function Eliminar() {
    alert($("#txtEliminaEmpl").val());
    $.ajax({
        type: "POST",
        url: "/Construcciones/EliminarEmpleadoPorIdConstruccion",
        data: { cons_Id: $("#txtIdCons").val() , empl_Id: $("#txtEliminaEmpl").val() },
        success: function (data) {
            if (data == 1) {
                window.location.reload();
            }
            else {
                mostrarErrorToast("Error al realizar la operacion");
            }
        }
    });
}

function format(d) {
    // `d` is the original data object for the row
    return (
        '<table cellpadding="8" cellspacing="0" border="0" class="col-12" >' +
        '<thead>' +
        '<tr>' +
        '<th> Codigo del empleado </th>' +
        '<th> Nombre </th>' +
        '<th> Apellido </th>' +
        '<th> Telefono </th>' +
        '<th> Correo electronico </th>' +
        '</tr>' +
        '</thead>' +
        '<tbody>' +
        d +
        '</tbody>'
    );
}

