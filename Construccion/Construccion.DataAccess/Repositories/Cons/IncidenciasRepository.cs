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
    public class IncidenciasRepository : IRepository<tbIncidencia>
    {
        ConstruccionCon con = new ConstruccionCon();
        public IEnumerable<VW_tbIncidencia> List()
        {
            return con.VW_tbIncidencia.AsList();
        }

        public RequestStatus Insert(tbIncidencia item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@cons_Id",              item.cons_Id,          DbType.Int32, ParameterDirection.Input);
            parameters.Add("@inci_Descripcion",     item.inci_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@user_UsuCreacion",     item.user_UsuCreacion, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@status",               DbType.Int32, direction: ParameterDirection.Output);

            using var db = new SqlConnection(ConstruccionCon.ConnectionString);
            db.Query<RequestStatus>(ScriptsDatabase.InsertarIncidencias, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            var result = new RequestStatus { CodeStatus = parameters.Get<int>("@status") };
            return result;
        }

        public RequestStatus Update(tbIncidencia item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@inci_Id",                item.inci_Id,                 DbType.Int32, ParameterDirection.Input);            parameters.Add("@inci_Descripcion",       item.inci_Descripcion,        DbType.String, ParameterDirection.Input);
            parameters.Add("@user_UsuModificacion",   item.user_UsuModificacion,    DbType.Int32, ParameterDirection.Input);
            parameters.Add("@status", DbType.Int32, direction: ParameterDirection.Output);

            using var db = new SqlConnection(ConstruccionCon.ConnectionString);
            db.Query<RequestStatus>(ScriptsDatabase.UpdateIncidencias, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            var result = new RequestStatus { CodeStatus = parameters.Get<int>("@status") };
            return result;
        }

        public RequestStatus Delete(tbIncidencia item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@inci_Id", item.inci_Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@user_UsuModificacion", item.user_UsuModificacion, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@status", DbType.Int32, direction: ParameterDirection.Output);

            using var db = new SqlConnection(ConstruccionCon.ConnectionString);
            db.Query<RequestStatus>(ScriptsDatabase.DeleteIncidencias, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            var result = new RequestStatus { CodeStatus = parameters.Get<int>("@status") };
            return result;
        }

        // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // //


        public tbIncidencia Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insertar(tbIncidencia item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbIncidencia> Lista()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbIncidencia item, int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tbIncidencia> IRepository<tbIncidencia>.List()
        {
            throw new NotImplementedException();
        }
    }
}
