using Construccion.DataAccess.Repositories.Cons;
using Construccion.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construccion.BusinessLogic.Services
{
    public class ConstruccionServices
    {
        private readonly ClientesRepository         _clientesRepository;
        private readonly ConstruccionesRepository   _construccionesRepository;
        private readonly InsumosRepository          _insumosRepository;
        private readonly UnidadesMedidaRepository   _unidadesMedidaRepository;
        private readonly CargosRepository           _cargosRepository;
        private readonly IncidenciasRepository      _incidenciasRepository;
        private readonly InsumosConstruccionRepository _insumosConstruccionRepository;
        private readonly EmpleadosPorConstruccionRepository _empleadosPorConstruccionRepository;

        public ConstruccionServices(ClientesRepository clientesRepository, ConstruccionesRepository construccionesRepository,
                                    InsumosRepository insumosRepository, UnidadesMedidaRepository unidadesMedidaRepository,
                                    CargosRepository cargosRepository, IncidenciasRepository incidenciasRepository,
                                    InsumosConstruccionRepository insumosConstruccionRepository,
                                    EmpleadosPorConstruccionRepository empleadosPorConstruccionRepository)
        {
            _clientesRepository = clientesRepository;
            _construccionesRepository = construccionesRepository;
            _insumosRepository = insumosRepository;
            _unidadesMedidaRepository = unidadesMedidaRepository;
            _cargosRepository = cargosRepository;
            _incidenciasRepository = incidenciasRepository;
            _insumosConstruccionRepository = insumosConstruccionRepository;
            _empleadosPorConstruccionRepository = empleadosPorConstruccionRepository;
        }


        #region Empleados Por Construccion
        public ServiceResult ListEmpleadosConstruccion()
        {
            var result = new ServiceResult();

            try
            {
                var list = _empleadosPorConstruccionRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ListarEmpleadosPorConstruccion(tbEmpleadosPorConstruccion tbEmpleadosPorConstruccion)
        {
            var result = new ServiceResult();

            try
            {
                var list = _empleadosPorConstruccionRepository.ListarEmpleadosPorConstruccion(tbEmpleadosPorConstruccion);
                return result.Ok(list);
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }

        #endregion

        #region Insumos Por Construccion
        public ServiceResult ListInsumosConstruccion()
        {
            var result = new ServiceResult();

            try
            {
                var list = _insumosConstruccionRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ListarInsumosPorIdConstruccion(tbInsumosConstruccion tbInsumosConstruccion)
        {
            var result = new ServiceResult();

            try
            {
                var list = _insumosConstruccionRepository.InsumosPorIdConstruccion(tbInsumosConstruccion);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion

        #region Clientes
        public ServiceResult ListClientes()
        {
            var result = new ServiceResult();

            try
            {
                var list = _clientesRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult CreateClientes(tbClientes item)
        {
            var result = new ServiceResult();

            try
            {
                if (item.clie_Nombre != "" && item.clie_Identificacion != "" && item. clie_Telefono != "" && item.muni_Id != ""
                    && item.clie_DireccionExacta != "" && item.clie_CorreoElectronico != "")
                {
                    var map = _clientesRepository.Insert(item);
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

        public tbClientes ObtenerCliente(int? id)
        {
            return _clientesRepository.Find(id);
        }

        public ServiceResult EditClientes(tbClientes item)
        {
                var result = new ServiceResult();

                try
                {
                    if (item.clie_Identificacion != "")
                    {
                        var map = _clientesRepository.Update(item);
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

        #region Construcciones
        public ServiceResult ListConstrucciones()
        {
            var result = new ServiceResult();

            try
            {
                var list = _construccionesRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ListConstruccionesPorId(tbConstrucciones item)
        {
            var result = new ServiceResult();

            try
            {
                var list = _construccionesRepository.ListConstruccionesPorId(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult CreateConstruccion(tbConstrucciones item)
        {
            var result = new ServiceResult();

            try
            {
                if (item.cons_Proyecto != "")
                {
                    var map = _construccionesRepository.InsertarConstruccion(item);                  
                    return result.Ok(map);                  
                }
                return result.Ok();
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarConstruccion(tbConstrucciones item)
        {
            var result = new ServiceResult();

            try
            {
                if (item.cons_Proyecto != "")
                {
                    var map = _construccionesRepository.EliminiarConstruccion(item);
                    return result.Ok(map);
                }
                return result.Ok();
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        #endregion

        #region Insumos
        public ServiceResult ListInsumos()
        {
            var result = new ServiceResult();

            try
            {
                var list = _insumosRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult CreateInsumos(tbInsumos item)
        {
            var result = new ServiceResult();

            try
            {
                if (item.unim_Descripcion != "" && item.insm_Descripcion != "")
                {
                    var map = _insumosRepository.Insert(item);
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

        public ServiceResult EditarInsumos(tbInsumos item)
        {
            var result = new ServiceResult();

            try
            {
                if (item.unim_Descripcion != "" )
                {
                    var map = _insumosRepository.Update(item);
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

        #region Unidades Medida
        public ServiceResult ListUnidadesMedida()
        {
            var result = new ServiceResult();

            try
            {
                var list = _unidadesMedidaRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult CreateUnidades(tbUnidadesMedida item)
        {
            var result = new ServiceResult();

            try
            {
                if (item.unim_Descripcion != "")
                {
                    var map = _unidadesMedidaRepository.Insert(item);
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

        public ServiceResult EditarUnidades(tbUnidadesMedida item)
        {
            var result = new ServiceResult();

            try
            {
                if (item.unim_Descripcion != "")
                {
                    var map = _unidadesMedidaRepository.Update(item);
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

        #region Cargos
        public ServiceResult ListCargos()
        {
            var result = new ServiceResult();

            try
            {
                var list = _cargosRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }


        public ServiceResult CreateCargos(tbCargos item)
        {
            var result = new ServiceResult();

            try
            {
                if (item.carg_Cargo != "")
                {
                    var map = _cargosRepository.Insert(item);
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


        public ServiceResult EditarCargos(tbCargos item)
        {
            var result = new ServiceResult();

            try
            {
                if (item.carg_Cargo != "")
                {
                    var map = _cargosRepository.Update(item);
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

        #region Incidencias
        public ServiceResult ListIncidencias()
        {
            var result = new ServiceResult();

            try
            {
                var list = _incidenciasRepository.List();
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
