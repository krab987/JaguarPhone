using System.Windows;
using JaguarPhone.Module;
using JaguarPhone.ViewModel;

namespace JaguarPhone.View
{
    /// <summary>
    /// Interaction logic for JaguarPhone.xaml
    /// </summary>
    public partial class JaguarPhone : Window
    {
        public JaguarPhone()
        {
            InitializeComponent();

            if (Jaguar.CurUser != null)
            {
                if (Equals(Jaguar.CurUser.GetType(), typeof(Admin)))
                    adminMenuItem.Visibility = Visibility.Visible;
                if (Equals(Jaguar.CurUser.GetType(), typeof(SuperAdmin)))
                {
                    adminMenuItem.Visibility = Visibility.Visible;
                    superAdminMenuItem.Visibility = Visibility.Visible;
                }

            }

            //var curUser = Jaguar.CurUser;
            //curUser.PriceServices = 0;
            //foreach (Service service in curUser.ListServices)
            //    curUser.PriceServices += service.Price;
        }

        /// <summary>
        /// Відкриває вікно входу в профіль і закриває основне вікно
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Клік</param>
        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            new Login().Show();
            Close();
        }

        /// <summary>
        /// Змінює властивість "IsCalling" після чого користувач починає дзвонити
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TelCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            MainViewModel.IsCalling = true;
        }
        /// <summary>
        /// Змінює властивість "IsCalling" після чого користувач перестає дзвонити
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TelCheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            MainViewModel.IsCalling = false;
        }

        /// <summary>
        /// Змінює властивість "IsInterneting" після чого користувач починає користуватись інтернетом
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InternetCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            MainViewModel.IsInterneting = true;
        }
        /// <summary>
        /// Змінює властивість "IsInterneting" після чого користувач перестає користуватись інтернетом
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InternetCheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            MainViewModel.IsInterneting = false;
        }

        /// <summary>
        /// Змінює властивість "IsSMSing" після чого користувач починає надсилати СМС
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SMSCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            MainViewModel.IsSMSing = true;
        }
        /// <summary>
        /// Змінює властивість "IsSMSing" після чого користувач перестає надсилати СМС
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SMSCheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            MainViewModel.IsSMSing = false;
        }
    }
}
