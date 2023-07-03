

using JaguarPhone.Module;
using JaguarPhone.Module.Enums;
using JaguarPhone.ViewModel;

namespace TestJaguarPhone
{
    [TestClass]
    public class TestAdmin
    {
        Jaguar jaguar = new Jaguar();
        User user = new User("test", "Test", "0995658965","123FFf", TelModel.Galaxy_Note_20);

        [TestMethod]
        public void AdminAddTariffFalse()
        {
            // act
            bool actual = Jaguar.SuperAdmin.AddTariff(new Tariff("Знайомтесь Jaguar!", 10, 20, false, 20, 0, false));
            // assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void AdminAddTariffTrue()
        {
            // act
            bool actual = Jaguar.SuperAdmin.AddTariff(new Tariff("Bober", 10, 20, false, 20, 0, false));
            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void AddCustomerTariffFalse_Exist()
        {
            // arrange
            user.AddTariff(new Tariff("База", 10, 20, false, 20, 0, false));
            // act
            Jaguar.SuperAdmin.AddTariff(new Tariff("База", 10, 20, false, 20, 0, false));
            bool actual = Jaguar.SuperAdmin.AddCustomerTariff("База");
            // assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void AddCustomerTariffFalse_Name()
        {
            // arrange
            user.AddTariff(new Tariff("Bober", 10, 20, false, 20, 0, false));
            // act
            bool actual = Jaguar.SuperAdmin.AddCustomerTariff("Can");
            // assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void RemoveTariffFalse()
        {
            // act
            bool actual = Jaguar.SuperAdmin.RemoveTariff("NNM");
            // assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void RemoveTariffTrue()
        {
            // act
            bool actual = Jaguar.SuperAdmin.RemoveTariff("Знайомтесь Jaguar!");
            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void CorrectTariffFalse()
        {
            // act
            bool actual = Jaguar.SuperAdmin.CorrectTariff("nn", "Тариф Новий", 500, 30, true, 100, 50, true);
            // assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void CorrectTariffTrue()
        {
            // act
            bool actual = Jaguar.SuperAdmin.CorrectTariff("Знайомтесь Jaguar!", "Тариф Новий", 500, 30, true, 100, 50, true);
            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void AddServiceFalse()
        {
            // arrange
            Jaguar.AllServices.Add(new Service("fff", 10, "ffffffffffffffffff"));
            // act
            bool actual = Jaguar.SuperAdmin.AddService(new Service("fff", 20, "ffffffffffffffffff"));
            // assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void AddServiceTrue()
        {
            // arrange
            Jaguar.AllServices.Add(new Service("fffd", 10, "ffffffffffffffffff"));
            // act
            bool actual = Jaguar.SuperAdmin.AddService(new Service("ddd", 20, "ffffffffffffffffff"));
            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void RemoveServiceFalse()
        {
            // arrange
            Jaguar.AllServices.Add(new Service("fff", 10, " ffffffffffffffffff"));
            // act
            bool actual = Jaguar.SuperAdmin.RemoveService("NNM");
            // assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void RemoveServiceTrue()
        {
            // arrange
            Jaguar.AllServices.Add(new Service("fff", 10, " ffffffffffffffffff"));
            // act
            bool actual = Jaguar.SuperAdmin.RemoveService("fff");
            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void CorrectServiceFalse()
        {
            // arrange
            Jaguar.AllServices.Add(new Service("fffjj", 10, " ffffffffffffffffff"));
            // act
            bool actual = Jaguar.SuperAdmin.CorrectService("fsdv", "fffd", 20, " ffffffffffdffffffff");
            // assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void CorrectServiceTrue()
        {
            // arrange
            Jaguar.AllServices.Add(new Service("fff", 10, " ffffffffffffffffff"));
            // act
            bool actual = Jaguar.SuperAdmin.CorrectService("fff", "ffg", 10, "ffffffffffffffffff ");
            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void AddSuperPowerFalse()
        {
            // arrange
            Jaguar.AllSuperPower.Add(new SuperPower("fff", 10, 200, false));
            // act
            bool actual = Jaguar.SuperAdmin.AddSuperPower(new SuperPower("fff", 10, 200, false));
            // assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void AddSuperPowerTrue()
        {
            // arrange
            Jaguar.AllSuperPower.Add(new SuperPower("fff", 10, 200, false));
            // act
            bool actual = Jaguar.SuperAdmin.AddSuperPower(new SuperPower("ddd", 10, 200, false));
            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void RemoveSuperPowerFalse()
        {
            // arrange
            Jaguar.AllSuperPower.Add(new SuperPower("fff", 10, 200, false));
            // act
            bool actual = Jaguar.SuperAdmin.RemoveSuperPower("NNM");
            // assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void RemoveSuperPowerTrue()
        {
            // arrange
            Jaguar.AllSuperPower.Add(new SuperPower("fff", 10, 200, false));
            // act
            bool actual = Jaguar.SuperAdmin.RemoveSuperPower("fff");
            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void CorrectSuperPowerFalse()
        {
            // arrange
            Jaguar.AllSuperPower.Add(new SuperPower("fff", 10, 200, false));
            // act
            bool actual = Jaguar.SuperAdmin.CorrectSuperPower("f", "ddd", 10, 200, false);
            // assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void CorrectSuperPowerTrue()
        {
            // arrange
            Jaguar.AllSuperPower.Add(new SuperPower("fff", 10, 200, false));
            // act
            bool actual = Jaguar.SuperAdmin.CorrectSuperPower("fff", "ddd", 10, 200, false);
            // assert
            Assert.IsTrue(actual);
        }
    }
    
}
