using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Construccion.Entities.Entities;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Construccion.DataAccess.Repositories.Acce
{
    public class RolesPorPantallaRepository : IRepository<tbPantallasRoles>
    {
        ConstruccionCon con = new ConstruccionCon();
        public IEnumerable<WV_tbPantallasRoles> List()
        {
            return con.WV_tbPantallasRoles.AsList();
        }

        public IEnumerable<tbPantallas> MenuPantallas(tbPantallas item)
        {
            using var db = new SqlConnection(ConstruccionCon.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@rol_Id", item.role_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@EsAdmin", item.esAdmin, DbType.Boolean, ParameterDirection.Input);

            return db.Query<tbPantallas>(ScriptsDatabase.Menu_PantallaPorRol, parametros, commandType: CommandType.StoredProcedure);

        }

        //////////////////////////////////////////////////
        /// <summary>
        public RequestStatus InsertPantallaRoles(tbPantallasRoles item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@role_Id", item.role_Id, DbType.String, ParameterDirection.Input);
            parameters.Add("@pant_Id", item.pant_Id, DbType.String, ParameterDirection.Input);
            parameters.Add("@user_UsuCreacion", item.user_UsuCreacion, DbType.String, ParameterDirection.Input);
            parameters.Add("@status", DbType.Int32, direction: ParameterDirection.Output);  
            using var db = new SqlConnection(ConstruccionCon.ConnectionString);
            db.Query<RequestStatus>(ScriptsDatabase.AgregarRolPantalla, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            var result = new RequestStatus { CodeStatus = parameters.Get<int>("@status") };
            return result;
        }

        public RequestStatus EliminarPantallaRoles(tbPantallasRoles item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@role_Id", item.role_Id, DbType.String, ParameterDirection.Input);
            parameters.Add("@pant_Id", item.pant_Id, DbType.String, ParameterDirection.Input);
            parameters.Add("@status", DbType.Int32, direction: ParameterDirection.Output);
            using var db = new SqlConnection(ConstruccionCon.ConnectionString);
            db.Query<RequestStatus>(ScriptsDatabase.EliminarRolPantalla, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            var result = new RequestStatus { CodeStatus = parameters.Get<int>("@status") };
            return result;
        }
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
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
