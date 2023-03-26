using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Construccion.Entities.Entities;
using Dapper;

namespace Construccion.DataAccess.Repositories.Acce
{
    public class RolesPorPantallaRepository : IRepository<tbPantallasRoles>
    {
        ConstruccionCon con = new ConstruccionCon();
        public IEnumerable<WV_tbPantallasRoles> List()
        {
            return con.WV_tbPantallasRoles.AsList();
        }



        //////////////////////////////////////////////////
        public RequestStatus Delete(tbPantallasRoles item)
        {
            throw new NotImplementedException();
        }

        public tbPantallasRoles Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbPantallasRoles item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbPantallasRoles> Lista()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbPantallasRoles item, int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tbPantallasRoles> IRepository<tbPantallasRoles>.List()
        {
            throw new NotImplementedException();
        }
    }
}
