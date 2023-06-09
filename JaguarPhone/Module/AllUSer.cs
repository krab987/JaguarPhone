﻿using JaguarPhone.Module.Enums;
using JaguarPhone.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace JaguarPhone.Module
{
    public abstract class AllUSer: INotifyPropertyChanged
    {
        private string name;
        private string lastName;
        private uint balance;
        private int telephone;
        private string password;
        private DateOnly dateConnecing;
        private TelModel telModel;
        private bool esimSupport;
        private ObservableCollection<Service> listServices;
        private ObservableCollection<string> activities;

        private Tariff account;
        private Tariff tariffCurrent;
        private DateOnly dateTariff;
        private SuperPower tSuperPower;

        public AllUSer(string name, string lastName, string telephone, string password, TelModel telModel)
        {
            this.name = name;
            LastName = lastName;

            if (telephone.Length != 10)
                throw new Exception("Номер телефону має складатися з 10 чисел та починатися з 0");
            Telephone = Convert.ToInt32(telephone);
            Password = password;
            this.telModel = telModel;
            balance = 0;
            dateConnecing = DateOnly.FromDateTime(DateTime.Now);
            DateTariff = DateOnly.FromDateTime(DateTime.Now);

            esimSupport = telModel != TelModel.Інша;
            listServices = new ObservableCollection<Service>();
            activities = new ObservableCollection<string>();
            Account = new Tariff();
            Account.CallsJaguar = false;
            Account.Tv = false;

            AvailableSP = true;
            AvailableTariffs = true;
        }
        public AllUSer(string name, string lastName, uint balance, int telephone, DateOnly dateConnecing, TelModel telModel, bool esimSupport, Tariff account, ObservableCollection<Service> listServices, ObservableCollection<string> activities)
        {
            this.name = name;
            this.lastName = lastName;
            this.balance = balance;
            this.telephone = telephone;
            this.dateConnecing = dateConnecing;
            this.telModel = telModel;
            this.esimSupport = esimSupport;
            account = account;
            ListServices = listServices;
            Activities = activities;
        }
        public AllUSer(){ }

        public virtual bool AddTariff(Tariff tariff)
        {
            try
            {
                Jaguar.CheckTariffs.Add(tariff);
                Activities.Add($"Запропоновано тариф: {tariff.Name} - {DateTime.Now}");
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
                Account ??= new Tariff();
                Account.Name = el.Name;
                Account.CallsJaguar = el.CallsJaguar;
                Account.CallsOther = el.CallsOther;
                Account.ListSuperpower = el.ListSuperpower;
                Account.Sms = el.Sms;
                Account.Tv = el.Tv;
                Account.GbInternet = el.GbInternet;
                Account.Price = el.Price;

                Activities.Add($"Підключено тариф: {name} - {DateTime.Now} - баланс: {Balance}");
                
                DateTariff = DateTariff.AddDays(28);
                return true;
            }
            return false;
        }
        public bool ConnectService(string name)
        {
            Service serv = null;
            foreach (var el in Jaguar.AllServices.Where(el => el.Name == name)) serv = el;

            if (serv == null)
                return false;

            if(Jaguar.CurUser.ListServices != null)
                foreach (Service service in Jaguar.CurUser.ListServices)
                    if (service == serv)
                    {
                        throw new Exception("Послуга вже підключена");
                        return false;
                    }

            ListServices.Add(serv);
            Activities.Add($"Підключено сервіс: {serv.Name} - {DateTime.Now} - баланс: {balance}");
            return true;
        }
        public bool RemoveService(Service serv) => ListServices.Remove(serv);

        public string Name
        {
            get => name;
            set => SetField(ref name, value, "Name");
        }
        public string LastName
        {
            get => lastName;
            set => SetField(ref lastName, value, "LastName");
        }
        public uint Balance
        {
            get => balance;
            set => SetField(ref balance, value, "Balance");
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
                if (value != null)
                {
                    if (!Regex.IsMatch(value, @"^(?=.*[a-zA-Z])(?=.*\d)") || value.Length < 6 || value.Length > 256)
                        throw new ArgumentException(
                            "Пароль повинен містити принаймні одну літеру і одну цифру, і бути від 6 до 256 символів."); 
                }
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
            set
            {
                telModel = value;
                EsimSupport = telModel != TelModel.Інша;
            }
        }
        public bool EsimSupport
        {
            get => esimSupport;
            set => SetField(ref esimSupport, value, "EsimSupport");
        }

        public ObservableCollection<Service> ListServices
        {
            get => listServices;
            set => SetField(ref listServices, value, "ListServices");
        }
        public ObservableCollection<string> Activities
        {
            get => activities;
            set => SetField(ref activities, value, "Activities");
        }

        public DateOnly DateTariff
        {
            get => dateTariff;
            set => SetField(ref dateTariff, value, "DateTariff");
        }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public SuperPower TSuperPower
        {
            get => tSuperPower;
            set => SetField(ref tSuperPower, value, "TSuperPower");

        }
        public SuperPower? SuperPowerCurrent { get; set; }
        public Tariff TariffCurrent
        {
            get => tariffCurrent;
            set => tariffCurrent = value;
        }
        public Tariff Account
        {
            get => account;
            set => SetField(ref account, value, "Account");

        }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public uint PriceServices
        {
            get
            {
                uint price = 0;
                foreach (Service service in ListServices) price += service.Price;
                return price;
            }
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

        public override string ToString()
        {
            return $"{Telephone}";
        }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public string GetInfo => GetInfoMethod();
        string GetInfoMethod()
        {
            return $"Ім'я: {name}\n Прізвище: {lastName}\n Дата підключення: {DateConnecing}";
        }

        private bool availableTariffses;
        public bool AvailableTariffs
        {
            get => availableTariffses;
            set => SetField(ref availableTariffses, value, "AvailableTariffs");
        }
        private bool availableSP;
        public bool AvailableSP
        {
            get => availableSP;
            set => SetField(ref availableSP, value, "AvailableSP");
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
