﻿using Construccion.Entities.Entities;
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
