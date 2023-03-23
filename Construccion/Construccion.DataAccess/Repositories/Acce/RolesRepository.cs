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

        public int Delete(tbRoles item)
        {
            throw new NotImplementedException();
        }

        public tbRoles Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbRoles item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@role_Nombre", item.role_Nombre, DbType.String, ParameterDirection.Input);

            using var db = new SqlConnection(ConstruccionCon.ConnectionString);

           
            var result = db.QueryFirst<RequestStatus>(ScriptsDatabase.InsertarRoles, parameters, commandType: CommandType.StoredProcedure);
            return result;
        }


        public IEnumerable<WW_tbRoles> List()
        {
            return con.WW_tbRoles.AsList();
        }

        public int Update(tbRoles item)
        {
            throw new NotImplementedException();
        }

        RequestStatus IRepository<tbRoles>.Delete(tbRoles item)
        {
            throw new NotImplementedException();
        }

        RequestStatus IRepository<tbRoles>.Insert(tbRoles item)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tbRoles> IRepository<tbRoles>.List()
        {
            throw new NotImplementedException();
        }

        RequestStatus IRepository<tbRoles>.Update(tbRoles item)
        {
            throw new NotImplementedException();
        }
    }
}
