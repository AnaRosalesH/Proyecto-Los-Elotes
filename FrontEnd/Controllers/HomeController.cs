using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {

        private IProductosDAL homeDAL;
        private ICarritoDAL carro;

        #region Constructor
        public HomeController()
        {
           homeDAL = new ProductosDALImpl(new db_a7b39f_diego1512Context());
        }
        #endregion

        public IActionResult Index()
        {
            IEnumerable<Producto> productos;
            productos = homeDAL.GetAll();

            if (TempData["IdRol"] == null)
            {
                TempData["IdRol"] = 3;
                
            }

            TempData.Keep("IdRol");

        

            return View(productos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
