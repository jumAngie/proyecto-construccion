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
    public class InsumosController : ControllerBase
    {
        private readonly ConstruccionServices _construccionServices;
        private readonly IMapper _mapper;
        public ConstruccionCon db = new ConstruccionCon();

        public InsumosController(ConstruccionServices construccionServices, IMapper mapper)
        {
            _construccionServices = construccionServices;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _construccionServices.ListInsumos();
            return Ok(list);
        }

        [HttpPost("Insert")]

        public IActionResult Insert(InsumosViewModel insumos)
        {
            var item = _mapper.Map<tbInsumos>(insumos);
            var response = _construccionServices.CreateInsumos(item);
            return Ok(response);
        }

        [HttpPut("Update")]
        public IActionResult Update(InsumosViewModel insumos)
        {
            var item = _mapper.Map<tbInsumos>(insumos);
            var response = _construccionServices.EditarInsumos(item);
            return Ok(response);
        }
    }
}
