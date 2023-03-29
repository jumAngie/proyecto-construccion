using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Construccion.WEBUI.Models
{
    public class UnidadesMedidaViewModel
    {
        [Display(Name = "ID")]
        public int unim_Id { get; set; }

        [Display(Name = "Descripción")]
        public string unim_Descripcion { get; set; }
        public int? user_UsuCreacion { get; set; }
        public DateTime user_FechaCreacion { get; set; }
        public int? user_UsuModificacion { get; set; }
        public DateTime? user_FechaModificacion { get; set; }
        public bool? user_Estado { get; set; }
    }
}
