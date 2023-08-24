using System;
using System.Collections.ObjectModel;
using JaguarPhone.Module.Enums;
using JaguarPhone.ViewModel;

namespace JaguarPhone.Module
{
    public class SuperAdmin: Admin
    {
        private AllUSer elem;

        public void GrantAdmin(User? user)
        {
            Admin admin = new Admin(user);
            Jaguar.AllUsers.Add(admin);
            Jaguar.Admins.Add(admin);

            Jaguar.Users.Remove(user);
            RemoveUser(user);

            Jaguar.AllUsers[^1].Activities.Add($"Вам надано права адміністратора - {DateTime.Now}");
        }
        public void UnGrantAdmin(Admin? admin)
        {
            User user = new User(admin);
            Jaguar.AllUsers.Add(user);
            Jaguar.Users.Add(user);

            Jaguar.Admins.Remove(admin);
            RemoveUser(admin);

            Jaguar.AllUsers[^1].Activities.Add($"У вас забрали права адміністратора 😊 - {DateTime.Now}");
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
