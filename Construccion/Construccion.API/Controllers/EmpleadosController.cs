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

        [HttpPost("Insert")]
        public IActionResult Insert(EmpleadosViewModel empleados)
        {
            //if(ExisteDNI(clientes.clie_Identificacion) == false)
            //{
            var item = _mapper.Map<tbEmpleados>(empleados);
            var response = _generalesServices.CreateEmpleados(item);
            return Ok(response);

            //}
            //else
            //{
            //    return Ok(clientes);
            //    // esto va en el front lol
            //}

        }
    }
}
