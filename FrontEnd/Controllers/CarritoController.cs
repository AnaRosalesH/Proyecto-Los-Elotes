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
    public class CarritoController : Controller
    {

        private ICarritoDAL carritoDAL;

        #region Constructor
        public CarritoController()
        {
           carritoDAL = new CarritoDALImpl(new db_a7b39f_diego1512Context());
        }
        #endregion

        public IActionResult Index()
        {

            try
            {
                if (TempData["IdRol"] != null)
                {
                    TempData.Keep("IdRol");
                    if (TempData["IdRol"].ToString().Equals("1") || TempData["IdRol"].ToString().Equals("2"))
                    {
                        TempData.Keep("IdRol");
                        int cedula = (int)TempData["Cedula"];
                        TempData.Keep("Cedula");
                        IEnumerable<Carrito> carrito;
                        carrito = carritoDAL.GetCarrito(cedula);

                        return View(carrito);
                    }
                    else
                    {
                        TempData.Keep("IdRol");
                        return RedirectToAction("Index", "Home");
                    }


                }
                else
                {
                    TempData.Keep("IdRol");
                    return RedirectToAction("Index", "Home");

                }

            }
            catch (Exception e)
            {
                TempData.Keep("IdRol");
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult EliminarCarrito()
        {

            try
            {
                        int cedula = (int)TempData["Cedula"];
                        TempData.Keep("Cedula");
                        carritoDAL.EliminarCarrito(cedula);
                        return RedirectToAction("Index", "Home");

            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult ComprarCarrito()
        {
            string correo = (string)TempData["Correo"];
            TempData.Keep("Correo");

            try
            {
                int cedula = (int)TempData["Cedula"];
                TempData.Keep("Cedula");
                carritoDAL.ComprarCarrito(cedula, correo);
                return RedirectToAction("Index", "Home");

            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult AgregarCarrito(int idProducto)
        {
            try
            {
                int cedula = (int)TempData["Cedula"];
                TempData.Keep("Cedula");

                carritoDAL.AgregarAlCarrito(idProducto, cedula);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                throw;
            }
            
        }
    }
}
