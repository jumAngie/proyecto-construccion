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

        public IEnumerable<WV_tbUsuarios> List()
        {
            return con.WV_tbUsuarios.AsList();
        }

        public IEnumerable<tbUsuarios> ListarUsuarioEmpleados()
        {
            using var db = new SqlConnection(ConstruccionCon.ConnectionString);
            var parametro = new DynamicParameters();
            parametro.Add("@empl_Id", 0, DbType.Int32, ParameterDirection.Input);
            return db.Query<tbUsuarios>(ScriptsDatabase.EmpleadoNoTieneUser, parametro, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<tbUsuarios> CargarDatosUsuario(tbUsuarios item)
        {
            using var db = new SqlConnection(ConstruccionCon.ConnectionString);
            var parametro = new DynamicParameters();
            parametro.Add("@user_Id", item.user_Id, DbType.Int32, ParameterDirection.Input);
            return db.Query<tbUsuarios>(ScriptsDatabase.CargarDatosUsuarios, parametro, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<tbUsuarios> EvaluarUsuarios(tbUsuarios item)
        {
            using var db = new SqlConnection(ConstruccionCon.ConnectionString);
            var parametro = new DynamicParameters();
            parametro.Add("@user_NombreUsuario", item.user_NombreUsuario, DbType.String, ParameterDirection.Input);
            return db.Query<tbUsuarios>(ScriptsDatabase.ValidarUsuario, parametro, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<tbUsuarios> ValidarUsuarioRestablecer(tbUsuarios item)
        {
            using var db = new SqlConnection(ConstruccionCon.ConnectionString);
            var parametro = new DynamicParameters();
            parametro.Add("@user_NombreUsuario", item.user_NombreUsuario, DbType.String, ParameterDirection.Input);
            parametro.Add("@user_Contrasena", item.user_Contrasena, DbType.String, ParameterDirection.Input);
            return db.Query<tbUsuarios>(ScriptsDatabase.ValidarRestablecerPassword, parametro, commandType: CommandType.StoredProcedure);
        }

        public RequestStatus UpdatePassword(tbUsuarios item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@user_NombreUsuario", item.user_NombreUsuario, DbType.String, ParameterDirection.Input);
            parameters.Add("@user_Contrasena", item.user_Contrasena, DbType.String, ParameterDirection.Input);
            parameters.Add("@status", DbType.Int32, direction: ParameterDirection.Output);
            using var db = new SqlConnection(ConstruccionCon.ConnectionString);
            db.Query<RequestStatus>(ScriptsDatabase.CambiarPassword, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            var result = new RequestStatus { CodeStatus = parameters.Get<int>("@status") };
            return result;
        }

        public RequestStatus InsertarUsuario(tbUsuarios item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@user_NombreUsuario", item.user_NombreUsuario, DbType.String, ParameterDirection.Input);
            parameters.Add("@user_Contrasena", item.user_Contrasena, DbType.String, ParameterDirection.Input);
            parameters.Add("@user_EsAdmin",item.user_EsAdmin, DbType.Boolean, direction: ParameterDirection.Input);
            parameters.Add("@role_Id", item.role_Id, DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@empe_Id", item.empe_Id, DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@status", DbType.Int32, direction: ParameterDirection.Output);
            using var db = new SqlConnection(ConstruccionCon.ConnectionString);
            db.Query<RequestStatus>(ScriptsDatabase.InsertarUsuario, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            var result = new RequestStatus { CodeStatus = parameters.Get<int>("@status") };
            return result;
        }

        public RequestStatus UpdateUsuario(tbUsuarios item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@user_Id", item.user_Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@user_NombreUsuario", item.user_NombreUsuario, DbType.String, ParameterDirection.Input);
            parameters.Add("@user_EsAdmin", item.user_EsAdmin, DbType.Boolean, direction: ParameterDirection.Input);
            parameters.Add("@role_Id", item.role_Id, DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@empe_Id", item.empe_Id, DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@user_UsuModificacion", item.user_UsuModificacion, DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@status", DbType.Int32, direction: ParameterDirection.Output);
            using var db = new SqlConnection(ConstruccionCon.ConnectionString);
            db.Query<RequestStatus>(ScriptsDatabase.EditarUsuarios, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            var result = new RequestStatus { CodeStatus = parameters.Get<int>("@status") };
            return result;
        }

        public RequestStatus ExisteUsuario(tbUsuarios item)
        {
            using var db = new SqlConnection(ConstruccionCon.ConnectionString);
            var parametro = new DynamicParameters();
            parametro.Add("@user_NombreUsuario", item.user_NombreUsuario, DbType.String, ParameterDirection.Input);
            parametro.Add("@status", DbType.Int32, direction: ParameterDirection.Output);
            db.Query<RequestStatus>(ScriptsDatabase.ExisteUsuario, parametro, commandType: CommandType.StoredProcedure).FirstOrDefault();
            var result = new RequestStatus { CodeStatus = parametro.Get<int>("@status") };
            return result;
        }

        public RequestStatus EliminarUsuario(tbUsuarios item)
        {
            using var db = new SqlConnection(ConstruccionCon.ConnectionString);
            var parametro = new DynamicParameters();
            parametro.Add("@user_Id", item.user_Id, DbType.String, ParameterDirection.Input);
            parametro.Add("@status", DbType.Int32, direction: ParameterDirection.Output);
            db.Query<RequestStatus>(ScriptsDatabase.EliminarUsuario, parametro, commandType: CommandType.StoredProcedure).FirstOrDefault();
            var result = new RequestStatus { CodeStatus = parametro.Get<int>("@status") };
            return result;
        }

        public IEnumerable<tbUsuarios> IniciarSesion(tbUsuarios item)
        {
            using var db = new SqlConnection(ConstruccionCon.ConnectionString);
            var parametro = new DynamicParameters();
            parametro.Add("@user_NombreUsuario", item.user_NombreUsuario, DbType.String, ParameterDirection.Input);
            parametro.Add("@user_Contrasena", item.user_Contrasena, DbType.String, ParameterDirection.Input);

            return db.Query<tbUsuarios>(ScriptsDatabase.ValidarLogin, parametro, commandType: CommandType.StoredProcedure);
        }

        public RequestStatus RestablecerPassword(tbUsuarios item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@user_NombreUsuario", item.user_NombreUsuario, DbType.String, ParameterDirection.Input);
            parameters.Add("@NewPassword", item.user_Contrasena, DbType.String, ParameterDirection.Input);
            parameters.Add("@status", DbType.Int32, direction: ParameterDirection.Output);
            using var db = new SqlConnection(ConstruccionCon.ConnectionString);
            db.Query<RequestStatus>(ScriptsDatabase.RestablecerPassword, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            var result = new RequestStatus { CodeStatus = parameters.Get<int>("@status") };
            return result;
        }
        //***************************************************************************************************************************************
        IEnumerable<tbUsuarios> IRepository<tbUsuarios>.List()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Delete(tbUsuarios item)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbUsuarios item, int id)
        {
            throw new NotImplementedException();
        }

        public tbUsuarios Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbUsuarios item)
        {
            throw new NotImplementedException();
        }
    }
}
