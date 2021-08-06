using Microsoft.AspNetCore.Mvc;

namespace Factory.Controllers
{
  [Route("/engineers")]
  public class EngineerController : Controller
  {
    [HttpGet]
    public ActionResult Index () { return View(); }
  }
}