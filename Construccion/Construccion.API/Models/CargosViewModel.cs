using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Construccion.API.Models
{
    public class CargosViewModel
    {
        public int carg_Id { get; set; }
        public string carg_Cargo { get; set; }
        public int? user_UsuCreacion { get; set; }
        public DateTime carg_FechaCreacion { get; set; }
        public int? user_IdModificacion { get; set; }
        public DateTime? carg_FechaModificacion { get; set; }
    }
}
