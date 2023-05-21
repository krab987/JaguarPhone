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
        private SuperPower? tempSuperPower;

        public AllUser()
        {
            InitializeComponent();
            foreach (var tariff in Jaguar.AllTariffs)
                if (tariff.Name == Jaguar.CurUser.Account.Name)
                {
                    tempTariff = new Tariff();
                    tempTariff.Name = tariff.Name;
                    tempTariff.GbInternet = tariff.GbInternet;
                    tempTariff.CallsJaguar = tariff.CallsJaguar;
                    tempTariff.CallsOther = tariff.CallsOther;
                    tempTariff.Sms = tariff.Sms;
                    tempTariff.Tv = tariff.Tv;
                }

            tempSuperPower = Jaguar.CurUser.SuperPowerCurrent;

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
            var curUser = Jaguar.CurUser;
            var dayPay = curUser.DateTariff;
            var dayNow = DateOnly.FromDateTime(DateTime.Now);

            if (dayPay < dayNow || dayPay == dayNow)
            {
                curUser.DateTariff = dayPay = dayNow;

                var acc = curUser.Account;
                acc.GbInternet = 0;
                acc.CallsJaguar = false;
                acc.CallsOther = 0;
                acc.Sms = 0;
                acc.Tv = false;

                curUser.AvailableTariffs = true;
            }

            if (dayPay == dayNow && curUser.Balance >= curUser.Account.Price)
            {
                curUser.Balance -= curUser.Account.Price;

                //Jaguar.CurUser.ConnectTariff(Jaguar.CurUser.Account.Name);
                var acc = curUser.Account;
                //tempTariff = curUser.TariffCurrent;

                acc.GbInternet = tempTariff.GbInternet;
                acc.CallsJaguar = tempTariff.CallsJaguar;
                acc.CallsOther = tempTariff.CallsOther;
                acc.Sms = tempTariff.Sms;
                acc.Tv = tempTariff.Tv;
                
                //curUser.Activities.Add($"Нараховано пакет послуг: {curUser.Account.Name} - {DateTime.Now} - баланс: {curUser.Balance}");
                //foreach (var el in Jaguar.AllTariffs.Where(el => el.Name == Jaguar.CurUser.Account.Name))
                //    tempTariff = el;

                var sp = curUser.SuperPowerCurrent;

                //account.CallsOther = tempTariff.CallsOther;
                //account.GbInternet = tempTariff.GbInternet;
                //account.Tv = tempTariff.Tv;

                if (sp != null)
                {
                    acc.CallsOther += sp.CallsOther;
                    acc.GbInternet += sp.GbInternet;
                    if (sp.Tv) acc.Tv = sp.Tv; 
                }

                curUser.AvailableSP = true;
                curUser.AvailableTariffs = true;
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
                uint priceCheck = 0;
                foreach (var el in Jaguar.AllTariffs.Where(el => el.Name == currentTariffname)) 
                    priceCheck = el.Price;

                if (Jaguar.CurUser.Balance < priceCheck)
                    throw new Exception("Недостатньо коштів для нарахування нового пакету послуг");
                foreach (var el in Jaguar.AllTariffs.Where(el => el.Name == currentTariffname))
                {
                    tempTariff.Name = el.Name;
                    tempTariff.GbInternet = el.GbInternet;
                    tempTariff.CallsJaguar = el.CallsJaguar;
                    tempTariff.CallsOther = el.CallsOther;
                    tempTariff.Sms = el.Sms;
                    tempTariff.Tv = el.Tv;
                    tempTariff.Price = el.Price;
                }

                //Jaguar.CurUser.TariffCurrent = tarCheckBalance;
                //foreach (var el in Jaguar.AllTariffs.Where(el => el.Name == currentTariffname))
                //{
                //    tempTariff = el;
                //    //tempTariff = el;
                //    //tempTariff.CallsJaguar = el.CallsJaguar;
                //    //tempTariff.CallsOther = el.CallsOther;
                //    //tempTariff.ListSuperpower = el.ListSuperpower;
                //    //tempTariff.Sms = el.Sms;
                //    //tempTariff.Tv = el.Tv;
                //    //tempTariff.GbInternet = el.GbInternet;
                //}

                Jaguar.CurUser.ConnectTariff(currentTariffname);
                Jaguar.CurUser.Balance -= Jaguar.CurUser.Account.Price;
                
                Jaguar.CurUser.SuperPowerCurrent = null;

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
                //tempTariff = Jaguar.CurUser.TariffCurrent;

                Tariff accCheck = tempTariff;
                var sp = Jaguar.CurUser.TSuperPower;
                bool? tempTariffTv = tempTariff.Tv;
                tempSuperPower = Jaguar.CurUser.SuperPowerCurrent;

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

                    Jaguar.CurUser.SuperPowerCurrent = sp;
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
