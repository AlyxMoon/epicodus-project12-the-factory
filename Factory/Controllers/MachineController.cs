using System.Threading.Tasks;
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

    [HttpGet("{machineId}/edit")]
    public ActionResult Edit (int machineId)
    {
      Machine machine = _db.Machines
        .SingleOrDefault(item => item.MachineId == machineId);

      return View(machine);
    }

    [HttpPost("{machineId}/edit")]
    public async Task<ActionResult> EditPost (int machineId)
    {
      Machine machine = await _db.Machines
        .SingleOrDefaultAsync(item => item.MachineId == machineId);

      if (await TryUpdateModelAsync<Machine>(machine, "", 
        m => m.Name, m => m.Product
      ))
      {
        await _db.SaveChangesAsync();
      }

      return RedirectToAction("Details", new { machineId });
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

    [HttpGet("{machineId}/machines/remove")]
    public ActionResult RemoveEngineer (int machineId, int engineerId)
    {
      Machine machine = _db.Machines
        .Include(machine => machine.Engineers)
        .SingleOrDefault(machine => machine.MachineId == machineId);

      Engineer engineer = _db.Engineers
        .SingleOrDefault(engineer => engineer.EngineerId == engineerId);

      machine.Engineers.Remove(engineer);
      _db.SaveChanges();

      return RedirectToAction("Details", new { machineId });
    }
  }
}