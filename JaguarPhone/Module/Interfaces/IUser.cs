namespace JaguarPhone.Module.Interfaces
{
    public interface IUser
    {
        string Name { get; set; }
        bool AddTariff(Tariff tariff);
    } 
}
