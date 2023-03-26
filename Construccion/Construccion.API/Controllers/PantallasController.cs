using AutoMapper;
using Construccion.BusinessLogic.Services;
using Construccion.DataAccess;
using Construccion.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Construccion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PantallasController : ControllerBase
    {
        private readonly AccessService _accessService;
        private readonly IMapper _mapper;
        public ConstruccionCon db = new ConstruccionCon();

        public PantallasController(AccessService accessService, IMapper mapper)
        {
            _accessService = accessService;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _accessService.ListPantallas();
            return Ok(list);
        }

        //[HttpGet("PantallasPorMenu")]
        //public IActionResult MenuPantallas(tbPantallas item)
        //{
        //    variables de sesion
        //    item.role_Id = (int)HttpContext.Session.GetInt32("role_Id");
        //    item.esAdmin = Convert.ToBoolean(HttpContext.Session.GetString("user_EsAdmin"));

        //    var pantallas = _accessService.MenuPantallas(item);

        //    return Ok(pantallas);
        //}
    }
}
