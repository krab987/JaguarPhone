using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace JaguarPhone.Module
{
    public class Service: INotifyPropertyChanged
    {
        private string name;
        private uint price;
        private string about;

        public Service(string name, uint price, string about)
        {
            Name = name;
            Price = price;
            About = about;
        }


        public string Name
        {
            get => name;
            set
            {
                if (value.Length < 3)
                    throw new Exception("Назва не може бути менше 3 символів");
                SetField(ref name, value, "Name");
            }
        }
        public uint Price
        {
            get => price;
            set => SetField(ref price, value, "Price");
        }
        public string About
        {
            get => about;
            set
            {
                if (value.Length < 15)
                    throw new Exception("Опис не може бути менше 15 символів");
                SetField(ref about, value, "About");

            }
        }

        protected bool Equals(Service other)
        {
            return name == other.name;
        }
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Service)obj);
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
        public string GetInfo
        {
            get => $"Ім'я: {name}\n Ціна: {price}\n Опис: {about}";
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
