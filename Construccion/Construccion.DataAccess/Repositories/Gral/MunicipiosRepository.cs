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
    public class MunicipiosRepository : IRepository<tbMunicipios>
    {
        public RequestStatus Delete(tbMunicipios item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbMunicipios> ListarMunicipiosPorIdDepartamento(tbMunicipios tbMunicipios)
        {
            using var db = new SqlConnection(ConstruccionCon.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@depa_Id", tbMunicipios.depa_Id, DbType.String, ParameterDirection.Input);
            return db.Query<tbMunicipios>(ScriptsDatabase.ListarMunicipiosPorIdDepartamento, parametros, commandType: CommandType.StoredProcedure);

        }

        public tbMunicipios Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbMunicipios item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbMunicipios> List()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbMunicipios item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
