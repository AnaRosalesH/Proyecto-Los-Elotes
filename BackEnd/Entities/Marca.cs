using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Entities
{
    public partial class Marca
    {
        public Marca()
        {
            Productos = new HashSet<Producto>();
        }

        public int IdMarca { get; set; }
        public string MarcaProducto { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
