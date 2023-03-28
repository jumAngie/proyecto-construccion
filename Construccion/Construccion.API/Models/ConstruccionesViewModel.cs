using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Construccion.API.Models
{
    public class ConstruccionesViewModel
    {
        public int cons_Id { get; set; }
        public string cons_Proyecto { get; set; }
        public string cons_ProyectoDescripcion { get; set; }
        public string muni_Id { get; set; }
        [NotMapped]
        public string depa_Nombre { get; set; }
        public string cons_Direccion { get; set; }
        public DateTime? cons_FechaInicio { get; set; }
        public DateTime? cons_FechaFin { get; set; }
        public int? user_UsuCreacion { get; set; }
        public DateTime cons_FechaCreacion { get; set; }
        public int? user_UsuModificacion { get; set; }
        public DateTime? cons_FechaModificacion { get; set; }
        public bool? cons_Estado { get; set; }

    }
}
