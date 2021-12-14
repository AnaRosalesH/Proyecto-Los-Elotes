using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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
        public IActionResult Create(Producto producto, List<IFormFile> files)
        {

            var file = Request.Form.Files[0];
            var root = Path.Combine("wwwroot");
            var folderName = Path.Combine("img");
            var PathToSave = Path.Combine(Directory.GetCurrentDirectory(), root, folderName);
       
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(PathToSave, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

            }

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
        public IActionResult Edit(Producto producto, List<IFormFile> files)
        {

            var file = Request.Form.Files[0];
            var root = Path.Combine("wwwroot");
            var folderName = Path.Combine("img");
            var PathToSave = Path.Combine(Directory.GetCurrentDirectory(), root, folderName);

            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(PathToSave, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

            }

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
