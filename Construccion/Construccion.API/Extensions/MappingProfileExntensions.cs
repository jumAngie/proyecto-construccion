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

            CreateMap<RolesViewModel, WV_tbRoles>().ReverseMap();
            CreateMap<tbRoles, RolesViewModel>().ReverseMap();

            CreateMap<UsuariosViewModel, WV_tbUsuarios>().ReverseMap();
            CreateMap<tbUsuarios, UsuariosViewModel>().ReverseMap();


        }
    }
}
