using CinemaBioscoop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CinemaBioscoop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Films")]
        public IActionResult Films()
        {
            return View();
        }

        [Route("Filmagenda")]
        public IActionResult Filmagenda()
        {
            return View();
        }

        [Route("Bioscoop")]
        public IActionResult Bioscoop()
        {
            return View();
        }

        [Route("Detailpagina")]
        public IActionResult Detailpagina()
        {
            return View();
        }

        [Route("Bestellen")]
        public IActionResult Bestellen1()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}