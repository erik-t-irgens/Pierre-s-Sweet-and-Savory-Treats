using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using PierresSweets.Models;
using System.Threading.Tasks;
using System.Security.Claims;

namespace PierresSweets.Controllers
{
    [Authorize]
    public class FlavorsController : Controller
    {
     private readonly PierresSweetsContext _db;
     private readonly UserManager<ApplicationUser> _userManager;

     public FlavorsController(UserManager<ApplicationUser> userManager, PierresSweetsContext db)
     {
         _userManager = userManager;
         _db = db;
     }

     public async Task<ActionResult> Index()
     {
          var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            return View(_db.Flavors
                .Where(x => x.User.Id == currentUser.Id).ToList());
     }

      public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Flavor flavor)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            flavor.User = currentUser;
            _db.Flavors.Add(flavor);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            var thisFlavor = _db.Flavors
                .Include(flavor => flavor.Treats)
                .ThenInclude(join => join.Treat)
                .Where(flavor => flavor.User.Id == currentUser.Id)  // queries for only flavors with the current user's Id
                .FirstOrDefault(flavor => flavor.FlavorId == id);
            if (thisFlavor != null)
            {
                return View(thisFlavor);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }

        public async Task<ActionResult> Edit(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            var thisFlavor = _db.Flavors
                .Where(r => r.User.Id == currentUser.Id)
                .FirstOrDefault(flavors => flavors.FlavorId == id);
            if (thisFlavor != null)
            {
                return View(thisFlavor);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult Edit(Flavor flavor)
        {
            _db.Entry(flavor).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");               
        }

      public async Task<ActionResult> Delete(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            var thisFlavor = _db.Flavors
                .Where(r => r.User.Id == currentUser.Id)
                .FirstOrDefault(flavors => flavors.FlavorId == id);
            if (thisFlavor != null)
            {
                return View(thisFlavor);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisFlavor = _db.Flavors
                .FirstOrDefault(flavors => flavors.FlavorId == id);
            _db.Flavors.Remove(thisFlavor);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}