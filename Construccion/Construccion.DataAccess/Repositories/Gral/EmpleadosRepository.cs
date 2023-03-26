using Construccion.Entities.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construccion.DataAccess.Repositories.Gral
{
    public class EmpleadosRepository : IRepository<tbEmpleados>
    {
        ConstruccionCon con = new ConstruccionCon();
        public IEnumerable<VW_tbEmpleados> List()
        {
            return con.VW_tbEmpleados.AsList();
        }
        // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // //
        public RequestStatus Delete(tbEmpleados item)
        {
            throw new NotImplementedException();
        }

        public tbEmpleados Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbEmpleados item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbEmpleados> List()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbEmpleados item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
