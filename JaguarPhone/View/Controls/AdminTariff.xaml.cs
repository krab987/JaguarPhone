using System;
using System.Windows;
using System.Windows.Controls;
using JaguarPhone.Module;
using JaguarPhone.ViewModel;

namespace JaguarPhone.View
{
    /// <summary>
    /// Контрол адміністратора для редагування або додавання, видалення тарифів 
    /// </summary>
    public partial class AdminTariff : UserControl
    {
        private Admin curUser = Jaguar.CurUser as Admin;
        public AdminTariff()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Додає суперсилу до списку всіх наявних суперсил
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Клік</param>
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
        /// <summary>
        /// Видаляє суперсилу із всіх доступних суперсил
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Клік</param>
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

        /// <summary>
        /// Редагує тариф: заповнює його властивості які ввів адміністратор шляхом редагування
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModifyTariff_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listTariffView.SelectedItem == null)
                    throw new Exception("Оберіть тариф та суперсилу із наявних");

                Tariff tariff = (((listTariffView.SelectedItem as Tariff)!));
                curUser.CorrectTariff(tariff, name_tb.Text, UInt32.Parse(price_tb.Text), Double.Parse(internet_tb.Text),
                    callsJag_tb.IsChecked, UInt32.Parse(callsOther_tb.Text), UInt32.Parse(sms_tb.Text), tv_tb.IsChecked);

                
                //tariff.Name = name_tb.Text;
                //tariff.GbInternet = Double.Parse(internet_tb.Text);
                //tariff.CallsOther = UInt32.Parse(callsOther_tb.Text);
                //tariff.CallsJaguar = callsJag_tb.IsChecked;
                //tariff.Tv = tv_tb.IsChecked;
                //tariff.Price = UInt32.Parse(price_tb.Text); 
                //tariff.Sms = UInt32.Parse(sms_tb.Text);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Додає тариф до списку всі тарифів, взявши дані із "текстбоксів форми"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTariff_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool r =curUser.AddTariff(new Tariff(
                    name_tb.Text, UInt32.Parse(price_tb.Text), UInt32.Parse(internet_tb.Text), callsJag_tb.IsChecked, UInt32.Parse(callsOther_tb.Text),
                    UInt32.Parse(sms_tb.Text), tv_tb.IsChecked));
                if (r == false)
                    throw new Exception("Тариф із таким іменем існує");
                //Jaguar.AllTariffs.Add(new Tariff(
                //    name_tb.Text, UInt32.Parse(price_tb.Text), UInt32.Parse(internet_tb.Text), callsJag_tb.IsChecked, UInt32.Parse(callsOther_tb.Text),
                //    UInt32.Parse(sms_tb.Text), tv_tb.IsChecked));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Додає обраний тариф із списку запропонованих користувачами до списку всіх доступних тарифів для підключення
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmAddTariff_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                if (listCheckTariffsView.SelectedItem == null)
                    throw new Exception("Оберіть тариф який хочете додати");

                //Tariff tariff = (listCheckTariffsView.SelectedItem as Tariff);
                bool r =curUser.AddCustomerTariff((listCheckTariffsView.SelectedItem as Tariff)!);
                if (r == false)
                    throw new Exception("Тариф із таким іменем існує");
                //Jaguar.AllTariffs.Add(tariff);
                //Jaguar.CheckTariffs.Remove((listCheckTariffsView.SelectedItem as Tariff)!);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        /// <summary>
        /// Видаляє тариф із списку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveTariff_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listTariffView.SelectedItem == null)
                    throw new Exception("Оберіть тариф із наявних");
                curUser.RemoveTariff((Tariff)listTariffView.SelectedItem);
                //Jaguar.AllTariffs.Remove();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
