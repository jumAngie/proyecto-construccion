using Construccion.Entities.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construccion.DataAccess.Repositories.Cons
{
    public class ConstruccionesRepository : IRepository<tbConstrucciones>
    {

        ConstruccionCon con = new ConstruccionCon();
        public IEnumerable<VW_tbConstrucciones> List()
        {
            return con.VW_tbConstrucciones.AsList();
        }

        // // // // // // // // // // // // // // // // // // // // // /// // // // // // // // // // // // // //
        public RequestStatus Delete(tbConstrucciones item)
        {
            throw new NotImplementedException();
        }

        public tbConstrucciones Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbConstrucciones item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbConstrucciones> Lista()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbConstrucciones item, int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tbConstrucciones> IRepository<tbConstrucciones>.List()
        {
            throw new NotImplementedException();
        }
    }
}
