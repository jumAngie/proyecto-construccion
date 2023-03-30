using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Construccion.API.Models
{
    public class ClientesViewModel
    {
        public int clie_Id { get; set; }
        public string clie_Identificacion { get; set; }
        public string clie_Nombre { get; set; }
        public string muni_Id { get; set; }
        public string clie_DireccionExacta { get; set; }
        public string clie_Telefono { get; set; }
        public string clie_CorreoElectronico { get; set; }
        public int user_IdCreacion { get; set; }

        public int user_IdModificacion { get; set; }

        [NotMapped]
        public string depto { get; set; }
    }
}
