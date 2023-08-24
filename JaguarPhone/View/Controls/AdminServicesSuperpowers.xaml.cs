using JaguarPhone.Module;
using JaguarPhone.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace JaguarPhone.View.Controls
{
    /// <summary>
    /// Interaction logic for AdminServicesSuperpowers.xaml
    /// </summary>
    public partial class AdminServicesSuperpowers : UserControl
    {
        private Admin curUser;
        public AdminServicesSuperpowers()
        {
            InitializeComponent();
            curUser = Jaguar.CurUser as Admin;
        }

        /// <summary>
        /// Редагує властивості обраної послуги
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModifyService_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listServisesView.SelectedItem == null)
                    throw new Exception("Оберіть послугу із наявних");
                
                curUser.CorrectService((listServisesView.SelectedItem as Service), name_tb.Text, UInt32.Parse(price_tb.Text), about_tb.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Додає послугу в список всіх послуг
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddService_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool r = curUser.AddService(new Service(name_tb.Text, UInt32.Parse(price_tb.Text), about_tb.Text));
                if (r == false)
                    throw new Exception("Сервіс із таким ім'ям уже існує");
                name_tb.Clear();
                price_tb.Clear();
                about_tb.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Видаляє послугу зі списку всіх послуг
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteService_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listServisesView.SelectedItem == null)
                    throw new Exception("Оберіть сервіс із наявних");
                curUser.RemoveService((Service)listServisesView.SelectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Редагує властивості обраної суперсили 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModifySuperpower_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listsuperpowerView.SelectedItem == null)
                    throw new Exception("Оберіть суперсилу із наявних");
                curUser.CorrectSuperPower(((listsuperpowerView.SelectedItem as SuperPower)!), nameSP_tb.Text,
                    Double.Parse(internetSP_tb.Text),
                    UInt32.Parse(callsOther_tb.Text), tv_tb.IsChecked);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Додає суперсилу до списку всіх суперсил
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddSuperpower_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool r = curUser.AddSuperPower(new SuperPower(
                    nameSP_tb.Text, Double.Parse(internetSP_tb.Text), UInt32.Parse(callsOther_tb.Text),
                    tv_tb.IsEnabled));
                if (r == false)
                    throw new Exception("Суперсила із таким іменем вже існує");
                nameSP_tb.Clear();
                internetSP_tb.Clear();
                callsOther_tb.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Видаляє суперсилу зі списку всіх суперсил
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteSuperpower_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listsuperpowerView.SelectedItem == null)
                    throw new Exception("Оберіть суперсилу із наявних");
                curUser.RemoveSuperPower((SuperPower)listsuperpowerView.SelectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
