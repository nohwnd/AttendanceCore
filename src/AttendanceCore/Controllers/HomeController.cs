using System;
using System.Security.Claims;
using AttendanceCore.Infrastructure;
using AttendanceCore.Models;
using AttendanceCore.ViewModels.Home;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace AttendanceCore.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(EntryViewModel vm)
        {
            var id = Guid.Parse(User.GetUserId());
            if (ModelState.IsValid)
            {
                _context.Entries.Add(new Entry
                {
                    Note = vm.Note,
                    PersonId = id,
                    Time = DateTimeOffset.Now,
                    Type = (EntryType) vm.EntryType
                });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}