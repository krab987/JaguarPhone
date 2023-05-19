using System;
using System.Windows;
using System.Windows.Controls;
using JaguarPhone.Module;
using JaguarPhone.ViewModel;

namespace JaguarPhone.View.Controls
{
    /// <summary>
    /// Interaction logic for AllUser.xaml
    /// </summary>
    public partial class AllUser : UserControl
    {
        string currentTariffname = " ";
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


        private void ConnectTariff_Click(object sender, RoutedEventArgs e)
        {
            Jaguar.CurUser.ConnectTariff(currentTariffname);
        }
        private void tariffItem_gd_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            currentTariffname = (sender as Grid).ToolTip.ToString();
        }
    }
}
