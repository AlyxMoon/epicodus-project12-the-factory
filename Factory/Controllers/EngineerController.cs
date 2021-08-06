using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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
    public ActionResult Index () { 
      List<Engineer> engineers = _db.Engineers
        .Include(engineer => engineer.Machines)
        .ToList();

      return View(engineers); 
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
      Engineer item = _db.Engineers.SingleOrDefault(item => item.Id == engineerId);

      return View(item);
    }

    [HttpGet("{engineerId}/remove")]
    public ActionResult Remove (int engineerId)
    {
      Engineer item = _db.Engineers.FirstOrDefault(item => item.Id == engineerId);
      _db.Engineers.Remove(item);
      _db.SaveChanges();
      
      return RedirectToAction("Index");
    }
  }
}