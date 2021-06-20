using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PierresTreats.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace PierresTreats.Controllers
{
  public class TreatsController : Controller
  {
    private readonly PierresTreatsContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public TreatsController(UserManager<ApplicationUser> userManager, PierresTreatsContext db)
    {
      _userManager = userManager;
      _db = db;
    }
    public ActionResult Index()
    {
      List<Treat> allTreats = _db.Treats.OrderBy(m => m.Name).ToList();
      return View(allTreats);
    }
    public ActionResult Create()
    {
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Description");
      return View();
    }
    [HttpPost]
    public ActionResult Create(Treat treat, int flavorId)
    {
      _db.Treats.Add(treat);
      _db.SaveChanges();
      if (flavorId != 0)
      {
        if (_db.FlavorTreats.Any(join => join.FlavorId == flavorId && join.TreatId == treat.TreatId) == false)
        {
          _db.FlavorTreats.Add(new FlavorTreat() { FlavorId = flavorId, TreatId = treat.TreatId });
        }
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      Treat thisTreat = _db.Treats
        .Include(m => m.JoinEntities)
        .ThenInclude(join => join.Flavor)
        .FirstOrDefault(m => m.TreatId == id);
      return View(thisTreat);
    }
    public ActionResult Edit(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(e => e.TreatId == id);
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Description");
      return View(thisTreat);
    }
    [HttpPost]
    public ActionResult Edit(Treat treat, int flavorId)
    {
      if (flavorId != 0)
      {
        if (_db.FlavorTreats.Any(join => join.FlavorId == flavorId && join.TreatId == treat.TreatId) == false)
        {
          _db.FlavorTreats.Add(new FlavorTreat() { FlavorId = flavorId, TreatId = treat.TreatId });
        }
      }
      _db.Entry(treat).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = treat.TreatId });
    }
    public ActionResult Delete(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(m => m.TreatId == id);
      return View(thisTreat);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(e => e.TreatId == id);
      _db.Remove(thisTreat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
