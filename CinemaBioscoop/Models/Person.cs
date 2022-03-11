using System.ComponentModel.DataAnnotations;

namespace CinemaBioscoop.Models
{
    public class Person
    {
        [Required]
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Email { get; set; }
        public string Telefoon { get; set; }
        public string Bericht { get; set; }

    }
}
