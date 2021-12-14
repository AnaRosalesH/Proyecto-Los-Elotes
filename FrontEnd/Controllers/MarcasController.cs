using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    public class MarcasController : Controller
    {
        private IMarcasDAL marcasDAL;
        
        #region Constructor
        public MarcasController()
        {
            marcasDAL = new MarcasDALImpl(new db_a7b39f_diego1512Context());
        }
        #endregion

        #region Lista
        public IActionResult Index()
        {
            try
            {
                IEnumerable<Marca> marcas;
                marcas = marcasDAL.GetAll();


                return View(marcas);
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
        public IActionResult Create(Marca marca)
        {
            try
            {
                marcasDAL.Add(marca);

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
                Marca marca = marcasDAL.Get(id);

                return View(marca);
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
                Marca marca = marcasDAL.Get(id);

                return View(marca);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        [HttpPost]
        public IActionResult Edit(Marca marca)
        {
            try
            {
                marcasDAL.Update(marca);

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
                Marca marca = marcasDAL.Get(id);

                return View(marca);
            }
            catch (Exception e)
            {

                throw;
            }
           
        }

        [HttpPost]
        public IActionResult Delete(Marca marca)
        {
            try
            {
                marcasDAL.Remove(marca);
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
