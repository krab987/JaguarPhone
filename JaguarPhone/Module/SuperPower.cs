using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JaguarPhone.Module
{
    public class SuperPower: INotifyPropertyChanged
    {
        private string name;
        private double gbInternet;
        private uint callsOther;
        private bool tv;

        public string Name
        {
            get => name;
            set => SetField(ref name, value, "Name");
        }
        public double GbInternet
        {
            get => gbInternet;
            set => SetField(ref gbInternet, value, "GbInternet");
        }
        public uint CallsOther
        {
            get => callsOther;
            set => SetField(ref callsOther, value, "CallsOther");
        }
        public bool Tv
        {
            get => tv;
            set => SetField(ref tv, value, "Tv");
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
