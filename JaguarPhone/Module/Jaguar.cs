using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using DevExpress.Mvvm.Native;
using JaguarPhone.Module.Enums;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace JaguarPhone.Module
{
    public class Jaguar
    {
        private static ObservableCollection<Service> _allServices = new();
        private static ObservableCollection<SuperPower> _allSuperPower = new();
        private static ObservableCollection<Tariff> _allTariffs = new ObservableCollection<Tariff>();
        private static ObservableCollection<Tariff> _allCheckTariffs = new ObservableCollection<Tariff>();
        private static ObservableCollection<AllUSer> _allUsers = new ObservableCollection<AllUSer>();
        private static SuperAdmin _superAdmin;

        private static string _superAdminFile = @"W:\projects\C#\CourseWork\JaguarPhone\JaguarPhone\Jsons\superadmin.json";
        private static string _adminFile = @"W:\projects\C#\CourseWork\JaguarPhone\JaguarPhone\Jsons\admins.json";
        private static string _userFile = @"W:\projects\C#\CourseWork\JaguarPhone\JaguarPhone\Jsons\users.json";
        private static string _servisesFile = @"W:\projects\C#\CourseWork\JaguarPhone\JaguarPhone\Jsons\SavesInfo\servises.json";
        private static string _superpowersFile = @"W:\projects\C#\CourseWork\JaguarPhone\JaguarPhone\Jsons\SavesInfo\superpowers.json";
        private static string _tariffsFile = @"W:\projects\C#\CourseWork\JaguarPhone\JaguarPhone\Jsons\SavesInfo\tariffs.json";
        private static string _checktariffsFile = @"W:\projects\C#\CourseWork\JaguarPhone\JaguarPhone\Jsons\SavesInfo\checktariffs.json";

        public Jaguar()
        {
            _allSuperPower.Add(new SuperPower("Немає", 0, 0, false));
            _allTariffs.Add(new Tariff("Знайомтесь Jaguar!", 0, 0.1, false, 20, 0, false));
            _superAdmin = new SuperAdmin("Vitalii", "Krabovich", "0960345222", "", TelModel.Motorola_Razr);
            _allUsers.Add(_superAdmin);
        }

        public static void SaveUser()
        {
            //File.WriteAllText(_userFile, Empty);
            var users = _allUsers.Where(el => el is User).Cast<User>().ToObservableCollection();
            JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
            jsonOptions.WriteIndented = true;
            string userJson = JsonSerializer.Serialize(users, jsonOptions);
            File.WriteAllText(_userFile, userJson);
        }
        public static void Save()
        {
            var superadmin = _allUsers[0];
            var admins = _allUsers.Where(el => el is Admin && el.Telephone != 960345222).Cast<Admin>().ToObservableCollection();
            var users = _allUsers.Where(el => el is User).Cast<User>().ToObservableCollection();

            JsonSerializerOptions jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string superAdminJson = JsonSerializer.Serialize(superadmin, jsonOptions);
            string adminJson = JsonSerializer.Serialize(admins, jsonOptions);
            string userJson = JsonSerializer.Serialize(users, jsonOptions);
            string checkTariffsjson = JsonSerializer.Serialize(_allCheckTariffs, jsonOptions);
            string servisesJson = JsonSerializer.Serialize(_allServices, jsonOptions);
            string superpowersJson = JsonSerializer.Serialize(_allSuperPower, jsonOptions);
            string tariffsJson = JsonSerializer.Serialize(_allTariffs, jsonOptions);


            File.WriteAllText(_superAdminFile, superAdminJson);
            File.WriteAllText(_adminFile, adminJson);
            File.WriteAllText(_userFile, userJson);
            File.WriteAllText(_checktariffsFile, checkTariffsjson);
            File.WriteAllText(_servisesFile, servisesJson);
            File.WriteAllText(_superpowersFile, superpowersJson);
            File.WriteAllText(_tariffsFile, tariffsJson);
        }
        public static void Load()
        {
            if (File.Exists(_superAdminFile))
            {
                SuperAdmin superAdmin = JsonSerializer.Deserialize<SuperAdmin>(File.ReadAllText(_superAdminFile));

                if (superAdmin != null && !_allUsers.Contains(superAdmin))
                    _allUsers.Add(superAdmin);
            }
            if (File.Exists(_adminFile))
            {
                var adminJson = File.ReadAllText(_adminFile);
                var admins = JsonSerializer.Deserialize<ObservableCollection<Admin>>(adminJson)!;

                if (admins.Count !=0)
                    foreach (var admin in admins)
                    {
                        if (!_allUsers.Contains(admin))
                            _allUsers.Add(admin);
                    }
            }
            if (File.Exists(_userFile))
            {
                var userJson = File.ReadAllText(_userFile);
                var users = JsonSerializer.Deserialize<ObservableCollection<User>>(userJson);

                foreach (var user in users)
                {
                    if (!_allUsers.Contains(user))
                        _allUsers.Add(user);
                }
            }

            if (File.Exists(_servisesFile))
            {
                var servises = JsonSerializer.Deserialize<ObservableCollection<Service>>(File.ReadAllText(_servisesFile));

                foreach (var el in servises)
                {
                    if (!_allServices.Contains(el))
                        _allServices.Add(el);
                }
            }
            if (File.Exists(_superpowersFile))
            {
                var superpowers = JsonSerializer.Deserialize<ObservableCollection<SuperPower>>(File.ReadAllText(_superpowersFile));

                foreach (var el in superpowers)
                {
                    if (!_allSuperPower.Contains(el))
                        _allSuperPower.Add(el);
                }
            }
            if (File.Exists(_checktariffsFile))
            {
                string checktariffsJson = File.ReadAllText(_checktariffsFile);
                var checktariffs = JsonSerializer.Deserialize<ObservableCollection<Tariff>>(checktariffsJson);

                foreach (var el in checktariffs)
                {
                    if (!_allCheckTariffs.Contains(el))
                        _allCheckTariffs.Add(el);
                }
            }
            if (File.Exists(_tariffsFile))
            {
                var tariffs = JsonSerializer.Deserialize<ObservableCollection<Tariff>>(File.ReadAllText(_tariffsFile));

                foreach (var el in tariffs)
                {
                    if (!_allTariffs.Contains(el))
                        _allTariffs.Add(el);
                }
            }
        }

        public static ObservableCollection<Service> AllServices
        {
            get => _allServices;
            set => _allServices = value ?? throw new ArgumentNullException(nameof(value));
        }
        public static ObservableCollection<SuperPower> AllSuperPower
        {
            get => _allSuperPower;
            set => _allSuperPower = value ?? throw new ArgumentNullException(nameof(value));
        }
        public static ObservableCollection<Tariff> AllTariffs
        {
            get => _allTariffs;
            set => _allTariffs = value ?? throw new ArgumentNullException(nameof(value));
        }
        public static ObservableCollection<Tariff> CheckTariffs
        {
            get => _allCheckTariffs;
            set => _allCheckTariffs = value ?? throw new ArgumentNullException(nameof(value));
        }
        public static ObservableCollection<AllUSer> AllUsers
        {
            get => _allUsers;
            set => _allUsers = value ?? throw new ArgumentNullException(nameof(value));
        }
        public static SuperAdmin SuperAdmin { get => _superAdmin; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public static int CurUserIndex { get; set; } = -1;
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public static AllUSer CurUser { get; set; } = null!;
    }
}
