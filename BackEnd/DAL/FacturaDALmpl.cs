using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class FacturaDALImpl : IFacturaDAL
    {


        private db_a7b39f_diego1512Context context;
        public FacturaDALImpl(db_a7b39f_diego1512Context _context)
        {
            context = _context;
        }

      

        public bool Add(Factura entity)
        {
            try
            {
                using (UnidadDeTrabajo<Factura> unidad = new UnidadDeTrabajo<Factura>(context))
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

        public void AddRange(IEnumerable<Factura> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Factura> Find(Expression<Func<Factura, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Factura Get(int id)
        {
            try
            {
                Factura factura;

                using (UnidadDeTrabajo<Factura> unidad = new UnidadDeTrabajo<Factura>(context))
                {
                    factura = unidad.genericDAL.Get(id);
                }

                return factura;

            }

            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Factura> GetAll()
        {
            List<Factura> facturas;
            using (UnidadDeTrabajo<Factura> Unidad = new UnidadDeTrabajo<Factura>(context))
            {
                facturas = Unidad.genericDAL.GetAll().ToList();
            }
            return facturas;
        }

        public bool Remove(Factura entity)
        {
            try
            {
                using (UnidadDeTrabajo<Factura> unidad = new UnidadDeTrabajo<Factura>(context))
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

        public void RemoveRange(IEnumerable<Factura> entities)
        {
            throw new NotImplementedException();
        }

        public Factura SingleOrDefault(Expression<Func<Factura, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Factura entity)
        {
            try
            {
                using (UnidadDeTrabajo<Factura> unidad = new UnidadDeTrabajo<Factura>(context))
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