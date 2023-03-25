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
        #endregion

        #region Roles
        public static string InsertarRoles = "Acce.UDP_tbRoles_Insert";
        public static string UpdateRoles = "Acce.UDP_tbRoles_Update";
        public static string DeleteRoles = "Acce.UDP_tbRoles_Delete";
        #endregion

        #region Pantallas
        #endregion

        #region RolesPorPantalla
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
        #endregion

        #region Incidencias
        #endregion

        #region Insumos
        #endregion

        #region Unidades Medida
        #endregion

        #region Cargos
        #endregion

        #region Departamentos
        #endregion

        #region Empleados
        #endregion

        #region Estados Civiles
        #endregion

        #region Municipios
        #endregion
    }
}
