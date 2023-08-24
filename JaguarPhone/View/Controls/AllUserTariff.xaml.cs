using JaguarPhone.Module;
using JaguarPhone.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace JaguarPhone.View.Controls
{
    /// <summary>
    /// Interaction logic for AllUserTariff.xaml
    /// </summary>
    public partial class AllUserTariff : UserControl
    {
        private Tariff tariff = new Tariff();
        public AllUserTariff()
        {
            InitializeComponent();
            Jaguar.TempSuperPowers.Clear();
        }

        /// <summary>
        /// Додає суперсилу до тарифу в список його суперсил
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddSuperPower_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listAllSuperpower.SelectedItem == null)
                    throw new Exception("Оберіть суперсилу");
                Jaguar.TempSuperPowers.Add((SuperPower)listAllSuperpower.SelectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Прибирає суперсилу з списку суперсил тарифу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveSuperpower_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listTariffSuperpower.SelectedItem == null)
                    throw new Exception("Оберіть суперсилу");
                Jaguar.TempSuperPowers.Remove((SuperPower)listTariffSuperpower.SelectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Додає тариф до списку таристувацьких тарифів, які потребують підтвердження
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTariff_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Jaguar.TempSuperPowers.Count >= 5)
                    throw new Exception("Максимум 4 суперсили");

                tariff.Name = name_tb.Text;
                tariff.Price = UInt32.Parse(price_tb.Text);
                tariff.GbInternet = UInt32.Parse(internet_tb.Text);
                tariff.CallsJaguar = callsJag_tb.IsEnabled;
                tariff.CallsOther = UInt32.Parse(callsOther_tb.Text);
                tariff.Sms = UInt32.Parse(sms_tb.Text);
                tariff.Tv = tv_tb.IsChecked;
                tariff.ListSuperpower = Jaguar.TempSuperPowers;

                Jaguar.CurUser.AddTariff(tariff);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
