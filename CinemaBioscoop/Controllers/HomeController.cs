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
            //lijst met producten ophalen
            var products = GetAllProducts();

            //Lijst met producten in de html stoppen
            return View(products);
        }

        public List<Product> GetAllProducts()
        {
            // alle producten ophalen uit de database
            var rows = DatabaseConnector.GetRows("select * from product");

            //lijst maken om alle producten in te stoppen
            List<Product> products = new List<Product>();

            foreach (var row in rows)
            {
                //voor elke rij maken we nu een product
                Product p = new Product();
                p.Naam = row["naam"].ToString();
                p.Prijs = row["prijs"].ToString();
                p.Beschikbaarheid = Convert.ToInt32(row["beschikbaarheid"]);
                p.Id = Convert.ToInt32(row["id"]);

                //en dat product voegen we toe aan de lijst met producten
                products.Add(p);
            }

            return products;
        }

        [Route("/product/{id}")]
        public IActionResult Product()
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