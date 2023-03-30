    function GuardarInsert() {
            var siuu = true;

        if ($('#identificacion').val() == "") {
        siuu = false;
        }
        if ($('#nombre').val() == "") {
            siuu = false;
        }
        if ($('#telefono').val() == "") {
            siuu = false;
        }
        if ($('#correo').val() == "") {
            siuu = false;
        }
        if ($('#ddlDepto').val() == "") {
            siuu = false;
        }
        if ($('#ddlMunicipio').val() == "") {
            siuu = false;
        }

    if (siuu == false) {
        mostrarErrorToast("Campos requeridos.");
    }

};
    if (siuu) {
        $('#CrearCliente').submit();
            }

        };