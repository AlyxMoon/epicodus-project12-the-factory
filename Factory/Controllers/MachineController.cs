using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Factory.Models;

namespace Factory.Controllers
{
  [Route("/machines")]
  public class MachineController : Controller
  {
    private readonly DatabaseContext _db;

    public MachineController(DatabaseContext db)
    {
      _db = db;
    }

    [HttpGet]
    public ActionResult Index () 
    { 
      List<Machine> machines = _db.Machines
        .Include(machine => machine.Engineers)
        .ToList();

      return View(machines); 
    }

    [HttpGet("new")]
    public ActionResult AddNew ()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create (Machine item)
    {
      _db.Machines.Add(item);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpGet("{machineId}")]
    public ActionResult Details (int machineId)
    {
      Machine machine = _db.Machines
        .Include(machine => machine.Engineers)
        .SingleOrDefault(item => item.MachineId == machineId);      

      IEnumerable<Engineer> engineers = _db.Engineers
        .AsEnumerable()
        .Where(engineer => machine.Engineers.All(engineerMachine => 
          engineerMachine.EngineerId != engineer.EngineerId
        ));

      ViewBag.Engineers = new SelectList(engineers, "EngineerId", "Name");

      return View(machine);
    }

    [HttpGet("{machineId}/remove")]
    public ActionResult Remove (int machineId)
    {
      Machine item = _db.Machines.FirstOrDefault(item => item.MachineId == machineId);
      _db.Machines.Remove(item);
      _db.SaveChanges();
      
      return RedirectToAction("Index");
    }

    [HttpPost("{machineId}/machines/add")]
    public ActionResult AddEngineer (int machineId, int engineerId)
    {
      Machine machine = _db.Machines
        .Include(machine => machine.Engineers)
        .SingleOrDefault(machine => machine.MachineId == machineId);

      Engineer engineer = _db.Engineers
        .SingleOrDefault(engineer => engineer.EngineerId == engineerId);

      machine.Engineers.Add(engineer);
      _db.SaveChanges();

      return RedirectToAction("Details", new { machineId });
    }
  }
}