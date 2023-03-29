using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Construccion.WEBUI.Models
{
    public class EmpleadosViewModel
    {
        public int empl_Id { get; set; }
        public string empl_DNI { get; set; }
        public string empl_Nombre { get; set; }
        public string empl_Apellidos { get; set; }
        public string empl_Sexo { get; set; }
        public string esta_ID { get; set; }
        public string muni_Id { get; set; }
        public int carg_Id { get; set; }
        [NotMapped]
        public string carg_Cargo { get; set; }
        public string empl_DireccionExacta { get; set; }
        public DateTime empl_FechaNacimiento { get; set; }
        public string empl_Telefono { get; set; }
        public string empl_CorreoEletronico { get; set; }
        public int user_IdCreacion { get; set; }
        public DateTime empl_FechaCreacion { get; set; }
        public int? user_IdModificacion { get; set; }
        public DateTime? empl_FechaModificacion { get; set; }
        public bool? empl_Estado { get; set; }
    }
}
