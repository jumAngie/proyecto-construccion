using Construccion.Entities.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construccion.DataAccess.Repositories.Cons
{
    public class InsumosConstruccionRepository : IRepository<tbInsumosConstruccion>
    {
        ConstruccionCon con = new ConstruccionCon();
        public IEnumerable<VW_tbInsumosConstruccion> List()
        {
            return con.VW_tbInsumosConstruccion.AsList();
        }
        // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // //
        public RequestStatus Delete(tbInsumosConstruccion item)
        {
            throw new NotImplementedException();
        }

        public tbInsumosConstruccion Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbInsumosConstruccion item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbInsumosConstruccion> Lista()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbInsumosConstruccion item, int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tbInsumosConstruccion> IRepository<tbInsumosConstruccion>.List()
        {
            throw new NotImplementedException();
        }
    }
}
