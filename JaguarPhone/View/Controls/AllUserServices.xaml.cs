using JaguarPhone.Module;
using JaguarPhone.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace JaguarPhone.View.Controls
{
    /// <summary>
    /// Контрол для вибору послу 
    /// </summary>
    public partial class AllUserServices : UserControl
    {
        public AllUserServices()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Підключити послугу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Клік</param>
        private void ConnectService_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listAllServices.SelectedItem == null)
                    throw new Exception("Оберіть послугу для підключення");
                Jaguar.CurUser.ConnectService(((listAllServices.SelectedItem as Service)!).Name);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Відключити послугу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveService_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listServices.SelectedItem == null)
                    throw new Exception("Оберіть послугу для відключення");
                Jaguar.CurUser.RemoveService((listServices.SelectedItem as Service)!);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
