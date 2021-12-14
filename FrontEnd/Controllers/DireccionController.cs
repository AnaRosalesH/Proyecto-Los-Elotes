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
            try
            {
                IEnumerable<Direccion> direcciones;
                direcciones = direccionesDAL.GetAll();


                return View(direcciones);
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
        public IActionResult Create(Direccion direccion)
        {
            try
            {
                direccionesDAL.Add(direccion);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                throw;
            }
            
        }
        #endregion


        #region Detalles

        public IActionResult Details(int id)
        {
            try
            {
                Direccion direccion = direccionesDAL.Get(id);

                return View(direccion);
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
                Direccion direccion = direccionesDAL.Get(id);

                return View(direccion);
            }
            catch (Exception e)
            {

                throw;
            }
            
        }

        [HttpPost]
        public IActionResult Edit(Direccion direccion)
        {
            try
            {
                direccionesDAL.Update(direccion);

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
                Direccion direccion = direccionesDAL.Get(id);

                return View(direccion);
            }
            catch (Exception e)
            {

                throw;
            }
         
        }

        [HttpPost]
        public IActionResult Delete(Direccion direccion)
        {
            try
            {
                direccionesDAL.Remove(direccion);
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