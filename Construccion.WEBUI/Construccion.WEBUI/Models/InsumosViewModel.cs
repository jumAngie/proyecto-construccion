using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Construccion.WEBUI.Models
{
    public class InsumosViewModel
    {
        [Display(Name = "Id")]
        public int insm_Id { get; set; }

        [Display(Name = "Insumo")]
        public string insm_Descripcion { get; set; }

        [Display(Name = "Unidad de Medida")]
        public int unim_Id { get; set; }

        [Display(Name = "Unidades de Medida")]
        public int user_UsuCreacion { get; set; }

        [Display(Name = "Fecha Creación")]
        public DateTime insm_FechaCreacion { get; set; }

        [Display(Name = "Usuario Modificación")]
        public int? user_UsuModificacion { get; set; }

        [Display(Name = "Fecha de Modificación")]
        public DateTime? insm_FechaModificacion { get; set; }

        [NotMapped]
        [Display(Name = "Unidad de Medida")]
        public string unim_Descripcion { get; set; }
    }
}
