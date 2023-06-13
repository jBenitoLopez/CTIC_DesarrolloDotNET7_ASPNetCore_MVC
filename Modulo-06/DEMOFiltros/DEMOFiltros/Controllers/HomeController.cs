using DEMOFiltros.Extensions.Filters;
using DEMOFiltros.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DEMOFiltros.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [ResponseCache(Duration = 10)]
        public IActionResult Index()
        {
            return View();
        }

        [SimpleCache]
        public IActionResult GetTime()
        {
            return Content(DateTime.Now.ToString("T"));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}