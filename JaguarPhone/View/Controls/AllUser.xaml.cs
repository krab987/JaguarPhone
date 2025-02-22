using System;
using System.Linq;
using System.Security.Principal;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using JaguarPhone.Module;
using JaguarPhone.ViewModel;

namespace JaguarPhone.View.Controls
{
    /// <summary>
    /// Interaction logic for AllUser.xaml
    /// </summary>
    public partial class AllUser : UserControl
    {
        string currentTariffname = "";
        private Tariff tempTariff;
        private SuperPower tempSuperPower;

        public AllUser()
        {
            InitializeComponent();
            foreach (var tariff in Jaguar.AllTariffs)
                if (tariff.Name == (string)nameTariff_lbl.Content)
                    tempTariff = tariff;
            var clock = new Clock();
            clock.NewDay += OnNewDay;
            TryGetTariffPack();
        }

        private void OnNewDay(object? sender, EventArgs e)
        {
            TryGetTariffPack();
        }

        private void TryGetTariffPack()
        {
            var dayPay = Jaguar.CurUser.DateTariff;
            var dayNow = DateOnly.FromDateTime(DateTime.Now);

            if (dayPay < dayNow || dayPay == dayNow)
            {
                Jaguar.CurUser.DateTariff = dayPay = dayNow;

                var acc = Jaguar.CurUser.Account;
                acc.GbInternet = 0;
                acc.CallsJaguar = false;
                acc.CallsOther = 0;
                acc.Sms = 0;
                acc.Tv = false;

                Jaguar.CurUser.AvailableTariffs = true;
            }

            if (dayPay == dayNow && Jaguar.CurUser.Balance >= Jaguar.CurUser.Account.Price)
            {
                Jaguar.CurUser.Balance -= Jaguar.CurUser.Account.Price;

                Jaguar.CurUser.ConnectTariff(tempTariff.Name);
                //foreach (var el in Jaguar.AllTariffs.Where(el => el.Name == Jaguar.CurUser.Account.Name))
                //    tempTariff = el;


                var account = Jaguar.CurUser.Account;
                var sp = Jaguar.CurUser.TSuperPower;

                //account.CallsOther = tempTariff.CallsOther;
                //account.GbInternet = tempTariff.GbInternet;
                //account.Tv = tempTariff.Tv;

                if (sp != null)
                {
                    account.CallsOther += sp.CallsOther;
                    account.GbInternet += sp.GbInternet;
                    if (sp.Tv) account.Tv = sp.Tv; 
                }

                Jaguar.CurUser.AvailableTariffs = true;
                Jaguar.CurUser.AvailableSP = true;
            }

        }

        private void TopUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Ви впевнені?", "Поповнення", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.OK)
                {
                    Jaguar.CurUser.Balance += UInt32.Parse(topUp_tb.Text);
                    topUp_tb.Text = "";
                    TryGetTariffPack();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void ConnectTariff_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (var el in Jaguar.AllTariffs.Where(el => el.Name == currentTariffname))
                {
                    tempTariff = el;
                    tempTariff = el;
                    tempTariff.CallsJaguar = el.CallsJaguar;
                    tempTariff.CallsOther = el.CallsOther;
                    tempTariff.ListSuperpower = el.ListSuperpower;
                    tempTariff.Sms = el.Sms;
                    tempTariff.Tv = el.Tv;
                    tempTariff.GbInternet = el.GbInternet;
                }
                    

                if (Jaguar.CurUser.Balance < tempTariff.Price)
                    throw new Exception("Недостатньо коштів для нарахування нового пакету послуг");

                Jaguar.CurUser.ConnectTariff(currentTariffname);
                Jaguar.CurUser.Balance -= Jaguar.CurUser.Account.Price;
                Jaguar.CurUser.TSuperPower = null;

                //account.CallsOther = tempTariff.CallsOther;
                //account.GbInternet = tempTariff.GbInternet;
                //account.Tv = tempTariff.Tv;

                Jaguar.CurUser.AvailableTariffs = false;
                Jaguar.CurUser.AvailableSP = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void tariffItem_gd_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            currentTariffname = (sender as Grid).ToolTip.ToString();
        }


        private void SelectSuperpower_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var account = Jaguar.CurUser.Account;
                Tariff accCheck = tempTariff;
                var sp = Jaguar.CurUser.TSuperPower;
                bool? tempTariffTv = tempTariff.Tv;

                if (sp == null)
                    throw new Exception("Оберіть суперсилу");

                if (sp != tempSuperPower)
                {
                    if (tempSuperPower != null)
                    {
                        tempTariff.CallsOther += tempSuperPower.CallsOther;
                        tempTariff.GbInternet += tempSuperPower.GbInternet;
                        if (tempSuperPower.Tv) tempTariff.Tv = tempSuperPower.Tv;
                    }
                    if (account.CallsOther != tempTariff.CallsOther || account.GbInternet != tempTariff.GbInternet || account.Sms != tempTariff.Sms)
                        throw new Exception("Ви вже розрочали користування тарифом, суперсилу вже неможливо змінити");
                    if (tempSuperPower != null)
                    {
                        tempTariff.CallsOther -= tempSuperPower.CallsOther;
                        tempTariff.GbInternet -= tempSuperPower.GbInternet;
                        tempTariff.Tv = tempTariffTv;
                    }
                    account.CallsOther = tempTariff.CallsOther;
                    account.GbInternet = tempTariff.GbInternet;
                    account.Tv = tempTariff.Tv;

                    account.CallsOther += sp.CallsOther;
                    account.GbInternet += sp.GbInternet;
                    if (sp.Tv) account.Tv = sp.Tv;

                    tempSuperPower = sp;
                    Jaguar.CurUser.AvailableSP = false; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
