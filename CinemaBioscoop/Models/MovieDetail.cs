using CinemaBioscoop.Database;
using System.ComponentModel.DataAnnotations;

namespace CinemaBioscoop.Models
{
    public class MovieDetail
    {
        public Film Film { get; set; }

        public Regisseur Regisseur { get; set; }

        public Filmcategorie Filmcategorie { get; set; }

        public Kijkwijzer Kijkwijzer1 { get; set; }
        public Kijkwijzer Kijkwijzer2 { get; set; }
        public Kijkwijzer Kijkwijzer3 { get; set; }
        public Kijkwijzer Kijkwijzer4 { get; set; }

    }
}
