namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class LampTest
    {
        [Fact]
        public void switchIsOnOff_WhenIsOnIsFalse_ItChangesItToTrue()
        {
            Lamp lamp = new Lamp();
            lamp.switchOnOff();
            Assert.True(lamp.IsOn);
        }
        
        [Fact]
        public void switchIsOnOff_WhenIsOnIsTrue_ItChangesItToFalse()
        {
            Lamp lamp = new Lamp();
            lamp.switchOnOff();
            lamp.switchOnOff();
            Assert.False(lamp.IsOn);
        }

        [Fact]

        public void increaseBrightness_WhenBrightnessIsLessThanMax_ItIncreasesByOne()
        {
            Lamp lamp = new Lamp();
            lamp.decreaseBrightness();
            lamp.increaseBrightness();
            Assert.Equal(10, lamp.Brightness);
        }

        [Fact]
        public void increaseBrightness_WhenBrightnessIsMax_ItRemainsMax()
        {
            Lamp lamp = new Lamp();
            lamp.increaseBrightness();
            Assert.Equal(10, lamp.Brightness);
        }

        [Fact]
        public void decreaseBrightness_WhenBrightnessIsMoreThanMin_ItDecreasesByOne()
        {
            Lamp lamp = new Lamp();
            lamp.decreaseBrightness();
            Assert.Equal(9, lamp.Brightness);
        }
        
        [Fact]
        public void decreaseBrightness_WhenBrightnessIsMin_ItRemainsMin()
        {
            Lamp lamp = new Lamp();
            for (int i = 0; i < 11; i++)
            {
                lamp.decreaseBrightness();
            }
            Assert.Equal(1, lamp.Brightness);
        }
    }
}