using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    public class FacturaController : Controller
    {
        private IFacturaDAL facturasDAL;

        #region Constructor
        public FacturaController()
        {
            facturasDAL = new FacturaDALImpl(new db_a7b39f_diego1512Context());
        }
        #endregion


        #region Lista
        public IActionResult Index()
        {

            try
            {
                if (TempData["IdRol"] != null)
                {
                    if (TempData["IdRol"].ToString().Equals("1"))
                    {
                        IEnumerable<Factura> facturas;
                        facturas = facturasDAL.GetAll();


                        return View(facturas);
                    }
                    else
                    {
                        TempData.Keep("IdRol");
                        return RedirectToAction("Index", "Home");
                    }

                }
                else
                {
                    TempData.Keep("IdRol");
                    return RedirectToAction("Index", "Home");

                }
                
            }
            catch (Exception e)
            {

                throw;
            }
           
        }
        #endregion



    }
}
