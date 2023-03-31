using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Construccion.WEBUI.Models
{
    public class UsuarioViewModel
    {
        public int user_Id { get; set; }
        public string user_NombreUsuario { get; set; }
        public string user_Contrasena { get; set; }
        public bool? user_EsAdmin { get; set; }
        public int role_Id { get; set; }

        public int? user_UsuCreacion { get; set; }
        public int? empe_Id { get; set; }
        [NotMapped]
        public int? empl_Id { get; set; }

        [NotMapped]
        public string empl_Nombre { get; set; }

        public int? user_UsuModificacion { get; set; }
    }
}
