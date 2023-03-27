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


$(document).ready(function () {
    var table = $('#TableRoles').DataTable({
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
                defaultContent: '<a class="btn btn-warning" style="color:white;"><span>Editar</span></a>',
            },
            {
                data: null,
                defaultContent: '<a class="btn btn-info" style="color:white;"><span>Detalles</span></a>',
            },
            {
                data: null,
                defaultContent: '<a class="btn btn-danger" style="color:white;"><span>Eliminar</span></a>',
            },
            {
                data: null,
                defaultContent: '<a class="btn btn-primary" style="color:white;"><span>EditarPermiso</span></div></a>',
            }
        ],
        order: [[1, 'asc']],
        language: {
            url: '//cdn.datatables.net/plug-ins/1.13.2/i18n/es-MX.json'
        }
    });
});



// Add event listener for opening and closing details
$('#TableRoles tbody').on('click', 'td.dt-control', function () {
    var tr = $(this).closest('tr');
    var row = table.row(tr);
    if (row.child.isShown()) {
        // This row is already open - close it
        row.child.hide();
        tr.removeClass('shown');
    } else {
        console.log(row.data().role_Id);
        var listado = "";

        $.ajax({
            url: "/Roles/RolesPantalla",
            method: "POST",
            data: { role_Id: row.data().role_Id },
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