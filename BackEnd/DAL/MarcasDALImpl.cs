using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
   public class MarcasDALImpl : IMarcasDAL
    {
        private db_a7b39f_diego1512Context context;
        public MarcasDALImpl(db_a7b39f_diego1512Context _context)
        {
            context = _context;
        }

        public bool Add(Marca entity)
        {
            try
            {
                using (UnidadDeTrabajo<Marca> unidad = new UnidadDeTrabajo<Marca>(context))
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

        public void AddRange(IEnumerable<Marca> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Marca> Find(Expression<Func<Marca, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Marca Get(int id)
        {
            Marca result;
            using (UnidadDeTrabajo<Marca> unidad = new UnidadDeTrabajo<Marca>(context))
            {
                result = unidad.genericDAL.Get(id);

            }
            return result;
        }

        public IEnumerable<Marca> GetAll()
        {
            List<Marca> products;
            using (UnidadDeTrabajo<Marca> Unidad = new UnidadDeTrabajo<Marca>(context))
            {
                products = Unidad.genericDAL.GetAll().ToList();
            }
            return products;
        }

        public bool Remove(Marca entity)
        {
            try
            {
                using (UnidadDeTrabajo<Marca> unidad = new UnidadDeTrabajo<Marca>(context))
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

        public void RemoveRange(IEnumerable<Marca> entities)
        {
            throw new NotImplementedException();
        }

        public Marca SingleOrDefault(Expression<Func<Marca, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Marca entity)
        {
            try
            {
                using (UnidadDeTrabajo<Marca> unidad = new UnidadDeTrabajo<Marca>(context))
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
