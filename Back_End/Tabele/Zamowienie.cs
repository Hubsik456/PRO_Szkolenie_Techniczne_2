using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_End.Tabele
{
    public class Zamowienie
    {
        [Key]
        public int ID { get; set; }
        public string Nazwa { get; set; } = null!;
        public string? Komentarz { get; set; }
        public DateTime Data_Zlozenia_Zamowienia { get; set; }
        public DateTime? Data_Odebrania_Zamowienia { get; set; }
        [Precision(6, 2)]
        public decimal Kwota { get; set; }
        public string Jaki_Samochod { get; set; } = null!;
    }
}
