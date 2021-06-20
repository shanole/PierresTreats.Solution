using Microsoft.AspNetCore.Mvc;

namespace PierresTreats.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}