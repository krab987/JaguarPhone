using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            this.name = name;
            this.price = price;
            this.about = about;
        }

        public override string ToString()
        {
            return $"{nameof(name)}: {name}, {nameof(price)}: {price}, {nameof(about)}: {about}";
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
        public string About
        {
            get => about;
            set => about = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
