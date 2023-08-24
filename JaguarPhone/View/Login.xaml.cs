using System;
using System.Windows;
using JaguarPhone.ViewModel;

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

        /// <summary>
        /// Запускає користувача в систему і відкриває йому головне вікно коли той вводить коректний телефон та пароль
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                for (var index = 0; index < Jaguar.AllUsers.Count; index++)
                {
                    var el = Jaguar.AllUsers[index];
                    if (el.Telephone == Int32.Parse(telephoneLogin.Text) && el.Password == passwordLogin.Password)
                        Jaguar.CurUser = el;
                }

                if (Jaguar.CurUser == null)
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
