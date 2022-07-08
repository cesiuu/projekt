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
    /// Logika interakcji dla klasy Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {
        public Window5()
        {
            /// <summary>
            /// Konstruktor inicjuje obiekt klasy Window5 i wypełnia comboboxy do dodawania i usuwania
            /// </summary>
            InitializeComponent();
            Dodawanieboxfill();
            Usuwanieboxfill();
        }
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\a\source\repos\projekt_programowanie\projekt_programowanie\_data\Database1.mdf;Integrated Security = True";
        private void EdytujKoszyk(object sender, RoutedEventArgs e)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                try
                {
                    db.Add(new Koszyk { id_zamówienia = Convert.ToInt32(text12.Text), id_produktu = Convert.ToInt32(text13.Text) });
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wprowadzono niepoprawne dane.");
                }
            }
        }
        private void UsunKoszykIdZamowienia(object sender, RoutedEventArgs e)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                try
                {
                    Koszyk rmv = db.Koszyk.Where(p => p.id_zamówienia == Convert.ToInt32(text112.Text)).First(); ;
                    db.Koszyk.Remove(rmv);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wprowadzono niepoprawne dane.");
                }
            }
        }
        private void UsunKoszykIdProduktu(object sender, RoutedEventArgs e)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                try
                {
                    Koszyk rmv = db.Koszyk.Where(p => p.id_produktu == Convert.ToInt32(text113.Text)).First(); ;
                    db.Koszyk.Remove(rmv);
                    db.SaveChanges();
                }
                catch (Exception ex)
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
                    var z = from k in db.Sprzedaż select k.id_zamówienia;
                    Zamowienieidboxdodaj.ItemsSource = z.ToList();
                    var p = from k in db.Towary select k.id_produktu;
                    Produktidboxdodaj.ItemsSource = p.ToList();
                }
                catch (Exception ex)
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
                    var z = from k in db.Sprzedaż select k.id_zamówienia;
                    Zamowienieidboxusun.ItemsSource = z.ToList();
                    var p = from k in db.Towary select k.id_produktu;
                    Produktidboxusun.ItemsSource = p.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wprowadzono niepoprawne dane.");
                }
            }
        }
        private void Zamowienieidboxdodaj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            text12.Text = Zamowienieidboxdodaj.SelectedValue.ToString();
        }
        private void Produktidboxdodaj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            text13.Text = Produktidboxdodaj.SelectedValue.ToString();
        }
        private void Zamowienieidboxusun_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            text112.Text = Zamowienieidboxusun.SelectedValue.ToString();
        }

        private void Produktidboxusun_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            text113.Text = Produktidboxusun.SelectedValue.ToString();
        }
    }
}
