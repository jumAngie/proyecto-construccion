using Construccion.DataAccess.Repositories.Acce;
using Construccion.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construccion.BusinessLogic.Services
{
    public class AccessService
    {
        private readonly RolesRepository _rolesRepository;
        private readonly UsuariosRepository _usuariosRepository;
        private readonly PantallasRepository _pantallasRepository;
        private readonly RolesPorPantallaRepository _rolesPorPantallaRepository;

        public AccessService(RolesRepository rolesRepository, UsuariosRepository usuariosRepository, 
                             PantallasRepository pantallasRepository, RolesPorPantallaRepository rolesPorPantallaRepository)
        {
            _rolesRepository = rolesRepository;
            _pantallasRepository = pantallasRepository;
            _usuariosRepository = usuariosRepository;
            _rolesPorPantallaRepository = rolesPorPantallaRepository;
        }

        #region Roles
        public ServiceResult ListRoles()
        {
            var result = new ServiceResult();

            try
            {
                var list = _rolesRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        public ServiceResult ListRolesPantalla(tbPantallasRoles tbPantallasRoles)
        {
            var result = new ServiceResult();

            try
            {
                var list = _rolesRepository.ListarRolesPantalla(tbPantallasRoles);
                return result.Ok(list);
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }

        public ServiceResult CargarDatosEditar(tbRoles item)
        {
            var result = new ServiceResult();

            try
            {
                var list = _rolesRepository.CargarDatosRoles(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }

        public ServiceResult CreateRoles(tbRoles item)
        {
            var result = new ServiceResult();

            try
            {
                if (item.role_Nombre != "")
                {
                    var map = _rolesRepository.Insert(item);
                    if (map.CodeStatus > 0)
                    {                       
                        return result.Ok(map);
                    }
                    else
                    {
                        map.MessageStatus = (map.CodeStatus == 0) ? "401 Error de Consulta" : map.MessageStatus;
                        return result.Error(map);
                    }                   
                }
                else
                {
                   return result.SetMessage("La solicitud contiene sintaxis erronea",ServiceResultType.BadRecuest);
                }
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }

        public ServiceResult UpdateRoles(tbRoles item)
        {
            var result = new ServiceResult();
            try
            {
                if (item.role_Nombre != "")
                {
                    var map = _rolesRepository.Update(item);
                    if (map.CodeStatus > 0)
                    {
                        return result.Ok(map);
                    }
                    else
                    {
                        map.MessageStatus = (map.CodeStatus == 0) ? "401 Error de Consulta" : map.MessageStatus;
                        return result.Error(map);
                    }
                }
                else
                {
                    return result.SetMessage("La solicitud contiene sintaxis erronea", ServiceResultType.BadRecuest);
                }
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }

        public ServiceResult Delete(tbRoles item)
        {
            var result = new ServiceResult();
            try
            {
                if (item.role_Nombre != "")
                {
                    var map = _rolesRepository.DELETE(item);
                    if (map.CodeStatus > 0)
                    {
                        return result.Ok(map);
                    }
                    else
                    {
                        map.MessageStatus = (map.CodeStatus == 0) ? "401 Error de Consulta" : map.MessageStatus;
                        return result.Error(map);
                    }
                }
                else
                {
                    return result.SetMessage("La solicitud contiene sintaxis erronea", ServiceResultType.BadRecuest);
                }
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        #endregion

        #region Usuarios
        public ServiceResult ListUsuarios()
        {
            var result = new ServiceResult();

            try
            {
                var list = _usuariosRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }

        public ServiceResult ExisteUsuario(tbUsuarios item)
        {
            var result = new ServiceResult();
            try
            {
                if (item.user_NombreUsuario != "")
                {
                    var map = _usuariosRepository.ExisteUsuario(item);
                    if (map.CodeStatus > 0)
                    {
                        return result.Ok(map);
                    }
                    else
                    {
                        map.MessageStatus = (map.CodeStatus == 0) ? "401 Error de Consulta" : map.MessageStatus;
                        return result.Error(map);
                    }
                }
                else
                {
                    return result.SetMessage("La solicitud contiene sintaxis erronea", ServiceResultType.BadRecuest);
                }
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
         
        }

        public ServiceResult CargarDatosUsuario(tbUsuarios item)
        {
            var result = new ServiceResult();

            try
            {
                var list = _usuariosRepository.CargarDatosUsuario(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }

        public ServiceResult ListarUsuarioEmpleados()
        {
            var result = new ServiceResult();

            try
            {
                var list = _usuariosRepository.ListarUsuarioEmpleados();
                return result.Ok(list);
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }

        public ServiceResult ValidarUsername(tbUsuarios item)
        {
            var result = new ServiceResult();

            try
            {
                var list = _usuariosRepository.EvaluarUsuarios(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }

        public ServiceResult UpdatePassword(tbUsuarios item)
        {
            var result = new ServiceResult();
            try
            {
                if (item.user_Contrasena != "")
                {
                    var map = _usuariosRepository.UpdatePassword(item);
                    if (map.CodeStatus > 0)
                    {
                        return result.Ok(map);
                    }
                    else
                    {
                        map.MessageStatus = (map.CodeStatus == 0) ? "401 Error de Consulta" : map.MessageStatus;
                        return result.Error(map);
                    }
                }
                else
                {
                    return result.SetMessage("La solicitud contiene sintaxis erronea", ServiceResultType.BadRecuest);
                }
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }

        public ServiceResult InsertarUsuario(tbUsuarios item)
        {
            var result = new ServiceResult();
            try
            {
                if (item.user_Contrasena != "")
                {
                    var map = _usuariosRepository.InsertarUsuario(item);
                    if (map.CodeStatus > 0)
                    {
                        return result.Ok(map);
                    }
                    else
                    {
                        map.MessageStatus = (map.CodeStatus == 0) ? "401 Error de Consulta" : map.MessageStatus;
                        return result.Error(map);
                    }
                }
                else
                {
                    return result.SetMessage("La solicitud contiene sintaxis erronea", ServiceResultType.BadRecuest);
                }
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarUsuario(tbUsuarios item)
        {
            var result = new ServiceResult();
            try
            {
                if (item.user_Contrasena != "")
                {
                    var map = _usuariosRepository.EliminarUsuario(item);
                    if (map.CodeStatus > 0)
                    {
                        return result.Ok(map);
                    }
                    else
                    {
                        map.MessageStatus = (map.CodeStatus == 0) ? "401 Error de Consulta" : map.MessageStatus;
                        return result.Error(map);
                    }
                }
                else
                {
                    return result.SetMessage("La solicitud contiene sintaxis erronea", ServiceResultType.BadRecuest);
                }
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }

        public ServiceResult UpdateUsuario(tbUsuarios item)
        {
            var result = new ServiceResult();
            try
            {
                if (item.user_Contrasena != "")
                {
                    var map = _usuariosRepository.UpdateUsuario(item);
                    if (map.CodeStatus > 0)
                    {
                        return result.Ok(map);
                    }
                    else
                    {
                        map.MessageStatus = (map.CodeStatus == 0) ? "401 Error de Consulta" : map.MessageStatus;
                        return result.Error(map);
                    }
                }
                else
                {
                    return result.SetMessage("La solicitud contiene sintaxis erronea", ServiceResultType.BadRecuest);
                }
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }

        public ServiceResult RestablecerPassword(tbUsuarios item)
        {
            var result = new ServiceResult();
            try
            {
                if (item.user_NombreUsuario != "")
                {
                    var map = _usuariosRepository.RestablecerPassword(item);
                    if (map.CodeStatus > 0)
                    {
                        return result.Ok(map);
                    }
                    else
                    {
                        map.MessageStatus = (map.CodeStatus == 0) ? "401 Error de Consulta" : map.MessageStatus;
                        return result.Error(map);
                    }
                }
                else
                {
                    return result.SetMessage("La solicitud contiene sintaxis erronea", ServiceResultType.BadRecuest);
                }
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }

        public ServiceResult ValidarUsuarioRestablecer(tbUsuarios item)
        {
            var result = new ServiceResult();

            try
            {
                var list = _usuariosRepository.ValidarUsuarioRestablecer(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        #endregion

        #region Pantallas
        public ServiceResult ListPantallas()
        {
            var result = new ServiceResult();

            try
            {
                var list = _pantallasRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }

        public ServiceResult MenuPantallas(tbPantallas item)
        {
            var result = new ServiceResult();
            var listado = _rolesPorPantallaRepository.MenuPantallas(item);
            return result.Ok(listado);
        }

        #endregion

        #region Roles Por Pantalla Repository
        public ServiceResult ListRolesPorPantalla()
        {
            var result = new ServiceResult();

            try
            {
                var list = _rolesPorPantallaRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }

        public ServiceResult InsertarPantallaRoles(tbPantallasRoles item)
        {
            var result = new ServiceResult();

            try
            {
                if (item.role_Id != 0)
                {
                    var map = _rolesPorPantallaRepository.InsertPantallaRoles(item);
                    if (map.CodeStatus > 0)
                    {
                        return result.Ok(map);
                    }
                    else
                    {
                        map.MessageStatus = (map.CodeStatus == 0) ? "401 Error de Consulta" : map.MessageStatus;
                        return result.Error(map);
                    }
                }
                else
                {
                    return result.SetMessage("La solicitud contiene sintaxis erronea", ServiceResultType.BadRecuest);
                }
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarPantallaRoles(tbPantallasRoles item)
        {
            var result = new ServiceResult();

            try
            {
                if (item.role_Id != 0)
                {
                    var map = _rolesPorPantallaRepository.EliminarPantallaRoles(item);
                    if (map.CodeStatus > 0)
                    {
                        return result.Ok(map);
                    }
                    else
                    {
                        map.MessageStatus = (map.CodeStatus == 0) ? "401 Error de Consulta" : map.MessageStatus;
                        return result.Error(map);
                    }
                }
                else
                {
                    return result.SetMessage("La solicitud contiene sintaxis erronea", ServiceResultType.BadRecuest);
                }
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        #endregion

        #region Login
        public ServiceResult IniciarSesion(tbUsuarios item)
        {
            var result = new ServiceResult();

            try
            {
                var list = _usuariosRepository.IniciarSesion(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        #endregion
    }
}
