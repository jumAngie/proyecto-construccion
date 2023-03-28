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
    public class UnidadesMedidaRepository : IRepository<tbUnidadesMedida>
    {
        ConstruccionCon con = new ConstruccionCon();
        public IEnumerable<VW_tbUnidadesMedida> List()
        {
            return con.VW_tbUnidadesMedida.AsList();
        }

        public RequestStatus Insert(tbUnidadesMedida item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@unim_Descripcion", item.unim_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@user_UsuCreacion", item.user_UsuCreacion, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@status", DbType.Int32, direction: ParameterDirection.Output);

            using var db = new SqlConnection(ConstruccionCon.ConnectionString);
            db.Query<RequestStatus>(ScriptsDatabase.InsertarUnidadesMedida, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            var result = new RequestStatus { CodeStatus = parameters.Get<int>("@status") };
            return result;
        }
        // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // //
        public RequestStatus Delete(tbUnidadesMedida item)
        {
            throw new NotImplementedException();
        }

        public tbUnidadesMedida Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Inserta(tbUnidadesMedida item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbUnidadesMedida> Lista()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbUnidadesMedida item, int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tbUnidadesMedida> IRepository<tbUnidadesMedida>.List()
        {
            throw new NotImplementedException();
        }
    }
}
