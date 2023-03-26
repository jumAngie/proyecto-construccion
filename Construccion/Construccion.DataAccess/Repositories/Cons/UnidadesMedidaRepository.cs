using Construccion.Entities.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construccion.DataAccess.Repositories.Cons
{
    public class UnidadesMedidaRepository : IRepository<tbUnidadesMedida>
    {
        ConstruccionCon con = new ConstruccionCon();
        public IEnumerable<VW_tbUnidadesMedida> List()
        {
            return con.VW_tbUnidadesMedida.AsList();
        }
        // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // //
        public RequestStatus Delete(tbUnidadesMedida item)
        {
            throw new NotImplementedException();
        }

        public tbUnidadesMedida Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbUnidadesMedida item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbUnidadesMedida> Lista()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbUnidadesMedida item, int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tbUnidadesMedida> IRepository<tbUnidadesMedida>.List()
        {
            throw new NotImplementedException();
        }
    }
}
