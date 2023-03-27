using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Construccion.API.Models
{
    public class PantallasViewModel
    {
        public int pant_Id { get; set; }
        public string pant_Nombre { get; set; }
        public string pant_URL { get; set; }
        public string pant_Menu { get; set; }
        public string pant_HtmlId { get; set; }
        public int user_UsuCreacion { get; set; }
        public DateTime pant_FechaCreacion { get; set; }
        public int? user_UsuModificacion { get; set; }
        public DateTime? pant_FechaModificacion { get; set; }
        public bool? pant_Estado { get; set; }


        [NotMapped]
        public int role_Id { get; set; }

        [NotMapped]
        public bool esAdmin { get; set; }
    }
}
