using Construccion.Entities.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

        //public RequestStatus Insert(tbConstrucciones item)
        //{
        //    var parameters = new DynamicParameters();
        //    parameters.Add("@clie_Identificacion", item.clie_Identificacion, DbType.String, ParameterDirection.Input);
        //    parameters.Add("@clie_Nombre", item.clie_Nombre, DbType.String, ParameterDirection.Input);
        //    parameters.Add("@muni_Id", item.muni_Id, DbType.String, ParameterDirection.Input);
        //    parameters.Add("@clie_DireccionExacta", item.clie_DireccionExacta, DbType.String, ParameterDirection.Input);
        //    parameters.Add("@clie_Telefono", item.clie_Telefono, DbType.String, ParameterDirection.Input);
        //    parameters.Add("@clie_CorreoElectronico", item.clie_CorreoElectronico, DbType.String, ParameterDirection.Input);
        //    parameters.Add("@user_IdCreacion", item.user_IdCreacion, DbType.Int32, ParameterDirection.Input);
        //    parameters.Add("@status", DbType.Int32, direction: ParameterDirection.Output);

        //    using var db = new SqlConnection(ConstruccionCon.ConnectionString);
        //    db.Query<RequestStatus>(ScriptsDatabase.InsertarConstrucciones, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        //    var result = new RequestStatus { CodeStatus = parameters.Get<int>("@status") };
        //    return result;
        //}

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
