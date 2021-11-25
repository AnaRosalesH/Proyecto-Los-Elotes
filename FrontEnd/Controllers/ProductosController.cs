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
    public class ProductosController : Controller
    {


        private IProductosDAL productosDAL;
        
        #region Constructor
        public ProductosController()
        {
            productosDAL = new ProductosDALImpl(new db_a7b39f_diego1512Context());
        }
        #endregion

        #region Lista
        public IActionResult Index()
        {
            IEnumerable<Producto> productos;
            productos = productosDAL.GetAll();

            
            return View(productos);
        }
        #endregion


        #region Agregar
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Create(Producto producto)
        {

            productosDAL.Add(producto);


            return RedirectToAction("Index");
        }
        #endregion


        #region Detalles

        public IActionResult Details(int id)
        {
            Producto producto = productosDAL.Get(id);

            return View(producto);
        }
        #endregion

        #region Editar
        public IActionResult Edit(int id)
        {
            Producto producto = productosDAL.Get(id);

            return View(producto);
        }

        [HttpPost]
        public IActionResult Edit(Producto producto)
        {

            productosDAL.Update(producto);

            return RedirectToAction("Index");
        }


        #endregion


        #region Eliminar

        public IActionResult Delete(int id)
        {

            Producto producto = productosDAL.Get(id);

            return View(producto);
        }

        [HttpPost]
        public IActionResult Delete(Producto producto)
        {
            productosDAL.Remove(producto);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
