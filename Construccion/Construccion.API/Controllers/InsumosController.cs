﻿using AutoMapper;
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
    }
}
