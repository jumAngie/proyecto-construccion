using AutoMapper;
using Construccion.API.Models;
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
    public class RolController : ControllerBase
    {
        private readonly AccessService _accessService;
        private readonly IMapper _mapper;
        public ConstruccionCon db = new ConstruccionCon();
        public RolController(AccessService accessService, IMapper mapper)
        {
            _accessService = accessService;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _accessService.ListRoles();
            return Ok(list);
        }

        //[HttpGet("(Id)")]
        //public Student GetStudent(int Id)
        //{

        //    context.students.Where(a => a.Id == Id).SingleOrDefault();
        //    var student = return student;

        //}

        [HttpPost("RolPantallaPorIdRol")]
        public IActionResult ListarRolPantalla(PantallasRolesViewModel pantallasRolesViewModel)
        {
            var item = _mapper.Map<tbPantallasRoles>(pantallasRolesViewModel);
            var list = _accessService.ListRolesPantalla(item);
            return Ok(list);
        }


        [HttpPost("Insert")]

        public IActionResult Insert (RolesViewModel roles)
        {
            var item = _mapper.Map<tbRoles>(roles);
            var response = _accessService.CreateRoles(item);
            return Ok(response);
        }

        [HttpPut("Update")]

        public IActionResult Update(RolesViewModel roles)
        {
            var item = _mapper.Map<tbRoles>(roles);
            var response = _accessService.UpdateRoles(item);
            return Ok(response);
        }
    }
}
