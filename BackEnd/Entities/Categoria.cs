using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BackEnd.Entities
{
    public partial class Categoria
    {
        public Categoria()
        {
            Productos = new HashSet<Producto>();
        }

        public int IdCategoria { get; set; }
        [Display(Name = "Categoría")]
        public string CategoriaProducto { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
