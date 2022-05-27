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
            //lijst met films ophalen
            var films = GetAllFilms();

            //Lijst met films in de html stoppen
            return View(films);
        }

        [Route("Filmagenda")]
        public IActionResult Filmagenda()
        {
            //lijst met films ophalen
            var films = GetAllFilms();

            //Lijst met films in de html stoppen
            return View(films);
        }

        [Route("Bioscoop")]
        public IActionResult Bioscoop()
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

        [Route("/film/{id}/Bestellen")]
        public IActionResult Bestellen(int id)
        {
            var film = GetFilm(id);

            var kijkwijzerRow1 = DatabaseConnector.GetRows($"select * from kijkwijzer where id = {film.Kijkwijzer1}");
            var kijkwijzer1 = GetKijkwijzerFromRow(kijkwijzerRow1[0]);

            var kijkwijzerRow2 = DatabaseConnector.GetRows($"select * from kijkwijzer where id = {film.Kijkwijzer2}");
            var kijkwijzer2 = GetKijkwijzerFromRow(kijkwijzerRow2[0]);

            var kijkwijzerRow3 = DatabaseConnector.GetRows($"select * from kijkwijzer where id = {film.Kijkwijzer3}");
            var kijkwijzer3 = GetKijkwijzerFromRow(kijkwijzerRow3[0]);

            var kijkwijzerRow4 = DatabaseConnector.GetRows($"select * from kijkwijzer where id = {film.Kijkwijzer4}");
            var kijkwijzer4 = GetKijkwijzerFromRow(kijkwijzerRow4[0]);

            var FilmcategorieRow1 = DatabaseConnector.GetRows($"select * from filmcategorie where id = {film.Filmcategorie1}");
            var filmcategorie1 = GetFilmcategorieFromRow(FilmcategorieRow1[0]);

            var FilmcategorieRow2 = DatabaseConnector.GetRows($"select * from filmcategorie where id = {film.Filmcategorie2}");
            var filmcategorie2 = GetFilmcategorieFromRow(FilmcategorieRow2[0]);

            var model = new MovieDetail();
            model.Film = film;

            model.Kijkwijzer1 = kijkwijzer1;
            model.Kijkwijzer2 = kijkwijzer2;
            model.Kijkwijzer3 = kijkwijzer3;
            model.Kijkwijzer4 = kijkwijzer4;

            model.Filmcategorie1 = filmcategorie1;
            model.Filmcategorie2 = filmcategorie2;

            return View(model);
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
            //lijst met films ophalen
            var films = GetAllFilms();

            //Lijst met films in de html stoppen
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
            
            var regisseurRow1 = DatabaseConnector.GetRows($"select * from regisseur where id = {film.Regisseur1}");
            var regisseur1 = GetRegisseurFromRow(regisseurRow1[0]);

            var regisseurRow2 = DatabaseConnector.GetRows($"select * from regisseur where id = {film.Regisseur2}");
            var regisseur2 = GetRegisseurFromRow(regisseurRow2[0]);

            var kijkwijzerRow1 = DatabaseConnector.GetRows($"select * from kijkwijzer where id = {film.Kijkwijzer1}");
            var kijkwijzer1 = GetKijkwijzerFromRow(kijkwijzerRow1[0]);

            var kijkwijzerRow2 = DatabaseConnector.GetRows($"select * from kijkwijzer where id = {film.Kijkwijzer2}");
            var kijkwijzer2 = GetKijkwijzerFromRow(kijkwijzerRow2[0]);
            
            var kijkwijzerRow3 = DatabaseConnector.GetRows($"select * from kijkwijzer where id = {film.Kijkwijzer3}");
            var kijkwijzer3 = GetKijkwijzerFromRow(kijkwijzerRow3[0]);

            var kijkwijzerRow4 = DatabaseConnector.GetRows($"select * from kijkwijzer where id = {film.Kijkwijzer4}");
            var kijkwijzer4 = GetKijkwijzerFromRow(kijkwijzerRow4[0]);

            var FilmcategorieRow1 = DatabaseConnector.GetRows($"select * from filmcategorie where id = {film.Filmcategorie1}");
            var filmcategorie1 = GetFilmcategorieFromRow(FilmcategorieRow1[0]);

            var FilmcategorieRow2 = DatabaseConnector.GetRows($"select * from filmcategorie where id = {film.Filmcategorie2}");
            var filmcategorie2 = GetFilmcategorieFromRow(FilmcategorieRow2[0]);

            var model = new MovieDetail();
            model.Film = film;
            
            model.Regisseur1 = regisseur1;
            model.Regisseur2 = regisseur2;

            model.Kijkwijzer1 = kijkwijzer1;
            model.Kijkwijzer2 = kijkwijzer2;
            model.Kijkwijzer3 = kijkwijzer3;
            model.Kijkwijzer4 = kijkwijzer4;

            model.Filmcategorie1 = filmcategorie1;
            model.Filmcategorie2 = filmcategorie2;

            return View(model);
        }

        private Regisseur GetRegisseurFromRow(Dictionary<string, object> row)
        {
            Regisseur r = new Regisseur();
            r.Id = Convert.ToInt32(row["id"]);
            r.Voornaam = row["voornaam"].ToString();
            r.Achternaam = row["achternaam"].ToString();
            return r;
        }

        private Kijkwijzer GetKijkwijzerFromRow(Dictionary<string, object> row)
        {
            Kijkwijzer k = new Kijkwijzer();
            k.Id = Convert.ToInt32(row["id"]);
            k.Image = row["image"].ToString();
            return k;
        }

        private Filmcategorie GetFilmcategorieFromRow(Dictionary<string, object> row)
        {
            Filmcategorie c = new Filmcategorie();
            c.Id = Convert.ToInt32(row["id"]);
            c.Categorienaam = row["categorienaam"].ToString();
            return c;
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
            f.Filmcategorie1 = row["filmcategorie_1"].ToString();
            f.Filmcategorie2 = row["filmcategorie_2"].ToString();
            f.Naam = row["naam"].ToString();
            f.Omschrijving = row["beschrijving"].ToString();
            f.Regisseur1 = row["regisseur_1"].ToString();
            f.Regisseur2 = row["regisseur_2"].ToString();
            f.Cast = row["Cast"].ToString();
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