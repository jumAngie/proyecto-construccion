using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Construccion.WEBUI.Models
{
    public class ConstruccionesViewModel
    {
        public int cons_Id { get; set; }
        public string cons_Proyecto { get; set; }
        public string cons_ProyectoDescripcion { get; set; }
        public string depa_Nombre { get; set; }
        public string muni_Nombre { get; set; }
        public string muni_Id { get; set; }
        public string cons_Direccion { get; set; }
    }
}
