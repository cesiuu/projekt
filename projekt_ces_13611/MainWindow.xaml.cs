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
        Window7 win7 = new Window7();
        string who_logged = Window7.who_logged;
        string admin_login = Window7.admin_login;
        string user_login = Window7.user_login;

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
            if (who_logged == admin_login)
            {
                Window1 win1 = new Window1();
                win1.Show();
            }
            else if (who_logged == user_login)
            {
                MessageBox.Show("Niewystarczające uprawnienia");
            }
        }
        void EdycjaKategorii(object sender, RoutedEventArgs e)
        {
            if (who_logged == admin_login)
            {
                Window2 win2 = new Window2();
                win2.Show();
            }
            else if (who_logged == user_login)
            {
                MessageBox.Show("Niewystarczające uprawnienia");
            }
        }
        void EdycjaTowaru(object sender, RoutedEventArgs e)
        {
            if (who_logged == admin_login)
            {
                Window3 win3 = new Window3();
                win3.Show();
            }
            else if (who_logged == user_login)
            {
                MessageBox.Show("Niewystarczające uprawnienia");
            }
        }
        void EdycjaKlienta(object sender, RoutedEventArgs e)
        {
            if (who_logged == admin_login)
            {
                Window4 win4 = new Window4();
                win4.Show();
            }
            else if (who_logged == user_login)
            {
                MessageBox.Show("Niewystarczające uprawnienia");
            }
        }
        void EdycjaKoszyka(object sender, RoutedEventArgs e)
        {
            if (who_logged == admin_login)
            {
                Window5 win5 = new Window5();
                win5.Show();
            }
            else if (who_logged == user_login)
            {
                MessageBox.Show("Niewystarczające uprawnienia");
            }
        }
        void EdycjaSprzedazy(object sender, RoutedEventArgs e)
        {
            if (who_logged == admin_login)
            {
                Window6 win6 = new Window6();
                win6.Show();
            }
            else if (who_logged == user_login)
            {
                MessageBox.Show("Niewystarczające uprawnienia");
            }
        }
        private void Wyloguj(object sender, RoutedEventArgs e)
        {
            win7.Show();
            Close();
            who_logged = "";
        }
    }
}
