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
    /// Logika interakcji dla klasy Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        /// <summary>
        /// Konstruktor inicjuje obiekt klasy Window2 i wypełnia combobox do usuwania
        /// </summary>
        public Window2()
        {
            InitializeComponent();
            Usuwanieboxfill();
        }
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\a\source\repos\projekt_programowanie\projekt_programowanie\_data\Database1.mdf;Integrated Security = True";

        private void EdytujKategorie(object sender, RoutedEventArgs e)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                try
                {
                    db.Add(new Kategoria_produktu { nazwa_kategorii = text2.Text });
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Wprowadzono niepoprawne dane.");
                }
            }
        }
        private void UsunKategorieID(object sender, RoutedEventArgs e)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                try
                {
                    Kategoria_produktu rmv = db.Kategoria_produktu.Where(p => p.id_kategorii == Convert.ToInt32(text1021.Text)).First(); ;
                    db.Kategoria_produktu.Remove(rmv);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Wprowadzono niepoprawne dane.");
                }
            }
        }
        private void UsunKategorieNazwa(object sender, RoutedEventArgs e)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                try
                {
                    Kategoria_produktu rmv = db.Kategoria_produktu.Where(p => p.nazwa_kategorii == text1021.Text).First(); ;
                    db.Kategoria_produktu.Remove(rmv);
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
                    var id = from k in db.Kategoria_produktu select k.id_kategorii;
                    Kategoriaidboxusun.ItemsSource = id.ToList();
                    var nazwa = from k in db.Kategoria_produktu select k.nazwa_kategorii;
                    Kategorianazwaboxusun.ItemsSource = nazwa.ToList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Wprowadzono niepoprawne dane.");
                }
            }
        }
        private void Kategoriaidboxusun_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            text1021.Text = Kategoriaidboxusun.SelectedValue.ToString();
        }

        private void Kategorianazwaboxusun_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            text102.Text = Kategorianazwaboxusun.SelectedValue.ToString();
        }
    }
}
