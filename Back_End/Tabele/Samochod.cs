using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_End.Tabele
{
    public class Samochod
    {
        [Key]
        public int ID { get; set; }
        public string Marka { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Kolor { get; set; } = null!;
        public string Numer_Rejestracyjny { get; set; } = null!;
        public string Wlasciciel { get; set; } = null!;
    }
}
