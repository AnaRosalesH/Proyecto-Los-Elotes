using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class DireccionDALImpl : IDireccionDAL
    {


        private db_a7b39f_diego1512Context context;
        public DireccionDALImpl(db_a7b39f_diego1512Context _context)
        {
            context = _context;
        }

        public bool Add(Direccion entity)
        {
            try
            {
                using (UnidadDeTrabajo<Direccion> unidad = new UnidadDeTrabajo<Direccion>(context))
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

        public void AddRange(IEnumerable<Direccion> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Direccion> Find(Expression<Func<Direccion, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Direccion Get(int id)
        {
            Direccion result;
            using (UnidadDeTrabajo<Direccion> unidad = new UnidadDeTrabajo<Direccion>(context))
            {
                result = unidad.genericDAL.Get(id);

            }
            return result;
        }

        public IEnumerable<Direccion> GetAll()
        {
            List<Direccion> direction;

            using (UnidadDeTrabajo<Direccion> Unidad = new UnidadDeTrabajo<Direccion>(context))
            {
                direction = Unidad.genericDAL.GetAll().ToList();
            }
            return direction;
        }

        public bool Remove(Direccion entity)
        {
            try
            {
                using (UnidadDeTrabajo<Direccion> unidad = new UnidadDeTrabajo<Direccion>(context))
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

        public void RemoveRange(IEnumerable<Direccion> entities)
        {
            throw new NotImplementedException();
        }

        public Direccion SingleOrDefault(Expression<Func<Direccion, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Direccion entity)
        {
            try
            {
                using (UnidadDeTrabajo<Direccion> unidad = new UnidadDeTrabajo<Direccion>(context))
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
