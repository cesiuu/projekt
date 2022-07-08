using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace projekt_ces_13611
{

    public class BloggingContext : DbContext
    {
        public DbSet<Kategoria_produktu> Kategoria_produktu { get; set; }
        public DbSet<Klienci> Klienci { get; set; }
        public DbSet<Koszyk> Koszyk { get; set; }
        public DbSet<Producenci> Producenci { get; set; }
        public DbSet<Sprzedaż> Sprzedaż { get; set; }
        public DbSet<Towary> Towary { get; set; }

        public string ConnectionString { get; }

        public BloggingContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(this.ConnectionString);
        }
    }
    public class Kategoria_produktu
    {
        [Key]
        public int id_kategorii { get; set; }
        public string nazwa_kategorii { get; set; }
    }
    public class Klienci
    {
        [Key]
        public int klient_id { get; set; }
        public string klient_imie { get; set; }
        public string klient_nazwisko { get; set; }
        public string klient_telefon { get; set; }
        public string klient_email { get; set; }
        public string klient_adres { get; set; }
    }
    public class Koszyk
    {
        [Key]
        public int id_pozycji { get; set; }
        public int id_zamówienia { get; set; }
        public int id_produktu { get; set; }
    }
    public class Producenci
    {
        [Key]
        public int id_producenta { get; set; }
        public string nazwa_producenta { get; set; }
    }
    public class Sprzedaż
    {
        [Key]
        public int id_zamówienia { get; set; }
        public int klient_id { get; set; }
        public DateTime? data_zamówienia { get; set; }
    }
    public class Towary
    {
        [Key]
        public int id_produktu { get; set; }
        public string nazwa_produktu { get; set; }
        public int id_kategorii { get; set; }
        public int cena_produktu { get; set; }
        public int id_producenta { get; set; }
    }
}
