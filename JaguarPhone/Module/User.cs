using System;
using System.Collections.ObjectModel;
using JaguarPhone.Module.Enums;
using JaguarPhone.Module.Interfaces;

namespace JaguarPhone.Module
{
    public class User: AllUSer, IUser
    {
        public User(string name, string lastName, string telephone, string password, TelModel telModel) : base(name, lastName, telephone, password, telModel)
        {
        }

        public User(string name, string lastName, uint balance, int telephone, DateOnly dateConnecing, TelModel telModel, bool esimSupport, Tariff account, ObservableCollection<Service> listServices, ObservableCollection<string> activities) : base(name, lastName, balance, telephone, dateConnecing, telModel, esimSupport, account, listServices, activities)
        {
        }

        public User()
        {
        }
        public User(Admin adminUs)
        {
            Name = adminUs.Name;
            LastName = adminUs.LastName;
            Balance = adminUs.Balance;
            Telephone = adminUs.Telephone;
            Password = adminUs.Password;
            DateConnecing = adminUs.DateConnecing;
            TelModel = adminUs.TelModel;
            ListServices = adminUs.ListServices;
            Activities = adminUs.Activities;
            DateTariff = adminUs.DateTariff;
            TSuperPower = adminUs.TSuperPower;
            SuperPowerCurrent = adminUs.SuperPowerCurrent;
            TariffCurrent = adminUs.TariffCurrent;
            Account = adminUs.Account;
            AvailableTariffs = adminUs.AvailableTariffs;
            AvailableSP = adminUs.AvailableSP;
        }
    }
}
