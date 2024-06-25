using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Back_End.Tabele;

namespace Back_End.DB
{
    public class DB_Context : DbContext
    {
        public DbSet<Klient> Klienci { get; set; } = null!;
        public DbSet<Samochod> Samochody { get; set; } = null!;
        public DbSet<Zamowienie> Zamowienia { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=WIP_8;Integrated Security=True;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DB_Context()
        {
        }
        public DB_Context(DbContextOptions<DB_Context> options) : base(options)
        {
        }
    }
}
