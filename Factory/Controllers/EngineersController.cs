using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Factory.Models;

namespace Factory.Controllers
{
    public class EngineersController : Controller
    {
        private readonly FactoryContext _db;
        public EngineerController(FactoryContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Engineer> engineers = _db.Engineers.ToList();
            return View(engineers);
        }
    }
}