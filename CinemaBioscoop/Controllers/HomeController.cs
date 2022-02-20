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

        [Route("Bestellen1")]
        public IActionResult Bestellen1()
        {
            return View();
        }

        [Route("Bestellen2")]
        public IActionResult Bestellen2()
        {
            return View();
        }

        [Route("Bestellen3")]
        public IActionResult Bestellen3()
        {
            return View();
        }

        [Route("Bestellen4")]
        public IActionResult Bestellen4()
        {
            return View();
        }

        [Route("Bestellen5")]
        public IActionResult Bestellen5()
        {
            return View();
        }

        [Route("Bestellen6")]
        public IActionResult Bestellen6()
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