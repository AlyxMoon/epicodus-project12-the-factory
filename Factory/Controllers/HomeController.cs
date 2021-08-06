using Microsoft.AspNetCore.Mvc;

namespace Factory.Controllers
{
  [Route("/")]
  public class HomeController : Controller
  {
    [HttpGet]
    public ActionResult Index () { return View(); }
  }
}