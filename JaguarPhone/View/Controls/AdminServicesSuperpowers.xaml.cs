using JaguarPhone.Module;
using JaguarPhone.ViewModel;
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

namespace JaguarPhone.View.Controls
{
    /// <summary>
    /// Interaction logic for AdminServicesSuperpowers.xaml
    /// </summary>
    public partial class AdminServicesSuperpowers : UserControl
    {
        public AdminServicesSuperpowers()
        {
            InitializeComponent();
        }

        private void ModifyService_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listServisesView.SelectedItem == null)
                    throw new Exception("Оберіть сервіс із наявних");

                Service serv = (((listServisesView.SelectedItem as Service)!));
                serv.Name = name_tb.Text;
                serv.Price = UInt32.Parse(price_tb.Text);
                serv.About = about_tb.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void AddService_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Jaguar.AllServices.Add(new Service(
                    name_tb.Text, UInt32.Parse(price_tb.Text), about_tb.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void DeleteService_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listServisesView.SelectedItem == null)
                    throw new Exception("Оберіть сервіс із наявних");
                Jaguar.AllServices.Remove((Service)listServisesView.SelectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ModifySuperpower_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listsuperpowerView.SelectedItem == null)
                    throw new Exception("Оберіть суперсилу із наявних");

                SuperPower superPower = ((listsuperpowerView.SelectedItem as SuperPower)!);
                superPower.Name = nameSP_tb.Text;
                superPower.CallsOther = UInt32.Parse(callsOther_tb.Text);
                superPower.GbInternet = Double.Parse(internetSP_tb.Text);
                if (tv_tb.IsEnabled) superPower.Tv = true;
                else superPower.Tv = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void AddSuperpower_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Jaguar.AllSuperPower.Add(new SuperPower(
                    nameSP_tb.Text, Double.Parse(internetSP_tb.Text), UInt32.Parse(callsOther_tb.Text), tv_tb.IsEnabled));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void DeleteSuperpower_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listsuperpowerView.SelectedItem == null)
                    throw new Exception("Оберіть суперсилу із наявних");
                Jaguar.AllSuperPower.Remove((SuperPower)listsuperpowerView.SelectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
