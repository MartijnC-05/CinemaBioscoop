using CinemaBioscoop.Database;
using System.ComponentModel.DataAnnotations;

namespace CinemaBioscoop.Models
{
    public class MovieDetail
    {
        public Film Film { get; set; }

        public Regisseur Regisseur { get; set; } 

        public Kijkwijzer Kijkwijzer { get; set; }

    }
}
