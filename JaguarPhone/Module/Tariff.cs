using System;
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
        private SuperPower tSuperPower;
        private readonly PrestigeTariffs prestigeTariff;

        public Tariff(string name, uint price, double gbInternet, bool callsJaguar, uint callsOther, uint sms, bool tv, SuperPower tSuperPower)
        {
            this.name = name;
            this.price = price;
            this.gbInternet = gbInternet;
            this.callsJaguar = callsJaguar;
            this.callsOther = callsOther;
            this.sms = sms;
            this.tv = tv;
            this.tSuperPower = tSuperPower;
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
            set => name = value ?? throw new ArgumentNullException(nameof(value));
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
                if(value >=0)
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
        public SuperPower TSuperPower
        {
            get => tSuperPower;
            set => tSuperPower = value ?? throw new ArgumentNullException(nameof(value));
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
            return $"Name: {name}, Price: {price}, GbInternet: {gbInternet}, CallsJaguar: {callsJaguar}, CallsOther: {callsOther}, Sms: {sms}, Tv: {tv}, TSuperPower: {tSuperPower}, PrestigeTariffs: {prestigeTariff}";
        }
    }
}
