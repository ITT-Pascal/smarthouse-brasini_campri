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
            device.SwitchOneLamp(lamp1.ID);
            // Assert
            Assert.True(lamp1.IsOn);
            Assert.False(lamp2.IsOn);
        }

        [Fact]
        public void SwitchOneLamp_WhenTheParameterIs2_TogglesTheLampStateOfTheLampChosen()
        {
            // Arrange
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.SwitchOneLamp(lamp2.ID);
            // Assert
            Assert.False(lamp1.IsOn);
            Assert.True(lamp2.IsOn);
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
            device.SwitchOneLamp(guid);
            // Assert
            Assert.False(lamp1.IsOn);
            Assert.False(lamp2.IsOn);
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
            Assert.True(lamp1.IsOn);
            Assert.True(lamp2.IsOn);

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
            Assert.False(lamp1.IsOn);
            Assert.False(lamp2.IsOn);
        }

        [Fact]
        public void IncreaseBothBrightness_WhenCalled_IncreasesBrightnessOfBothLamps()
        {
            // Arrange
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
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
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
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
            LampModel lamp1 = new Lamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
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
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new EcoLamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
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
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.DecreaseOneBrightness(lamp1.ID);
            device.DecreaseOneBrightness(lamp1.ID);
            device.IncreaseBothBrightness();
            // Assert
            Assert.Equal(10, lamp2.Brightness);
            Assert.Equal(4, lamp1.Brightness);
        }

        [Fact]
        public void IncreaseBothBrigthness_WhenLamp1IsAtMax_IncreaseOnlyLamp2Brightness()
        {
            // Arrange
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.DecreaseOneBrightness(lamp2.ID);
            device.DecreaseOneBrightness(lamp2.ID);
            device.IncreaseBothBrightness();
            // Assert
            Assert.Equal(5, lamp1.Brightness);
            Assert.Equal(9, lamp2.Brightness);
        }

        [Fact]
        public void DecreaseBothBrigthness_WhenLamp2IsAtMin_DecreaseOnlyLamp1Brightness()
        {
            // Arrange
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            // Act
            for (int i = 0; i < 10; i++)
            {
                device.DecreaseOneBrightness(lamp2.ID);
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
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            // Act
            for (int i = 0; i < 6; i++)
            {
                device.DecreaseOneBrightness(lamp1.ID);
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
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.DecreaseOneBrightness(lamp1.ID);
            device.DecreaseOneBrightness(lamp1.ID);
            device.IncreaseOneBrightness(lamp1.ID);
            // Assert
            Assert.Equal(4, lamp1.Brightness);
        }

        [Fact]
        public void IncreaseOneBrightness_WhenParameterIs2_IncreasesLamp2Brightness()
        {
            // Arrange
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.DecreaseOneBrightness(lamp2.ID);
            device.DecreaseOneBrightness(lamp2.ID);
            device.IncreaseOneBrightness(lamp2.ID);
            // Assert
            Assert.Equal(9, lamp2.Brightness);
        }

        [Fact]
        public void DecreaseOneBrightness_WhenParameterIs1_DecreasesLamp1Brightness()
        {
            // Arrange
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.DecreaseOneBrightness(lamp1.ID);
            // Assert
            Assert.Equal(4, lamp1.Brightness);
        }

        [Fact]
        public void DecreaseOneBrightness_WhenParameterIs2_DecreasesLamp2Brightness()
        {
            // Arrange
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.DecreaseOneBrightness(lamp2.ID);
            // Assert
            Assert.Equal(9, lamp2.Brightness);
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
            device.DecreaseOneBrightness(guid);
            // Assert
            Assert.Equal(5, lamp1.Brightness);
            Assert.Equal(10, lamp2.Brightness);
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
            device.IncreaseOneBrightness(guid);
            // Assert
            Assert.Equal(5, lamp1.Brightness);
            Assert.Equal(10, lamp2.Brightness);
        }

        [Fact]
        public void IncreaseOneBrightness_AtMaxBrightness_DoesNotExceedMax()
        {
            // Arrange
            LampModel lamp1 = new Lamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            // Act
            device.IncreaseOneBrightness(lamp1.ID);
            device.IncreaseOneBrightness(lamp2.ID);
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
            for (int i = 0; i <= 6; i++)
            {
                device.DecreaseOneBrightness(lamp1.ID);
                device.DecreaseOneBrightness(lamp2.ID);
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
            device.ChangeOneBrightness(lamp1.ID, 4);
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
            device.ChangeOneBrightness(lamp2.ID, 6);
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
            device.ChangeOneBrightness(guid, 7);
            // Assert
            Assert.Equal(5, lamp1.Brightness);
            Assert.Equal(10, lamp2.Brightness);
        }

        [Fact]
        public void ChangeOneBrightness_InvalidBrightness_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            LampModel lamp1 = new EcoLamp("a");
            LampModel lamp2 = new Lamp("b");
            TwoLampDevice device = new TwoLampDevice(lamp1, lamp2);
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => device.ChangeOneBrightness(lamp1.ID, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => device.ChangeOneBrightness(lamp2.ID, 11));
        }
    }
}
