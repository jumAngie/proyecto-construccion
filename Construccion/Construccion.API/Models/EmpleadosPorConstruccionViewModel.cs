using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Construccion.API.Models
{
    public class EmpleadosPorConstruccionViewModel
    {
        public int emco_Id { get; set; }
        public int cons_Id { get; set; }
        public int empl_Id { get; set; }
        [NotMapped]
        public string empl_Nombre { get; set; }
        [NotMapped]
        public string empl_Apellidos { get; set; }
        [NotMapped]
        public string empl_Telefono { get; set; }
        [NotMapped]
        public string empl_CorreoEletronico { get; set; }
    }
}
