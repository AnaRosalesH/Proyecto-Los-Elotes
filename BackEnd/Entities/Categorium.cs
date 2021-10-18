using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Entities
{
    public partial class Categorium
    {
        public Categorium()
        {
            Productos = new HashSet<Producto>();
        }

        public int IdCategoria { get; set; }
        public string CategoriaProducto { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
