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
