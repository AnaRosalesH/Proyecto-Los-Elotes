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
                IEnumerable<Factura> facturas;
                facturas = facturasDAL.GetAll();


                return View(facturas);
            }
            catch (Exception e)
            {

                throw;
            }
           
        }
        #endregion

        #region Agregar
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Create(Factura factura)
        {
            try
            {
                facturasDAL.Add(factura);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                throw;
            }
           
        }
        #endregion

        #region Editar
        public IActionResult Edit(int id)
        {
            try
            {
                Factura factura = facturasDAL.Get(id);

                return View(factura);
            }
            catch (Exception e)
            {

                throw;
            }
           
        }

        [HttpPost]
        public IActionResult Edit(Factura factura)
        {
            try
            {
                facturasDAL.Update(factura);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                throw;
            }
            
        }


        #endregion

        #region Eliminar

        public IActionResult Delete(int id)
        {
            try
            {
                Factura factura = facturasDAL.Get(id);

                return View(factura);
            }
            catch (Exception e)
            {

                throw;
            }
            
        }

        [HttpPost]
        public IActionResult Delete(Factura factura)
        {
            try
            {
                facturasDAL.Remove(factura);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                throw;
            }
            
        }
        #endregion

    }
}
