using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Factory.Models;

namespace Factory.Controllers
{
    public class MachinesController : Controller
    {
        private readonly FactoryContext _db;
        public MachinesController(FactoryContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Machine> machines = _db.Machines.ToList();
            return View(machines);
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Machine machine)
        {
            _db.Machines.Add(machine);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Show(int id)
        {
            Machine machine = _db.Machines
                .Include(model => model.EngineerMachines)
                .ThenInclude(model => model.Engineer)
                .FirstOrDefault(machine => machine.MachineId == id);
            return View(machine);
        }

        public ActionResult Edit(int id)
        {
            Machine machine = _db.Machines
                .FirstOrDefault(machine => machine.MachineId == id);
            return View(machine);
        }

        [HttpPost]
        public ActionResult Update(Machine machine)
        {
            _db.Machines.Update(machine);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Machine machine = _db.Machines
                .FirstOrDefault(machine => machine.MachineId == id);
            return View(machine);
        }

        [HttpPost]
        public ActionResult Destroy(int id)
        {
            Machine machine = _db.Machines
                .FirstOrDefault(machine => machine.MachineId == id);
            _db.Machines.Remove(machine);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddEngineer(int id)
        {
            Machine machine = _db.Machines
                .FirstOrDefault(model => model.MachineId == id);
            ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
            return View(machine);
        }

        [HttpPost]
        public ActionResult AddEngineer(Machine machine, int engineerId)
        {
#nullable enable
            EngineerMachine? engineerMachine = _db.EngineerMachines
                .FirstOrDefault(model => (model.EngineerId == engineerId && model.MachineId == machine.MachineId));
#nullable disable
            if (engineerMachine == null && engineerId != 0)
            {
                _db.EngineerMachines.Add(new EngineerMachine() { EngineerId = engineerId, MachineId = machine.MachineId });
                _db.SaveChanges();
            }
            return RedirectToAction("Show", new { id = machine.MachineId });
        }
    }
}