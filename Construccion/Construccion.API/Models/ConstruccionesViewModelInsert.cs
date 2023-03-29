using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Construccion.API.Models
{
    public class ConstruccionesViewModelInsert
    {
        public int cons_Id { get; set; }
        public string cons_Proyecto { get; set; }
        public string cons_ProyectoDescripcion { get; set; }
        public string muni_Id { get; set; }
        public string cons_Direccion { get; set; }
        public DateTime? cons_FechaInicio { get; set; }
        public DateTime? cons_FechaFin { get; set; }
        public int? user_UsuCreacion { get; set; }
    }
}
