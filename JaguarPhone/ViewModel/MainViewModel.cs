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

            //Jaguar.CurUser = Jaguar.AllUsers[0];
            CurrentView = new AllUser();

            if (Jaguar.CurUser != null)
            {
                var userAccount = Jaguar.CurUser.Account;
                Task.Factory.StartNew(action: () =>
                {
                    while (true)
                    {
                        Task.Delay(500).Wait();

                        if (IsCalling == true && userAccount.CallsOther != 0)
                            userAccount.CallsOther -= 1;
                        if (IsInterneting == true && userAccount.GbInternet != 0)
                            userAccount.GbInternet -= 0.5;
                        if (IsSMSing == true && userAccount.Sms != 0)
                            userAccount.Sms -= 1;
                    }
                }); 
            }

        }

        private ObservableCollection<User> users = Jaguar.AllUsers.Where(el => el is User).Cast<User>().ToObservableCollection();
        private ObservableCollection<Admin> admins = Jaguar.AllUsers.Where(el => el is Admin && el.Telephone != 880345322).Cast<Admin>().ToObservableCollection();
        public ObservableCollection<Admin> Admins
        {
            get
            {
                return admins;
            }
            set
            {
                admins = value ?? throw new ArgumentNullException(nameof(value));
                RaisePropertyChanged(() => Admins); // обнова змінної при кожному set
            }
        }
        public ObservableCollection<User> Users
        {
            get
            {
                return users;
            }
            set
            {
                users = value ?? throw new ArgumentNullException(nameof(value));
                RaisePropertyChanged(() => Users); // обнова змінної при кожному set
            }
        }

        public static bool? IsCalling { get; set; } = false;
        public static bool? IsInterneting { get; set; } = false;
        public static bool? IsSMSing { get; set; } = false;

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
        public ICommand OpenSuperAdminGrant=> new DelegateCommand(() => CurrentView = new SuperAdminGrant());
        public ICommand OpenAllUserServices => new DelegateCommand(() => CurrentView = new AllUserServices());
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
