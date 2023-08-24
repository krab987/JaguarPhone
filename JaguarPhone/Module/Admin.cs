using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;
using JaguarPhone.Module.Enums;
using JaguarPhone.Module.Interfaces;
using JaguarPhone.ViewModel;

namespace JaguarPhone.Module
{
    public class Admin: AllUSer, IUser
    {
        public bool AddTariff(Tariff tariff)
        {
            foreach (var el in Jaguar.AllTariffs.Where(el => el.Equals(tariff)))
            {
                return false;
            }
            Activities.Add($"Адмін: Додано тариф: {tariff.Name} - {DateTime.Now}");
            Jaguar.AllTariffs.Add(tariff);
            return true;
        }
        public bool AddCustomerTariff(string name)
        {
            foreach (var el in Jaguar.CheckTariffs.Where(el => el.Name == name))
            {
                Activities.Add($"Адмін: Підтверджено тариф: {name} - {DateTime.Now}");
                return AddTariff(el);
            }
            return false;
        }
        public bool AddCustomerTariff(Tariff tariff)
        {
            Activities.Add($"Адмін: Підтверджено тариф: {tariff.Name} - {DateTime.Now}");
            Jaguar.CheckTariffs.Remove(tariff);
            return AddTariff(tariff);
        }
        public bool RemoveTariff(string name)
        {
            foreach (var el in Jaguar.AllTariffs.Where(el => el.Name == name))
            {
                Activities.Add($"Адмін: Видалено тариф: {el.Name} - {DateTime.Now}");
                Jaguar.AllTariffs.Remove(el);
                return true;
            }

            return false;
        }
        public bool RemoveTariff(Tariff tariff)
        {
            Activities.Add($"Адмін: Видалено тариф: {tariff.Name} - {DateTime.Now}");
            return Jaguar.AllTariffs.Remove(tariff);
        }
        public bool CorrectTariff(string name, string newName, uint newPrice, double newGbInternet, bool newCallsJaguar,
            uint newCallsOther, uint newSms, bool newTv)
        {
            foreach (var el in Jaguar.AllTariffs.Where(el => el.Name == name))
            {
                el.Name = newName;
                el.Price = newPrice;
                el.GbInternet = newGbInternet;
                el.CallsJaguar = newCallsJaguar;
                el.CallsOther = newCallsOther;
                el.Sms = newSms;
                el.Tv = newTv;
                Activities.Add($"Адмін: Кореговано тариф: {el.Name} - {DateTime.Now}");
                return true;
            }

            return false;
        }
        public bool CorrectTariff(Tariff tariff, string newName, uint newPrice, double newGbInternet, bool? newCallsJaguar,
            uint newCallsOther, uint newSms, bool? newTv)
        {
            tariff.Name = newName;
            tariff.Price = newPrice;
            tariff.GbInternet = newGbInternet;
            tariff.CallsJaguar = newCallsJaguar;
            tariff.CallsOther = newCallsOther;
            tariff.Sms = newSms;
            tariff.Tv = newTv;
            Activities.Add($"Адмін: Кореговано тариф: {tariff.Name} - {DateTime.Now}");
            return true;
        }

        public bool AddService(Service service)
        {
            foreach (var el in Jaguar.AllServices.Where(el => el.Equals(service)))
            {
                return false;
            }
            Activities.Add($"Адмін: Додано сервіс: {service.Name} - {DateTime.Now}");
            Jaguar.AllServices.Add(service);
            return true;
        }
        public bool RemoveService(Service service)
        {
            Activities.Add($"Адмін: Видалено сервіс: {service.Name} - {DateTime.Now}");
            return Jaguar.AllServices.Remove(service);
        }
        public bool CorrectService(Service? service, string newName, uint newPrice, string newAbout)
        {
            if (service != null)
            {
                service.Name = newName;
                service.Price = newPrice;
                service.About = newAbout;
                Activities.Add($"Адмін: Кореговано сервіс: {service.Name} - {DateTime.Now}");
                return true;
            }

            return false;
        }

        public bool AddSuperPower(SuperPower superPower)
        {
            foreach (var el in Jaguar.AllSuperPower.Where(el => el.Equals(superPower)))
            {
                return false;
            }
            Activities.Add($"Адмін: Додано суперсилу: {superPower.Name} - {DateTime.Now}");
            Jaguar.AllSuperPower.Add(superPower);
            return true;
        }
        public bool RemoveSuperPower(SuperPower sp)
        {
            Activities.Add($"Адмін: Видалено суперсилу: {sp.Name} - {DateTime.Now}");
            return Jaguar.AllSuperPower.Remove(sp);
        }
        public bool CorrectSuperPower(SuperPower sp, string newName, double gbInternet, uint callsOther, bool? tv)
        {
            sp.Name = newName;
            sp.GbInternet = gbInternet;
            sp.CallsOther = callsOther;
            if (tv == true) sp.Tv = true;
            Activities.Add($"Адмін: Кореговано суперсилу: {sp.Name} - {DateTime.Now}");
            return true;
        }

        public bool AddUser(User user)
        {
            foreach (var el in Jaguar.AllUsers.Where(el => el.Equals(user)))
            {
                return false;
            }
            Jaguar.AllUsers.Add(user);
            Jaguar.AllUsers[^1].Activities.Add($"Користувача {Jaguar.AllUsers[^1].Name} створено - {DateTime.Now}");
            return true;
        }
        
        public bool RemoveUser(AllUSer allUSer)
        {
            return Jaguar.AllUsers.Remove(allUSer);
        }

        public Admin(string name, string lastName, string telephone, string password, TelModel telModel) : base(name, lastName, telephone, password, telModel)
        {
        }
        public Admin(string name, string lastName, uint balance, int telephone, DateOnly dateConnecing, TelModel telModel, bool esimSupport, Tariff account, ObservableCollection<Service> listServices, ObservableCollection<string> activities) : base(name, lastName, balance, telephone, dateConnecing, telModel, esimSupport, account, listServices, activities)
        {
        }
        public Admin()
        {
        }
        public Admin(User userAd)
        {
            Name = userAd.Name;
            LastName = userAd.LastName;
            Balance = userAd.Balance;
            Telephone = userAd.Telephone;
            Password = userAd.Password;
            DateConnecing = userAd.DateConnecing;
            TelModel = userAd.TelModel;
            ListServices = userAd.ListServices;
            Activities = userAd.Activities;
            DateTariff = userAd.DateTariff;
            TSuperPower = userAd.TSuperPower;
            SuperPowerCurrent = userAd.SuperPowerCurrent;
            TariffCurrent = userAd.TariffCurrent;
            Account = userAd.Account;
            AvailableTariffs = userAd.AvailableTariffs;
            AvailableSP = userAd.AvailableSP;
        }
    }
}
