using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Entities
{
    public partial class Bitacora
    {
        public int IdEvento { get; set; }
        public string Descripcion { get; set; }
        public string FechaHora { get; set; }
    }
}
