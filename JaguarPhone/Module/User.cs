using System;
using System.Collections.Generic;
using System.Linq;
using JaguarPhone.Module.Enums;
using JaguarPhone.Module.Interfaces;

namespace JaguarPhone.Module
{
    public class User: IUser
    {
        private string name;
        private string lastName;
        private int balance;
        private int telephone;
        private DateOnly dateConnecing;
        private TelModel telModel;
        private bool esimSupport;
        private string town;
        private Tariff _tariff;
        private List<Service> listServices;
        private List<string> activities;

        public User(string name, string lastName, int telephone, TelModel telModel, string town)
        {
            this.name = name;
            this.lastName = lastName;
            this.telephone = telephone;
            this.telModel = telModel;
            this.town = town;
            balance = 0;
            dateConnecing = DateOnly.FromDateTime(DateTime.Now);
            esimSupport = telModel != TelModel.Other;
            listServices = new List<Service>();
            activities = new List<string>();
            _tariff = Jaguar.AllTariffs[0];
        }

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
            return $"Name: {name}, LastName: {lastName}, Balance: {balance}, Telephone: {telephone}, DateConnecing: {dateConnecing}, TelModel: {telModel}, EsimSupport: {esimSupport}, Town: {town}, Tariff: {_tariff}, ListServices: {listServices}";
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

        public List<string> Activities
        {
            get => activities;
            set => activities = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
