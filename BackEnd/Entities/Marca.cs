using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Marca")]
        public string MarcaProducto { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
