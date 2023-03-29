CargarTable(0);

function CargarTable(e) {
    $(document).ready(function () {
        table = $('#TableInsumos').DataTable({
            destroy: true,
            ajax: ({
                url: "/DetallesCompras/ListarGuardarDetalles",
                method: "POST",
                data: { comp_Id: e },
                dataSrc: ""
            }),
            columns: [
                {
                    data: 'insm_Id'
                },
                {
                    data: 'insm_Descripcion'
                },
            ],
            order: [[1, 'asc']],
            language: {
                url: '//cdn.datatables.net/plug-ins/1.13.2/i18n/es-MX.json'
            }
        });
    });
}
