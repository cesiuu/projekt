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
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            Usuwanieboxfill();
        }
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\a\source\repos\projekt_programowanie\projekt_programowanie\_data\Database1.mdf;Integrated Security = True";

        private void EdytujProducenta(object sender, RoutedEventArgs e)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                try
                {
                    db.Add(new Producenci { nazwa_producenta = text1.Text });
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Wprowadzono niepoprawne dane.");
                }
            }
        }
        private void UsunProducentaID(object sender, RoutedEventArgs e)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                try
                {
                    Producenci rmv = db.Producenci.Where(p => p.id_producenta == Convert.ToInt32(text1011.Text)).First(); ;
                    db.Producenci.Remove(rmv);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Wprowadzono niepoprawne dane.");
                }
            }
        }
        private void UsunProducentaNazwa(object sender, RoutedEventArgs e)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                try
                {
                    Producenci rmv = db.Producenci.Where(p => p.nazwa_producenta == text101.Text).First(); ;
                    db.Producenci.Remove(rmv);
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
                    var id = from k in db.Producenci select k.id_producenta;
                    Producentidboxusun.ItemsSource = id.ToList();
                    var nazwa = from k in db.Producenci select k.nazwa_producenta;
                    Producentnazwaboxusun.ItemsSource = nazwa.ToList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Wprowadzono niepoprawne dane.");
                }
            }
        }
        private void Producentidboxusun_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            text1011.Text = Producentidboxusun.SelectedValue.ToString();
        }

        private void Producentnazwaboxusun_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            text101.Text = Producentnazwaboxusun.SelectedValue.ToString();
        }
    }
}
