using System;
using System.Windows;
using System.Windows.Controls;
using JaguarPhone.Module;
using JaguarPhone.ViewModel;

namespace JaguarPhone.View
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminTariff : UserControl
    {
        public AdminTariff()
        {
            InitializeComponent();
        }

        private void AddSuperpower_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listTariffView.SelectedItem == null || listAllSuperpower.SelectedItem == null)
                    throw new Exception("Оберіть тариф та суперсилу із наявних");

                ((listTariffView.SelectedItem as Tariff))?.ListSuperpower.Add(
                    (((listAllSuperpower.SelectedItem as SuperPower)!)));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void RemoveSuperpower_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listTariffView.SelectedItem == null || listTariffSuperpower.SelectedItem == null)
                    throw new Exception("Оберіть тариф та суперсилу тарифу до видалення");

                ((listTariffView.SelectedItem as Tariff))?.ListSuperpower.Remove(
                    (SuperPower)listTariffSuperpower.SelectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void ModifyTariff_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listTariffView.SelectedItem == null)
                    throw new Exception("Оберіть тариф та суперсилу із наявних");

                Tariff tariff = (((listTariffView.SelectedItem as Tariff)!));
                tariff.Name = name_tb.Text;
                tariff.GbInternet = Double.Parse(internet_tb.Text);
                tariff.CallsOther = UInt32.Parse(callsOther_tb.Text);
                tariff.CallsJaguar = callsJag_tb.IsEnabled;
                tariff.Tv = tv_tb.IsEnabled;
                tariff.Price = UInt32.Parse(price_tb.Text); 
                tariff.Sms = UInt32.Parse(sms_tb.Text);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void AddTariff_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Jaguar.AllTariffs.Add(new Tariff(
                    name_tb.Text, UInt32.Parse(price_tb.Text), UInt32.Parse(internet_tb.Text), callsJag_tb.IsEnabled, UInt32.Parse(callsOther_tb.Text),
                    UInt32.Parse(sms_tb.Text), tv_tb.IsEnabled));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void ConfirmAddTariff_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                if (listCheckTariffsView.SelectedItem == null)
                    throw new Exception("Оберіть тариф який хочете додати");

                Tariff tariff = (listCheckTariffsView.SelectedItem as Tariff);
                Jaguar.AllTariffs.Add(tariff);
                Jaguar.CheckTariffs.Remove((listCheckTariffsView.SelectedItem as Tariff)!);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        private void RemoveTariff_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listTariffView.SelectedItem == null)
                    throw new Exception("Оберіть тариф із наявних");
                Jaguar.AllTariffs.Remove((Tariff)listTariffView.SelectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
