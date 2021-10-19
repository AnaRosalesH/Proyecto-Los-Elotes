using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class ProductosDALImpl : IProductosDAL
    {


        private db_a7b39f_diego1512Context context;
        public ProductosDALImpl(db_a7b39f_diego1512Context _context)
        {
            context = _context;
        }

        public bool Add(Producto entity)
        {
            try
            {
                using (UnidadDeTrabajo<Producto> unidad = new UnidadDeTrabajo<Producto>(context))
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

        public void AddRange(IEnumerable<Producto> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Producto> Find(Expression<Func<Producto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Producto Get(int id)
        {
            Producto result;
            using (UnidadDeTrabajo<Producto> unidad = new UnidadDeTrabajo<Producto> (context))
            {
                result = unidad.genericDAL.Get(id);

            }
            return result;
        }

        public IEnumerable<Producto> GetAll()
        {
            List<Producto> products;
            using (UnidadDeTrabajo<Producto> Unidad = new UnidadDeTrabajo<Producto>(context))
            {
                products = Unidad.genericDAL.GetAll().ToList();
            }
            return products;
        }

        public bool Remove(Producto entity)
        {
            try
            {
                using (UnidadDeTrabajo<Producto> unidad = new UnidadDeTrabajo<Producto>(context))
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

        public void RemoveRange(IEnumerable<Producto> entities)
        {
            throw new NotImplementedException();
        }

        public Producto SingleOrDefault(Expression<Func<Producto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Producto entity)
        {
            try
            {
                using (UnidadDeTrabajo<Producto> unidad = new UnidadDeTrabajo<Producto>(context))
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
