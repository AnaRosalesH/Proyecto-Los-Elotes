using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BackEnd.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            Carritos = new HashSet<Carrito>();
            Direccions = new HashSet<Direccion>();
            Facturas = new HashSet<Factura>();
        }

        public long Cedula { get; set; }

        [Required]
        public string NombreUsuario { get; set; }
        [Required]
        public string Contrasena { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? IdRol { get; set; }

        public virtual Role IdRolNavigation { get; set; }
        public virtual ICollection<Carrito> Carritos { get; set; }
        public virtual ICollection<Direccion> Direccions { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
