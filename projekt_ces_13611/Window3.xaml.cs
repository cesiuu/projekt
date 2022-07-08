using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace projekt_ces_13611
{
    /// <summary>
    /// Logika interakcji dla klasy Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
            Dodawanieboxfill();
            Usuwanieboxfill();
        }
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\a\source\repos\projekt_programowanie\projekt_programowanie\_data\Database1.mdf;Integrated Security = True";
        private void EdytujTowar(object sender, RoutedEventArgs e)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                try
                {
                    db.Add(new Towary { nazwa_produktu = text3.Text, cena_produktu = Convert.ToInt32(text4.Text), id_kategorii = Convert.ToInt32(text5.Text), id_producenta = Convert.ToInt32(text5.Text) });
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Wprowadzono niepoprawne dane.");
                }
            }
        }
        private void UsunTowarID(object sender, RoutedEventArgs e)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                try
                {
                    Towary rmv = db.Towary.Where(p => p.id_produktu == Convert.ToInt32(text1031.Text)).First(); ;
                    db.Towary.Remove(rmv);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Wprowadzono niepoprawne dane.");
                }
            }
        }
        private void UsunTowarNazwa(object sender, RoutedEventArgs e)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                try
                {
                    Towary rmv = db.Towary.Where(p => p.nazwa_produktu == text103.Text).First(); ;
                    db.Towary.Remove(rmv);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Wprowadzono niepoprawne dane.");
                }
            }
        }
        private void UsunTowarIdKategorii(object sender, RoutedEventArgs e)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                try
                {
                    Towary rmv = db.Towary.Where(p => p.id_kategorii == Convert.ToInt32(text104.Text)).First(); ;
                    db.Towary.Remove(rmv);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Wprowadzono niepoprawne dane.");
                }
            }
        }
        private void UsunTowarCena(object sender, RoutedEventArgs e)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                try
                {
                    Towary rmv = db.Towary.Where(p => p.cena_produktu == Convert.ToInt32(text105.Text)).First(); ;
                    db.Towary.Remove(rmv);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Wprowadzono niepoprawne dane.");
                }
            }
        }
        private void UsunTowarIdProducenta(object sender, RoutedEventArgs e)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                try
                {
                    Towary rmv = db.Towary.Where(p => p.id_producenta == Convert.ToInt32(text106.Text)).First(); ;
                    db.Towary.Remove(rmv);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Wprowadzono niepoprawne dane.");
                }
            }
        }
        private void Dodawanieboxfill()
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                try
                {
                    var idk = from k in db.Kategoria_produktu select k.id_kategorii;
                    Kategoriaboxdodaj.ItemsSource = idk.ToList();
                    var idp = from k in db.Producenci select k.id_producenta;
                    Producentboxdodaj.ItemsSource = idp.ToList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Wprowadzono niepoprawne dane.");
                }
            }
        }
        private void Usuwanieboxfill()
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                try
                {
                    var idpk = from k in db.Towary select k.id_produktu;
                    Produktidboxusun.ItemsSource = idpk.ToList();
                    var nazwa = from k in db.Towary select k.nazwa_produktu;
                    Produktnazwaboxusun.ItemsSource = nazwa.ToList();
                    var idk = from k in db.Towary select k.id_kategorii;
                    Kategoriaidboxusun.ItemsSource = idk.ToList();
                    var cena = from k in db.Towary select k.cena_produktu;
                    Produktcenaboxusun.ItemsSource = cena.ToList();
                    var idpc = from k in db.Towary select k.id_producenta;
                    Producentidboxusun.ItemsSource = idpc.ToList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Wprowadzono niepoprawne dane.");
                }
            }
        }
        private void Idkategoriiboxdodaj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            text5.Text = Kategoriaboxdodaj.SelectedValue.ToString();
        }

        private void Producentboxdodaj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            text6.Text = Producentboxdodaj.SelectedValue.ToString();
        }
        private void Produktidboxusun_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            text1031.Text = Produktidboxusun.SelectedValue.ToString();
        }

        private void Produktnazwaboxusun_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            text103.Text = Produktnazwaboxusun.SelectedValue.ToString();
        }

        private void Kategoriaidboxusun_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            text104.Text = Kategoriaidboxusun.SelectedValue.ToString();
        }

        private void Produktcenaboxusun_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            text105.Text = Produktcenaboxusun.SelectedValue.ToString();
        }

        private void Producentidboxusun_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            text106.Text = Producentidboxusun.SelectedValue.ToString();
        }
    }
}
