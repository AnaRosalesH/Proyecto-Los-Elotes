using BackEnd.Entities;
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