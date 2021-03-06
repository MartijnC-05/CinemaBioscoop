using CinemaBioscoop.Database;
using System.ComponentModel.DataAnnotations;

namespace CinemaBioscoop.Models
{
    public class MovieDetail
    {
        public Film? Film { get; set; }

        public Regisseur? Regisseur1 { get; set; }
        public Regisseur? Regisseur2 { get; set; }

        public Filmcategorie? Filmcategorie1 { get; set; }
        public Filmcategorie? Filmcategorie2 { get; set; }


        public Kijkwijzer? Kijkwijzer1 { get; set; }
        public Kijkwijzer? Kijkwijzer2 { get; set; }
        public Kijkwijzer? Kijkwijzer3 { get; set; }
        public Kijkwijzer? Kijkwijzer4 { get; set; }

    }
}
