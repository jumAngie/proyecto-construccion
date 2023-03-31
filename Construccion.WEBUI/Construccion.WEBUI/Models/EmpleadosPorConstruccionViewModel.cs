using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Construccion.WEBUI.Models
{
    public class EmpleadosPorConstruccionViewModel
    {
        public int emco_Id { get; set; }
        public int cons_Id { get; set; }
        public int empl_Id { get; set; }
        public string empl_Nombre { get; set; }
        public string empl_Apellidos { get; set; }
        public string empl_Telefono { get; set; }
        public string empl_CorreoEletronico { get; set; }
        public int? user_UsuModificacion { get; set; }
        public int? user_UsuCreacion { get; set; }

    }
}
