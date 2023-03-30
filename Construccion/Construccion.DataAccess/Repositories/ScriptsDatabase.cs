using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construccion.DataAccess.Repositories
{
    public class ScriptsDatabase
    {

        #region Login
        public static string ValidarLogin = "Acce.UDP_Login";
        public static string CambiarPassword = "Acce.UDP_tbUsuarios_CambiarPassword";
        public static string ValidarUsuario = "Acce.UDP_tbUsuarios_ValidarExisteUsername";
        public static string RestablecerPassword = "Acce.UDP_tbUsuarios_ResetPassword";
        public static string ValidarRestablecerPassword = "Acce.UDP_tbUsuarios_ValidarUsuarioRestablecerContraseña";
        #endregion

        #region Roles
        public static string InsertarRoles = "Acce.UDP_tbRoles_Insert";
        public static string UpdateRoles = "Acce.UDP_tbRoles_Update";
        public static string DeleteRoles = "Acce.UDP_tbRoles_Delete";
        public static string RolesPorPantalla = "Acce.UDP_tbRolesPorPantalla_ListarPantallas";
        #endregion

        #region Pantallas
        #endregion

        #region RolesPorPantalla
        public static string Menu_PantallaPorRol = "Acce.UDP_Menu_PantallasPorRol";
        public static string AgregarRolPantalla = "Acce.tbPantallaRoles_AgregarPantallaRol";
        public static string EliminarRolPantalla = "Acce.tbPantallaRoles_EliminarPantallaRol";
        #endregion

        #region Usuarios
        #endregion

        #region Clientes
        public static string InsertarClientes = "Cons.UDP_tbClientes_Insert";
        public static string UpdateClientes = "Cons.UDP_tbClientes_Update";
        public static string DeleteClientes = "Cons.UDP_tbClientes_Delete";
        #endregion

        #region Construcciones
        public static string InsertarConstrucciones = "Cons.UDP_tbConstrucciones_Insert";
        public static string UpdateConstrucciones = "Cons.UDP_tbConstrucciones_Update";
        public static string DeleteConstrucciones = "Cons.UDP_tbConstrucciones_Delete";
        #endregion

        #region EmpleadosPorConstruccion
        public static string EmpleadosPorConstruccionListar = "Cons.UDP_EmpleadosPorConstruccion";
        #endregion

        #region Incidencias
        #endregion

        #region Insumos
        public static string InsertarInsumos = "Cons.UDP_tbInsumos_Insert";
        public static string UpdateInsumos = "Cons.UDP_tbInsumos_Update";
        public static string DeleteInsumos = "Cons.UDP_tbInsumos_Delete";

        #endregion

        #region Unidades Medida
        public static string InsertarUnidadesMedida = "Cons.UDP_tbUnidadesMedidas_Insert";
        public static string UpdateUnidadesMedida = "Cons.UDP_tbUnidadesMedidas_Update";
        public static string DeleteUnidadesMedida = "Cons.UDP_tbUnidadesMedida_Delete";

        #endregion

        #region Cargos
        public static string InsertarCargos = "Gral.UDP_tbCargo_Insert";
        public static string UpdateCargos = "Gral.UDP_tbCargos_Update";
        #endregion

        #region Departamentos
        public static string ListarDepartamentos = "Gral.UDP_tbDepartamentos_ListarDepartamentos";
        #endregion

        #region Empleados
        public static string InsertarEmpleados = "Gral.UDP_tbEmpleados_Insert";
        public static string UpdateEmpleados = "Gral.UDP_tbEmpleados_Update";
        public static string DeleteEmpleados = "Gral.UDP_tbEmpleados_Delete";
        public static string DdlEmpleados = "UDP_tbEmpleadosConstruccion_EmpleadosTieneConstruccion";
        #endregion

        #region Estados Civiles
        #endregion

        #region Municipios
        public static string ListarMunicipiosPorIdDepartamento = "Gral.UDP_tbMunicipios_ListarMunicipiosPorIdDepartamentos";
        #endregion

        #region Insumos Por Construcciones
        public static string InsumosPorIdConstruccion = "Cons.UDP_tbInsumosConstruccion_ListarInsumosPorIdConstruccion";
        #endregion
    }
}
