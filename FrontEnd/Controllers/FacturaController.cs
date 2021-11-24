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
            IEnumerable<Factura> facturas;
            facturas = facturasDAL.GetAll();


            return View(facturas);
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
            facturasDAL.Add(factura);
          
            return RedirectToAction("Index");
        }
        #endregion

        #region Editar
        public IActionResult Edit(int id)
        {
            Factura factura = facturasDAL.Get(id);

            return View(factura);
        }

        [HttpPost]
        public IActionResult Edit(Factura factura)
        {

            facturasDAL.Update(factura);

            return RedirectToAction("Index");
        }


        #endregion

        #region Eliminar

        public IActionResult Delete(int id)
        {

            Factura factura = facturasDAL.Get(id);

            return View(factura);
        }

        [HttpPost]
        public IActionResult Delete(Factura factura)
        {
            facturasDAL.Remove(factura);
            return RedirectToAction("Index");
        }
        #endregion

    }
}
