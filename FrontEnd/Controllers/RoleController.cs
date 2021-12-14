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

            try
            {
                if (TempData["IdRol"] != null)
                {
                    if (TempData["IdRol"].ToString().Equals("1"))
                    {
                        IEnumerable<Role> roles;
                        roles = rolesDAL.GetAll();


                        return View(roles);
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

                throw;
            }
           
        }
        #endregion

        #region Agregar
        public IActionResult Create()
        {
            if (TempData["IdRol"] != null)
            {
                if (TempData["IdRol"].ToString().Equals("1"))
                {
                    return View();
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

        [HttpPost]
        public IActionResult Create(Role roles)
        {
            try
            {
                rolesDAL.Add(roles);

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
                if (TempData["IdRol"] != null)
                {
                    if (TempData["IdRol"].ToString().Equals("1"))
                    {
                        Role roles = rolesDAL.Get(id);

                        return View(roles);
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

                throw;
            }
            
        }
        #endregion

        #region Editar
        public IActionResult Edit(int id)
        {
            try
            {
                if (TempData["IdRol"] != null)
                {
                    if (TempData["IdRol"].ToString().Equals("1"))
                    {
                        Role roles = rolesDAL.Get(id);

                        return View(roles);
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

                throw;
            }
           
        }

        [HttpPost]
        public IActionResult Edit(Role roles)
        {
            try
            {
                rolesDAL.Update(roles);

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
                if (TempData["IdRol"] != null)
                {
                    if (TempData["IdRol"].ToString().Equals("1"))
                    {
                        Role roles = rolesDAL.Get(id);

                        return View(roles);
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

                throw;
            }
           
        }

        [HttpPost]
        public IActionResult Delete(Role roles)
        {
            try
            {
                rolesDAL.Remove(roles);
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
