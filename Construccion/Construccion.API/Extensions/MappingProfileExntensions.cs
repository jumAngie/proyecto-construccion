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

            #region Construcciones
            CreateMap<ConstruccionesViewModel, VW_tbConstrucciones>().ReverseMap();
            CreateMap<tbConstrucciones, ConstruccionesViewModel>().ReverseMap();
            #endregion

            #region Rol Pantallas
            CreateMap<PantallasViewModel, WV_tbPantallas>().ReverseMap();
            CreateMap<tbPantallas, PantallasViewModel>().ReverseMap();
            CreateMap<PantallasRolesViewModel, tbPantallasRoles>().ReverseMap();
            #endregion

            #region EmpleadosPorConstrucciones
            CreateMap<EmpleadosPorConstruccionViewModel, VW_tbEmpleadosPorConstruccion>().ReverseMap();
            CreateMap<tbEmpleadosPorConstruccion, EmpleadosPorConstruccionViewModel>().ReverseMap();
            #endregion

            #region Insumos e InsumosPorConstruccion
            CreateMap<InsumosViewModel, VW_tbInsumos>().ReverseMap();
            CreateMap<tbInsumos, InsumosViewModel>().ReverseMap();

            CreateMap<InsumosPorConstruccionViewModel, VW_tbInsumosConstruccion>().ReverseMap();
            CreateMap<tbInsumosConstruccion, InsumosPorConstruccionViewModel>().ReverseMap();
            #endregion

            #region Municipios
            CreateMap<tbMunicipios, MunicipiosViewModel>().ReverseMap();
            #endregion
        }
    }
}
