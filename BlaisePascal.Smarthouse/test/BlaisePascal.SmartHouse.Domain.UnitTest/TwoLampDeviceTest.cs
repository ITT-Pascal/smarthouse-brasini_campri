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
            var lamp1 = new EcoLamp();
            var lamp2 = new Lamp();
            // Act
            var device = new TwoLampDevice(lamp1, lamp2);
            // Assert
            Assert.Equal(lamp1, device.Lamp1);
            Assert.Equal(lamp2, device.Lamp2);
        }

        [Fact]
        public void SwitchOneLamp_WhenParameteeIs1_TogglesTheLampStateOfTheLampChosen()
        {
            // Arrange
            var lamp1 = new EcoLamp();
            var lamp2 = new Lamp();
            var device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.SwitchOneLamp(1);
            // Assert
            Assert.True(lamp1.IsOn);
            Assert.False(lamp2.IsOn);
        }

        [Fact]
        public void SwitchOneLamp_WhenTheParameterIs2_TogglesTheLampStateOfTheLampChosen()
        {
            // Arrange
            var lamp1 = new EcoLamp();
            var lamp2 = new Lamp();
            var device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.SwitchOneLamp(2);
            // Assert
            Assert.False(lamp1.IsOn);
            Assert.True(lamp2.IsOn);
        }

        [Fact]
        public void SwitchOneLamp_InvalidLampNumber_DoesNotChangeAnyLampState()
        {
            // Arrange
            var lamp1 = new EcoLamp();
            var lamp2 = new Lamp();
            var device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.SwitchOneLamp(3);
            // Assert
            Assert.False(lamp1.IsOn);
            Assert.False(lamp2.IsOn);
        }

        [Fact]
        public void TurnBothOn_WhenCalled_TurnsOnBothLamps()
        {
            // Arrange
            var lamp1 = new EcoLamp();
            var lamp2 = new Lamp();
            var device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.TurnBothOn();
            // Assert
            Assert.True(lamp1.IsOn);
            Assert.True(lamp2.IsOn);

        }

        [Fact]
        public void TurnBothOff_WhenCalled_TurnsOffBothLamps()
        {
            // Arrange
            var lamp1 = new EcoLamp();
            var lamp2 = new Lamp();
            var device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.TurnBothOff();
            // Assert
            Assert.False(lamp1.IsOn);
            Assert.False(lamp2.IsOn);
        }

        [Fact]
        public void IncreaseBothBrightness_WhenCalled_IncreasesBrightnessOfBothLamps()
        {
            // Arrange
            var lamp1 = new EcoLamp();
            var lamp2 = new Lamp();
            var device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.DecreaseBothBrightness();
            device.DecreaseBothBrightness();
            device.IncreaseBothBrightness();
            // Assert
            Assert.Equal(4, lamp1.Brightness);
            Assert.Equal(9, lamp2.Brightness);
        }

        [Fact]
        public void DecreaseBothBrightness_WhenCalled_DecreasesBrightnessOfBothLamps()
        {
            // Arrange
            var lamp1 = new EcoLamp();
            var lamp2 = new Lamp();
            var device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.DecreaseBothBrightness();
            // Assert
            Assert.Equal(4, lamp1.Brightness);
            Assert.Equal(9, lamp2.Brightness);
        }

        [Fact]
        public void IncreaseBothBrightness_AtMaxBrightness_DoesNotExceedMax()
        {
            // Arrange
            var lamp1 = new Lamp();
            var lamp2 = new Lamp();
            var device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.IncreaseBothBrightness();
            // Assert
            Assert.Equal(10, lamp1.Brightness);
            Assert.Equal(10, lamp2.Brightness);
        }

        [Fact]
        public void DecreaseBothBrightness_AtMinBrightness_DoesNotGoBelowMin()
        {
            // Arrange
            var lamp1 = new EcoLamp();
            var lamp2 = new EcoLamp();
            var device = new TwoLampDevice(lamp1, lamp2);
            // Act
            for (int i = 0; i <= 6; i++)
            {
                device.DecreaseBothBrightness();
            }
            // Assert
            Assert.Equal(1, lamp1.Brightness);
            Assert.Equal(1, lamp2.Brightness);
        }

        [Fact]
        public void IncreaseBothBrigthness_WhenLamp2IsAtMax_IncreaseOnlyLamp1Brightness()
        {
            // Arrange
            var lamp1 = new EcoLamp();
            var lamp2 = new Lamp();
            var device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.DecreaseOneBrightness(1);
            device.DecreaseOneBrightness(1);
            device.IncreaseBothBrightness();
            // Assert
            Assert.Equal(10, lamp2.Brightness);
            Assert.Equal(4, lamp1.Brightness);
        }

        [Fact]
        public void IncreaseBothBrigthness_WhenLamp1IsAtMax_IncreaseOnlyLamp2Brightness()
        {
            // Arrange
            var lamp1 = new EcoLamp();
            var lamp2 = new Lamp();
            var device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.DecreaseOneBrightness(2);
            device.DecreaseOneBrightness(2);
            device.IncreaseBothBrightness();
            // Assert
            Assert.Equal(5, lamp1.Brightness);
            Assert.Equal(9, lamp2.Brightness);
        }

        [Fact]
        public void DecreaseBothBrigthness_WhenLamp2IsAtMin_DecreaseOnlyLamp1Brightness()
        {
            // Arrange
            var lamp1 = new EcoLamp();
            var lamp2 = new Lamp();
            var device = new TwoLampDevice(lamp1, lamp2);
            // Act
            for (int i = 0; i < 10; i++)
            {
                device.DecreaseOneBrightness(2);
            }
            device.DecreaseBothBrightness();
            // Assert
            Assert.Equal(1, lamp2.Brightness);
            Assert.Equal(4, lamp1.Brightness);

        }

        [Fact]
        public void DecreaseBothBrigthness_WhenLamp1IsAtMin_DecreaseOnlyLamp2Brightness()
        {
            // Arrange
            var lamp1 = new EcoLamp();
            var lamp2 = new Lamp();
            var device = new TwoLampDevice(lamp1, lamp2);
            // Act
            for (int i = 0; i < 6; i++)
            {
                device.DecreaseOneBrightness(1);
            }
            device.DecreaseBothBrightness();
            // Assert
            Assert.Equal(1, lamp1.Brightness);
            Assert.Equal(9, lamp2.Brightness);
        }

        [Fact]
        public void IncreaseOneBrightness_WhenParameterIs1_IncreasesLamp1Brightness()
        {
            // Arrange
            var lamp1 = new EcoLamp();
            var lamp2 = new Lamp();
            var device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.DecreaseOneBrightness(1);
            device.DecreaseOneBrightness(1);
            device.IncreaseOneBrightness(1);
            // Assert
            Assert.Equal(4, lamp1.Brightness);
        }

        [Fact]
        public void IncreaseOneBrightness_WhenParameterIs2_IncreasesLamp2Brightness()
        {
            // Arrange
            var lamp1 = new EcoLamp();
            var lamp2 = new Lamp();
            var device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.DecreaseOneBrightness(2);
            device.DecreaseOneBrightness(2);
            device.IncreaseOneBrightness(2);
            // Assert
            Assert.Equal(9, lamp2.Brightness);
        }

        [Fact]
        public void DecreaseOneBrightness_WhenParameterIs1_DecreasesLamp1Brightness()
        {
            // Arrange
            var lamp1 = new EcoLamp();
            var lamp2 = new Lamp();
            var device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.DecreaseOneBrightness(1);
            // Assert
            Assert.Equal(4, lamp1.Brightness);
        }

        [Fact]
        public void DecreaseOneBrightness_WhenParameterIs2_DecreasesLamp2Brightness()
        {
            // Arrange
            var lamp1 = new EcoLamp();
            var lamp2 = new Lamp();
            var device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.DecreaseOneBrightness(2);
            // Assert
            Assert.Equal(9, lamp2.Brightness);
        }

        [Fact]
        public void DecreaseOneBrightness_InvalidLampNumber_DoesNotChangeAnyLampBrightness()
        {
            // Arrange
            var lamp1 = new EcoLamp();
            var lamp2 = new Lamp();
            var device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.DecreaseOneBrightness(3);
            // Assert
            Assert.Equal(5, lamp1.Brightness);
            Assert.Equal(10, lamp2.Brightness);
        }

        [Fact]
        public void IncreaseOneBrightness_InvalidLampNumber_DoesNotChangeAnyLampBrightness()
        {
            // Arrange
            var lamp1 = new EcoLamp();
            var lamp2 = new Lamp();
            var device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.IncreaseOneBrightness(3);
            // Assert
            Assert.Equal(5, lamp1.Brightness);
            Assert.Equal(10, lamp2.Brightness);
        }

        [Fact]
        public void IncreaseOneBrightness_AtMaxBrightness_DoesNotExceedMax()
        {
            // Arrange
            var lamp1 = new Lamp();
            var lamp2 = new Lamp();
            var device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.IncreaseOneBrightness(1);
            device.IncreaseOneBrightness(2);
            // Assert
            Assert.Equal(10, lamp1.Brightness);
            Assert.Equal(10, lamp2.Brightness);
        }

        [Fact]
        public void DecreaseOneBrightness_AtMinBrightness_DoesNotGoBelowMin()
        {
            // Arrange
            var lamp1 = new EcoLamp();
            var lamp2 = new EcoLamp();
            var device = new TwoLampDevice(lamp1, lamp2);
            // Act
            for (int i = 0; i <= 6; i++)
            {
                device.DecreaseOneBrightness(1);
                device.DecreaseOneBrightness(2);
            }
            // Assert
            Assert.Equal(1, lamp1.Brightness);
            Assert.Equal(1, lamp2.Brightness);
        }

        [Fact]
        public void ChangeOneBrightness_WhenParameterIs1_ChangesLamp1Brightness()
        {
            // Arrange
            var lamp1 = new EcoLamp();
            var lamp2 = new Lamp();
            var device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.ChangeOneBrightness(1, 4);
            // Assert
            Assert.Equal(4, lamp1.Brightness);
        }

        [Fact]
        public void ChangeOneBrightness_WhenParameterIs2_ChangesLamp2Brightness()
        {
            // Arrange
            var lamp1 = new EcoLamp();
            var lamp2 = new Lamp();
            var device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.ChangeOneBrightness(2, 6);
            // Assert
            Assert.Equal(6, lamp2.Brightness);
        }

        [Fact]
        public void ChangeOneBrightness_InvalidLampNumber_DoesNotChangeAnyLampBrightness()
        {
            // Arrange
            var lamp1 = new EcoLamp();
            var lamp2 = new Lamp();
            var device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.ChangeOneBrightness(3, 7);
            // Assert
            Assert.Equal(5, lamp1.Brightness);
            Assert.Equal(10, lamp2.Brightness);
        }

        [Fact]
        public void ChangeOneBrightness_InvalidBrightness_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var lamp1 = new EcoLamp();
            var lamp2 = new Lamp();
            var device = new TwoLampDevice(lamp1, lamp2);
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => device.ChangeOneBrightness(1, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => device.ChangeOneBrightness(2, 11));
        }
    }
}
