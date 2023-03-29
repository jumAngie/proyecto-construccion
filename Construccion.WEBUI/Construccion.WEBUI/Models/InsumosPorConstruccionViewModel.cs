using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Construccion.WEBUI.Models
{
    public class InsumosViewModel
    {
        public int insm_Id { get; set; }
        public string insm_Descripcion { get; set; }
        public int unim_Id { get; set; }
        [NotMapped]
        public string unim_Descripcion { get; set; }
    }
}
