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
    public class InsumosConstruccionController : Controller
    {
        private readonly ConstruccionServices _construccionServices;
        private readonly IMapper _mapper;
        public ConstruccionCon db = new ConstruccionCon();
        public InsumosConstruccionController(ConstruccionServices construccionServices, IMapper mapper)
        {
            _construccionServices = construccionServices;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _construccionServices.ListInsumosConstruccion();
            return Ok(list);
        }

        [HttpPost("InsumosPorIdConstruccion")]
        public IActionResult InsumosPorIdConstruccion(InsumosPorConstruccionViewModel insumosPorConstruccionViewModel)
        {
            var item = _mapper.Map<tbInsumosConstruccion>(insumosPorConstruccionViewModel);
            var Insumos = _construccionServices.ListarInsumosPorIdConstruccion(item);
            return Ok(Insumos);
        }
    }
}
