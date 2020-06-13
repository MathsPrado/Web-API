using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SmartSchool.API.Controllers
{
    public class LixoController : Controller
    {
        // GET: Lixo
        public ActionResult Index()
        {
            return View();
        }

        // GET: Lixo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Lixo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lixo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Lixo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Lixo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Lixo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Lixo/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}