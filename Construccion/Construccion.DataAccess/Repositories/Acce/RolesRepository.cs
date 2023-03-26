using Construccion.DataAccess;
using Construccion.Entities.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construccion.DataAccess.Repositories.Acce
{
    public class RolesRepository : IRepository<tbRoles>
    {
        ConstruccionCon con = new ConstruccionCon();

        

        public tbRoles Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(int id,tbRoles item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@role_Id", id, DbType.String, ParameterDirection.Input);
            parameters.Add("@role_Nombre", item.role_Nombre, DbType.String, ParameterDirection.Input);
            parameters.Add("@status", DbType.Int32, direction: ParameterDirection.Output);
            using var db = new SqlConnection(ConstruccionCon.ConnectionString);
            db.Query<RequestStatus>(ScriptsDatabase.UpdateRoles, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            var result = new RequestStatus { CodeStatus = parameters.Get<int>("@status") };
            return result;
        }


        public RequestStatus Insert(tbRoles item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@role_Nombre", item.role_Nombre, DbType.String, ParameterDirection.Input);
            parameters.Add("@status", DbType.Int32, direction: ParameterDirection.Output);  
            using var db = new SqlConnection(ConstruccionCon.ConnectionString);
            db.Query<RequestStatus>(ScriptsDatabase.InsertarRoles, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            var result = new RequestStatus { CodeStatus = parameters.Get<int>("@status") };
            return result;
        }

            
        public IEnumerable<WV_tbRoles> List()
        {
            return con.WV_tbRoles.AsList();
        }

        public RequestStatus Delete(int id, int mod)
        {   
            var parameters = new DynamicParameters();
            parameters.Add("@role_Id", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@role_UsuModificacion", mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(ConstruccionCon.ConnectionString);
            return db.QueryFirst<RequestStatus>(ScriptsDatabase.DeleteRoles, parameters, commandType: CommandType.StoredProcedure);
        }

        public RequestStatus Inserts(tbRoles item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbRoles> Lists()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbRoles item, int id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Deletes(tbRoles item)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tbRoles> IRepository<tbRoles>.List()
        {
            throw new NotImplementedException();
        }

        RequestStatus IRepository<tbRoles>.Delete(tbRoles item)
        {
            throw new NotImplementedException();
        }

        public int Delete(tbRoles item)
        {
            throw new NotImplementedException();
        }
    }
}
