using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Construccion.WEBUI.Models
{
    public class ResponseAPI<T>
    {
        public int code { get; set; }
        public bool success { get; set; }

        public string message { get; set; }

        public List<T> data { get; set; }
    }
}
