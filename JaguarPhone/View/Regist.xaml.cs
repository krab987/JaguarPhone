using JaguarPhone.Module;
using System;
using System.Windows;
using JaguarPhone.Module.Enums;
using System.ComponentModel;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization.Formatters.Binary;
using JaguarPhone.ViewModel;

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
        protected override void OnClosing(CancelEventArgs e)
        {
            Jaguar.SaveUser();
            base.OnClosing(e);
        }
    }
}
