using JaguarPhone.Module.Enums;
using JaguarPhone.Module;
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

namespace JaguarPhone.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                for (var index = 0; index < Jaguar.AllUsers.Count; index++)
                {
                    var el = Jaguar.AllUsers[index];
                    if (el.Telephone == Int32.Parse(telephoneLogin.Text) && el.Password == passwordLogin.Password)
                        Jaguar.CurUserIndex = index;
                }

                if (Jaguar.CurUserIndex == -1)
                    throw new Exception("Невірний логін або пароль");

                new JaguarPhone().Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
