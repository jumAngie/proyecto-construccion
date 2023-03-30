using AutoMapper;
using Construccion.API.Models;
using Construccion.BusinessLogic.Services;
using Construccion.DataAccess;
using Construccion.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Construccion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolPantallasController : Controller
    {
        private readonly AccessService _accessService;
        private readonly IMapper _mapper;
        public ConstruccionCon db = new ConstruccionCon();


        public RolPantallasController(AccessService accessService, IMapper mapper)
        {
            _accessService = accessService;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _accessService.ListRolesPorPantalla();
            return Ok(list);
        }

        [HttpPost("PantallasPorMenu")]
        public IActionResult MenuPantallas(PantallasViewModel pantallasView)
        {
            var item = _mapper.Map<tbPantallas>(pantallasView);
            var pantallas = _accessService.MenuPantallas(item);

            return Ok(pantallas);
        }

        [HttpPost("AgregarPantallaRol")]
        public IActionResult AgregarPantallaRol(PantallasRolesViewModel pantallasRolesViewModel)
        {
            var item = _mapper.Map<tbPantallasRoles>(pantallasRolesViewModel);
            var response = _accessService.InsertarPantallaRoles(item);
            return Ok(response);
        }

        [HttpPost("EliminarPantallaRol")]
        public IActionResult EliminarPantallaRol(PantallasRolesViewModel pantallasRolesViewModel)
        {
            var item = _mapper.Map<tbPantallasRoles>(pantallasRolesViewModel);
            var response = _accessService.EliminarPantallaRoles(item);
            return Ok(response);
        }
    }
}
