using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
   public class RolesDALImpl : IRolesDAL
    {
        private db_a7b39f_diego1512Context context;
        public RolesDALImpl(db_a7b39f_diego1512Context _context)
        {
            context = _context;
        }

        public bool Add(Role entity)
        {
            try
            {
                using (UnidadDeTrabajo<Role> unidad = new UnidadDeTrabajo<Role>(context))
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


        public void AddRange(IEnumerable<Role> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> Find(Expression<Func<Role, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Role Get(int id)
        {
            Role result;
            using (UnidadDeTrabajo<Role> unidad = new UnidadDeTrabajo<Role>(context))
            {
                result = unidad.genericDAL.Get(id);

            }
            return result;
        }

        public IEnumerable<Role> GetAll()
        {
            List<Role> roles;
            using (UnidadDeTrabajo<Role> Unidad = new UnidadDeTrabajo<Role>(context))
            {
                roles = Unidad.genericDAL.GetAll().ToList();
            }
            return roles;
        }

        public bool Remove(Role entity)
        {
            try
            {
                using (UnidadDeTrabajo<Role> unidad = new UnidadDeTrabajo<Role>(context))
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

        public void RemoveRange(IEnumerable<Role> entities)
        {
            throw new NotImplementedException();
        }

        public Role SingleOrDefault(Expression<Func<Role, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Role entity)
        {
            try
            {
                using (UnidadDeTrabajo<Role> unidad = new UnidadDeTrabajo<Role>(context))
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


        Role IDALGenerico<Role>.Get(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Role> IDALGenerico<Role>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
