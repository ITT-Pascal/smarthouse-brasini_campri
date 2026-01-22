using BlaisePascal.SmartHouse.Domain.abstraction;
using BlaisePascal.SmartHouse.Domain.Device;
using BlaisePascal.SmartHouse.Domain.LuminousDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.LuminousDevices
{
    public class EcoLampTest
    {
        [Fact]
        public void constructor_WhenLampIsCreated_IsOnIsFalseAndBrightnessIsHisMaxValue()
        {
            EcoLamp lamp = new EcoLamp("a");
            Assert.Equal(DeviceStatus.Off, lamp.Status);
            Assert.Equal(new BrightnessRecord(1), lamp.Brightness);
        }

        [Fact]
        public void switchOnOff_WhenIsOnIsFalse_ItChangesItToTrue()
        {
            EcoLamp lamp = new EcoLamp("a");
            lamp.Toggle();
            Assert.Equal(DeviceStatus.On, lamp.Status);
        }

        [Fact]
        public void switchOnOff_WhenIsOnIsTrue_ItChangesItToFalse()
        {
            EcoLamp lamp = new EcoLamp("a");
            lamp.Toggle();
            lamp.Toggle();
            Assert.Equal(DeviceStatus.Off, lamp.Status);
        }

        [Fact]
        public void increaseBrightness_WhenBrightnessIsMax_ItDoesNotIncrease()
        {
            EcoLamp lamp = new EcoLamp("a");
            lamp.TurnOn();
            lamp.IncreaseBrightness();
            Assert.Equal(new BrightnessRecord(2), lamp.Brightness);
        }

        [Fact]
        public void increaseBrightness_WhenBrightnessIsLessThanMax_ItIncreasesByOne()
        {
            EcoLamp lamp = new EcoLamp("a");
            lamp.TurnOn();
            lamp.DecreaseBrightness();
            lamp.IncreaseBrightness();
            Assert.Equal(new BrightnessRecord(2), lamp.Brightness);
        }

        [Fact]
        public void decreaseBrightness_WhenBrightnessIsMoreThanMinBrightness_ItDecreasesByOne()
        {
            EcoLamp lamp = new EcoLamp("a");
            lamp.TurnOn();
            lamp.IncreaseBrightness();
            lamp.DecreaseBrightness();
            Assert.Equal(new BrightnessRecord(1), lamp.Brightness);
        }

        [Fact]
        public void decreaseBrightness_WhenBrightnessIsMin_ItDoesNotDecrease()
        {
            EcoLamp lamp = new EcoLamp("a");
            lamp.TurnOn();
            for (int i = 0; i < 5; i++)
            {
                lamp.DecreaseBrightness();
            }

            Assert.Equal(new BrightnessRecord(1), lamp.Brightness);
        }

        [Fact]
        public void changeBrightness_WhenNewBrightnessIsMoreThanMax_ThrowError()
        {
            EcoLamp lamp = new EcoLamp("a");
            lamp.TurnOn();
            Assert.Throws<ArgumentOutOfRangeException>(() => lamp.ChangeBrightness(6));
        }

        [Fact]
        public void changeBrightness_WhenNewBrightnessIsLessThanMin_ThrowError()
        {
            EcoLamp lamp = new EcoLamp("a");
            lamp.TurnOn();
            Assert.Throws<ArgumentOutOfRangeException>(() => lamp.ChangeBrightness(0));
        }

        [Fact]
        public void changeBrightness_WhenNewBrightnessIsInsideTheRange_AssignBightnessCorrectly()
        {
            EcoLamp lamp = new EcoLamp("a");
            lamp.TurnOn();
            lamp.ChangeBrightness(3);
            Assert.Equal(new BrightnessRecord(3), lamp.Brightness);
        }

        [Fact]
        public void checkAutoOff_WhenAutoOffTimeIsNotReached_LampRemainsOn()
        {
            EcoLamp lamp = new EcoLamp("a");
            lamp.TurnOn();
            lamp.CheckAutoOff();
            Assert.Equal(DeviceStatus.On, lamp.Status);
        }

        [Fact]
        public void changeBrightness_IncreasesAutoOffTime()
        {
            EcoLamp lamp = new EcoLamp("a");
            lamp.TurnOn();
            lamp.ChangeBrightness(2);
            lamp.CheckAutoOff();
            Assert.Equal(DeviceStatus.On, lamp.Status);
        }
        [Fact]
        public void increaseBrightness_IncreasesAutoOffTime()
        {
            EcoLamp lamp = new EcoLamp("a");
            lamp.TurnOn();
            lamp.IncreaseBrightness();
            lamp.CheckAutoOff();
            Assert.Equal(DeviceStatus.On, lamp.Status);
        }
        [Fact]
        public void decreaseBrightness_IncreasesAutoOffTime()
        {
            EcoLamp lamp = new EcoLamp("a");
            lamp.TurnOn();
            lamp.DecreaseBrightness();
            lamp.CheckAutoOff();
            Assert.Equal(DeviceStatus.On, lamp.Status);
        }
        
    }
}
