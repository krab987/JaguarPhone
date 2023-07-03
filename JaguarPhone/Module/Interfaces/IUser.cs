namespace JaguarPhone.Module.Interfaces
{
    public interface IUser
    {
        string Name { get; set; }
        public bool AddTariff(Tariff tariff);
    } 
}
