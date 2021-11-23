using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
   public class UsuarioDALImpl : IUsuarioDAL
    {
        private db_a7b39f_diego1512Context context;
        public UsuarioDALImpl(db_a7b39f_diego1512Context _context)
        {
            context = _context;
        }

        public bool Add(Usuario entity)
        {
            try
            {
                using (UnidadDeTrabajoLong<Usuario> unidad = new UnidadDeTrabajoLong<Usuario>(context))
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

        public void AddRange(IEnumerable<Usuario> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> Find(Expression<Func<Usuario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Usuario Get(long id)
        {
            Usuario result;
            using (UnidadDeTrabajoLong<Usuario> unidad = new UnidadDeTrabajoLong<Usuario>(context))
            {
                result = unidad.genericDAL.Get(id);

            }
            return result;
        }

        public IEnumerable<Usuario> GetAll()
        {
            List<Usuario> usuarios;
            using (UnidadDeTrabajo<Usuario> Unidad = new UnidadDeTrabajo<Usuario>(context))
            {
                usuarios = Unidad.genericDAL.GetAll().ToList();
            }
            return usuarios;
        }

        public bool Remove(Usuario entity)
        {
            try
            {
                using (UnidadDeTrabajo<Usuario> unidad = new UnidadDeTrabajo<Usuario>(context))
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

        public void RemoveRange(IEnumerable<Usuario> entities)
        {
            throw new NotImplementedException();
        }

        public Usuario SingleOrDefault(Expression<Func<Usuario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Usuario entity)
        {
            try
            {
                using (UnidadDeTrabajo<Usuario> unidad = new UnidadDeTrabajo<Usuario>(context))
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
