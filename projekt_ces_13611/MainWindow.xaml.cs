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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace projekt_ces_13611
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Konstruktor inicjuje obiekt klasy MainWindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\a\source\repos\projekt_programowanie\projekt_programowanie\_data\Database1.mdf;Integrated Security = True";
        void FillKlienci(object sender, RoutedEventArgs e)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                var klienci = from k in db.Klienci select k;
                grid1.ItemsSource = klienci.ToList();
            }
        }
        void FillKategoria(object sender, RoutedEventArgs e)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                var kategoria = from k in db.Kategoria_produktu select k;
                grid1.ItemsSource = kategoria.ToList();
            }
        }
        void FillKoszyk(object sender, RoutedEventArgs e)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                var koszyk = from k in db.Koszyk select k;
                grid1.ItemsSource = koszyk.ToList();
            }
        }
        void FillProducenci(object sender, RoutedEventArgs e)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                var producenci = from k in db.Producenci select k;
                grid1.ItemsSource = producenci.ToList();
            }
        }
        void FillSprzedaz(object sender, RoutedEventArgs e)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                var sprzedaz = from k in db.Sprzedaż select k;
                grid1.ItemsSource = sprzedaz.ToList();
            }
        }
        void FillTowary(object sender, RoutedEventArgs e)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                var towary = from k in db.Towary select k;
                grid1.ItemsSource = towary.ToList();
            }
        }
        void EdycjaProducenta(object sender, RoutedEventArgs e)
        {
            Window1 win1 = new Window1();
            win1.Show();
        }
        void EdycjaKategorii(object sender, RoutedEventArgs e)
        {
            Window2 win2 = new Window2();
            win2.Show();
        }
        void EdycjaTowaru(object sender, RoutedEventArgs e)
        {
            Window3 win3 = new Window3();
            win3.Show();
        }
        void EdycjaKlienta(object sender, RoutedEventArgs e)
        {
            Window4 win4 = new Window4();
            win4.Show();
        }
        void EdycjaKoszyka(object sender, RoutedEventArgs e)
        {
            Window5 win5 = new Window5();
            win5.Show();
        }
        void EdycjaSprzedazy(object sender, RoutedEventArgs e)
        {
            Window6 win6 = new Window6();
            win6.Show();
        }
    }
}
