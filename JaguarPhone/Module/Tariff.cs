using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text.Json.Serialization;
using JaguarPhone.Module.Enums;

namespace JaguarPhone.Module
{
    public class Tariff
    {
        private string name;
        private uint price;
        private double gbInternet;
        private bool callsJaguar;
        private uint callsOther;
        private uint sms;
        private bool tv;
        private ObservableCollection<SuperPower> listSuperpower = new();
        private readonly PrestigeTariffs prestigeTariff;

        public Tariff(string name, uint price, double gbInternet, bool callsJaguar, uint callsOther, uint sms, bool tv)
        {
            Name = name;
            Price = price;
            GbInternet = gbInternet;
            CallsJaguar = callsJaguar;
            CallsOther = callsOther;
            Sms = sms;
            Tv = tv;
            prestigeTariff = SetPrestigeTariff();
        }

        PrestigeTariffs SetPrestigeTariff()
        {
            PrestigeTariffs rez = PrestigeTariffs.Silver;

            if (gbInternet >= 20) rez = PrestigeTariffs.Gold;
            if (gbInternet >= 100) rez = PrestigeTariffs.Platinum;

            return rez;
        }

        public string Name
        {
            get => name;
            set
            {
                if (value.Length < 3)
                    throw new Exception("Назва тарифу має бути більше 2 символів");
                name = value;
            }
        }
        public uint Price
        {
            get => price;
            set => price = value;
        }
        public double GbInternet
        {
            get => gbInternet;
            set
            {
                if (value < 0)
                    throw new Exception("Кількість гігабайт інтернету не може бути від'ємною");
                gbInternet = value;
            }
        }
        public bool CallsJaguar
        {
            get => callsJaguar;
            set => callsJaguar = value;
        }
        public uint CallsOther
        {
            get => callsOther;
            set => callsOther = value;
        }
        public uint Sms
        {
            get => sms;
            set => sms = value;
        }
        public bool Tv
        {
            get => tv;
            set => tv = value;
        }

        public ObservableCollection<SuperPower> ListSuperpower
        {
            get => listSuperpower;
            set => listSuperpower = value ?? throw new ArgumentNullException(nameof(value));
        }

        public PrestigeTariffs PrestigeTariff => prestigeTariff;

        protected bool Equals(Tariff other)
        {
            return name == other.name;
        }
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Tariff)obj);
        }
        public override int GetHashCode()
        {
            return name.GetHashCode();
        }

        public override string ToString()
        {
            return $" {name}";
        }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public string GetInfo => GetInfoMethod();
        string GetInfoMethod()
        {
            string t = "∞";
            string callsJags = "-";
            string tvs = "-";

            if(callsJaguar)
                callsJags = "∞";
            if (tv)
                tvs = "∞";

            return $"Ім'я: {name}\n Ціна: {price}\n Інтернет(ГБ): {gbInternet}\n Дзвінки Ягуар: {callsJags}\n " +
                   $"Дзвінки на інших операторів: {callsOther}\n СМС: {sms}\n ТВ: {tvs}";
        }

    }
}
