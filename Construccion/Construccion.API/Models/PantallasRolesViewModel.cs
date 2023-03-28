using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Construccion.API.Models
{
    public class PantallasRolesViewModel
    {
        public int ptro_Id { get; set; }
        public int role_Id { get; set; }
        public int pant_Id { get; set; }
        [NotMapped]
        public string pant_Nombre { get; set; }
    }
}
