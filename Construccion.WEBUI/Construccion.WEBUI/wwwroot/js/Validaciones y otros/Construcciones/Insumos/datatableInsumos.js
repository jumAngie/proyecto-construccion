function AbrirModalInsumos() {
    $("#ModalInsumosPorConstruccion").modal("show");
}

function CerrarModalInsumos() {
    $("#ModalInsumosPorConstruccion").modal("hide");
}

var table1;
function CargarTableInsumos(e) {
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
            ],
            order: [[1, 'asc']],
            language: {
                url: '//cdn.datatables.net/plug-ins/1.13.2/i18n/es-MX.json'
            }
        });
        AbrirModalInsumos();
    });
}

