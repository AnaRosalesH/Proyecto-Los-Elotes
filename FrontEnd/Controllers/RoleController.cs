using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    public class RoleController : Controller
    {

         private IRolesDAL rolesDAL;
        
        #region Constructor
        public RoleController()
        {
            rolesDAL = new RolesDALImpl(new db_a7b39f_diego1512Context());
        }
        #endregion
        #region Lista
        public IActionResult Index()
        {
            IEnumerable<Role> roles;
            roles = rolesDAL.GetAll();


            return View(roles);
        }
        #endregion

        #region Agregar
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Create(Role roles)
        {
            rolesDAL.Add(roles);

            return RedirectToAction("Index");
        }
        #endregion

        #region Detalles

        public IActionResult Details(int id)
        {
            Role roles = rolesDAL.Get(id);

            return View(roles);
        }
        #endregion

        #region Editar
        public IActionResult Edit(int id)
        {
            Role roles = rolesDAL.Get(id);

            return View(roles);
        }

        [HttpPost]
        public IActionResult Edit(Role roles)
        {

            rolesDAL.Update(roles);

            return RedirectToAction("Index");
        }
        #endregion

        #region Eliminar

        public IActionResult Delete(int id)
        {

            Role roles = rolesDAL.Get(id);

            return View(roles);
        }

        [HttpPost]
        public IActionResult Delete(Role roles)
        {
            rolesDAL.Remove(roles);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
