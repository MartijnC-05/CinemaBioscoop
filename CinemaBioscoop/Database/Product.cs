namespace CinemaBioscoop.Database
{
    public class Film
    {
        public int Id { get; set; }
        public string? Naam { get; set; }
        public string? Omschrijving { get; set; }
        public string? Regisseur { get; set; }
        public string? Cast { get; set; }
        public string? Release { get; set; }
        public string? Speelduur { get; set; }
        public string? Taal { get; set; }
        public string? Ondertiteling { get; set; }

    }

    public class Product
    {
        public int Id { get; set; }
        public string? Naam { get; set; }
        public string? Prijs { get; set; }
        public int Beschikbaarheid { get; set; }

    }

    
}
