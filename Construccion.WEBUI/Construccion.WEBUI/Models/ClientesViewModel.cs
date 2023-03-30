using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Construccion.WEBUI.Models
{
    public class ClientesViewModel
    {
        [Display(Name = "ID")]
        public int clie_Id { get; set; }


        [Display(Name = "Identificación")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string clie_Identificacion { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string clie_Nombre { get; set; }

        [Display(Name = "Municipio")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string muni_Id { get; set; }

        [Display(Name = "Dirección Exacta")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string clie_DireccionExacta { get; set; }

        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string clie_Telefono { get; set; }

        [Display(Name = "Correo Electronico")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Formato inválido")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string clie_CorreoElectronico { get; set; }

        [Display(Name = "Usuario Creación")]
        public int? user_IdCreacion { get; set; }
    }
}
