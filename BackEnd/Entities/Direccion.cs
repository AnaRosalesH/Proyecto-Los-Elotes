using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Entities
{
    public partial class Direccion
    {
        public int IdDireccion { get; set; }
        public string Provincia { get; set; }
        public long? Cedula { get; set; }
        public string DireccionEspecifica { get; set; }

        public virtual Usuario CedulaNavigation { get; set; }
    }
}
