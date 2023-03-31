
CargarDataTable();
var table;
function CargarDataTable() {
      table = $('#TableRoles').DataTable({
        destroy: true,
        ajax: ({
            url: "/Roles/Listar",
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
                data: 'role_Id'
            },
            {
                data: 'role_Nombre'
            },
            {
                data: null,
                defaultContent: '<a class="btn btn-warning" style="color:white;">Editar</a>',
            },
            {
                data: null,
                defaultContent: '<a class="btn btn-danger" style="color:white;">Eliminar</a>',
            },
            {
                data: null,
                defaultContent: '<a class="btn btn-primary" style="color:white;">Accesos</a>',
            }
        ],
        order: [[1, 'asc']],
        language: {
            url: '//cdn.datatables.net/plug-ins/1.13.2/i18n/es-MX.json'
        }
    });
}

$('#TableRoles tbody').on('click', 'a.btn.btn-primary', function () {
        var tr = $(this).closest('tr');
        var row = table.row(tr);

        $("#txtIdRol").val(row.data().role_Id);
        AbrirModalAccesos();
});


$('#TableRoles tbody').on('click', 'td.dt-control', function () {
    var tr = $(this).closest('tr');
    var row = table.row(tr);

    if (row.child.isShown()) {
        // This row is already open - close it
        row.child.hide();
        tr.removeClass('shown');
    } else {

        var listado = "";

        $.ajax({
            url: "/Roles/RolesPantalla",
            method: "POST",
            data: { role_Id: row.data().role_Id },
            success: function (data) {
                if (data.success) {
                    $.each(data.res, function (index, item) {
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

$('#TableRoles tbody').on('click', 'a.btn.btn-warning', function () {
    var tr = $(this).closest('tr');
    var row = table.row(tr);

    $("#txtRolId").val(row.data().role_Id);
    AbrirModalEditarAccesoName();
});

$('#TableRoles tbody').on('click', 'a.btn.btn-danger', function () {
    var tr = $(this).closest('tr');
    var row = table.row(tr);

    $("#txtRoleIdEliminar").val(row.data().role_Id);
    EliminarRol();
});

function EliminarRol() {
    $("#DeleteRol").modal("show");    
}

function btnEliminar() {
    $.ajax({
        url: "/Roles/Delete",
        method: "POST",
        data: { role_Id: $("#txtRoleIdEliminar").val() },
        success: function (data) {
            window.location.reload();
        }
    });
}

function CerrarModalElminar() {
    $("#DeleteRol").modal("hide");
}

function AbrirModalEditarAccesoName() {
    $("#ModalExampleEditar").modal("show");
    $.ajax({
        url: "/Roles/CargarDatos",
        method: "POST",
        data: { role_Id: $("#txtRolId").val() },
        success: function (data) {
                $("#txtRolEditar").val(data[0].role_Nombre);
        }
    });
}




function format(d) {
    // `d` is the original data object for the row
    return (
        '<table cellpadding="8" cellspacing="0" border="0" class="col-12" >' +
        '<thead>' +
        '<tr>' +
        '<th> Pantalla Id </th>' +
        '<th> Pantalla </th>' +
        '</tr>' +
        '</thead>' +
        '<tbody>' +
        d +
        '</tbody>'
    );
}