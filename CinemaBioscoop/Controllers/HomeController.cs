using CinemaBioscoop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MySql.Data;
using CinemaBioscoop.Database;

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

        [Route("Contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [Route("Contact")]
        public IActionResult Contact(Person person)
        {
            if (ModelState.IsValid)
            {
                // todo: oplsaan in database
                return Redirect("Succes");
            }

            return View(person);
        }

        [Route("Succes")]
        public IActionResult Succes()
        {
            return View();
        }

        [Route("Bestellen")]
        public IActionResult Bestellen()
        {
            return View();
        }

        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("FAQ")]
        public IActionResult FAQ()
        {
            return View();
        }

        [Route("Cookies")]
        public IActionResult Cookies()
        {
            return View();
        }

        [Route("Database")]
        public IActionResult Database()
        {
            //Alle producten ophalen
            var rows = DatabaseConnector.GetRows("select * from product");

            //Lijst maken om alle namen in te stoppen
            List<string> names = new List<string>();

            foreach (var row in rows)
            {
                //elke naam toevoegen aan lijst
                names.Add(row["naam"].ToString());
            }

            //de lijst met namen in html
            return View(names);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}