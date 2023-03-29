using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Construccion.API.Models
{
    public class IncidenciasViewModel
    {
        [Display(Name = "ID")]
        public int inci_Id { get; set; }

        [Display(Name = "Construcción")]
        public int cons_Id { get; set; }

        [NotMapped]
        public string cons_Proyecto { get; set; }

        [Display(Name = "Incidencia")]
        public string inci_Descripcion { get; set; }
        public int? user_UsuCreacion { get; set; }
        public DateTime inci_FechaCreacion { get; set; }
        public int? user_UsuModificacion { get; set; }
        public DateTime? inci_FechaModificacion { get; set; }
        public bool? user_Estado { get; set; }
    }
}
