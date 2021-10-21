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
            IEnumerable<Marca> marcas;
            marcas = marcasDAL.GetAll();

            
            return View(marcas);
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
            marcasDAL.Add(marca);

            return RedirectToAction("Index");
        }
        #endregion


        #region Detalles

        public IActionResult Details(int id)
        {
            Marca marca = marcasDAL.Get(id);

            return View(marca);
        }
        #endregion

        #region Editar
        public IActionResult Edit(int id)
        {
            Marca marca = marcasDAL.Get(id);

            return View(marca);
        }

        [HttpPost]
        public IActionResult Edit(Marca marca)
        {

            marcasDAL.Update(marca);

            return RedirectToAction("Index");
        }


        #endregion


        #region Eliminar

        public IActionResult Delete(int id)
        {

            Marca marca = marcasDAL.Get(id);

            return View(marca);
        }

        [HttpPost]
        public IActionResult Delete(Marca marca)
        {
            marcasDAL.Remove(marca);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
