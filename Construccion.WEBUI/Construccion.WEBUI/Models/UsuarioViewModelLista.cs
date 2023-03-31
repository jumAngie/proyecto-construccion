using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Construccion.WEBUI.Models
{
    public class UsuarioViewModelLista
    {
        public int user_Id { get; set; }
        public string user_NombreUsuario { get; set; }
        public string role_Nombre { get; set; }
        public string Es_Admin { get; set; }
        public int? empl_Id { get; set; }
        public string empl_Nombre { get; set; }
    }
}
