using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Entities
{
    public partial class Factura
    {
        public int IdFactura { get; set; }
        public long Cedula { get; set; }
        public double MontoTotal { get; set; }
        public string Fecha { get; set; }

        public virtual Usuario CedulaNavigation { get; set; }
    }
}
