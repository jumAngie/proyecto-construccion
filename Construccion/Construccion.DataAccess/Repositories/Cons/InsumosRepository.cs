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
    public class InsumosRepository : IRepository<tbInsumos>
    {
        ConstruccionCon con = new ConstruccionCon();
        public IEnumerable<VW_tbInsumos> List()
        {
            return con.VW_tbInsumos.AsList();
        }

        public RequestStatus Insert(tbInsumos item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@insm_Descripcion",             item.insm_Descripcion, DbType.String,   ParameterDirection.Input);
            parameters.Add("@unim_Id",                      item.unim_Id,          DbType.Int32,    ParameterDirection.Input);
            parameters.Add("@user_UsuCreacion",             item.user_UsuCreacion, DbType.Int32,    ParameterDirection.Input);
            parameters.Add("@status",                                              DbType.Int32,    direction: ParameterDirection.Output);

            using var db = new SqlConnection(ConstruccionCon.ConnectionString);
            db.Query<RequestStatus>(ScriptsDatabase.InsertarInsumos, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            var result = new RequestStatus { CodeStatus = parameters.Get<int>("@status") };
            return result;
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

        public RequestStatus Inserta(tbInsumos item)
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
