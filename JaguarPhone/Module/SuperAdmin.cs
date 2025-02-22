using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DevExpress.Mvvm.POCO;
using JaguarPhone.Module.Enums;
using JaguarPhone.Module.Interfaces;
using JaguarPhone.ViewModel;

namespace JaguarPhone.Module
{
    public class SuperAdmin: Admin
    {

        public void GrantAdmin(int telephone)
        {
            int id = 0;
            for (int i = 0; i < Jaguar.AllUsers.Count; i++)
            {
                if (Jaguar.AllUsers[i].GetType() == typeof(User) && 
                    Jaguar.AllUsers[i].Telephone == telephone)
                {
                    Jaguar.AllUsers[i] = (Admin)Jaguar.AllUsers[i];
                }
            }
        }

        public SuperAdmin(string name, string lastName, string telephone, string password, TelModel telModel) : base(name, lastName, telephone, password, telModel)
        {
        }

        public SuperAdmin(string name, string lastName, uint balance, int telephone, DateOnly dateConnecing, TelModel telModel, bool esimSupport, Tariff account, ObservableCollection<Service> listServices, ObservableCollection<string> activities) : base(name, lastName, balance, telephone, dateConnecing, telModel, esimSupport, account, listServices, activities)
        {
        }

        public SuperAdmin()
        {
        }
    }
}
