using System;
using System.Collections.Generic;
using System.Linq;
using JaguarPhone.Module.Enums;
using JaguarPhone.Module.Interfaces;

namespace JaguarPhone.Module
{
    public class User: AllUSer, IUser
    {
        public User(string name, string lastName, string telephone, string password, TelModel telModel) : base(name, lastName, telephone, password, telModel)
        {
        }
        public User(string name, string lastName, int balance, int telephone, DateOnly dateConnecing, TelModel telModel, bool esimSupport, Tariff tariff, List<Service> listServices, List<string> activities) : base(name, lastName, balance, telephone, dateConnecing, telModel, esimSupport, tariff, listServices, activities)
        {
        }
        public User()
        {
        }
    }
}
