using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JaguarPhone.Module
{
    public class Service
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
                name = value;
            }
        }
        public uint Price
        {
            get => price;
            set => price = value;
        }
        public string About
        {
            get => about;
            set
            {
                if (value.Length < 15)
                    throw new Exception("Опис не може бути менше 15 символів");
                about = value;
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
    }
}
