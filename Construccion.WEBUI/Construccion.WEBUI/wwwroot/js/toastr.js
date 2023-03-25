function MostrarMensajeSuccess(bodymessage) {
    toastr.success(bodymessage, 'Exitoso')
}

function MostrarMensajeWarning(bodymessage) {
    toastr.warning(bodymessage, 'Advertencia')
}

function MostrarMensajeDanger(bodymessage) {
    toastr.error(bodymessage, 'Error')
}

function MostrarMensajeInfo(bodymessage) {
    toastr.info(bodymessage, 'Info')
}

function CerrarSesion() {
    localStorage.removeItem("Session");
}

if (!localStorage.getItem("Session")) {
    setTimeout(function () {
        window.location.reload();
    }, 20)
}
