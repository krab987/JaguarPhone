using JaguarPhone.Module.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaguarPhone.Module
{
    public abstract class AllUSer
    {
        private string name;
        private string lastName;
        private int balance;
        private int telephone;
        private DateOnly dateConnecing;
        private TelModel telModel;
        private bool esimSupport;
        private Tariff _tariff;
        private List<Service> listServices;
        private List<string> activities;

        public AllUSer(string name, string lastName, string telephone, TelModel telModel)
        {
            this.name = name;
            this.lastName = lastName;

            if (telephone.Length != 10)
                throw new Exception("Номер телефону має складатися з 10 чисел та починатися з 0");
            this.telephone = Convert.ToInt32(telephone);

            this.telModel = telModel;
            balance = 0;
            dateConnecing = DateOnly.FromDateTime(DateTime.Now);
            esimSupport = telModel != TelModel.Інша;
            listServices = new List<Service>();
            activities = new List<string>();
            _tariff = Jaguar.AllTariffs[0];
        }
        public AllUSer(string name, string lastName, int balance, int telephone, DateOnly dateConnecing, TelModel telModel, bool esimSupport, Tariff tariff, List<Service> listServices, List<string> activities)
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
            set => _tariff = value ?? throw new ArgumentNullException(nameof(value));
        }

        public List<Service> ListServices
        {
            get => listServices;
            set => listServices = value ?? throw new ArgumentNullException(nameof(value));
        }

        public List<string> Activities
        {
            get => activities;
            set => activities = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
