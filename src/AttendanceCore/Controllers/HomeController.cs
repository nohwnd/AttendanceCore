using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AttendanceCore.Infrastructure;
using AttendanceCore.Services;
using AttendanceCore.ViewModels.Home;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace AttendanceCore.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IEntryService _service;

        public HomeController(IEntryService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(EntryViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(vm);

                if (ModelState.IsValid)
                {
                    await _service.AddEntryAsync(vm);

                    ViewBag.Result = new Result {Type = "success", Message = "Entry was saved successfully."};
                    ModelState.Clear();
                    return View();
                }
                return View(vm);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);

                ViewBag.Result = new Result {Type = "danger", Message = "There was some unexpected error, sorry."};
                return View(vm);
            }
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