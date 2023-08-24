using JaguarPhone.Module;
using System;
using System.Windows;
using System.Windows.Controls;
using JaguarPhone.ViewModel;

namespace JaguarPhone.View.Controls
{
    /// <summary>
    /// Interaction logic for SuperAdminGrant.xaml
    /// </summary>
    public partial class SuperAdminGrant : UserControl
    {
        public SuperAdminGrant()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Надає права адміністратора обраному звичайному користувачеві шляхом перетворення об'єкту класу User в Admin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrantAdmin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listUsers.SelectedItem == null)
                    throw new Exception("Оберіть користувача для надання прав адміністратора");
                ((Jaguar.CurUser as SuperAdmin)!).GrantAdmin(listUsers.SelectedItem as User);
                listUsers.Items.Refresh();
                listAdmins.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Забирає права адміністратора в обраного адміністратора шляхом перетворення об'єкту класу Admin в User
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UnGrantAdmin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listAdmins.SelectedItem == null)
                    throw new Exception("Оберіть адміністратора для того щоб забрати права адміністратора");
                ((Jaguar.CurUser as SuperAdmin)!).UnGrantAdmin(listAdmins.SelectedItem as Admin);
                listUsers.Items.Refresh();
                listAdmins.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}
