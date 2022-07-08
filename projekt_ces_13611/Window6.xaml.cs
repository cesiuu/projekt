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
    /// Logika interakcji dla klasy Window6.xaml
    /// </summary>
    public partial class Window6 : Window
    {
        public Window6()
        {
            InitializeComponent();
            Dodawanieboxfill();
            Usuwanieboxfill();
        }
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\a\source\repos\projekt_programowanie\projekt_programowanie\_data\Database1.mdf;Integrated Security = True";
        private void EdytujSprzedaz(object sender, RoutedEventArgs e)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                try
                {
                    db.Add(new Sprzedaż { klient_id = Convert.ToInt32(text14.Text), data_zamówienia = DateTime.Parse(text15.Text) });
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Wprowadzono niepoprawne dane.");
                }
            }
        }
        private void UsunZamowienieID(object sender, RoutedEventArgs e)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                try
                {
                    Sprzedaż rmv = db.Sprzedaż.Where(p => p.id_zamówienia == Convert.ToInt32(text1141.Text)).First(); ;
                    db.Sprzedaż.Remove(rmv);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Wprowadzono niepoprawne dane.");
                }
            }
        }
        private void UsunZamowienieIdKlienta(object sender, RoutedEventArgs e)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                try
                {
                    Sprzedaż rmv = db.Sprzedaż.Where(p => p.klient_id == Convert.ToInt32(text114.Text)).First(); ;
                    db.Sprzedaż.Remove(rmv);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Wprowadzono niepoprawne dane.");
                }
            }
        }
        private void UsunZamowienieData(object sender, RoutedEventArgs e)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                try
                {
                    Sprzedaż rmv = db.Sprzedaż.Where(p => p.data_zamówienia == DateTime.Parse(text1141.Text)).First();
                    db.Sprzedaż.Remove(rmv);
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
                    var kl = from k in db.Klienci select k.klient_id;
                    Klientidboxdodaj.ItemsSource = kl.ToList();
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
                    var idz = from k in db.Sprzedaż select k.id_zamówienia;
                    Zamowienieidboxusun.ItemsSource = idz.ToList();
                    var idk = from k in db.Klienci select k.klient_id;
                    Klientidboxusun.ItemsSource = idk.ToList();
                    var data = from k in db.Sprzedaż select k.data_zamówienia;
                    Zamowieniedataboxusun.ItemsSource = idk.ToList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Wprowadzono niepoprawne dane.");
                }
            }
        }
        private void Zamowienieidboxusun_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            text1141.Text = Zamowienieidboxusun.SelectedValue.ToString();
        }

        private void Klientidboxusun_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            text114.Text = Klientidboxusun.SelectedValue.ToString();
        }

        private void Zamowieniedataboxusun_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            text115.Text = Zamowieniedataboxusun.SelectedValue.ToString();
        }

        private void Klientiddodaj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            text14.Text = Klientidboxdodaj.SelectedValue.ToString();
        }
    }
}
