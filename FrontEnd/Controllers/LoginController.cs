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

        private readonly db_a7b39f_diego1512Context _context;

        public LoginController(db_a7b39f_diego1512Context context)
        {
            _context = context;
        }

        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IniciarSesion(Usuario usr)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.mensaje = "Error al iniciar sesión.";
                return View();
            }

            using (var db = new db_a7b39f_diego1512Context())
            {
                var usuario = (from x in db.Usuarios where x.NombreUsuario == usr.NombreUsuario &&
                               x.Contrasena == usr.Contrasena select x).FirstOrDefault();

                if (usuario != null)
                {
                    TempData["Cedula"] = (int)usuario.Cedula; 
                    TempData["NombreUsuario"] = usuario.NombreUsuario;
                    TempData["Correo"] = usuario.Correo;
                    TempData["Nombre"] = usuario.Nombre;
                    TempData["Apellido"] = usuario.Apellido;
                    TempData["IdRol"] = usuario.IdRol;

                    return RedirectToAction("Index", "Home");

                }
            }

            return View();
        }
    }
}
