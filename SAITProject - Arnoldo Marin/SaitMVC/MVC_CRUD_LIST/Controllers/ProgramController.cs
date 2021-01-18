using MVC_CRUD_LIST.Models;
using MVC_CRUD_LIST.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using static MVC_CRUD_LIST.Models.SaitPrograms;

namespace MVC_CRUD_LIST.Controllers
{
    /// <summary>
    /// Controller of the Aplication that recieves input from the views and processes their requests. It also gets the data from model (SaitPrograms) and passes it to the Views.
    /// </summary>
    public class ProgramController : Controller
    {
        ProgramRepository progRepo = new ProgramRepository();


        /// <summary>
        /// Controller method that returns data model to the Index View
        /// </summary>
        /// <param name="SearchString">Status of SAIT program to be searched for</param>
        /// <param name="searchModel">Data Model for SAIT Programs</param>
        /// <returns></returns>
        public ActionResult Index(string SearchString, ProgramSearchModel searchModel)
        {            
            IEnumerable<SaitPrograms> obj = progRepo.SelectAllPrograms();


            // Make the table searchable by Program Status
            if (!String.IsNullOrEmpty(SearchString))
            {
                obj = obj.Where(s => (s.ProgramStatus.Contains(SearchString))).ToList();
            }

            return View(obj);
        }

        public ActionResult Create()
        {            
            return View();
        }

        /// <summary>
        /// Controller method that returns data model to the Create View.
        /// </summary>
        /// <param name="prog">Program to be created</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(SaitPrograms prog)
        {
            try
            {
                progRepo.InsertProgram(prog);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        /// <summary>
        /// Controller method that returns data model to the Delete View.
        /// </summary>
        /// <param name="id">ID of program to be deleted</param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            SaitPrograms prog = progRepo.SelectProgramById(id);
            return View(prog);
        }


        /// <summary>
        /// Controller method that returns data model to the Delete View.
        /// </summary>
        /// <param name="id">ID of program to be deleted</param>
        /// <param name="collection"> Collection of values of form elements</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                progRepo.DeleteProgram(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
