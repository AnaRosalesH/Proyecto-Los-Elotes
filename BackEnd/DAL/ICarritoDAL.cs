using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
   public interface ICarritoDAL : IDALGenerico<Carrito>
    {
        List<Carrito> GetCarrito(long cedula);
        bool Update(long cedula, int producto, string nombre, string imagen, decimal precio);
        void EliminarCarrito(long cedula);
        void ComprarCarrito(long cedula);
    }
}
