﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Construccion.Entities.Entities
{
    public partial class tbClientes
    {
        public int clie_Id { get; set; }
        public string clie_Identificacion { get; set; }
        public string clie_Nombre { get; set; }
        public string muni_Id { get; set; }
        public string clie_DireccionExacta { get; set; }
        public string clie_Telefono { get; set; }
        public string clie_CorreoElectronico { get; set; }
        public int user_IdCreacion { get; set; }
        public DateTime clie_FechaCreacion { get; set; }
        public int? user_IdModificacion { get; set; }
        public DateTime? clie_FechaModificacion { get; set; }
        public bool? clie_Estado { get; set; }

        [NotMapped]
        public string depto { get; set; }
        public virtual tbMunicipios muni { get; set; }
    }
}