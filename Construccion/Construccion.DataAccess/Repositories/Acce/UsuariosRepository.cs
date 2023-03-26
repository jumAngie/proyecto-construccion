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
    public class UsuariosRepository : IRepository<tbUsuarios>
    {
        ConstruccionCon con = new ConstruccionCon();
        public RequestStatus Delete(tbUsuarios item)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<tbUsuarios> IniciarSesion(tbUsuarios item)
        {
            using var db = new SqlConnection(ConstruccionCon.ConnectionString);
            var parametro = new DynamicParameters();
            parametro.Add("@user_NombreUsuario", item.user_NombreUsuario, DbType.String, ParameterDirection.Input);
            parametro.Add("@user_Contrasena", item.user_Contrasena, DbType.String, ParameterDirection.Input);

            return db.Query<tbUsuarios>(ScriptsDatabase.ValidarLogin, parametro, commandType: CommandType.StoredProcedure);
        }
        public tbUsuarios Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbUsuarios item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WV_tbUsuarios> List()
        {
            return con.WV_tbUsuarios.AsList();
        }

        public RequestStatus Update(tbUsuarios item, int id)
        {
            throw new NotImplementedException();
        }



        //***************************************************************************************************************************************
        IEnumerable<tbUsuarios> IRepository<tbUsuarios>.List()
        {
            throw new NotImplementedException();
        }
    }
}
