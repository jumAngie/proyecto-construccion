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
        [HttpPost("Find")]

        public IActionResult Find(ClientesViewModel clientesView)
        {
            int id = clientesView.clie_Id;
            var cliente = _construccionServices.ObtenerCliente(id);
            if(cliente != null)
            {
                clientesView.clie_Id = cliente.clie_Id;
                clientesView.clie_Nombre = cliente.clie_Nombre;
                clientesView.clie_Identificacion = cliente.clie_Identificacion;
                clientesView.muni_Id = cliente.muni_Id;
                clientesView.clie_DireccionExacta = cliente.clie_DireccionExacta;
                clientesView.clie_Telefono = cliente.clie_Telefono;
                clientesView.clie_CorreoElectronico = cliente.clie_CorreoElectronico;
                clientesView.depto = db.tbMunicipios.Where(m => m.muni_id == cliente.muni_Id).Select(m => m.depa_Id).FirstOrDefault().ToString();
                return Ok(clientesView);

            }

            return null;
            
        }

        //[HttpPost("Editar")]

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
