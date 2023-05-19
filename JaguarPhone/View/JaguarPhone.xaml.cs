using System.Windows;
using System.Windows.Controls;
using JaguarPhone.Module;
using JaguarPhone.View.Controls;

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
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            new Login().Show();
            Close();
        }
    }
}
