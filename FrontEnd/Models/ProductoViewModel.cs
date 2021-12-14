using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Models
{
    public class ProductoViewModel
    {
        [Key]
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }

        [Display(Name = "Categorías")]
        public int IdCategoria { get; set; }
        public IEnumerable<Categoria> Categorias { get; set; }

        [Display(Name = "Categorías")]
        public Categoria Categoria { get; set; }

        [Display(Name = "Marcas")]
        public int IdMarca { get; set; }
        public IEnumerable<Marca> Marcas { get; set; }

        [Display(Name = "Marcas")]
        public Marca Marca { get; set; }

        public string RutaImagen { get; set; }
        public double PrecioProducto { get; set; }
        public int CantidadProducto { get; set; }

    }
}
