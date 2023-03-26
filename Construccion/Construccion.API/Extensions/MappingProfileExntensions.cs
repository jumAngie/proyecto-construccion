using AutoMapper;
using Construccion.API.Models;
using Construccion.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Construccion.API.Extensions
{
    public class MappingProfileExntensions : Profile
    {
        public MappingProfileExntensions()
       {
            #region Roles
            CreateMap<RolesViewModel, WV_tbRoles>().ReverseMap();
            CreateMap<tbRoles, RolesViewModel>().ReverseMap();
            #endregion

            #region Usuarios
            CreateMap<UsuariosViewModel, WV_tbUsuarios>().ReverseMap();
            CreateMap<tbUsuarios, UsuariosViewModel>().ReverseMap();
            #endregion

            #region Clientes
            CreateMap<ClientesViewModel, VW_tbClientes>().ReverseMap();
            CreateMap<tbClientes, ClientesViewModel>().ReverseMap();
            #endregion

            #region Empleados
            CreateMap<EmpleadosViewModel, VW_tbEmpleados>().ReverseMap();
            CreateMap<tbEmpleados, EmpleadosViewModel>().ReverseMap();
            #endregion

        }
    }
}
