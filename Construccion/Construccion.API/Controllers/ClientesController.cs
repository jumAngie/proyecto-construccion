using AutoMapper;
using Construccion.API.Models;
using Construccion.BusinessLogic;
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
    public class ClientesController : ControllerBase
    {
        private readonly ConstruccionServices _construccionServices;
        private readonly IMapper _mapper;
        public ConstruccionCon db = new ConstruccionCon();

        public ClientesController(ConstruccionServices construccionServices, IMapper mapper)
        {
            _construccionServices = construccionServices;
            _mapper = mapper;
        }

        #region Validaciones
        //public bool ExisteDNI(string DNI)
        //{
        //    var Existe = db.tbClientes.Any(p => p.clie_Identificacion == DNI);
        //    return Ok(Existe);

        //}
        #endregion

        #region Listado
        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _construccionServices.ListClientes();
            return Ok(list);
        }
        #endregion

        #region Crear Cliente
        [HttpPost("Insert")]
        public IActionResult Insert(ClientesViewModel clientes)
        {
                var item = _mapper.Map<tbClientes>(clientes);
                var response = _construccionServices.CreateClientes(item);
                return Ok(response);
            
        }
        #endregion

        #region EditarCliente
        //[HttpGet("Find")]

        //public IActionResult Find(int id)
        //{
        //    var encontrar = _construccionServices.ObtenerCliente(id);
        //    return Ok(encontrar);
        //}

        //[HttpPut("Editar")]

        ////public IActionResult Edit(ClientesViewModel clientesViewModel)
        ////{
        ////    if(ModelState.IsValid)
        ////    {
        ////        tbClientes clientes = new tbClientes();
        ////    }
        ////    else
        ////    {
        ////        return null;
        ////    }

        ////}
        #endregion
    }
}
