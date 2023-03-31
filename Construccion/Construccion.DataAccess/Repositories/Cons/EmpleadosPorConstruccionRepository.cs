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
    public class EmpleadosPorConstruccionRepository : IRepository<tbEmpleados>
    {

        ConstruccionCon con = new ConstruccionCon();
        public IEnumerable<VW_tbEmpleadosPorConstruccion> List()
        {
            return con.VW_tbEmpleadosPorConstruccion.AsList();
        }
        // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // //
        public IEnumerable<tbEmpleadosPorConstruccion> ListarEmpleadosPorConstruccion(tbEmpleadosPorConstruccion tbEmpleadosPorConstruccion)
        {
            using var db = new SqlConnection(ConstruccionCon.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@cons_Id", tbEmpleadosPorConstruccion.cons_Id, DbType.Int32, ParameterDirection.Input);
            return db.Query<tbEmpleadosPorConstruccion>(ScriptsDatabase.EmpleadosPorConstruccionListar, parametros, commandType: CommandType.StoredProcedure);

        }

        public IEnumerable<tbEmpleadosPorConstruccion> InsertarEmpleadoPorConstruccion(tbEmpleadosPorConstruccion item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@cons_Id", item.cons_Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@empl_Id", item.empl_Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@user_UsuCreacion", item.user_UsuCreacion, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@status", DbType.Int32, direction: ParameterDirection.Output);
            using var db = new SqlConnection(ConstruccionCon.ConnectionString);
            var result = db.Query<tbEmpleadosPorConstruccion>(ScriptsDatabase.InsertarEmpleadoPorConstruccion, parameters, commandType: CommandType.StoredProcedure);
            return result;
        }
        public RequestStatus EliminarEmpleadoPorConstruccion(tbEmpleadosPorConstruccion item)
        {
            using var db = new SqlConnection(ConstruccionCon.ConnectionString);
            var parametro = new DynamicParameters();
            parametro.Add("@cons_Id", item.cons_Id, DbType.String, ParameterDirection.Input);
            parametro.Add("@empl_Id", item.empl_Id, DbType.String, ParameterDirection.Input);
            parametro.Add("@status", DbType.Int32, direction: ParameterDirection.Output);
            db.Query<RequestStatus>(ScriptsDatabase.EliminarEmpleadoPorConstruccion, parametro, commandType: CommandType.StoredProcedure).FirstOrDefault();
            var result = new RequestStatus { CodeStatus = parametro.Get<int>("@status") };
            return result;
        }

        public RequestStatus Delete(tbEmpleados item)
        {
            throw new NotImplementedException();
        }

        public tbEmpleados Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbEmpleados item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbEmpleados> Lista()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbEmpleados item, int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tbEmpleados> IRepository<tbEmpleados>.List()
        {
            throw new NotImplementedException();
        }
    }
}
