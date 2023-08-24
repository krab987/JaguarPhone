using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using JaguarPhone.Module.Enums;

namespace JaguarPhone.Module
{
    public class Tariff: INotifyPropertyChanged
    {
        private string name;
        private uint price;
        private double gbInternet;
        private bool? callsJaguar;
        private uint callsOther;
        private uint sms;
        private bool? tv;
        private ObservableCollection<SuperPower> listSuperpower = new();
        private PrestigeTariffs prestigeTariff;

        public Tariff(string name, uint price, double gbInternet, bool? callsJaguar, uint callsOther, uint sms, bool? tv)
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
        public Tariff(){ }
        PrestigeTariffs SetPrestigeTariff()
        {
            PrestigeTariffs rez = PrestigeTariffs.Silver;

            if (gbInternet >= 10) rez = PrestigeTariffs.Gold;
            if (gbInternet >= 40) rez = PrestigeTariffs.Platinum;

            return rez;
        }

        public string Name
        {
            get => name;
            set
            {
                if (value.Length < 3)
                    throw new Exception("Назва тарифу має бути більше 2 символів");
                SetField(ref name, value, "Name");
            }
        }
        public uint Price
        {
            get => price;
            set
            {
                SetField(ref price, value, "Price");
            }
        }

        public double GbInternet
        {
            get => gbInternet;
            set
            {
                if (value < 0)
                    throw new Exception("Кількість гігабайт інтернету не може бути від'ємною");
                SetField(ref gbInternet, value, "GbInternet");
                prestigeTariff = SetPrestigeTariff();
            }
        }
        public bool? CallsJaguar
        {
            get => callsJaguar;
            set => SetField(ref callsJaguar, value, "CallsJaguar");
        }

        public uint CallsOther
        {
            get => callsOther;
            set => SetField(ref callsOther, value, "CallsOther");
        }
        public uint Sms
        {
            get => sms;
            set => SetField(ref sms, value, "Sms");
        }
        public bool? Tv
        {
            get => tv;
            set => SetField(ref tv, value, "Tv");

        }

        public ObservableCollection<SuperPower> ListSuperpower
        {
            get => listSuperpower;
            set => SetField(ref listSuperpower, value, "ListSuperpower");
        }

        public PrestigeTariffs PrestigeTariff
        {
            get => prestigeTariff;
        }

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

            if(callsJaguar == true)
                callsJags = "∞";
            if (tv == true)
                tvs = "∞";

            return $"Ім'я: {name}\n Ціна: {price}\n Інтернет(ГБ): {gbInternet}\n Дзвінки Ягуар: {callsJags}\n " +
                   $"Дзвінки на інших операторів: {callsOther}\n СМС: {sms}\n ТВ: {tvs}";
        }



        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
