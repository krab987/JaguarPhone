using JaguarPhone.Module.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JaguarPhone.Module
{
    public abstract class AllUSer: INotifyPropertyChanged
    {
        private string name;
        private string lastName;
        private int balance;
        private int telephone;
        private string password;
        private DateOnly dateConnecing;
        private TelModel telModel;
        private bool esimSupport;
        private Tariff _tariff;
        private ObservableCollection<Service> listServices;
        private ObservableCollection<string> activities;
        private DateOnly dateTariff;

        public AllUSer(string name, string lastName, string telephone, string password, TelModel telModel)
        {
            this.name = name;
            this.lastName = lastName;

            if (telephone.Length != 10)
                throw new Exception("Номер телефону має складатися з 10 чисел та починатися з 0");
            Telephone = Convert.ToInt32(telephone);
            Password = password;
            this.telModel = telModel;
            balance = 0;
            dateConnecing = DateOnly.FromDateTime(DateTime.Now);
            esimSupport = telModel != TelModel.Інша;
            listServices = new ObservableCollection<Service>();
            activities = new ObservableCollection<string>();
            Tariff = Jaguar.AllTariffs[0];
        }
        public AllUSer(string name, string lastName, int balance, int telephone, DateOnly dateConnecing, TelModel telModel, bool esimSupport, Tariff tariff, ObservableCollection<Service> listServices, ObservableCollection<string> activities)
        {
            this.name = name;
            this.lastName = lastName;
            this.balance = balance;
            this.telephone = telephone;
            this.dateConnecing = dateConnecing;
            this.telModel = telModel;
            this.esimSupport = esimSupport;
            _tariff = tariff;
            ListServices = listServices;
            Activities = activities;
        }

        public AllUSer(){ }

        public bool AddTariff(Tariff tariff)
        {
            try
            {
                Jaguar.CheckTariffs.Add(tariff);
                activities.Add($"Created Tariff: {tariff.Name} - {DateTime.Now}");
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool ConnectTariff(string name)
        {
            foreach (var el in Jaguar.AllTariffs.Where(el => el.Name == name))
            {
                _tariff = el;
                activities.Add($"Connected Tariff: {name} - {DateTime.Now}");
                return true;
            }
            return false;

        }
        public bool ConnectService(string name)
        {
            foreach (var el in Jaguar.AllServices.Where(el => el.Name == name))
            {
                listServices.Add(el);
                activities.Add($"Connected Service: {name} - {DateTime.Now}");
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Name: {name}, LastName: {lastName}, Balance: {balance}, Telephone: {telephone}, DateConnecing: {dateConnecing}, TelModel: {telModel}, EsimSupport: {esimSupport}, Tariff: {_tariff}, ListServices: {listServices}";
        }
        public string Name
        {
            get => name;
            set => name = value ?? throw new ArgumentNullException(nameof(value));
        }
        public string LastName
        {
            get => lastName;
            set => lastName = value ?? throw new ArgumentNullException(nameof(value));
        }
        public int Balance
        {
            get => balance;
            set => balance = value;
        }
        public int Telephone
        {
            get => telephone;
            set => telephone = value;
        }
        public string Password
        {
            get => password;
            set
            {
                //if (!Regex.IsMatch(value, @"^(?=.*[a-zA-Z])(?=.*\d)") || value.Length < 6 || value.Length > 256)
                //{
                //    throw new ArgumentException(
                //        "Пароль повинен містити принаймні одну літеру і одну цифру, і бути від 6 до 256 символів.");
                //}
                password = value;
            }
        }

        public DateOnly DateConnecing
        {
            get => dateConnecing;
            set => dateConnecing = value;
        }
        public TelModel TelModel
        {
            get => telModel;
            set => telModel = value;
        }
        public Tariff Tariff
        {
            get => _tariff;
            set
            {
                _tariff = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        public ObservableCollection<Service> ListServices
        {
            get => listServices;
            set => listServices = value ?? throw new ArgumentNullException(nameof(value));
        }
        public ObservableCollection<string> Activities
        {
            get => activities;
            set => activities = value ?? throw new ArgumentNullException(nameof(value));
        }

        public DateOnly DateTariff
        {
            get => dateTariff;
            set => SetField(ref dateTariff, value, "DateTariff");
        }

        protected bool Equals(AllUSer other)
        {
            return telephone == other.telephone;
        }
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AllUSer)obj);
        }
        public override int GetHashCode()
        {
            return telephone;
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
