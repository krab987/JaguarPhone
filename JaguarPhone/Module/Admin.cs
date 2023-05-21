﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public bool RemoveService(string name)
        {
            foreach (var el in Jaguar.AllServices.Where(el => el.Name == name))
            {
                Activities.Add($"Адмін: Видалено сервіс: {el.Name} - {DateTime.Now}");
                Jaguar.AllServices.Remove(el);
                return true;
            }

            return false;
        }
        public bool CorrectService(string name, string newName, uint newPrice, string newAbout)
        {
            foreach (var el in Jaguar.AllServices.Where(el => el.Name == name))
            {
                el.Name = newName;
                el.Price = newPrice;
                el.About = newAbout;
                Activities.Add($"Адмін: Кореговано сервіс: {el.Name} - {DateTime.Now}");
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
        public bool RemoveSuperPower(string name)
        {
            foreach (var el in Jaguar.AllSuperPower.Where(el => el.Name == name))
            {
                Activities.Add($"Адмін: Видалено суперсилу: {el.Name} - {DateTime.Now}");
                Jaguar.AllSuperPower.Remove(el);
                return true;
            }

            return false;
        }
        public bool CorrectSuperPower(string name, string newName, double gbInternet, uint callsOther, bool tv)
        {
            foreach (var el in Jaguar.AllSuperPower.Where(el => el.Name == name))
            {
                el.Name = newName;
                el.GbInternet = gbInternet;
                el.CallsOther = callsOther;
                el.Tv = tv;
                Activities.Add($"Адмін: Кореговано суперсилу: {el.Name} - {DateTime.Now}");
                return true;
            }
            return false;
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
        public bool RemoveUser(string name)
        {
            foreach (var el in Jaguar.AllUsers.Where(el => el.Name == name))
            {
                Jaguar.AllUsers.Remove(el);
                return true;
            }
            return false;
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
    }
}
