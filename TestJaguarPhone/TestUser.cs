using JaguarPhone.Module.Enums;
using JaguarPhone.Module;
using JaguarPhone.ViewModel;

namespace TestJaguarPhone
{
    [TestClass]
    public class TestUser
    {
        Jaguar jaguar = new Jaguar();
        User user = new User("test", "Test", "0969542355","1234Ff", TelModel.Galaxy_Note_20);

        [TestMethod]
        public void ConnectTariffFalse()
        {
            // Act
            var actual = user.ConnectTariff("b");

            // Assert
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void ConnectTariffTrue()
        {
            // Act
            var actual = user.ConnectTariff("Знайомтесь Jaguar!");

            // Assert
            Assert.IsTrue(actual);
        }
        [TestMethod]
        public void ConnectServiceFalse()
        {
            // Act
            Jaguar.AllServices.Add(new Service("fffjj", 10, " ffffffffffffffffff"));
            Jaguar.CurUser = user;
            var actual = user.ConnectService("fffjj");

            // Assert
            Assert.IsFalse(false);
        }
        [TestMethod]
        public void ConnectServiceTrue()
        {
            //Arrange
            Jaguar.AllServices.Add(new Service("Serv", 10, "about about about"));
            Jaguar.CurUser = user;
            // Act
            var actual = user.ConnectService("Serv");

            // Assert
            Assert.IsTrue(true);
        }

    }
}
