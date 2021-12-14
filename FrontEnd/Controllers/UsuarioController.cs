using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    public class UsuarioController : Controller
    {

         private IUsuarioDAL usuariosDAL;
        
        #region Constructor
        public UsuarioController()
        {
            usuariosDAL = new UsuarioDALImpl(new db_a7b39f_diego1512Context());
        }
        #endregion
        #region Lista
        public IActionResult Index()
        {
            IEnumerable<Usuario> usuarios;
            usuarios = usuariosDAL.GetAll();


            return View(usuarios);
        }
        #endregion

        #region Agregar
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            usuario.IdRol = 2;
            usuariosDAL.Add(usuario);

            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Detalles

        public IActionResult Details(int id)
        {
            Usuario usuario = usuariosDAL.Get(id);

            return View(usuario);
        }
        #endregion

        #region Editar
        public IActionResult Edit()
        {
            int id = (int)TempData["Cedula"];

            TempData.Keep("Cedula");

            int idRol = (int)TempData["IdRol"];
            TempData.Keep("IdRol");

            Usuario usuario = usuariosDAL.Get(id);

            return View(usuario);
        }

        [HttpPost]
        public IActionResult Edit(Usuario usuario)
        {

            if ((int)TempData["IdRol"] == 1)
            {
                usuario.IdRol = 1;
            } else
            {
                usuario.IdRol = 2;
            }

            TempData.Keep("IdRol");
           

                usuariosDAL.Update(usuario);

            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Eliminar

        public IActionResult Delete(int id)
        {

            Usuario usuario = usuariosDAL.Get(id);

            return View(usuario);
        }

        [HttpPost]
        public IActionResult Delete(Usuario usuario)
        {
            usuariosDAL.Remove(usuario);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
