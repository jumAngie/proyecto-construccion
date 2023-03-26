using Construccion.Entities.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construccion.DataAccess.Repositories.Cons
{
    public class ClientesRepository : IRepository<tbClientes>
    {
        ConstruccionCon con = new ConstruccionCon();
        public IEnumerable<VW_tbClientes> List()
        {
            return con.VW_tbClientes.AsList();
        }


        //   ///   ///// ///  //// /////////////////////////////////////////////////////////////////////////77
        public RequestStatus Delete(tbClientes item)
        {
            throw new NotImplementedException();
        }

        public tbClientes Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbClientes item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbClientes> List()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbClientes item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
