using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Construccion.WEBUI.Models
{
    public class EmpleadosViewModel
    {
        [Display(Name = "ID")]
        public int empl_Id { get; set; }

        [Display(Name = "DNI")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string empl_DNI { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string empl_Nombre { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string empl_Apellidos { get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string empl_Sexo { get; set; }

        [Display(Name = "Estado Civil")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string esta_ID { get; set; }

        [Display(Name = "Municipio")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string muni_Id { get; set; }

        [Display(Name = "Cargo")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int carg_Id { get; set; }


        [NotMapped]
        [Display(Name = "Cargo")]
        public string carg_Cargo { get; set; }

        [Display(Name = "Dirección Exacta")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string empl_DireccionExacta { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [Required(ErrorMessage = "Campo Requerido")]
        public DateTime empl_FechaNacimiento { get; set; }

        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string empl_Telefono { get; set; }

        [Display(Name = "Correo Electronico")]
        [Required(ErrorMessage = "Campo Requerido")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Formato inválido")]
        public string empl_CorreoEletronico { get; set; }

        [NotMapped]
        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string depto { get; set; }
        public int? user_IdCreacion { get; set; }
        public DateTime empl_FechaCreacion { get; set; }
        public int? user_IdModificacion { get; set; }
        public DateTime? empl_FechaModificacion { get; set; }
        public bool? empl_Estado { get; set; }
    }
}
