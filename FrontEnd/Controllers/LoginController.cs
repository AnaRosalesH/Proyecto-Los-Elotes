using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    public class LoginController : Controller
    {
        

        public LoginController(db_a7b39f_diego1512Context context)
        {
            
        }

        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IniciarSesion(Usuario usr)
        {
            try
            {
                using (var db = new db_a7b39f_diego1512Context())
                {
                    var usuario = (from x in db.Usuarios
                                   where x.NombreUsuario == usr.NombreUsuario &&
             x.Contrasena == usr.Contrasena
                                   select x).FirstOrDefault();

                    if (usuario != null)
                    {

                        TempData["DatosUsuario"] = "siHay";

                        TempData["Cedula"] = (int)usuario.Cedula;
                        TempData["NombreUsuario"] = usuario.NombreUsuario;
                        TempData["Correo"] = usuario.Correo;
                        TempData["Nombre"] = usuario.Nombre;
                        TempData["Apellido"] = usuario.Apellido;
                        TempData["IdRol"] = usuario.IdRol;

                        return RedirectToAction("Index", "Home");

                    }
                    else
                    {
                        ViewBag.mensaje = "Error al iniciar sesión.";
                    }
                }

                return View();
            }
            catch (Exception e)
            {

                throw;
            }

           
        }

        public IActionResult CerrarSesion()
        {
            TempData["Cedula"] = null;
            TempData["NombreUsuario"] = null;
            TempData["Correo"] = null;
            TempData["Nombre"] = null;
            TempData["Apellido"] = null;
            TempData["IdRol"] = null;

            TempData["DatosUsuario"] = null;

            return RedirectToAction("Index", "Home");
        }





    }
}
