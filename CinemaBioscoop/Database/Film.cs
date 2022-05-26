namespace CinemaBioscoop.Database
{
    public class Film
    {
        public int Id { get; set; }
        public string? Trailer { get; set; }
        public string? Poster { get; set; }
        public string? Uitgelicht { get; set; }
        public string? Kijkwijzer1 { get; set; }
        public string? Kijkwijzer2 { get; set; }
        public string? Kijkwijzer3 { get; set; }
        public string? Kijkwijzer4 { get; set; }
        public string? Filmcategorie1 { get; set; }
        public string? Filmcategorie2 { get; set; }
        public string? Naam { get; set; }
        public string? Omschrijving { get; set; }
        public string? Regisseur1 { get; set; }
        public string? Regisseur2 { get; set; }

        public string? Cast { get; set; }
        public string? Release { get; set; }
        public string? Speelduur { get; set; }
        public string? Taal { get; set; }
        public string? Ondertiteling { get; set; }
    }
    
}
