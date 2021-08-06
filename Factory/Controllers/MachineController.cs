using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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
    public ActionResult Index () { 
      List<Machine> machines = _db.Machines
        .Include(machine => machine.Engineers)
        .ToList();

      return View(machines); 
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
      Machine item = _db.Machines.SingleOrDefault(item => item.Id == machineId);

      return View(item);
    }

    [HttpGet("{machineId}/remove")]
    public ActionResult Remove (int machineId)
    {
      Machine item = _db.Machines.FirstOrDefault(item => item.Id == machineId);
      _db.Machines.Remove(item);
      _db.SaveChanges();
      
      return RedirectToAction("Index");
    }
  }
}