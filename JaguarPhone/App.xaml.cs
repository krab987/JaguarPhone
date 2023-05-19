using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using DevExpress.Mvvm;
using JaguarPhone.View;
using JaguarPhone.View.Controls;
using JaguarPhone.ViewModel;

namespace JaguarPhone
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnExit(object sender, ExitEventArgs e)
        {
            Jaguar.Save();
        }
    }
}