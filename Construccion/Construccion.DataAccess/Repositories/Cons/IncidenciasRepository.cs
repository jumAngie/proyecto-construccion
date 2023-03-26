using Construccion.Entities.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construccion.DataAccess.Repositories.Cons
{
    public class IncidenciasRepository : IRepository<tbIncidencia>
    {
        ConstruccionCon con = new ConstruccionCon();
        public IEnumerable<VW_tbIncidencia> List()
        {
            return con.VW_tbIncidencia.AsList();
        }
        // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // //
        public RequestStatus Delete(tbIncidencia item)
        {
            throw new NotImplementedException();
        }

        public tbIncidencia Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbIncidencia item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbIncidencia> List()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbIncidencia item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
