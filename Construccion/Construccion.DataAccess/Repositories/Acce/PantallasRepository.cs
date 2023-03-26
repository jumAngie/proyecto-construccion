using Construccion.Entities.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construccion.DataAccess.Repositories.Acce
{
    public class PantallasRepository : IRepository<tbPantallas>
    {
        ConstruccionCon con = new ConstruccionCon();

        public IEnumerable<WV_tbPantallas> List()
        {
            return con.WV_tbPantallas.AsList();
        }








        /// /////////////////////////////////////////////
        public RequestStatus Delete(tbPantallas item)
        {
            throw new NotImplementedException();
        }

        public tbPantallas Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbPantallas item)
        {
            throw new NotImplementedException();
        }

        

        public RequestStatus Update(tbPantallas item, int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tbPantallas> IRepository<tbPantallas>.List()
        {
            throw new NotImplementedException();
        }
    }
}
