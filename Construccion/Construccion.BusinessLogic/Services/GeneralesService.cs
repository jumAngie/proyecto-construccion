﻿using Construccion.DataAccess.Repositories.Gral;
using Construccion.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construccion.BusinessLogic.Services
{
    public class GeneralesService
    {
        private readonly DepartamentosRepository _departamentosRepository;
        private readonly EmpleadosRepository     _empleadosRepository;

        public GeneralesService(DepartamentosRepository departamentosRepository, EmpleadosRepository empleadosRepository)
        {
            _departamentosRepository = departamentosRepository;
            _empleadosRepository = empleadosRepository;
        }


        #region Empleados
        public ServiceResult ListEmpleados()
        {
            var result = new ServiceResult();

            try
            {
                var list = _empleadosRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult CreateEmpleados(tbEmpleados item)
        {
            var result = new ServiceResult();

            try
            {
                if (item.empl_Nombre != "" && item.empl_Apellidos != "" && item.empl_DNI != "" && item.empl_CorreoEletronico != ""
                    && item.empl_DireccionExacta != "" && item.empl_Telefono != "" && item.esta_ID != "" && item.muni_Id != ""
                    && item.empl_Sexo != "") 
                {
                    var map = _empleadosRepository.Insert(item);
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
    }

}
