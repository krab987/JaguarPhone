using System;
using System.Collections.Generic;

namespace JaguarPhone.Module
{
    public class Jaguar
    {
        private static List<Service> _allServices;
        private static List<SuperPower> _allSuperPower;
        private static List<Tariff> _allTariffs;
        private static List<Tariff> _checkTariffs;
        private static List<User> _allUsers;
        private static Admin _admin;


        public Jaguar()
        {
            _allServices = new List<Service>();
            _allSuperPower = new List<SuperPower>();
            _allTariffs = new List<Tariff>();
            _checkTariffs = new List<Tariff>();
            _allUsers = new List<User>();
            _admin = new Admin("Vitalii");

            _allSuperPower.Add(new SuperPower("Немає", 0, 0, false));
            _allTariffs.Add(new Tariff("Знайомтесь Jaguar!",0, 0.1, false, 20, 0, false, _allSuperPower[0]));
        }
        
        public static List<Service> AllServices
        {
            get => _allServices;
            set => _allServices = value ?? throw new ArgumentNullException(nameof(value));
        }
        public static List<SuperPower> AllSuperPower
        {
            get => _allSuperPower;
            set => _allSuperPower = value ?? throw new ArgumentNullException(nameof(value));
        }
        public static List<Tariff> AllTariffs
        {
            get => _allTariffs;
            set => _allTariffs = value ?? throw new ArgumentNullException(nameof(value));
        }
        public static List<Tariff> CheckTariffs
        {
            get => _checkTariffs;
            set => _checkTariffs = value ?? throw new ArgumentNullException(nameof(value));
        }
        public static List<User> AllUsers
        {
            get => _allUsers;
            set => _allUsers = value ?? throw new ArgumentNullException(nameof(value));
        }
        public static Admin Admin { get => _admin; }
    }
}
