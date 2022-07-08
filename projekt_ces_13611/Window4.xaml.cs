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
    /// Logika interakcji dla klasy Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
            Usuwanieboxfill();
        }
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\a\source\repos\projekt_programowanie\projekt_programowanie\_data\Database1.mdf;Integrated Security = True";
        private void EdytujKlienta(object sender, RoutedEventArgs e)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                try
                {
                    db.Add(new Klienci { klient_imie = text7.Text, klient_nazwisko = text8.Text, klient_telefon = text9.Text, klient_email = text10.Text, klient_adres = text11.Text });
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Wprowadzono niepoprawne dane.");
                }
            }
        }
        private void UsunKlientaID(object sender, RoutedEventArgs e)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                try
                {
                    Klienci rmv = db.Klienci.Where(p => p.klient_id == Convert.ToInt32(text1071.Text)).First(); ;
                    db.Klienci.Remove(rmv);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Wprowadzono niepoprawne dane.");
                }
            }
        }
        private void UsunKlientaImie(object sender, RoutedEventArgs e)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                try
                {
                    Klienci rmv = db.Klienci.Where(p => p.klient_imie == text107.Text).First(); ;
                    db.Klienci.Remove(rmv);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Wprowadzono niepoprawne dane.");
                }
            }
        }
        private void UsunKlientaNazwisko(object sender, RoutedEventArgs e)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                try
                {
                    Klienci rmv = db.Klienci.Where(p => p.klient_nazwisko == text108.Text).First(); ;
                    db.Klienci.Remove(rmv);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Wprowadzono niepoprawne dane.");
                }
            }
        }
        private void UsunKlientaTelefon(object sender, RoutedEventArgs e)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                try
                {
                    Klienci rmv = db.Klienci.Where(p => p.klient_telefon == text109.Text).First(); ;
                    db.Klienci.Remove(rmv);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Wprowadzono niepoprawne dane.");
                }
            }
        }
        private void UsunKlientaEmail(object sender, RoutedEventArgs e)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                try
                {
                    Klienci rmv = db.Klienci.Where(p => p.klient_email == text110.Text).First(); ;
                    db.Klienci.Remove(rmv);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Wprowadzono niepoprawne dane.");
                }
            }
        }
        private void UsunKlientaAdres(object sender, RoutedEventArgs e)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                try
                {
                    Klienci rmv = db.Klienci.Where(p => p.klient_adres == text111.Text).First(); ;
                    db.Klienci.Remove(rmv);
                    db.SaveChanges();
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
                    var idk = from k in db.Klienci select k.klient_id;
                    Klientidboxusun.ItemsSource = idk.ToList();
                    var im = from k in db.Klienci select k.klient_imie;
                    Imieboxusun.ItemsSource = im.ToList();
                    var nz = from k in db.Klienci select k.klient_nazwisko;
                    Nazwiskoboxusun.ItemsSource = nz.ToList();
                    var tf = from k in db.Klienci select k.klient_telefon;
                    Telefonboxusun.ItemsSource = tf.ToList();
                    var em = from k in db.Klienci select k.klient_email;
                    Emailboxusun.ItemsSource = em.ToList();
                    var ad = from k in db.Klienci select k.klient_adres;
                    Adresboxusun.ItemsSource = ad.ToList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Wprowadzono niepoprawne dane.");
                }
            }
        }
        private void Klientidboxusun_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            text1071.Text = Klientidboxusun.SelectedValue.ToString();
        }

        private void Imieboxusun_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            text107.Text = Imieboxusun.SelectedValue.ToString();
        }

        private void Nazwiskoboxusun_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            text108.Text = Nazwiskoboxusun.SelectedValue.ToString();
        }

        private void Telefonboxusun_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            text109.Text = Telefonboxusun.SelectedValue.ToString();
        }

        private void Emailboxusun_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            text110.Text = Emailboxusun.SelectedValue.ToString();
        }

        private void Adresboxusun_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            text111.Text = Adresboxusun.SelectedValue.ToString();
        }
    }
}
