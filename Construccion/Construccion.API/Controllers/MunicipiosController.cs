using AutoMapper;
using Construccion.API.Models;
using Construccion.BusinessLogic.Services;
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
    public class MunicipiosController : Controller
    {
        private readonly GeneralesService _generalesServices;
        private readonly IMapper _mapper;

        public MunicipiosController(GeneralesService generalesService, IMapper mapper)
        {
            _generalesServices = generalesService;
            _mapper = mapper;
        }

        [HttpPost("ListarMunicipiosPorIdDepartamento")]
        public IActionResult ListarMunicipiosPorIdDepartamento(MunicipiosViewModel municipiosViewModel)
        {
            var item = _mapper.Map<tbMunicipios>(municipiosViewModel);
            var response = _generalesServices.ListarMunicipiosPorIdDepartamento(item);
            return Ok(response);
        }
    }
}
