namespace Tests
{
    [TestClass]
    public class CurrencyServiceTests
    {
        [TestMethod]
        public void NameCurrencyCheck()
        {
            // Arrange
            string name = "Test";
            string expected = "Test";

            // Act
            CurrencyService<int> currencyService = new(name, 0, 0);

            // Assert
            Assert.AreEqual(expected, currencyService.NameCurrency);
        }

        [TestMethod]
        public void Int_CurrentValueCheck()
        {
            // Arrange
            int maxValue = 100; // 100 is default value
            int currentValue = 10;
            int expected = 10;

            // Act
            CurrencyService<int> currencyService = new(currentValue, maxValue);

            // Assert
            Assert.AreEqual(expected, currencyService.CurrentValue);
        }

        [TestMethod]
        public void Int_MaxValueCheck()
        {
            // Arrange
            int currentValue = 0;
            int maxValue = 100;
            int expected = 100;

            // Act
            CurrencyService<int> currencyService = new(currentValue, maxValue);

            // Assert
            Assert.AreEqual(expected, currencyService.MaxValue);
        }

        [TestMethod]
        public void Int_MinValueCheck()
        {
            // Arrange
            int currentValue = 0;
            int maxValue = 0;
            int expected = 0;

            // Act
            CurrencyService<int> currencyService = new(currentValue, maxValue);

            // Assert
            Assert.AreEqual(expected, currencyService.MinValue);
        }

        [TestMethod]
        public void Int_AddCurrentValue()
        {
            // Arrange
            int currentValue = 10;
            int maxValue = 100;
            int expected = 20;

            // Act
            CurrencyService<int> currencyService = new(currentValue, maxValue);
            currencyService.CurrentValue += 10;
            int value = currencyService.CurrentValue;

            // Assert
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void Int_SubtractCurrentValue()
        {
            // Arrange
            int currentValue = 100;
            int maxValue = 100;
            int expected = 90;

            // Act
            CurrencyService<int> currencyService = new(currentValue, maxValue);
            currencyService.CurrentValue -= 10;
            int value = currencyService.CurrentValue;

            // Assert
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void Int_DivideCurrentValue()
        {
            // Arrange
            int currentValue = 100;
            int maxValue = 100;
            int expected = 10;

            // Act
            CurrencyService<int> currencyService = new(currentValue, maxValue);
            currencyService.CurrentValue /= 10;
            int value = currencyService.CurrentValue;

            // Assert
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void Int_MultiplyCurrentValue()
        {
            // Arrange
            int currentValue = 10;
            int maxValue = 100;
            int expected = 100;

            // Act
            CurrencyService<int> currencyService = new(currentValue, maxValue);
            currencyService.CurrentValue *= 10;
            int value = currencyService.CurrentValue;

            // Assert
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void Int_ClampCurrentValueMax()
        {
            // Arrange
            int currentValue = 10;
            int maxValue = 10;
            int expected = 10;

            // Act
            CurrencyService<int> currencyService = new(currentValue, maxValue);
            currencyService.CurrentValue += 10;
            int value = currencyService.CurrentValue;

            // Assert
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void Int_ClampCurrentValueMinZero()
        {
            // Arrange
            int currentValue = 0;
            int maxValue = 10;
            int expected = 0;

            // Act
            CurrencyService<int> currencyService = new(currentValue, maxValue);
            currencyService.CurrentValue -= 10;
            int value = currencyService.CurrentValue;

            // Assert
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void Double_CurrentValueCheck()
        {
            // Arrange
            double maxValue = 100.0; // 100 is default value
            double currentValue = 10.0;
            double expected = 10.0;

            // Act
            CurrencyService<double> currencyService = new(currentValue, maxValue);

            // Assert
            Assert.AreEqual(expected, currencyService.CurrentValue);
        }

        [TestMethod]
        public void Double_MaxValueCheck()
        {
            // Arrange
            double currentValue = 0.0;
            double maxValue = 100.0;
            double expected = 100.0;

            // Act
            CurrencyService<double> currencyService = new(currentValue, maxValue);

            // Assert
            Assert.AreEqual(expected, currencyService.MaxValue);
        }

        [TestMethod]
        public void Double_MinValueCheck()
        {
            // Arrange
            double currentValue = 0.0;
            double maxValue = 0.0;
            double expected = 0.0;

            // Act
            CurrencyService<double> currencyService = new(currentValue, maxValue);

            // Assert
            Assert.AreEqual(expected, currencyService.MinValue);
        }

        [TestMethod]
        public void Double_AddCurrentValue()
        {
            // Arrange
            double currentValue = 10.0;
            double maxValue = 100.0;
            double expected = 20.0;

            // Act
            CurrencyService<double> currencyService = new(currentValue, maxValue);
            currencyService.CurrentValue += 10.0;
            double value = currencyService.CurrentValue;

            // Assert
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void Double_SubtractCurrentValue()
        {
            // Arrange
            double currentValue = 100.0;
            double maxValue = 100.0;
            double expected = 90.0;

            // Act
            CurrencyService<double> currencyService = new(currentValue, maxValue);
            currencyService.CurrentValue -= 10.0;
            double value = currencyService.CurrentValue;

            // Assert
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void Double_DivideCurrentValue()
        {
            // Arrange
            double currentValue = 100.0;
            double maxValue = 100.0;
            double expected = 10.0;

            // Act
            CurrencyService<double> currencyService = new(currentValue, maxValue);
            currencyService.CurrentValue /= 10.0;
            double value = currencyService.CurrentValue;

            // Assert
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void Double_MultiplyCurrentValue()
        {
            // Arrange
            double currentValue = 10.0;
            double maxValue = 100.0;
            double expected = 100.0;

            // Act
            CurrencyService<double> currencyService = new(currentValue, maxValue);
            currencyService.CurrentValue *= 10.0;
            double value = currencyService.CurrentValue;

            // Assert
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void Float_CurrentValueCheck()
        {
            // Arrange
            float maxValue = 100.0f; // 100 is default value
            float currentValue = 10.0f;
            float expected = 10.0f;

            // Act
            CurrencyService<float> currencyService = new(currentValue, maxValue);

            // Assert
            Assert.AreEqual(expected, currencyService.CurrentValue);
        }

        [TestMethod]
        public void Float_MaxValueCheck()
        {
            // Arrange
            float currentValue = 0.0f;
            float maxValue = 100.0f;
            float expected = 100.0f;

            // Act
            CurrencyService<float> currencyService = new(currentValue, maxValue);

            // Assert
            Assert.AreEqual(expected, currencyService.MaxValue);
        }

        [TestMethod]
        public void Float_MinValueCheck()
        {
            // Arrange
            float currentValue = 0.0f;
            float maxValue = 0.0f;
            float expected = 0.0f;

            // Act
            CurrencyService<float> currencyService = new(currentValue, maxValue);

            // Assert
            Assert.AreEqual(expected, currencyService.MinValue);
        }

        [TestMethod]
        public void Float_AddCurrentValue()
        {
            // Arrange
            float currentValue = 10.0f;
            float maxValue = 100.0f;
            float expected = 20.0f;

            // Act
            CurrencyService<float> currencyService = new(currentValue, maxValue);
            currencyService.CurrentValue += 10.0f;
            float value = currencyService.CurrentValue;

            // Assert
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void Float_SubtractCurrentValue()
        {
            // Arrange
            float currentValue = 100.0f;
            float maxValue = 100.0f;
            float expected = 90.0f;

            // Act
            CurrencyService<float> currencyService = new(currentValue, maxValue);
            currencyService.CurrentValue -= 10.0f;
            float value = currencyService.CurrentValue;

            // Assert
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void Float_DivideCurrentValue()
        {
            // Arrange
            float currentValue = 100.0f;
            float maxValue = 100.0f;
            float expected = 10.0f;

            // Act
            CurrencyService<float> currencyService = new(currentValue, maxValue);
            currencyService.CurrentValue /= 10.0f;
            float value = currencyService.CurrentValue;

            // Assert
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void Float_MultiplyCurrentValue()
        {
            // Arrange
            float currentValue = 10.0f;
            float maxValue = 100.0f;
            float expected = 100.0f;

            // Act
            CurrencyService<float> currencyService = new(currentValue, maxValue);
            currencyService.CurrentValue *= 10.0f;
            float value = currencyService.CurrentValue;

            // Assert
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void Decimal_CurrentValueCheck()
        {
            // Arrange
            decimal maxValue = 100.0m; // 100 is default value
            decimal currentValue = 10.0m;
            decimal expected = 10.0m;

            // Act
            CurrencyService<decimal> currencyService = new(currentValue, maxValue);

            // Assert
            Assert.AreEqual(expected, currencyService.CurrentValue);
        }

        [TestMethod]
        public void Decimal_MaxValueCheck()
        {
            // Arrange
            decimal currentValue = 0.0m;
            decimal maxValue = 100.0m;
            decimal expected = 100.0m;

            // Act
            CurrencyService<decimal> currencyService = new(currentValue, maxValue);

            // Assert
            Assert.AreEqual(expected, currencyService.MaxValue);
        }

        [TestMethod]
        public void Decimal_MinValueCheck()
        {
            // Arrange
            decimal currentValue = 0.0m;
            decimal maxValue = 0.0m;
            decimal expected = 0.0m;

            // Act
            CurrencyService<decimal> currencyService = new(currentValue, maxValue);

            // Assert
            Assert.AreEqual(expected, currencyService.MinValue);
        }

        [TestMethod]
        public void Decimal_AddCurrentValue()
        {
            // Arrange
            decimal currentValue = 10.0m;
            decimal maxValue = 100.0m;
            decimal expected = 20.0m;

            // Act
            CurrencyService<decimal> currencyService = new(currentValue, maxValue);
            currencyService.CurrentValue += 10.0m;
            decimal value = currencyService.CurrentValue;

            // Assert
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void Decimal_SubtractCurrentValue()
        {
            // Arrange
            decimal currentValue = 100.0m;
            decimal maxValue = 100.0m;
            decimal expected = 90.0m;

            // Act
            CurrencyService<decimal> currencyService = new(currentValue, maxValue);
            currencyService.CurrentValue -= 10.0m;
            decimal value = currencyService.CurrentValue;

            // Assert
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void Decimal_DivideCurrentValue()
        {
            // Arrange
            decimal currentValue = 100.0m;
            decimal maxValue = 100.0m;
            decimal expected = 10.0m;

            // Act
            CurrencyService<decimal> currencyService = new(currentValue, maxValue);
            currencyService.CurrentValue /= 10.0m;
            decimal value = currencyService.CurrentValue;

            // Assert
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void Decimal_MultiplyCurrentValue()
        {
            // Arrange
            decimal currentValue = 10.0m;
            decimal maxValue = 100.0m;
            decimal expected = 100.0m;

            // Act
            CurrencyService<decimal> currencyService = new(currentValue, maxValue);
            currencyService.CurrentValue *= 10.0m;
            decimal value = currencyService.CurrentValue;

            // Assert
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void Byte_CurrentValueCheck()
        {
            // Arrange
            byte maxValue = 100; // 100 is default value
            byte currentValue = 10;
            byte expected = 10;

            // Act
            CurrencyService<byte> currencyService = new(currentValue, maxValue);

            // Assert
            Assert.AreEqual(expected, currencyService.CurrentValue);
        }

        [TestMethod]
        public void Byte_MaxValueCheck()
        {
            // Arrange
            byte currentValue = 0;
            byte maxValue = 100;
            byte expected = 100;

            // Act
            CurrencyService<byte> currencyService = new(currentValue, maxValue);

            // Assert
            Assert.AreEqual(expected, currencyService.MaxValue);
        }

        [TestMethod]
        public void Byte_MinValueCheck()
        {
            // Arrange
            byte currentValue = 0;
            byte maxValue = 0;
            byte expected = 0;

            // Act
            CurrencyService<byte> currencyService = new(currentValue, maxValue);

            // Assert
            Assert.AreEqual(expected, currencyService.MinValue);
        }

        [TestMethod]
        public void Byte_AddCurrentValue()
        {
            // Arrange
            byte currentValue = 10;
            byte maxValue = 100;
            byte expected = 20;

            // Act
            CurrencyService<byte> currencyService = new(currentValue, maxValue);
            currencyService.CurrentValue += 10;
            byte value = currencyService.CurrentValue;

            // Assert
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void Byte_SubtractCurrentValue()
        {
            // Arrange
            byte currentValue = 100;
            byte maxValue = 100;
            byte expected = 90;

            // Act
            CurrencyService<byte> currencyService = new(currentValue, maxValue);
            currencyService.CurrentValue -= 10;
            byte value = currencyService.CurrentValue;

            // Assert
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void Byte_MultiplyCurrentValue()
        {
            // Arrange
            byte currentValue = 10;
            byte maxValue = 100;
            byte expected = 50; // 10 * 5

            // Act
            CurrencyService<byte> currencyService = new(currentValue, maxValue);
            currencyService.CurrentValue *= 5;
            byte value = currencyService.CurrentValue;

            // Assert
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void Byte_DivideCurrentValue()
        {
            // Arrange
            byte currentValue = 50;
            byte maxValue = 100;
            byte expected = 10; // 50 / 5

            // Act
            CurrencyService<byte> currencyService = new(currentValue, maxValue);
            currencyService.CurrentValue /= 5;
            byte value = currencyService.CurrentValue;

            // Assert
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void Short_CurrentValueCheck()
        {
            // Arrange
            short maxValue = 100; // 100 is default value
            short currentValue = 10;
            short expected = 10;

            // Act
            CurrencyService<short> currencyService = new(currentValue, maxValue);

            // Assert
            Assert.AreEqual(expected, currencyService.CurrentValue);
        }

        [TestMethod]
        public void Short_MaxValueCheck()
        {
            // Arrange
            short currentValue = 0;
            short maxValue = 100;
            short expected = 100;

            // Act
            CurrencyService<short> currencyService = new(currentValue, maxValue);

            // Assert
            Assert.AreEqual(expected, currencyService.MaxValue);
        }

        [TestMethod]
        public void Short_MinValueCheck()
        {
            // Arrange
            short currentValue = 0;
            short maxValue = 0;
            short expected = 0;

            // Act
            CurrencyService<short> currencyService = new(currentValue, maxValue);

            // Assert
            Assert.AreEqual(expected, currencyService.MinValue);
        }

        [TestMethod]
        public void Short_AddCurrentValue()
        {
            // Arrange
            short currentValue = 10;
            short maxValue = 100;
            short expected = 20;

            // Act
            CurrencyService<short> currencyService = new(currentValue, maxValue);
            currencyService.CurrentValue += 10;
            short value = currencyService.CurrentValue;

            // Assert
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void Short_SubtractCurrentValue()
        {
            // Arrange
            short currentValue = 100;
            short maxValue = 100;
            short expected = 90;

            // Act
            CurrencyService<short> currencyService = new(currentValue, maxValue);
            currencyService.CurrentValue -= 10;
            short value = currencyService.CurrentValue;

            // Assert
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void Short_MultiplyCurrentValue()
        {
            // Arrange
            short currentValue = 10;
            short maxValue = 100;
            short expected = 50; // 10 * 5

            // Act
            CurrencyService<short> currencyService = new(currentValue, maxValue);
            currencyService.CurrentValue *= 5;
            short value = currencyService.CurrentValue;

            // Assert
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void Short_DivideCurrentValue()
        {
            // Arrange
            short currentValue = 50;
            short maxValue = 100;
            short expected = 10; // 50 / 5

            // Act
            CurrencyService<short> currencyService = new(currentValue, maxValue);
            currencyService.CurrentValue /= 5;
            short value = currencyService.CurrentValue;

            // Assert
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void SByte_CurrentValueCheck()
        {
            // Arrange
            sbyte maxValue = 100; // 100 is default value
            sbyte currentValue = 10;
            sbyte expected = 10;

            // Act
            CurrencyService<sbyte> currencyService = new(currentValue, maxValue);

            // Assert
            Assert.AreEqual(expected, currencyService.CurrentValue);
        }

        [TestMethod]
        public void SByte_MaxValueCheck()
        {
            // Arrange
            sbyte currentValue = 0;
            sbyte maxValue = 100;
            sbyte expected = 100;

            // Act
            CurrencyService<sbyte> currencyService = new(currentValue, maxValue);

            // Assert
            Assert.AreEqual(expected, currencyService.MaxValue);
        }

        [TestMethod]
        public void SByte_MinValueCheck()
        {
            // Arrange
            sbyte currentValue = 0;
            sbyte maxValue = 0;
            sbyte expected = 0;

            // Act
            CurrencyService<sbyte> currencyService = new(currentValue, maxValue);

            // Assert
            Assert.AreEqual(expected, currencyService.MinValue);
        }

        [TestMethod]
        public void SByte_AddCurrentValue()
        {
            // Arrange
            sbyte currentValue = 10;
            sbyte maxValue = 100;
            sbyte expected = 20;

            // Act
            CurrencyService<sbyte> currencyService = new(currentValue, maxValue);
            currencyService.CurrentValue += 10;
            sbyte value = currencyService.CurrentValue;

            // Assert
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void SByte_SubtractCurrentValue()
        {
            // Arrange
            sbyte currentValue = 100;
            sbyte maxValue = 100;
            sbyte expected = 90;

            // Act
            CurrencyService<sbyte> currencyService = new(currentValue, maxValue);
            currencyService.CurrentValue -= 10;
            sbyte value = currencyService.CurrentValue;

            // Assert
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void SByte_MultiplyCurrentValue()
        {
            // Arrange
            sbyte currentValue = 10;
            sbyte maxValue = 100;
            sbyte expected = 50; // 10 * 5

            // Act
            CurrencyService<sbyte> currencyService = new(currentValue, maxValue);
            currencyService.CurrentValue *= 5;
            sbyte value = currencyService.CurrentValue;

            // Assert
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void SByte_DivideCurrentValue()
        {
            // Arrange
            sbyte currentValue = 50;
            sbyte maxValue = 100;
            sbyte expected = 10; // 50 / 5

            // Act
            CurrencyService<sbyte> currencyService = new(currentValue, maxValue);
            currencyService.CurrentValue /= 5;
            sbyte value = currencyService.CurrentValue;

            // Assert
            Assert.AreEqual(expected, value);
        }
    }
}
