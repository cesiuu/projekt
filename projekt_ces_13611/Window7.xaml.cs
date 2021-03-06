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

namespace projekt_ces_13611
{
    /// <summary>
    /// Logika interakcji dla klasy Window7.xaml
    /// </summary>
    public partial class Window7 : Window
    {
        /// <summary>
        /// Zmienne potrzebne do logowania i nadawania uprawnień
        /// </summary>
        public static string admin_login = "admin";
        public static string admin_password = "admin";
        public static string user_login = "user";
        public static string user_password = "user";
        public static string who_logged = "";
        public Window7()
        {
            InitializeComponent();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            if ((username.Text == admin_login && userpass.Password == admin_password) || (username.Text == user_login && userpass.Password == user_password))
                {
                    who_logged = username.Text;
                    MainWindow win1 = new MainWindow();
                    win1.Show();
                    Close();
                }
            else
            {
                MessageBox.Show("Niepoprawna nazwa użytkownika lub hasło");
            }
        }
    }
}
