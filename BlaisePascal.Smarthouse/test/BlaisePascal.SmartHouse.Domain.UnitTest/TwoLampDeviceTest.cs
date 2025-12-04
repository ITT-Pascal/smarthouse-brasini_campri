using BlaisePascal.SmartHouse.Domain.LuminousDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class TwoLampDeviceTest
    {

        [Fact]
        public void TwoLampDevice_Constructor_SetsLampsCorrectly()
        {
            // Arrange
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new Lamp("b");
            // Act
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            // Assert
            Assert.Equal(lamp1, device.Lamp1);
            Assert.Equal(lamp2, device.Lamp2);
        }

        [Fact]
        public void SwitchOneLamp_WhenParameteeIs1_TogglesTheLampStateOfTheLampChosen()
        {
            // Arrange
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.ToggleOneLamp(lamp1.Id);
            // Assert
            Assert.Equal(DeviceStatus.On, lamp1.Status);
            Assert.Equal(DeviceStatus.Off, lamp2.Status);
        }

        [Fact]
        public void SwitchOneLamp_WhenTheParameterIs2_TogglesTheLampStateOfTheLampChosen()
        {
            // Arrange
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.ToggleOneLamp(lamp2.Id);
            // Assert
            Assert.Equal(DeviceStatus.Off, lamp1.Status);
            Assert.Equal(DeviceStatus.On, lamp2.Status);
        }

        [Fact]
        public void SwitchOneLamp_InvalidLampNumber_DoesNotChangeAnyLampState()
        {
            // Arrange
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            Guid guid = Guid.NewGuid();
            // Act
            device.ToggleOneLamp(guid);
            // Assert
            Assert.Equal(DeviceStatus.Off, lamp1.Status);
            Assert.Equal(DeviceStatus.Off, lamp2.Status);
        }

        [Fact]
        public void TurnBothOn_WhenCalled_TurnsOnBothLamps()
        {
            // Arrange
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.TurnBothOn();
            // Assert
            Assert.Equal(DeviceStatus.On, lamp1.Status);
            Assert.Equal(DeviceStatus.On, lamp2.Status);

        }

        [Fact]
        public void TurnBothOff_WhenCalled_TurnsOffBothLamps()
        {
            // Arrange
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.TurnBothOff();
            // Assert
            Assert.Equal(DeviceStatus.Off, lamp1.Status);
            Assert.Equal(DeviceStatus.Off, lamp2.Status);
        }

        [Fact]
        public void IncreaseBothBrightness_WhenCalled_IncreasesBrightnessOfBothLamps()
        {
            // Arrange
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.TurnBothOn();
            device.IncreaseBothBrightness();
            // Assert
            Assert.Equal(2, lamp1.Brightness);
            Assert.Equal(2, lamp2.Brightness);
        }

        [Fact]
        public void DecreaseBothBrightness_WhenCalled_DecreasesBrightnessOfBothLamps()
        {
            // Arrange
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.TurnBothOn();
            device.IncreaseBothBrightness();
            device.DecreaseBothBrightness();
            // Assert
            Assert.Equal(1, lamp1.Brightness);
            Assert.Equal(1, lamp2.Brightness);
        }

        [Fact]
        public void IncreaseBothBrightness_AtMaxBrightness_DoesNotExceedMax()
        {
            // Arrange
            LampModel lamp1 = new Lamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.TurnBothOn();
            for (int i = 0; i < 10; i++)
            {
                device.IncreaseBothBrightness();
            }

                // Assert
            Assert.Equal(10, lamp1.Brightness);
            Assert.Equal(10, lamp2.Brightness);
        }

        [Fact]
        public void DecreaseBothBrightness_AtMinBrightness_DoesNotGoBelowMin()
        {
            // Arrange
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new EcoLamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.TurnBothOn();
            device.DecreaseBothBrightness();
            // Assert
            Assert.Equal(1, lamp1.Brightness);
            Assert.Equal(1, lamp2.Brightness);
        }

        [Fact]
        public void IncreaseBothBrigthness_WhenLamp2IsAtMax_IncreaseOnlyLamp1Brightness()
        {
            // Arrange
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.TurnBothOn();
            for( int i = 0; i < 10; i++)
            {
                device.IncreaseOneBrightness(lamp2.Id);
            }
            device.IncreaseBothBrightness();
            // Assert
            Assert.Equal(10, lamp2.Brightness);
            Assert.Equal(2, lamp1.Brightness);
        }

        [Fact]
        public void IncreaseBothBrigthness_WhenLamp1IsAtMax_IncreaseOnlyLamp2Brightness()
        {
            // Arrange
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.TurnBothOn();
            for (int i = 0; i < 5; i++)
            {
                device.IncreaseOneBrightness(lamp1.Id);
            }
            device.IncreaseBothBrightness();
            // Assert
            Assert.Equal(5, lamp1.Brightness);
            Assert.Equal(2, lamp2.Brightness);
        }

        [Fact]
        public void DecreaseBothBrigthness_WhenLamp2IsAtMin_DecreaseOnlyLamp1Brightness()
        {
            // Arrange
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.TurnBothOn();
            device.IncreaseOneBrightness(lamp1.Id);
            device.DecreaseBothBrightness();
            // Assert
            Assert.Equal(1, lamp2.Brightness);
            Assert.Equal(1, lamp1.Brightness);

        }

        [Fact]
        public void DecreaseBothBrigthness_WhenLamp1IsAtMin_DecreaseOnlyLamp2Brightness()
        {
            // Arrange
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.TurnBothOn();
            device.IncreaseOneBrightness(lamp2.Id);
            device.DecreaseBothBrightness();
            // Assert
            Assert.Equal(1, lamp1.Brightness);
            Assert.Equal(1, lamp2.Brightness);
        }

        [Fact]
        public void IncreaseOneBrightness_WhenParameterIs1_IncreasesLamp1Brightness()
        {
            // Arrange
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.TurnBothOn();
            device.IncreaseOneBrightness(lamp1.Id);
            // Assert
            Assert.Equal(2, lamp1.Brightness);
        }

        [Fact]
        public void IncreaseOneBrightness_WhenParameterIs2_IncreasesLamp2Brightness()
        {
            // Arrange
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.TurnBothOn();
            device.IncreaseOneBrightness(lamp2.Id);
            // Assert
            Assert.Equal(2, lamp2.Brightness);
        }

        [Fact]
        public void DecreaseOneBrightness_WhenParameterIs1_DecreasesLamp1Brightness()
        {
            // Arrange
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.TurnBothOn();
            device.IncreaseOneBrightness(lamp1.Id);
            device.DecreaseOneBrightness(lamp1.Id);
            // Assert
            Assert.Equal(1, lamp1.Brightness);
        }

        [Fact]
        public void DecreaseOneBrightness_WhenParameterIs2_DecreasesLamp2Brightness()
        {
            // Arrange
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.TurnBothOn();
            device.IncreaseOneBrightness(lamp2.Id);
            device.DecreaseOneBrightness(lamp2.Id);
            // Assert
            Assert.Equal(1, lamp2.Brightness);
        }

        [Fact]
        public void DecreaseOneBrightness_InvalidLampNumber_DoesNotChangeAnyLampBrightness()
        {
            // Arrange
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            Guid guid = Guid.NewGuid();
            // Act
            device.TurnBothOn();
            device.DecreaseOneBrightness(guid);
            // Assert
            Assert.Equal(1, lamp1.Brightness);
            Assert.Equal(1, lamp2.Brightness);
        }

        [Fact]
        public void IncreaseOneBrightness_InvalidLampNumber_DoesNotChangeAnyLampBrightness()
        {
            // Arrange  
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            Guid guid = Guid.NewGuid();
            // Act
            device.TurnBothOn();
            device.IncreaseOneBrightness(guid);
            // Assert
            Assert.Equal(1, lamp1.Brightness);
            Assert.Equal(1, lamp2.Brightness);
        }

        [Fact]
        public void IncreaseOneBrightness_AtMaxBrightness_DoesNotExceedMax()
        {
            // Arrange
            LampModel lamp1 = new Lamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.TurnBothOn();
            for(int i = 0; i < 10; i++)
            {
                device.IncreaseOneBrightness(lamp1.Id);
                device.IncreaseOneBrightness(lamp2.Id);
            }
            // Assert
            Assert.Equal(10, lamp1.Brightness);
            Assert.Equal(10, lamp2.Brightness);
        }

        [Fact]
        public void DecreaseOneBrightness_AtMinBrightness_DoesNotGoBelowMin()
        {
            // Arrange
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new EcoLamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.TurnBothOn();
            for (int i = 0; i <= 6; i++)
            {
                device.DecreaseOneBrightness(lamp1.Id);
                device.DecreaseOneBrightness(lamp2.Id);
            }
            // Assert
            Assert.Equal(1, lamp1.Brightness);
            Assert.Equal(1, lamp2.Brightness);
        }

        [Fact]
        public void ChangeOneBrightness_WhenParameterIs1_ChangesLamp1Brightness()
        {
            // Arrange
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.TurnBothOn();
            device.ChangeOneBrightness(lamp1.Id, 4);
            // Assert
            Assert.Equal(4, lamp1.Brightness);
        }

        [Fact]
        public void ChangeOneBrightness_WhenParameterIs2_ChangesLamp2Brightness()
        {
            // Arrange
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.TurnBothOn();
            device.ChangeOneBrightness(lamp2.Id, 6);
            // Assert
            Assert.Equal(6, lamp2.Brightness);
        }

        [Fact]
        public void ChangeOneBrightness_InvalidLampNumber_DoesNotChangeAnyLampBrightness()
        {
            // Arrange
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            Guid guid = Guid.NewGuid();
            // Act
            device.TurnBothOn();
            device.ChangeOneBrightness(guid, 7);
            // Assert
            Assert.Equal(1, lamp1.Brightness);
            Assert.Equal(1, lamp2.Brightness);
        }

        [Fact]
        public void ChangeOneBrightness_InvalidBrightness_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            // Act & Assert
            device.TurnBothOn();
            Assert.Throws<ArgumentOutOfRangeException>(() => device.ChangeOneBrightness(lamp1.Id, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => device.ChangeOneBrightness(lamp2.Id, 11));
        }
    }
}
