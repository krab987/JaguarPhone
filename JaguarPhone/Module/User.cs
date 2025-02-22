using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public User(string name, string lastName, uint balance, int telephone, DateOnly dateConnecing, TelModel telModel, bool esimSupport, Tariff account, ObservableCollection<Service> listServices, ObservableCollection<string> activities) : base(name, lastName, balance, telephone, dateConnecing, telModel, esimSupport, account, listServices, activities)
        {
        }

        public User()
        {
        }
    }
}
