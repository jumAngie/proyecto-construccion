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

    public class CargosController : ControllerBase
    {
        private readonly ConstruccionServices _construccionServices;
        private readonly IMapper _mapper;
        public ConstruccionCon db = new ConstruccionCon();

        public CargosController(ConstruccionServices construccionServices, IMapper mapper)
        {
            _construccionServices = construccionServices;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _construccionServices.ListCargos();
            return Ok(list);
        }

        [HttpPost("Insert")]

        public IActionResult Insert(CargosViewModel cargos)
        {
            var item = _mapper.Map<tbCargos>(cargos);
            var response = _construccionServices.CreateCargos(item);
            return Ok(response);
        }

        [HttpPut("Update")]
        public IActionResult Update(CargosViewModel cargos)
        {
            var item = _mapper.Map<tbCargos>(cargos);
            var response = _construccionServices.EditarCargos(item);
            return Ok(response);
        }
    }
}
