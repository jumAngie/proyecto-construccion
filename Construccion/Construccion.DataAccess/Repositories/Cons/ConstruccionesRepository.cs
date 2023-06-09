﻿using Construccion.Entities.Entities;
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
    public class ConstruccionesRepository : IRepository<tbConstrucciones>
    {

        ConstruccionCon con = new ConstruccionCon();
        public IEnumerable<VW_tbConstrucciones> List()
        {
            return con.VW_tbConstrucciones.AsList();
        }

        public IEnumerable<tbConstrucciones> ListConstruccionesPorId(tbConstrucciones item)
        {   
            using var db = new SqlConnection(ConstruccionCon.ConnectionString);
            var parametro = new DynamicParameters();
            parametro.Add("@cons_Id", item.cons_Id, DbType.String, ParameterDirection.Input);
            return db.Query<tbConstrucciones>(ScriptsDatabase.ListarConstruccion, parametro, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<tbConstrucciones> InsertarConstruccion(tbConstrucciones item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@cons_Proyecto", item.cons_Proyecto, DbType.String, ParameterDirection.Input);
            parameters.Add("@cons_ProyectoDescripcion", item.cons_ProyectoDescripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@muni_Id", item.muni_Id, DbType.String, ParameterDirection.Input);
            parameters.Add("@cons_Direccion", item.cons_Direccion, DbType.String, ParameterDirection.Input);
            parameters.Add("@cons_FechaInicio", item.cons_FechaInicio, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@cons_FechaFin", item.cons_FechaFin, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@user_UsuCreacion", item.user_UsuCreacion, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@status", DbType.Int32, direction: ParameterDirection.Output);
            using var db = new SqlConnection(ConstruccionCon.ConnectionString);
            var result  = db.Query<tbConstrucciones>(ScriptsDatabase.InsertarConstrucciones, parameters, commandType: CommandType.StoredProcedure);
            return result;
        }

        public RequestStatus EliminiarConstruccion(tbConstrucciones item)
        {
            using var db = new SqlConnection(ConstruccionCon.ConnectionString);
            var parametro = new DynamicParameters();
            parametro.Add("@cons_Id", item.cons_Id, DbType.String, ParameterDirection.Input);
            parametro.Add("@status", DbType.Int32, direction: ParameterDirection.Output);
            db.Query<RequestStatus>(ScriptsDatabase.EliminarConstruccion, parametro, commandType: CommandType.StoredProcedure).FirstOrDefault();
            var result = new RequestStatus { CodeStatus = parametro.Get<int>("@status") };
            return result;
        }

        //public RequestStatus Insert(tbConstrucciones item)
        //{
        //    var parameters = new DynamicParameters();
        //    parameters.Add("@clie_Identificacion", item.clie_Identificacion, DbType.String, ParameterDirection.Input);
        //    parameters.Add("@clie_Nombre", item.clie_Nombre, DbType.String, ParameterDirection.Input);
        //    parameters.Add("@muni_Id", item.muni_Id, DbType.String, ParameterDirection.Input);
        //    parameters.Add("@clie_DireccionExacta", item.clie_DireccionExacta, DbType.String, ParameterDirection.Input);
        //    parameters.Add("@clie_Telefono", item.clie_Telefono, DbType.String, ParameterDirection.Input);
        //    parameters.Add("@clie_CorreoElectronico", item.clie_CorreoElectronico, DbType.String, ParameterDirection.Input);
        //    parameters.Add("@user_IdCreacion", item.user_IdCreacion, DbType.Int32, ParameterDirection.Input);
        //    parameters.Add("@status", DbType.Int32, direction: ParameterDirection.Output);

        //    using var db = new SqlConnection(ConstruccionCon.ConnectionString);
        //    db.Query<RequestStatus>(ScriptsDatabase.InsertarConstrucciones, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        //    var result = new RequestStatus { CodeStatus = parameters.Get<int>("@status") };
        //    return result;
        //}

        // // // // // // // // // // // // // // // // // // // // // /// // // // // // // // // // // // // //
        public RequestStatus Delete(tbConstrucciones item)
        {
            throw new NotImplementedException();
        }

        public tbConstrucciones Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbConstrucciones item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbConstrucciones> Lista()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbConstrucciones item, int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tbConstrucciones> IRepository<tbConstrucciones>.List()
        {
            throw new NotImplementedException();
        }
    }
}
