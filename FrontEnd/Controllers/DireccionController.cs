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
    public class DireccionController : Controller
    {


        private IDireccionDAL direccionesDAL;

        #region Constructor
        public DireccionController()
        {
            direccionesDAL = new DireccionDALImpl(new db_a7b39f_diego1512Context());
        }
        #endregion

        #region Lista
        public IActionResult Index()
        {
            IEnumerable<Direccion> direcciones;
            direcciones = direccionesDAL.GetAll();


            return View(direcciones);
        }
        #endregion


        #region Agregar
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Create(Direccion direccion)
        {
            direccionesDAL.Add(direccion);

            return RedirectToAction("Index");
        }
        #endregion


        #region Detalles

        public IActionResult Details(int id)
        {
            Direccion direccion= direccionesDAL.Get(id);

            return View(direccion);
        }
        #endregion

        #region Editar
        public IActionResult Edit(int id)
        {
            Direccion direccion = direccionesDAL.Get(id);

            return View(direccion);
        }

        [HttpPost]
        public IActionResult Edit(Direccion direccion)
        {

            direccionesDAL.Update(direccion);

            return RedirectToAction("Index");
        }


        #endregion


        #region Eliminar

        public IActionResult Delete(int id)
        {

            Direccion direccion = direccionesDAL.Get(id);

            return View(direccion);
        }

        [HttpPost]
        public IActionResult Delete(Direccion direccion)
        {
            direccionesDAL.Remove(direccion);
            return RedirectToAction("Index");
        }
        #endregion
    }
}