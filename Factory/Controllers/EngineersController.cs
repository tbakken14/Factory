using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using Factory.Models;

namespace Factory.Controllers
{
    public class EngineersController : Controller
    {
        private readonly FactoryContext _db;
        public EngineersController(FactoryContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Engineer> engineers = _db.Engineers.ToList();
            return View(engineers);
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Engineer engineer)
        {
            _db.Engineers.Add(engineer);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Show(int id)
        {
            Engineer engineer = _db.Engineers
                .FirstOrDefault(engineer => engineer.EngineerId == id);
            return View(engineer);
        }

        public ActionResult Edit(int id)
        {
            Engineer engineer = _db.Engineers
                .FirstOrDefault(engineer => engineer.EngineerId == id);
            return View(engineer);
        }

        [HttpPost]
        public ActionResult Update(Engineer engineer)
        {
            _db.Engineers.Update(engineer);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}