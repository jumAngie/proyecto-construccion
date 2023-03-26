$(document).ready(function () {
    $('#TableUsuarios').DataTable();
});

$('#TableUsuarios').DataTable({
    language: {
        url: '//cdn.datatables.net/plug-ins/1.13.2/i18n/es-MX.json'
    }
});

function AbrirModalCrear() {
    $("#ModalCrearUsuario").modal("show");
}