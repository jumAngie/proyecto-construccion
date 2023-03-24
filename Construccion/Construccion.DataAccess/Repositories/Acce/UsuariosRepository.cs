using Construccion.Entities.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construccion.DataAccess.Repositories.Acce
{
    public class UsuariosRepository : IRepository<tbUsuarios>
    {
        ConstruccionCon con = new ConstruccionCon();
        public RequestStatus Delete(tbUsuarios item)
        {
            throw new NotImplementedException();
        }

        public tbUsuarios Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbUsuarios item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WV_tbUsuarios> List()
        {
            return con.WV_tbUsuarios.AsList();
        }

        public RequestStatus Update(tbUsuarios item, int id)
        {
            throw new NotImplementedException();
        }



        //***************************************************************************************************************************************
        IEnumerable<tbUsuarios> IRepository<tbUsuarios>.List()
        {
            throw new NotImplementedException();
        }
    }
}
