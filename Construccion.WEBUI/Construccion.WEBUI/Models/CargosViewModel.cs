using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Construccion.WEBUI.Models
{
    public class CargosViewModel
    {
        [Display(Name = "Cargo Id")]
        public int carg_Id { get; set; }

        [Display(Name = "Cargo")]
        public string carg_Cargo { get; set; }

        [Display(Name = "Usuario Creación")]
        public int user_UsuCreacion { get; set; }

        [Display(Name = "Fecha Creación")]
        public DateTime carg_FechaCreacion { get; set; }

        [Display(Name = "Usuario Modificación")]
        public int? user_IdModificacion { get; set; }

        [Display(Name = "Fecha Modificación")]
        public DateTime? carg_FechaModificacion { get; set; }
    }
}
