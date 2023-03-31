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
    public class InsumosConstruccionRepository : IRepository<tbInsumosConstruccion>
    {
        ConstruccionCon con = new ConstruccionCon();
        public IEnumerable<VW_tbInsumosConstruccion> List()
        {
            return con.VW_tbInsumosConstruccion.AsList();
        }
        // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // //

        public IEnumerable<tbInsumosConstruccion> InsumosPorIdConstruccion(tbInsumosConstruccion tbInsumosConstruccion)
        {
            using var db = new SqlConnection(ConstruccionCon.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@cons_Id", tbInsumosConstruccion.cons_Id, DbType.Int32, ParameterDirection.Input);
            return db.Query<tbInsumosConstruccion>(ScriptsDatabase.InsumosPorIdConstruccion, parametros, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<tbInsumosConstruccion> InsertarInsumosPorIdConstruccion(tbInsumosConstruccion item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@cons_Id", item.cons_Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@insm_Id", item.insm_Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@user_UsuCreacion", item.user_UsuCreacion, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@status", DbType.Int32, direction: ParameterDirection.Output);
            using var db = new SqlConnection(ConstruccionCon.ConnectionString);
            var result = db.Query<tbInsumosConstruccion>(ScriptsDatabase.InsertarInsumoPorConstruccion, parameters, commandType: CommandType.StoredProcedure);
            return result;
        }

        public IEnumerable<tbInsumosConstruccion> EliminarInsumoConstruccion(tbInsumosConstruccion item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@cons_Id", item.cons_Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@insm_Id", item.insm_Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@status", DbType.Int32, direction: ParameterDirection.Output);
            using var db = new SqlConnection(ConstruccionCon.ConnectionString);
            var result = db.Query<tbInsumosConstruccion>(ScriptsDatabase.EliminarInsumoPorConstruccion, parameters, commandType: CommandType.StoredProcedure);
            return result;
        }

        public RequestStatus Delete(tbInsumosConstruccion item)
        {
            throw new NotImplementedException();
        }

        public tbInsumosConstruccion Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbInsumosConstruccion item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbInsumosConstruccion> Lista()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbInsumosConstruccion item, int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tbInsumosConstruccion> IRepository<tbInsumosConstruccion>.List()
        {
            throw new NotImplementedException();
        }
    }
}
