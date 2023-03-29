
function mostrarSuccessToast(mensaje) {
    toastr.success(mensaje, 'Exitoso')
}

function mostrarErrorToast(mensaje) {
    toastr.error(mensaje, 'Error')
}

function mostrarWarningToast(mensaje) {
    toastr.warning(mensaje, 'Advertencia')
}

function mostrarInfoToast(mensaje) {
    toastr.info(mensaje, 'Información')
}


toastr.options = {
    closeButton: true,
    progressBar: true
};



