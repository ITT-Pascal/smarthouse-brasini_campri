namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class LampTest
    {
        [Fact]
        public void switchIsOnOff_WhenIsOnIsFalse_ItChangesItToTrue()
        {
            Lamp lamp = new Lamp();
            lamp.SwitchOnOff();
            Assert.True(lamp.IsOn);
        }
        
        [Fact]
        public void switchIsOnOff_WhenIsOnIsTrue_ItChangesItToFalse()
        {
            Lamp lamp = new Lamp();
            lamp.SwitchOnOff();
            lamp.SwitchOnOff();
            Assert.False(lamp.IsOn);
        }

        [Fact]

        public void increaseBrightness_WhenBrightnessIsLessThanMax_ItIncreasesByOne()
        {
            Lamp lamp = new Lamp();
            lamp.DecreaseBrightness();
            lamp.IncreaseBrightness();
            Assert.Equal(10, lamp.Brightness);
        }

        [Fact]
        public void increaseBrightness_WhenBrightnessIsMax_ItRemainsMax()
        {
            Lamp lamp = new Lamp();
            lamp.IncreaseBrightness();
            Assert.Equal(10, lamp.Brightness);
        }

        [Fact]
        public void decreaseBrightness_WhenBrightnessIsMoreThanMin_ItDecreasesByOne()
        {
            Lamp lamp = new Lamp();
            lamp.DecreaseBrightness();
            Assert.Equal(9, lamp.Brightness);
        }
        
        [Fact]
        public void decreaseBrightness_WhenBrightnessIsMin_ItRemainsMin()
        {
            Lamp lamp = new Lamp();
            for (int i = 0; i < 11; i++)
            {
                lamp.DecreaseBrightness();
            }
            Assert.Equal(1, lamp.Brightness);
        }

        [Fact]
        public void ChangeBrightness_WhenTheParameterIsGreaterThan0AndLowerThan11_BrightnessChangesToParameter()
        {
            Lamp lamp = new Lamp();
            lamp.ChangeBrightness(7);
            Assert.Equal(7, lamp.Brightness);
        }

        [Fact]
        public void ChangeBrightness_WhenParameterIsBelow1_ThrowAnArgumentOutOfRangeException()
        {
            Lamp lamp = new Lamp();
            Assert.Throws<ArgumentOutOfRangeException>(() => lamp.ChangeBrightness(0));
        }

        [Fact]
        public void ChangeBrightness_WhenParameterIsAbove10_ThrowAnArgumentOutOfRangeException()
        {
            Lamp lamp = new Lamp();
            Assert.Throws<ArgumentOutOfRangeException>(() => lamp.ChangeBrightness(10));
        }

    }
}