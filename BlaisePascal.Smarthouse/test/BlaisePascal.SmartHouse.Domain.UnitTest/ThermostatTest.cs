using BlaisePascal.SmartHouse.Domain.Device;
using BlaisePascal.SmartHouse.Domain.ThermostatDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class ThermostatTest
    {
        [Fact]
        public void SetTemperatureToReach_WhenTemperatureIsWithinRange_ShouldSetTemperature()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Living Room Thermostat");
            thermostat.TurnOn();
            int validTemperature = 25;
            // Act
            thermostat.SetTemperatureToReach(validTemperature);
            // Assert
            Assert.Equal(validTemperature, thermostat.TemperatureToReach);
        }
        [Fact]
        public void SetTemperatureToReach_WhenTemperatureIsOutOfRange_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Living Room Thermostat");
            thermostat.TurnOn();
            int invalidTemperature = 50; // Assuming max temperature is 40
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => thermostat.SetTemperatureToReach(invalidTemperature));
        }
        [Fact]
        public void IncreaseTemperatureToReach_WhenCalled_ShouldIncreaseTemperatureByStep()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Living Room Thermostat");
            thermostat.TurnOn();
            int initialTemperature = thermostat.TemperatureToReach;
            // Act
            thermostat.IncreaseTemperatureToReach();
            // Assert
            Assert.Equal(initialTemperature + thermostat.TemperatureStep, thermostat.TemperatureToReach);
        }
        [Fact]
        public void DecreaseTemperatureToReach_WhenCalled_ShouldDecreaseTemperatureByStep()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Living Room Thermostat");
            thermostat.TurnOn();
            int initialTemperature = thermostat.TemperatureToReach;
            // Act
            thermostat.DecreaseTemperatureToReach();
            // Assert
            Assert.Equal(initialTemperature - thermostat.TemperatureStep, thermostat.TemperatureToReach);
        }
        [Fact]
        public void IncreaseTemperatureToReach_WhenAtMaxTemperature_ShouldNotExceedMax()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Living Room Thermostat");
            thermostat.TurnOn();
            thermostat.SetTemperatureToReach(thermostat.MaxTemperature);
            // Act
            thermostat.IncreaseTemperatureToReach();
            // Assert
            Assert.Equal(thermostat.MaxTemperature, thermostat.TemperatureToReach);
        }
        [Fact]
        public void DecreaseTemperatureToReach_WhenAtMinTemperature_ShouldNotGoBelowMin()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Living Room Thermostat");
            thermostat.TurnOn();
            thermostat.SetTemperatureToReach(thermostat.MinTemperature);
            // Act
            thermostat.DecreaseTemperatureToReach();
            // Assert
            Assert.Equal(thermostat.MinTemperature, thermostat.TemperatureToReach);
        }
        [Fact]
        public void SetTemperatureToReach_WhenDeviceIsOff_ShouldThrowException()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Living Room Thermostat");
            int validTemperature = 25;
            // Act & Assert
            Assert.Throws<Exception>(() => thermostat.SetTemperatureToReach(validTemperature));
        }
        [Fact]
        public void IncreaseTemperatureToReach_WhenDeviceIsOff_ShouldThrowException()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Living Room Thermostat");
            // Act & Assert
            Assert.Throws<Exception>(() => thermostat.IncreaseTemperatureToReach());
        }
        [Fact]
        public void DecreaseTemperatureToReach_WhenDeviceIsOff_ShouldThrowException()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Living Room Thermostat");
            // Act & Assert
            Assert.Throws<Exception>(() => thermostat.DecreaseTemperatureToReach());
        }
        [Fact]
        public void SetFahrenheitMode_WhenAlreadyInFahrenheit_ShouldThrowException()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Living Room Thermostat");
            thermostat.TurnOn();
            thermostat.SetFahrenheitMode();
            // Act & Assert
            Assert.Throws<Exception>(() => thermostat.SetFahrenheitMode());
        }
        [Fact]
        public void SetCelsiusMode_WhenAlreadyInCelsius_ShouldThrowException()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Living Room Thermostat");
            thermostat.TurnOn();
            // Act & Assert
            Assert.Throws<Exception>(() => thermostat.SetCelsiusMode());
        }
        [Fact]
        public void SetFahrenheitMode_WhenCalled_ShouldConvertTemperaturesToFahrenheit()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Living Room Thermostat");
            thermostat.TurnOn();
            int initialTemperature = thermostat.TemperatureToReach;
            // Act
            thermostat.SetFahrenheitMode();
            // Assert
            int expectedTemperature = (int)(initialTemperature * 9 / 5) + 32;
            Assert.Equal(expectedTemperature, thermostat.TemperatureToReach);
        }
        [Fact]
        public void SetCelsiusMode_WhenCalled_ShouldConvertTemperaturesToCelsius()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Living Room Thermostat");
            thermostat.TurnOn();
            thermostat.SetFahrenheitMode();
            int temperatureInFahrenheit = thermostat.TemperatureToReach;
            // Act
            thermostat.SetCelsiusMode();
            // Assert
            int expectedTemperature = (int)((temperatureInFahrenheit - 32) * 5 / 9);
            Assert.Equal(expectedTemperature, thermostat.TemperatureToReach);
        }
        [Fact]
        public void SetCelsiusMode_AfterSettingFahrenheit_ShouldRestoreOriginalCelsiusTemperature()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Living Room Thermostat");
            thermostat.TurnOn();
            int originalCelsiusTemperature = thermostat.TemperatureToReach;
            // Act
            thermostat.SetFahrenheitMode();
            thermostat.SetCelsiusMode();
            // Assert
            Assert.Equal(originalCelsiusTemperature, thermostat.TemperatureToReach);
        }
        [Fact]
        public void SetFahrenheitMode_WhenDeviceIsOff_ShouldThrowException()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Living Room Thermostat");
            // Act & Assert
            Assert.Throws<Exception>(() => thermostat.SetFahrenheitMode());
        }
        [Fact]
        public void SetCelsiusMode_WhenDeviceIsOff_ShouldThrowException()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Living Room Thermostat");
            // Act & Assert
            Assert.Throws<Exception>(() => thermostat.SetCelsiusMode());
        }


    }
}
