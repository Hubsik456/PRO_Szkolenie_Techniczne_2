using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_End.Tabele
{
    public class Klient
    {
        [Key]
        public int ID { get; set; }
        public string Imie { get; set; } = null!;
        public string Nazwisko { get; set; } = null!;
        public DateTime Data_Rejestracji { get; set; }
    }
}
