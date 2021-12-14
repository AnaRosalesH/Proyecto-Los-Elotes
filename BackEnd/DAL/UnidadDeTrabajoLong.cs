using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.DAL
{
    public class UnidadDeTrabajoLong<T> : IDisposable where T : class
    {
        private readonly db_a7b39f_diego1512Context context;
        //public IDALGenerico<Queja> quejaDAL;
        //public IDALGenerico<TablaGeneral> tablaDAL;
        public IDALGenericoLong<T> genericDAL;


        public UnidadDeTrabajoLong(db_a7b39f_diego1512Context _context)
        {
            context = _context;
            genericDAL = new DALGenericoImplLong<T>(context);
          
        }

        public bool Complete()
        {
            try
            {
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                string msj = e.Message;
                return false;
            }

        }


        public void Dispose()
        {
            context.Dispose();
        }
    }
}
