using System;
using System.Windows;
using System.Windows.Controls;
using JaguarPhone.Module.Enums;
using JaguarPhone.ViewModel;

namespace JaguarPhone.View.Controls
{
    /// <summary>
    /// Контрол для редагування профілю коритувача 
    /// </summary>
    public partial class Profile : UserControl
    {
        public Profile()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Редагує профіль користувача - присвоює йому всі дані які були введені в поля. Якщо поле не змінювалось - попередні дані зберігаються
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModifyProfile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (passwordTwoRegist.Password != passwordOneRegist.Password)
                    throw new Exception("Паролі не співпали");

                Jaguar.CurUser.Name = firstNameRegist.Text;
                Jaguar.CurUser.LastName = lastNameRegist.Text;
                Jaguar.CurUser.TelModel = (TelModel)telModelRegist.SelectedItem;
                Jaguar.CurUser.Password = passwordTwoRegist.Password;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
