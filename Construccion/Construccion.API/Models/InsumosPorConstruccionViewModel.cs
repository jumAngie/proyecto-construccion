using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Construccion.API.Models
{
    public class InsumosPorConstruccionViewModel
    {
        public int inco_Id { get; set; }
        public int? cons_Id { get; set; }
        public int? insm_Id { get; set; }
        public string insm_Descripcion { get; set; }
        public int unim_Id { get; set; }
        [NotMapped]
        public string unim_Descripcion { get; set; }
    }
}
