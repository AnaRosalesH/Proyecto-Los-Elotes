using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
   public class CategoriasDALImpl : ICategoriasDAL
    {
        private db_a7b39f_diego1512Context context;
        public CategoriasDALImpl(db_a7b39f_diego1512Context _context)
        {
            context = _context;
        }

        public bool Add(Categoria entity)
        {
            try
            {
                using (UnidadDeTrabajo<Categoria> unidad = new UnidadDeTrabajo<Categoria>(context))
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

        public void AddRange(IEnumerable<Categoria> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Categoria> Find(Expression<Func<Categoria, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Categoria Get(int id)
        {
            Categoria result;
            using (UnidadDeTrabajo<Categoria> unidad = new UnidadDeTrabajo<Categoria>(context))
            {
                result = unidad.genericDAL.Get(id);

            }
            return result;
        }

        public IEnumerable<Categoria> GetAll()
        {
            List<Categoria> categorias;
            using (UnidadDeTrabajo<Categoria> Unidad = new UnidadDeTrabajo<Categoria>(context))
            {
                categorias = Unidad.genericDAL.GetAll().ToList();
            }
            return categorias;
        }

        public bool Remove(Categoria entity)
        {
            try
            {
                using (UnidadDeTrabajo<Categoria> unidad = new UnidadDeTrabajo<Categoria>(context))
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

        public void RemoveRange(IEnumerable<Categoria> entities)
        {
            throw new NotImplementedException();
        }

        public Categoria SingleOrDefault(Expression<Func<Categoria, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Categoria entity)
        {
            try
            {
                using (UnidadDeTrabajo<Categoria> unidad = new UnidadDeTrabajo<Categoria>(context))
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
