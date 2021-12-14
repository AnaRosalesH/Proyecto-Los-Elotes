using BackEnd.Entities;
using FrontEnd.Utilidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class CarritoDALImpl : ICarritoDAL
    {
        private db_a7b39f_diego1512Context context;

        public CarritoDALImpl(db_a7b39f_diego1512Context _context)
        {
            context = _context;
        }


        public void AgregarAlCarrito(int idProducto, int cedula)
        {
            string nombre;
            string rutaImagen;
            double precio;

            using (var db = new db_a7b39f_diego1512Context())
            {
                var productoDatos = db.Productos.Where(p => p.IdProducto == idProducto).FirstOrDefault();

                nombre = productoDatos.NombreProducto;
                rutaImagen = productoDatos.RutaImagen;
                precio = productoDatos.PrecioProducto;

                db.SaveChanges();
            }

            using (var db2 = new db_a7b39f_diego1512Context())
            {
                var carrito = new Carrito();

                carrito.IdProducto = idProducto;
                carrito.Cedula = cedula;
                carrito.NombreProducto = nombre;
                carrito.RutaImagen = rutaImagen;
                carrito.PrecioProducto = precio;

                db2.Carritos.Add(carrito);
                db2.SaveChanges();

            }

        }

        public bool Add(Carrito entity)
        {
            try
            {
                using (UnidadDeTrabajo<Carrito> unidad = new UnidadDeTrabajo<Carrito>(context))
                {
                    unidad.genericDAL.Add(entity);
                    return unidad.Complete();
                }
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public void AddRange(IEnumerable<Carrito> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Carrito> Find(Expression<Func<Carrito, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Carrito> GetCarrito(long cedula)
        {
            List<Carrito> result;

            result = context.Carritos.FromSqlRaw($"exec dbo.ConsultarCarrito @id ={cedula} ")
            .ToListAsync().Result;

            return result;
        }
        public void EliminarCarrito(long cedula)
        {

            //context.Carritos.FromSqlRaw($"exec dbo.EliminarProductoCarrito @id ={cedula} ");


            using (var db = new db_a7b39f_diego1512Context())
            {

                var itemsLista = db.Carritos.Where(c => c.Cedula == cedula);

                foreach (var item in itemsLista)
                {
                    db.Remove(item);
                }

                db.SaveChanges();

            }

        }

        public void ComprarCarrito(long cedula, string correo)
        {

            //context.Carritos.FromSqlRaw($"exec dbo.EliminarProductoCarrito @id ={cedula} ");
            double montoTotal = 0;
            string listaProductos = "";

            using (var db = new db_a7b39f_diego1512Context())
            {

                var itemsLista = db.Carritos.Where(c => c.Cedula == cedula);

                foreach (var item in itemsLista)
                {
                    listaProductos += item.NombreProducto + "\n";
                    montoTotal += item.PrecioProducto;
                    db.Remove(item);
                }
                db.SaveChanges();
            }

            using (var db2 = new db_a7b39f_diego1512Context())
            {
                Factura facturas = new Factura();
                facturas.Cedula = cedula;
                facturas.MontoTotal = montoTotal;
                facturas.Fecha = DateTime.Now.ToString();
                db2.Facturas.Add(facturas);
                db2.SaveChanges();

            }

            Correo.enviarCorreo(correo, "Productos comprados:\n" + listaProductos + "\nTotal: " + montoTotal);
        }

        public bool Update(long cedula, int producto, string nombre, string imagen, decimal precio)
        {
            try
            {
                context.Carritos.FromSqlRaw($"exec dbo.InsertarCarrito @id ={cedula}, @producto ={producto}, @nombre ={nombre}," +
                    $"@imagen ={imagen}, @precio ={precio}");
                
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
 

        public Carrito Get(int id)
        {
            Carrito result;
            using (UnidadDeTrabajo<Carrito> unidad = new UnidadDeTrabajo<Carrito>(context))
            {
                result = unidad.genericDAL.Get(id);

            }
            return result;
        }

  

        public IEnumerable<Carrito> GetAll()
        {
            List<Carrito> carritos;
            using (UnidadDeTrabajo<Carrito> Unidad = new UnidadDeTrabajo<Carrito>(context))
            {
                carritos = Unidad.genericDAL.GetAll().ToList();
            }
            return carritos;
        }

        public bool Remove(Carrito entity)
        {
            try
            {
                using (UnidadDeTrabajo<Carrito> unidad = new UnidadDeTrabajo<Carrito>(context))
                {
                    unidad.genericDAL.Remove(entity);
                    return unidad.Complete();
                }

            }
            catch (Exception)
            {

                return false;
            }
        }


        public void RemoveRange(IEnumerable<Carrito> entities)
        {
            throw new NotImplementedException();
        }

        public Carrito SingleOrDefault(Expression<Func<Carrito, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Carrito entity)
        {
            try
            {
                using (UnidadDeTrabajo<Carrito> unidad = new UnidadDeTrabajo<Carrito>(context))
                {
                    unidad.genericDAL.Update(entity);
                    return unidad.Complete();
                }

            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}