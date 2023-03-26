using AutoMapper;
using Construccion.BusinessLogic.Services;
using Construccion.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Construccion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly GeneralesService _generalesServices;
        private readonly IMapper _mapper;
        public ConstruccionCon db = new ConstruccionCon();

        public EmpleadosController(GeneralesService generalesService, IMapper mapper)
        {
            _generalesServices = generalesService;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _generalesServices.ListEmpleados();
            return Ok(list);
        }
    }
}
