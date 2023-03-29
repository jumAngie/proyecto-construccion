using Construccion.Entities.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construccion.DataAccess.Repositories.Gral
{
    public class EmpleadosRepository : IRepository<tbEmpleados>
    {
        ConstruccionCon con = new ConstruccionCon();
        public IEnumerable<VW_tbEmpleados> List()
        {
            return con.VW_tbEmpleados.AsList();
        }

        public IEnumerable<tbEmpleados> ListarEmpleadosSinCons()
        {
            using var db = new SqlConnection(ConstruccionCon.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@empl_Id", null, DbType.Int32, ParameterDirection.Input);
            return db.Query<tbEmpleados>(ScriptsDatabase.DdlEmpleados, parametros, commandType: CommandType.StoredProcedure);

        }

        public RequestStatus Insert(tbEmpleados item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@empl_DNI",             item.empl_DNI,             DbType.String, ParameterDirection.Input);
            parameters.Add("@empl_Nombre",          item.empl_Nombre,          DbType.String, ParameterDirection.Input);
            parameters.Add("@empl_Apellidos",       item.empl_Apellidos,       DbType.String, ParameterDirection.Input);
            parameters.Add("@empl_Sexo",            item.empl_Sexo,            DbType.String, ParameterDirection.Input);
            parameters.Add("@esta_ID",              item.esta_ID,              DbType.String, ParameterDirection.Input);
            parameters.Add("@muni_Id",              item.muni_Id,              DbType.String, ParameterDirection.Input);
            parameters.Add("@carg_Id",              item.carg_Id,              DbType.Int32,  ParameterDirection.Input);
            parameters.Add("@empl_DireccionExacta", item.empl_DireccionExacta, DbType.String, ParameterDirection.Input);
            parameters.Add("@empl_FechaNacimiento", item.empl_FechaNacimiento, DbType.Date,   ParameterDirection.Input);
            parameters.Add("@empl_Telefono",        item.empl_Telefono,        DbType.String, ParameterDirection.Input);
            parameters.Add("@empl_CorreoEletronico",item.empl_CorreoEletronico,DbType.String, ParameterDirection.Input);
            parameters.Add("@user_IdCreacion",      item.user_IdCreacion,      DbType.Int32,  ParameterDirection.Input);
            parameters.Add("@status", DbType.Int32, direction: ParameterDirection.Output);

            using var db = new SqlConnection(ConstruccionCon.ConnectionString);
            db.Query<RequestStatus>(ScriptsDatabase.InsertarEmpleados, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            var result = new RequestStatus { CodeStatus = parameters.Get<int>("@status") };
            return result;
        }


        // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // //
        public RequestStatus Delete(tbEmpleados item)
        {
            throw new NotImplementedException();
        }

        public tbEmpleados Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Inserta(tbEmpleados item)
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
