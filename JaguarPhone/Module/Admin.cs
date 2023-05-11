using System;
using System.Linq;
using JaguarPhone.Module.Interfaces;

namespace JaguarPhone.Module
{
    public class Admin: IUser
    {
        private string name;

        public Admin(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get => name;
            set => name = value ?? throw new ArgumentNullException(nameof(value));
        }

        public bool AddTariff(Tariff tariff)
        {
            foreach (var el in Jaguar.AllTariffs.Where(el => el.Equals(tariff)))
            {
                return false;
            }
            Jaguar.AllTariffs.Add(tariff);
            return true;
        }
        public bool AddCustomerTariff(string name)
        {
            foreach (var el in Jaguar.CheckTariffs.Where(el => el.Name == name))
            {
                return AddTariff(el);
            }
            return false;
        }
        public bool RemoveTariff(string name)
        {
            foreach (var el in Jaguar.AllTariffs.Where(el => el.Name == name))
            {
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
            Jaguar.AllServices.Add(service);
            return true;
        }
        public bool RemoveService(string name)
        {
            foreach (var el in Jaguar.AllServices.Where(el => el.Name == name))
            {
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
            Jaguar.AllSuperPower.Add(superPower);
            return true;
        }
        public bool RemoveSuperPower(string name)
        {
            foreach (var el in Jaguar.AllSuperPower.Where(el => el.Name == name))
            {
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
                return true;
            }
            return false;
        }


        public override string ToString()
        {
            return $"Name: {name}";
        }
    }
}
