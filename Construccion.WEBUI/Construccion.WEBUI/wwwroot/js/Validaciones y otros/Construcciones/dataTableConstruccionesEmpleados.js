
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
                defaultContent: '<a class="btn btn-warning" style="color:white;">Editar</a>',                            
            },
            {
                data: null,
                defaultContent: '<a class="btn btn-warning" style="color:white;">Insumos</a>',
            },
            {
                data: null,
                defaultContent: '<a class="btn btn-warning" style="color:white;">Eliminar</a>',
            },
        ],
        order: [[1, 'asc']],
        language: {
            url: '//cdn.datatables.net/plug-ins/1.13.2/i18n/es-MX.json'
        }
    });
}




$('#TableConstrucciones tbody').on('click', 'td.dt-control', function () {
    var tr = $(this).closest('tr');
    var row = table.row(tr);

    if (row.child.isShown()) {
        // This row is already open - close it
        row.child.hide();
        tr.removeClass('shown');
    } else {

        var listado = "";

        $.ajax({
            url: "/Construcciones/EmpleadosListar",
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
                        listado += '<td><button class=\"btn btn-danger\" onclick="PostEliminar(' + item.role_Id + ')">Eliminar</button></td>'
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