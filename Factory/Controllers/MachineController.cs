using Microsoft.AspNetCore.Mvc;

namespace Factory.Controllers
{
  [Route("/machines")]
  public class MachineController : Controller
  {
    [HttpGet]
    public ActionResult Index () { return View(); }
  }
}