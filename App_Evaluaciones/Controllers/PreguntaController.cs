using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App_Evaluaciones.Controllers
{
    public class PreguntaController : Controller
    {
        // GET: PreguntaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PreguntaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PreguntaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PreguntaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PreguntaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PreguntaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PreguntaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PreguntaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
