using JaguarPhone.Module;
using System;
using System.Windows;
using JaguarPhone.Module.Enums;

namespace JaguarPhone.View
{
    /// <summary>
    /// Interaction logic for Regist.xaml
    /// </summary>
    public partial class Regist : Window
    {
        public Regist()
        {
            InitializeComponent();
        }
        private AllUSer currentUser;
        private void Regist_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (passwordOneRegist.Password != passwordTwoRegist.Password)
                    throw new Exception("Паролі не співпали");

                Admin currentUser = new Admin();
                currentUser.AddUser(new User(
                    firstNameRegist.Text, lastNameRegist.Text, telephoneRegist.Text,
                     passwordTwoRegist.Password, (TelModel)telModelRegist.SelectedItem));
                MessageBox.Show($"Користувач {telephoneRegist.Text} успішно доданий", "Успіх", MessageBoxButton.OK, MessageBoxImage.Information);
                Jaguar.SaveUser();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
