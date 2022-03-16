using System.ComponentModel.DataAnnotations;

namespace CinemaBioscoop.Models
{
    public class Person
    {
        [Required (ErrorMessage ="Gelieve uw voornaam in te vullen")]
        public string Voornaam { get; set; }

        [Required(ErrorMessage = "Gelieve uw achternaam in te vullen")]
        public string Achternaam { get; set; }

        [Required(ErrorMessage = "Gelieve uw emailadres in te vullen")]
        [EmailAddress(ErrorMessage = "Gelieve een geldig emailadres in te vullen")]
        public string Email { get; set; }

        public string? Telefoon { get; set; }

        [Required(ErrorMessage = "Gelieve een bericht achter te laten")]
        public string Bericht { get; set; }

    }
}
