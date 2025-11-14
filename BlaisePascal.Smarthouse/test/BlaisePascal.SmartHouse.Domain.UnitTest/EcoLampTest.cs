using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class EcoLampTest
    {
        [Fact]
        public void constructor_WhenLampIsCreated_IsOnIsFalseAndBrightnessIsHisMaxValue()
        {
            EcoLamp lamp = new EcoLamp("a");
            Assert.False(lamp.IsOn);
            Assert.Equal(5, lamp.Brightness);
        }

        [Fact]
        public void switchOnOff_WhenIsOnIsFalse_ItChangesItToTrue()
        {
            EcoLamp lamp = new EcoLamp("a");
            lamp.SwitchOnOff();
            Assert.True(lamp.IsOn);
        }

        [Fact]
        public void switchOnOff_WhenIsOnIsTrue_ItChangesItToFalse()
        {
            EcoLamp lamp = new EcoLamp("a");
            lamp.SwitchOnOff();
            lamp.SwitchOnOff();
            Assert.False(lamp.IsOn);
        }

        [Fact]
        public void increaseBrightness_WhenBrightnessIsMax_ItDoesNotIncrease()
        {
            EcoLamp lamp = new EcoLamp("a");
            lamp.IncreaseBrightness();
            Assert.Equal(5, lamp.Brightness);
        }

        [Fact]
        public void increaseBrightness_WhenBrightnessIsLessThanMax_ItIncreasesByOne()
        {
            EcoLamp lamp = new EcoLamp("a");
            lamp.DecreaseBrightness();
            lamp.IncreaseBrightness();
            Assert.Equal(5, lamp.Brightness);
        }

        [Fact]
        public void decreaseBrightness_WhenBrightnessIsMoreThanMinBrightness_ItDecreasesByOne()
        {
            EcoLamp lamp = new EcoLamp("a");
            lamp.DecreaseBrightness();
            Assert.Equal(4, lamp.Brightness);
        }

        [Fact]
        public void decreaseBrightness_WhenBrightnessIsMin_ItDoesNotDecrease()
        {
            EcoLamp lamp = new EcoLamp("a");
            for(int i = 0; i < 5; i++)
            {
                lamp.DecreaseBrightness();
            }

            Assert.Equal(1, lamp.Brightness);
        }

        [Fact]
        public void changeBrightness_WhenNewBrightnessIsMoreThanMax_ThrowError()
        {
            EcoLamp lamp = new EcoLamp("a");
            Assert.Throws<ArgumentOutOfRangeException>(() => lamp.ChangeBrightness(6));
        }

        [Fact]
        public void changeBrightness_WhenNewBrightnessIsLessThanMin_ThrowError()
        {
            EcoLamp lamp = new EcoLamp("a");
            Assert.Throws<ArgumentOutOfRangeException>(() => lamp.ChangeBrightness(0));
        }

        [Fact]
        public void changeBrightness_WhenNewBrightnessIsInsideTheRange_AssignBightnessCorrectly()
        {
            EcoLamp lamp = new EcoLamp("a");
            lamp.ChangeBrightness(3);
            Assert.Equal(3, lamp.Brightness);
        }

   
    }
}
