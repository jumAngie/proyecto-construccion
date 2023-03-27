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
    }
}
