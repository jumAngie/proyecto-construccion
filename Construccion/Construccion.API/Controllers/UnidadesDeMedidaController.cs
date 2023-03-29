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

    public class UnidadesDeMedidaController : ControllerBase
    {
        private readonly ConstruccionServices _construccionServices;
        private readonly IMapper _mapper;
        public ConstruccionCon db = new ConstruccionCon();

        public UnidadesDeMedidaController(ConstruccionServices construccionServices, IMapper mapper)
        {
            _construccionServices = construccionServices;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _construccionServices.ListUnidadesMedida();
            return Ok(list);
        }

        [HttpPost("Insert")]
        public IActionResult Insert(UnidadesMedidaViewModel unidades)
        {
            var item = _mapper.Map<tbUnidadesMedida>(unidades);
            var response = _construccionServices.CreateUnidades(item);
            return Ok(response);
        }

        [HttpPut("Update")]
        public IActionResult Update(UnidadesMedidaViewModel unidades)
        {
            var item = _mapper.Map<tbUnidadesMedida>(unidades);
            var response = _construccionServices.EditarUnidades(item);
            return Ok(response);
        }

    }
}
