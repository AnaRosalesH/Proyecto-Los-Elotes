using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    public class MarcasController : Controller
    {
        private IMarcasDAL marcasDAL;
        
        #region Constructor
        public MarcasController()
        {
            marcasDAL = new MarcasDALImpl(new db_a7b39f_diego1512Context());
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
                        IEnumerable<Marca> marcas;
                        marcas = marcasDAL.GetAll();


                        return View(marcas);
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
        public IActionResult Create(Marca marca)
        {
            try
            {
                marcasDAL.Add(marca);

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
                        Marca marca = marcasDAL.Get(id);

                        return View(marca);
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
                        Marca marca = marcasDAL.Get(id);

                        return View(marca);
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
            catch (Exception)
            {

                throw;
            }
            
        }

        [HttpPost]
        public IActionResult Edit(Marca marca)
        {
            try
            {
                marcasDAL.Update(marca);

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
                        Marca marca = marcasDAL.Get(id);

                        return View(marca);
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
        public IActionResult Delete(Marca marca)
        {
            try
            {
                marcasDAL.Remove(marca);
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
