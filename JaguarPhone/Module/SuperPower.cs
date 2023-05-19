using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JaguarPhone.Module
{
    public class SuperPower
    {
        private string name;
        private double gbInternet;
        private uint callsOther;
        private bool tv;

        public string Name
        {
            get => name;
            set => name = value ?? throw new ArgumentNullException(nameof(value));
        }
        public double GbInternet
        {
            get => gbInternet;
            set => gbInternet = value;
        }
        public uint CallsOther
        {
            get => callsOther;
            set => callsOther = value;
        }
        public bool Tv
        {
            get => tv;
            set => tv = value;
        }

        public SuperPower(string name, double gbInternet, uint callsOther, bool tv)
        {
            this.name = name;
            this.gbInternet = gbInternet;
            this.callsOther = callsOther;
            this.tv = tv;
        }

        protected bool Equals(SuperPower other)
        {
            return name == other.name;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SuperPower)obj);
        }

        public override int GetHashCode()
        {
            return name.GetHashCode();
        }

        public override string ToString()
        {
            return $"{name}";
        }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public string GetInfo => GetInfoMethod();
        string GetInfoMethod()
        {
            string t = "∞";
            string tvs = "-";

            if (tv)
                tvs = "∞";

            return $"Ім'я: {name}\n Інтернет(ГБ): {gbInternet}\n Дзвінки на інших операторів: {callsOther}\n ТВ: {tvs}";
        }
    }
}
