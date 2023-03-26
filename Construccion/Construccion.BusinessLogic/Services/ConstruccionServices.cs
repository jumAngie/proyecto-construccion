using Construccion.DataAccess.Repositories.Cons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construccion.BusinessLogic.Services
{
    public class ConstruccionServices
    {
        private readonly ClientesRepository _clientesRepository;
        private readonly ConstruccionesRepository _construccionesRepository;

        public ConstruccionServices(ClientesRepository clientesRepository, ConstruccionesRepository construccionesRepository)
        {
            _clientesRepository = clientesRepository;
            _construccionesRepository = construccionesRepository;
        }

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
        #endregion

        
    }
}
