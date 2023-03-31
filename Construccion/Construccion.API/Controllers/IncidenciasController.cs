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

    public class IncidenciasController : Controller
    {
        private readonly ConstruccionServices _construccionServices;
        private readonly IMapper _mapper;
        public ConstruccionCon db = new ConstruccionCon();

        public IncidenciasController(ConstruccionServices construccionServices, IMapper mapper)
        {
            _construccionServices = construccionServices;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _construccionServices.ListIncidencias();
            return Ok(list);
        }

        [HttpPost("Insert")]

        public IActionResult Insert(IncidenciasViewModel incidencias)
        {
            var item = _mapper.Map<tbIncidencia>(incidencias);
            var response = _construccionServices.CreateIncidencias(item);
            return Ok(response);
        }

        [HttpPut("Update")]
        public IActionResult Update(IncidenciasViewModel incidencias)
        {
            var item = _mapper.Map<tbIncidencia>(incidencias);
            var response = _construccionServices.EditarIncidencias(item);
            return Ok(response);
        }

        [HttpPost("EliminarIncidencia")]
        public IActionResult EliminarIncidencia(IncidenciasViewModel incidencias)
        {
            var item = _mapper.Map<tbIncidencia>(incidencias);
            var response = _construccionServices.EliminarIncidencia(item);
            return Ok(response);
        }

        [HttpGet("ListadoConstrucciones")]

        public IActionResult ListadoConstruc()
        {
            var resultado = from c in db.tbConstrucciones
                            select new { cons_Id = c.cons_Id, cons_Proyecto = c.cons_Proyecto };

            // Devolver los resultados de la consulta como un objeto JSON
            return Json(resultado.ToList());
        }
    }
}
