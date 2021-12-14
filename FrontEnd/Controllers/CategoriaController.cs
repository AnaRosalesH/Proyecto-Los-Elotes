using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    public class CategoriaController : Controller
    {

         private ICategoriasDAL categoriasDAL;
        
        #region Constructor
        public CategoriaController()
        {
            categoriasDAL = new CategoriasDALImpl(new db_a7b39f_diego1512Context());
        }
        #endregion

        #region Lista
        public IActionResult Index()
        {
            try
            {
                IEnumerable<Categoria> categorias;
                categorias = categoriasDAL.GetAll();


                return View(categorias);
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
        public IActionResult Create(Categoria categoria)
        {
            try
            {
                categoriasDAL.Add(categoria);

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
                Categoria categoria = categoriasDAL.Get(id);

                return View(categoria);
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
                Categoria categoria = categoriasDAL.Get(id);

                return View(categoria);
            }
            catch (Exception e)
            {

                throw;
            }
           
        }

        [HttpPost]
        public IActionResult Edit(Categoria categoria)
        {
            try
            {
                categoriasDAL.Update(categoria);

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
                Categoria categoria = categoriasDAL.Get(id);

                return View(categoria);
            }
            catch (Exception e)
            {

                throw;
            }
         
        }

        [HttpPost]
        public IActionResult Delete(Categoria categoria)
        {
            try
            {
                categoriasDAL.Remove(categoria);
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
