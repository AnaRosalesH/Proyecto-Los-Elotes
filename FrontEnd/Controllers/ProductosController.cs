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

        #region ConvertirViewModel
        private ProductoViewModel ConvertirProducto(Producto producto)
        {
            return new ProductoViewModel
            {
                IdProducto = producto.IdProducto,
                NombreProducto = producto.NombreProducto,
                IdCategoria = producto.IdCategoria,
                IdMarca = producto.IdMarca,
                RutaImagen = producto.RutaImagen,
                PrecioProducto = producto.PrecioProducto,
                CantidadProducto = producto.CantidadProducto
            };
        }
       #endregion

        #region Lista
        public IActionResult Index()
        {
            try
            {
                IEnumerable<Producto> productos;
                productos = productosDAL.GetAll();

                List<ProductoViewModel> products = new
                    List<ProductoViewModel>();

                ProductoViewModel productoViewModel;
                foreach (var item in productos)
                {
                    productoViewModel = this.ConvertirProducto(item);
                    products.Add(productoViewModel);
                }

                return View(products);
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
            try
            {
                ProductoViewModel producto = new ProductoViewModel { };

                ICategoriasDAL categoriasDAL = new CategoriasDALImpl(new db_a7b39f_diego1512Context());
                IMarcasDAL marcasDAL = new MarcasDALImpl(new db_a7b39f_diego1512Context());

                producto.Categorias = categoriasDAL.GetAll().ToList();
                producto.Marcas = marcasDAL.GetAll().ToList();

                return View(producto);
            }
            catch (Exception e)
            {

                throw;
            }
            

        }

        [HttpPost]
        public IActionResult Create(Producto producto, List<IFormFile> files)
        {
            try
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
                Producto producto = productosDAL.Get(id);

                return View(producto);
            }
            catch (Exception)
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
                ProductoViewModel producto = ConvertirProducto(productosDAL.Get(id));

                ICategoriasDAL categoriasDAL = new CategoriasDALImpl(new db_a7b39f_diego1512Context());
                IMarcasDAL marcasDAL = new MarcasDALImpl(new db_a7b39f_diego1512Context());

                producto.Categorias = categoriasDAL.GetAll().ToList();
                producto.Marcas = marcasDAL.GetAll().ToList();

                return View(producto);
            }
            catch (Exception e)
            {

                throw;
            }
            
        }

        [HttpPost]
        public IActionResult Edit(Producto producto, List<IFormFile> files)
        {
            try
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
                Producto producto = productosDAL.Get(id);

                return View(producto);
            }
            catch (Exception e)
            {

                throw;
            }
            
        }

        [HttpPost]
        public IActionResult Delete(Producto producto)
        {
            try
            {
                productosDAL.Remove(producto);
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
