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

        //[Route("Detailpagina")]
        //public IActionResult Detailpagina()
        //{
        //    lijst met films ophalen
        //    var films = GetAllFilms();

        //    Lijst met films in de html stoppen
        //    return View(films);
        //}

        //public List<Film> GetAllFilms()
        //{
        //    alle films ophalen uit de database
        //    var rows = DatabaseConnector.GetRows("select * from film");

        //    lijst maken om alle films in te stoppen
        //    List<Film> films = new List<Film>();

        //    foreach (var row in rows)
        //    {
        //        voor elke rij maken we nu een film
        //        Film f = new Film();
        //        f.Trailer = row["trailer"].ToString();
        //        f.Poster = row["poster"].ToString();
        //        f.Kijkwijzer1 = row["kijkwijzer_1"].ToString();
        //        f.Kijkwijzer2 = row["kijkwijzer_2"].ToString();
        //        f.Kijkwijzer3 = row["kijkwijzer_3"].ToString();
        //        f.Kijkwijzer4 = row["kijkwijzer_4"].ToString();
        //        f.Categorie1 = row["categorie1"].ToString();
        //        f.Categorie2 = row["categorie2"].ToString();
        //        f.Naam = row["naam"].ToString();
        //        f.Omschrijving = row["beschrijving"].ToString();
        //        f.Regisseur = row["regisseur"].ToString();
        //        f.Cast = row["cast"].ToString();
        //        f.Release = row["release"].ToString();
        //        f.Speelduur = row["speelduur"].ToString();
        //        f.Taal = row["taal"].ToString();
        //        f.Ondertiteling = row["ondertiteling"].ToString();
        //        f.Id = Convert.ToInt32(row["id"]);

        //        en die film voegen we toe aan de lijst met producten
        //        //films.Add(f);
        //    }

        //    return films;
        //}

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
            var films = GetAllFilms();

            //Lijst met producten in de html stoppen
            return View(films);
        }

        public List<Film> GetAllFilms()
        {
            // alle producten ophalen uit de database
            var rows = DatabaseConnector.GetRows("select * from film");

            //lijst maken om alle producten in te stoppen
            List<Film> films = new List<Film>();

            foreach (var row in rows)
            {
                //voor elke rij maken we nu een product
                Film f = GetFilmFromRow(row);

                //en dat product voegen we toe aan de lijst met producten
                films.Add(f);
            }

            return films;
        }

        [Route("/film/{id}")]
        public IActionResult FilmDetails(int id)
        {
            var film = GetFilm(id);

            return View(film);
        }

        private Film GetFilmFromRow(Dictionary<string,object> row)
        {
            Film f = new Film(); ;
            f.Trailer = row["trailer"].ToString();
            f.Poster = row["poster"].ToString();
            f.Kijkwijzer1 = row["kijkwijzer_1"].ToString();
            f.Kijkwijzer2 = row["kijkwijzer_2"].ToString();
            f.Kijkwijzer3 = row["kijkwijzer_3"].ToString();
            f.Kijkwijzer4 = row["kijkwijzer_4"].ToString();
            f.Categorie1 = row["categorie1"].ToString();
            f.Categorie2 = row["categorie2"].ToString();
            f.Naam = row["naam"].ToString();
            f.Omschrijving = row["beschrijving"].ToString();
            f.Regisseur = row["regisseur"].ToString();
            //f.Cast = row["cast"].ToString();
            f.Release = row["release"].ToString();
            f.Speelduur = row["speelduur"].ToString();
            f.Taal = row["taal"].ToString();
            f.Ondertiteling = row["ondertiteling"].ToString();
            f.Id = Convert.ToInt32(row["id"]);

            return f;
        }

        public Film GetFilm(int id)
        {
            //product ophalen uit de database op basis van het id
            var rows = DatabaseConnector.GetRows($"select * from film where id = {id}");

            //we krijgen altijd een lijst terug maar er zou altijd één product in moeten zitten dus we pakken voor het gemak gewoon de eerste
            Film film = GetFilmFromRow(rows[0]);

            //als laatste sturen we het product uit de lijst terug
            return film;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}