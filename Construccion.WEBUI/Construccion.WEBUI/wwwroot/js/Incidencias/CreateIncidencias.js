function AbrirModalCrearIncidencia() {
    $("#CreateIncidencias").modal("show");
    Cargarddls();
}

function Cargarddls() {
    $.ajax({
        type: "GET",
        url: "/Incidencias/ListarConstrucciones",
        data: "{}",
        success: function (data) {
            var s = '<option value="" selected hidden >Selecciona una Construccion</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].cons_Id + '" >' + data[i].cons_Proyecto + '</option>';
            }
            $("#cons_Id").html(s);
        }
    })
}