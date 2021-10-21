using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Entities
{
    public partial class Producto
    {
        public Producto()
        {
            Carritos = new HashSet<Carrito>();
        }

        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int IdCategoria { get; set; }
        public int IdMarca { get; set; }
        public string RutaImagen { get; set; }
        public double PrecioProducto { get; set; }
        public int CantidadProducto { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual Marca IdMarcaNavigation { get; set; }
        public virtual ICollection<Carrito> Carritos { get; set; }
    }
}
