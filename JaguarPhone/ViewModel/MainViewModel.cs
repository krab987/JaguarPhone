using System.Threading.Tasks;
using System.Windows.Input;
using DevExpress.Mvvm;

namespace JaguarPhone.ViewModel
{
    class MainViewModel: ViewModelBase
    {
        public ICommand WatermarkCheck
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    //Clicks++;
                });
            }
        }

        private int clicks;
        public int Clicks
        {
            get => clicks;
            set
            {
                clicks = value;
                RaisePropertyChanged(() => Clicks); // обнова змінної при кожному set
            }
        }
        public MainViewModel()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Task.Delay(1000).Wait();
                    Clicks++;
                }
            });
        }
        public ICommand ClickAdd
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    Clicks++;
                });
            }
        }
    }
}
