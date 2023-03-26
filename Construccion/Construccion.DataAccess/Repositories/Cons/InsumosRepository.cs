using Construccion.Entities.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construccion.DataAccess.Repositories.Cons
{
    public class InsumosRepository : IRepository<tbInsumos>
    {
        ConstruccionCon con = new ConstruccionCon();
        public IEnumerable<VW_tbInsumos> List()
        {
            return con.VW_tbInsumos.AsList();
        }
        // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // //
        public RequestStatus Delete(tbInsumos item)
        {
            throw new NotImplementedException();
        }

        public tbInsumos Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbInsumos item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbInsumos> Lista()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbInsumos item, int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tbInsumos> IRepository<tbInsumos>.List()
        {
            throw new NotImplementedException();
        }
    }
}
