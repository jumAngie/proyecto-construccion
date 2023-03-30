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
    public class ClientesRepository : IRepository<tbClientes>
    {
        ConstruccionCon con = new ConstruccionCon();
        public IEnumerable<VW_tbClientes> List()
        {
            return con.VW_tbClientes.AsList();
        }

        public RequestStatus Insert(tbClientes item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@clie_Identificacion",    item.clie_Identificacion,       DbType.String,  ParameterDirection.Input);
            parameters.Add("@clie_Nombre",            item.clie_Nombre,               DbType.String,  ParameterDirection.Input);
            parameters.Add("@muni_Id",                item.muni_Id,                   DbType.String,  ParameterDirection.Input);
            parameters.Add("@clie_DireccionExacta",   item.clie_DireccionExacta,      DbType.String,  ParameterDirection.Input);
            parameters.Add("@clie_Telefono",          item.clie_Telefono,             DbType.String,  ParameterDirection.Input);
            parameters.Add("@clie_CorreoElectronico", item.clie_CorreoElectronico,    DbType.String,  ParameterDirection.Input);
            parameters.Add("@user_IdCreacion",        item.user_IdCreacion,           DbType.Int32,   ParameterDirection.Input);
            parameters.Add("@status", DbType.Int32, direction: ParameterDirection.Output);

            using var db = new SqlConnection(ConstruccionCon.ConnectionString);
            db.Query<RequestStatus>(ScriptsDatabase.InsertarClientes, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            var result = new RequestStatus { CodeStatus = parameters.Get<int>("@status") };
            return result;
        }
        public tbClientes Find(int? id)
        {
            using var db = new ConstruccionCon();
            var result = db.tbClientes.Find(id);

            return result;
        }

         public RequestStatus Update(tbClientes item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@clie_Id",                  item.clie_Id,                       DbType.Int32,  ParameterDirection.Input);
            parameters.Add("@clie_Identificacion",      item.clie_Identificacion,           DbType.String, ParameterDirection.Input);
            parameters.Add("@clie_Nombre",              item.clie_Nombre,                   DbType.String, ParameterDirection.Input);
            parameters.Add("@muni_Id",                  item.muni_Id,                       DbType.String, ParameterDirection.Input);
            parameters.Add("@clie_DireccionExacta",     item.clie_DireccionExacta,          DbType.String, ParameterDirection.Input);
            parameters.Add("@clie_Telefono",            item.clie_Telefono,                 DbType.String, ParameterDirection.Input);
            parameters.Add("@clie_Telefono",            item.clie_Telefono,                 DbType.String, ParameterDirection.Input);
            parameters.Add("@clie_CorreoElectronico",   item.clie_CorreoElectronico,        DbType.String, ParameterDirection.Input);
            parameters.Add("@user_IdModificacion",      item.user_IdModificacion,           DbType.Int32, ParameterDirection.Input);
            parameters.Add("@status", DbType.Int32, direction: ParameterDirection.Output);

            using var db = new SqlConnection(ConstruccionCon.ConnectionString);
            db.Query<RequestStatus>(ScriptsDatabase.UpdateClientes, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            var result = new RequestStatus { CodeStatus = parameters.Get<int>("@status") };
            return result;
        }



        //   ///   ///// ///  //// /////////////////////////////////////////////////////////////////////////77
        public RequestStatus Delete(tbClientes item)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Inserta(tbClientes item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbClientes> Lista()
        {
            throw new NotImplementedException();
        }

        IEnumerable<tbClientes> IRepository<tbClientes>.List()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbClientes item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
