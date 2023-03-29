using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Construccion.API.Models
{
    public class InsumosViewModel
    {
        public int insm_Id { get; set; }
        public string insm_Descripcion { get; set; }
        public int unim_Id { get; set; }
        public int user_UsuCreacion { get; set; }
        public DateTime insm_FechaCreacion { get; set; }
        public int? user_UsuModificacion { get; set; }
        public DateTime? insm_FechaModificacion { get; set; }
        public bool? user_Estado { get; set; }

        [NotMapped]
        public string unim_Descripcion { get; set; }
    }
}
