using CinemaBioscoop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MySql.Data;
using CinemaBioscoop.Database;
using MySql.Data.MySqlClient;

namespace CinemaBioscoop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string connectionString = "Server=informatica.st-maartenscollege.nl;Port=3306;Database=110739;Uid=110739;Pwd=inf2122sql;";
        //private readonly string connectionString = "Server=172.16.160.21;Port=3306;Database=110739;Uid=110739;Pwd=inf2122sql;";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //lijst met producten ophalen
            var films = GetAllFilms();

            //Lijst met producten in de html stoppen
            return View(films);
        }

        [Route("Films_oud")]
        public IActionResult Films_oud()
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
                SavePerson(person);
                return Redirect("Succes");
            }

            return View(person);
        }

        [Route("Succes")]
        public IActionResult Succes()
        {
            return View();
        }

        private void SavePerson(Person person)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO contact(naam, achternaam, email, telefoon, bericht) VALUES(?naam, ?achternaam, ?email, ?telefoon, ?bericht)", conn);

                cmd.Parameters.Add("?naam", MySqlDbType.Text).Value = person.Voornaam;
                cmd.Parameters.Add("?achternaam", MySqlDbType.Text).Value = person.Achternaam;
                cmd.Parameters.Add("?email", MySqlDbType.Text).Value = person.Email;
                cmd.Parameters.Add("?telefoon", MySqlDbType.Text).Value = person.Telefoon;
                cmd.Parameters.Add("?bericht", MySqlDbType.Text).Value = person.Bericht;
                cmd.ExecuteNonQuery();
            }
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

        [Route("Films")]
        public IActionResult Films()
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
            f.Uitgelicht = row["uitgelicht"].ToString();
            f.Kijkwijzer1 = row["kijkwijzer_1"].ToString();
            f.Kijkwijzer2 = row["kijkwijzer_2"].ToString();
            f.Kijkwijzer3 = row["kijkwijzer_3"].ToString();
            f.Kijkwijzer4 = row["kijkwijzer_4"].ToString();
            f.Categorie1 = row["filmcategorie_1"].ToString();
            f.Categorie2 = row["filmcategorie_2"].ToString();
            f.Naam = row["naam"].ToString();
            f.Omschrijving = row["beschrijving"].ToString();
            f.Regisseur = row["regisseur_1"].ToString();
            f.Cast = row["cast_1"].ToString();
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