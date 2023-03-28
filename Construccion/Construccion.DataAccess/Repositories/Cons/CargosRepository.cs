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
    public class CargosRepository : IRepository<tbCargos>
    {
        ConstruccionCon con = new ConstruccionCon();
        public IEnumerable<VW_tbCargos> List()
        {
            return con.VW_tbCargos.AsList();
        }
        public RequestStatus Insert(tbCargos item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@carg_Cargo",           item.carg_Cargo, DbType.String,      ParameterDirection.Input);
            parameters.Add("@user_UsuCreacion",     item.user_UsuCreacion, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@status", DbType.Int32, direction: ParameterDirection.Output);

            using var db = new SqlConnection(ConstruccionCon.ConnectionString);
            db.Query<RequestStatus>(ScriptsDatabase.InsertarCargos, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            var result = new RequestStatus { CodeStatus = parameters.Get<int>("@status") };
            return result;
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
