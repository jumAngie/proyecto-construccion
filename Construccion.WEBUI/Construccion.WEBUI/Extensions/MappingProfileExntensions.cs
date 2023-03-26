using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Construccion.WEBUI.Extensions
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

        }
    }
}
