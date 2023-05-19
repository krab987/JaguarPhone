using System;
using System.Threading.Tasks;
using System.Windows.Input;
using DevExpress.Mvvm;
using JaguarPhone.Module;
using JaguarPhone.View;

namespace JaguarPhone.ViewModel
{
    class MainViewModel: ViewModelBase
    {
        public MainViewModel()
        {
            Jaguar.Load();
            Jaguar.CurUser = Jaguar.AllUsers[0];
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

            Task.Factory.StartNew(() =>
            {
                DatePayTariff = Jaguar.CurUser.DateTariff.AddDays(28);
            });
        }
        private DateOnly datePayTariff;
        public DateOnly DatePayTariff
        {
            get => datePayTariff;
            set
            {
                datePayTariff = Jaguar.CurUser.DateTariff.AddDays(28);
                RaisePropertyChanged(() => DatePayTariff); // обнова змінної при кожному set
            }
        }

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
    }
}
