using System;
using System.Windows;
using System.Windows.Controls;
using JaguarPhone.Module;

namespace JaguarPhone.View.Controls
{
    /// <summary>
    /// Interaction logic for AllUser.xaml
    /// </summary>
    public partial class AllUser : UserControl
    {
        public AllUser()
        {
            InitializeComponent();
        }

        private void TopUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Ви впевнені?", "Поповнення", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.OK)
                {
                    Jaguar.CurUser.Balance += Int32.Parse(topUp_tb.Text);
                    topUp_tb.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
