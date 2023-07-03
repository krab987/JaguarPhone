using JaguarPhone.Module;
using JaguarPhone.Module.Enums;

namespace TestJaguarPhone
{
    [TestClass]
    public class TestTariff
    {

        [TestMethod]
        public void SetPrestigeTariffSilver()
        {
            // Arrange
            Tariff tariff = new Tariff("Test Tariff", 100, 9, true, 50, 100, true);
            // Act
            PrestigeTariffs actual = tariff.PrestigeTariff;
            // Exp
            PrestigeTariffs expected = PrestigeTariffs.Silver;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetPrestigeTariffGold()
        {
            // Arrange
            Tariff tariff = new Tariff("Test Tariff", 100, 30, true, 50, 100, true);
            // Act
            PrestigeTariffs actual = tariff.PrestigeTariff;
            // Exp
            PrestigeTariffs expected = PrestigeTariffs.Gold;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetPrestigeTariffPlatinum()
        {
            // Arrange
            Tariff tariff = new Tariff("Test Tariff", 100, 150, true, 50, 100, true);
            // Act
            PrestigeTariffs actual = tariff.PrestigeTariff;
            // Exp
            PrestigeTariffs expected = PrestigeTariffs.Platinum;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
    
}
