$(document).ready(function () {
    $('#TableMuni').DataTable();
});

$('#TableMuni').DataTable({
    language: {
        url: '//cdn.datatables.net/plug-ins/1.13.2/i18n/es-MX.json'
    }
});

function Abrir() {
    $("#ModalMunicipioCrear").modal('show');
    $.ajax({
        type: "GET",
        url: "/Municipios/GetDepartment",
        data: "{}",
        success: function (data) {
            var s = '<option value="-1" selected hidden >Por favor selecciona un departamento</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].dept_Id + '" >' + data[i].dept_Departamento + '</option>';
            }
            $("#dept_Id").html(s);
        }
    });
};


function Agregar() {

    InputMuni = $("#txtMunicipio").val();
    InputDept = $("#dept_Id").val();
    if (InputMuni == "" && InputDept == "-1") {
        $("#Lb2").removeAttr("hidden");
        $("#Lb1").removeAttr("hidden");
        $("#LbGeneral").text("Los campos son requeridos");
    }
    if (InputMuni != "" && InputDept == "-1") {
        $("#Lb2").removeAttr("hidden");
        $("#Lb1").attr("hidden", "");
        $("#LbGeneral").text("Departamento requerido");
    }
    if (InputMuni == "" && InputDept != "-1") {
        $("#Lb2").attr("hidden", "");
        $("#Lb1").removeAttr("hidden");
        $("#LbGeneral").text("Municipio requerido");
    }
    if (InputMuni != "" && InputDept != "-1") {
        $("#Lb2").attr("hidden", "");
        $("#Lb1").attr("hidden", "");
        $("#LbGeneral").text("");

        $.ajax({
            url: '/Municipios/Create',
            type: 'POST',
            data: { muni_Municipios: InputMuni, dept_Id: InputDept },
            success: function (data) {
                if (data.data == 1) {
                    MostrarMensajeSuccess("Registro agregado con exito");
                    setTimeout(function () {
                        window.location.reload();
                    }, 5000);
                }
                if (data.data == 0) {
                    MostrarMensajeWarning("El municipio digitado ya existe en el departamento seleccionado");
                }
            }
        });
    }
};

function Cerrar() {
    $("#txtMunicipio").val("");
    $("#dept_Id").val("");
    $("#Lb2").attr("hidden", "");
    $("#Lb1").attr("hidden", "");
    $("#LbGeneral").text("");
}

