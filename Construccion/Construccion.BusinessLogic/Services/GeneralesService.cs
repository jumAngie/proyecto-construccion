using Construccion.DataAccess.Repositories.Gral;
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
        #endregion
    }

}
