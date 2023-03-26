using Construccion.Entities.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construccion.DataAccess.Repositories.Cons
{
    public class CargosRepository : IRepository<tbCargos>
    {
        ConstruccionCon con = new ConstruccionCon();
        public IEnumerable<VW_tbCargos> List()
        {
            return con.VW_tbCargos.AsList();
        }
        // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // //
        public RequestStatus Delete(tbCargos item)
        {
            throw new NotImplementedException();
        }

        public tbCargos Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbCargos item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbCargos> Lista()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbCargos item, int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tbCargos> IRepository<tbCargos>.List()
        {
            throw new NotImplementedException();
        }
    }
}
