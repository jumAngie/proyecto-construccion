$(document).ready(function () {
    $('#TableEstadoCivil').DataTable();
});

$('#TableEstadoCivil').DataTable({
    language: {
        url: '//cdn.datatables.net/plug-ins/1.13.2/i18n/es-MX.json'
    }
});

function AbriCrear() {
    $("#error-modal").modal('show');
}