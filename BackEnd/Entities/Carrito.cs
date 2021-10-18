using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Entities
{
    public partial class Carrito
    {
        public int IdCarrito { get; set; }
        public long Cedula { get; set; }
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string RutaImagen { get; set; }
        public double PrecioProducto { get; set; }

        public virtual Usuario CedulaNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
