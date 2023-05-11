using JaguarPhone.Module.Enums;
using JaguarPhone.Module;

namespace TestJaguarPhone
{
    [TestClass]
    public class TestUser
    {
        Jaguar jaguar = new Jaguar();
        User user = new User("test", "Test", 96954235, TelModel.Galaxy_Note_20, "Plt");

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
            var actual = user.ConnectService("Serv");

            // Assert
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void ConnectServiceTrue()
        {
            //Arrange
            Jaguar.AllServices.Add(new Service("Serv", 10, "about"));

            // Act
            var actual = user.ConnectService("Serv");

            // Assert
            Assert.IsTrue(actual);
        }

    }
}
