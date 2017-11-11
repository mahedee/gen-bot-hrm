using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMBot.Web.Controllers
{
    public class QuickEntryController : Controller
    {
        // GET: QuickEntry
        public ActionResult Index()
        {
            return View();
        }

        // GET: QuickEntry/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: QuickEntry/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuickEntry/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: QuickEntry/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: QuickEntry/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: QuickEntry/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QuickEntry/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
