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
using JaguarPhone.Module.Enums;
using JaguarPhone.ViewModel;

namespace JaguarPhone.View.Controls
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : UserControl
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void ModifyProfile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (passwordTwoRegist.Password != passwordOneRegist.Password)
                    throw new Exception("Паролі не співпали");

                Jaguar.CurUser.Name = firstNameRegist.Text;
                Jaguar.CurUser.LastName = lastNameRegist.Text;
                Jaguar.CurUser.Telephone = Int32.Parse(telephoneRegist.Text);
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
