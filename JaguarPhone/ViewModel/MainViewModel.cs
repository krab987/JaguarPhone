using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Threading.Tasks;
using System.Windows;
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
                    Regist regist = new Regist();
                    regist.ShowDialog();
                });
            }
        }

        public ICommand Login
        {
            get
            {
                return new DelegateCommand(() =>
                {

                    SqlConnection myConnection = new SqlConnection();


                    SqlConnectionStringBuilder myBuilder = new SqlConnectionStringBuilder();

                    myBuilder.UserID = "sa";

                    myBuilder.Password = "admin@123";

                    myBuilder.InitialCatalog = "test";

                    myBuilder.DataSource = "RAVI";

                    myBuilder.ConnectTimeout = 30;

                    myConnection.ConnectionString = myBuilder.ConnectionString;
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
