using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using JaguarPhone.Module;
using JaguarPhone.View;
using JaguarPhone.View.Controls;

namespace JaguarPhone.ViewModel
{
    class MainViewModel: ViewModelBase
    {
        public MainViewModel()
        {
            Jaguar.Load();

            // delete this to show prog
            Jaguar.CurUser = Jaguar.AllUsers[0];
            CurrentView = new AllUser();

            //Jaguar.AllServices.Add(new Service("30 хвилин на інші мережі", 25, "Отримайте 30 хвилин до вашого тарифу, щоб телефонувати на інші мережі та міські номери по Україні.\r\n\r\nВитрачайте додаткові хвилини для дзвінків на інші мобільні та міські номери по Україні. Термін дії: 4 тижні, невикористані хвилини анулюються.\r\n\r\nПакет продовжується автоматично.\r\n\r\nБудь ласка, зверніть увагу. Якщо у вашому тарифі передбачені нетарифіковані хвилини, у першу чергу використовуватимуться додаткові хвилини з пакета, потім діють умови вашого тарифу.\r\n\r\nЩоб підключити, треба мати на рахунку суму для першого платежу за послугу."));
            //Jaguar.AllServices.Add(new Service("День Онлайн 1000мб", 25, "Не шукайте Wi-Fi, якщо раптом закінчився мобільний інтернет. Підключайте додаткові 1000 МБ у пакеті День онлайн.\r\n\r\nЩоб підключити, треба мати на рахунку суму для першого платежу за послугу."));
            //Jaguar.AllTariffs.Add(new Tariff("Знайомтесь Jaguar!", 30, 0.2, true, 0, 0, false));
            //Jaguar.AllTariffs.Add(new Tariff("Смачний", 125, 25, true, 100, 10, false));
            //Jaguar.AllTariffs.Add(new Tariff("Планшет", 140, 40, false, 0, 15, true));
            //Jaguar.AllSuperPower.Add((new SuperPower("Телебачення", 0, 0, true)));
            //Jaguar.AllSuperPower.Add((new SuperPower("Разом - сила!", 4, 50, false)));
            //Jaguar.CheckTariffs.Add(new Tariff("МегаУльтраПроМакс", 20, 60, true, 1000, 3000, true));
            //Jaguar.CheckTariffs.Add(new Tariff("Вперед", 200, 45, true, 200, 10, true));
            //Jaguar.Save();


            //Task.Factory.StartNew(() =>
            //{
            //    Account = Jaguar.CurUser.Tariff;
            //    foreach (var el in Jaguar.CurUser.Tariff.ListSuperpower)
            //    {
            //        if (Equals(Jaguar.CurUser.TSuperPower, el))
            //        {
            //            Account.CallsOther += el.CallsOther;
            //            Account.GbInternet += el.GbInternet;
            //            if (el.Tv)
            //                Account.Tv = el.Tv;
            //        }
            //    }
            //});
            //Task.Factory.StartNew(() =>
            //{
            //    AvailableTariffs = Jaguar.AllTariffs;
            //    foreach (var el in Jaguar.AllTariffs)
            //        if (Equals(Jaguar.CurUser.Tariff, el))
            //            AvailableTariffs.Remove(el);
            //})

            //DatePayTariff = Jaguar.CurUser.DateTariff.AddDays(28);
            //if (DatePayTariff < DateOnly.FromDateTime(DateTime.Now))
            //    DatePayTariff = DateOnly.FromDateTime(DateTime.Now);

            //Account = Jaguar.CurUser.Tariff;
            //foreach (var el in Jaguar.CurUser.Tariff.ListSuperpower)
            //{
            //    if (Equals(Jaguar.CurUser.TSuperPower, el))
            //    {
            //        Account.CallsOther += el.CallsOther;
            //        Account.GbInternet += el.GbInternet;
            //        if (el.Tv)
            //            Account.Tv = el.Tv;
            //    }
            //}

            //foreach (var el in Jaguar.AllTariffs)
            //    if (Equals(Jaguar.CurUser.Account, el))
            //        AvailableTariffs.Remove(el);

        }

        ObservableCollection<Admin> admins = Jaguar.AllUsers.Where(el => el is Admin && el.Telephone != 960345222).Cast<Admin>().ToObservableCollection();
        ObservableCollection<User> users = Jaguar.AllUsers.Where(el => el is User).Cast<User>().ToObservableCollection();
        public ObservableCollection<Admin> Admins
        {
            get => admins;
            set
            {
                admins = value ?? throw new ArgumentNullException(nameof(value));
                RaisePropertyChanged(() => Users); // обнова змінної при кожному set

            }
        }
        public ObservableCollection<User> Users
        {
            get => users;
            set
            {
                users = value ?? throw new ArgumentNullException(nameof(value));
                RaisePropertyChanged(() => Users); // обнова змінної при кожному set
            }
        }

        #region Switch UserControls
        private object currentView;
        public object CurrentView
        {
            get => currentView;
            set
            {
                currentView = value;
                RaisePropertyChanged(() => CurrentView); // обнова змінної при кожному set
            }
        }
        public ICommand OpenAllUserControl => new DelegateCommand(() => CurrentView = new AllUser());
        public ICommand OpenAdminTariffControl => new DelegateCommand(() => CurrentView = new AdminTariff());
        public ICommand OpenAdminServSPControl => new DelegateCommand(() => CurrentView = new AdminServicesSuperpowers());
        public ICommand OpenProfile=> new DelegateCommand(() => CurrentView = new Profile()); 
        public ICommand OpenAllUserTariff=> new DelegateCommand(() => CurrentView = new AllUserTariff()); 
        #endregion


        public ICommand OpenRegist
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    Regist registForm = new Regist();
                    registForm.ShowDialog();
                });
            }
        }
    }
}


        //private int clicks;
        //public int Clicks
        //{
        //    get => clicks;
        //    set
        //    {
        //        clicks = value;
        //        RaisePropertyChanged(() => Clicks); // обнова змінної при кожному set
        //    }
        //}
        //public MainViewModel()
        //{
        //    Task.Factory.StartNew(() =>
        //    {
        //        while (true)
        //        {
        //            Task.Delay(1000).Wait();
        //            Clicks++;
        //        }
        //    });
        //}
        //public ICommand ClickAdd
        //{
        //    get
        //    {
        //        return new DelegateCommand(() =>
        //        {
        //            Clicks++;
        //        });
        //    }
        //}
