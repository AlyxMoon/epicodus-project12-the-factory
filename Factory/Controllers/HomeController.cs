using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Factory.Models;
using Factory.ViewModels;

namespace Factory.Controllers
{
  [Route("/")]
  public class HomeController : Controller
  {
    private readonly DatabaseContext _db;

    public HomeController(DatabaseContext db)
    {
      _db = db;
    }

    [HttpGet]
    public ActionResult Index () 
    {
      AllEngineersAndMachines data = new () {
        Engineers = _db.Engineers
          .Include(engineer => engineer.Machines)
          .ToList(),
        Machines = _db.Machines
          .Include(machine => machine.Engineers)
          .ToList()
      };

      return View(data);
    }
  }
}