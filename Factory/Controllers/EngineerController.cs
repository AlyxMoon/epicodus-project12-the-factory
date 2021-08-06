using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Factory.Models;

namespace Factory.Controllers
{
  [Route("/engineers")]
  public class EngineerController : Controller
  {
    private readonly DatabaseContext _db;

    public EngineerController(DatabaseContext db)
    {
      _db = db;
    }

    [HttpGet]
    public ActionResult Index ()
    { 
      List<Engineer> engineers = _db.Engineers
        .Include(engineer => engineer.Machines)
        .ToList();

      return View(engineers); 
    }

    [HttpGet("new")]
    public ActionResult AddNew ()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create (Engineer item)
    {
      _db.Engineers.Add(item);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpGet("{engineerId}")]
    public ActionResult Details (int engineerId)
    {
      ViewBag.Machines = new SelectList(_db.Machines, "MachineId", "Name");

      Engineer item = _db.Engineers
        .Include(engineer => engineer.Machines)
        .SingleOrDefault(item => item.EngineerId == engineerId);

      return View(item);
    }

    [HttpGet("{engineerId}/remove")]
    public ActionResult Remove (int engineerId)
    {
      Engineer item = _db.Engineers.FirstOrDefault(item => item.EngineerId == engineerId);
      _db.Engineers.Remove(item);
      _db.SaveChanges();
      
      return RedirectToAction("Index");
    }

    [HttpPost("{engineerId}/machines/add")]
    public ActionResult AddMachine (int engineerId, int machineId)
    {
      Engineer engineer = _db.Engineers
        .Include(engineer => engineer.Machines)
        .SingleOrDefault(engineer => engineer.EngineerId == engineerId);

      Machine machine = _db.Machines
        .SingleOrDefault(machine => machine.MachineId == machineId);

      engineer.Machines.Add(machine);
      _db.SaveChanges();

      return RedirectToAction("Details", new { engineerId });
    }
  }
}