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
            IEnumerable<Categoria> categorias;
            categorias = categoriasDAL.GetAll();


            return View(categorias);
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
            categoriasDAL.Add(categoria);

            return RedirectToAction("Index");
        }
        #endregion

        #region Detalles

        public IActionResult Details(int id)
        {
            Categoria categoria = categoriasDAL.Get(id);

            return View(categoria);
        }
        #endregion

        #region Editar
        public IActionResult Edit(int id)
        {
            Categoria categoria = categoriasDAL.Get(id);

            return View(categoria);
        }

        [HttpPost]
        public IActionResult Edit(Categoria categoria)
        {

            categoriasDAL.Update(categoria);

            return RedirectToAction("Index");
        }
        #endregion

        #region Eliminar

        public IActionResult Delete(int id)
        {

            Categoria categoria = categoriasDAL.Get(id);

            return View(categoria);
        }

        [HttpPost]
        public IActionResult Delete(Categoria categoria)
        {
            categoriasDAL.Remove(categoria);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
