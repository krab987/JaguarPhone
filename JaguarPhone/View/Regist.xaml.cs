using JaguarPhone.Module;
using System;
using System.Windows;
using JaguarPhone.Module.Enums;
using System.ComponentModel;
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
        /// <summary>
        /// Реєструє користувача за введеними ним даними в поля форми коли користувача з таким же логіном не знайдено і два паролі співпали
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Regist_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (passwordOneRegist.Password != passwordTwoRegist.Password)
                    throw new Exception("Паролі не співпали");
                foreach (AllUSer el in Jaguar.AllUsers)
                {
                    if(el.Telephone == Convert.ToInt32(telephoneRegist.Text))
                        throw new Exception($"Користувач з телефоном {telephoneRegist.Text} вже існує");
                }

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
