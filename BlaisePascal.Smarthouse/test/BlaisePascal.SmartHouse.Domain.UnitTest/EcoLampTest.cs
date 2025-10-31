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
        public void switchIsOnOff_WhenIsOnIsFalse_ItChangesItToTrue()
        {
            EcoLamp lamp = new EcoLamp();
            lamp.SwitchOnOff();
            Assert.True(lamp.IsOn);
        }

        [Fact]
        public void switchIsOnOff_WhenIsOnIsTrue_ItChangesItToFalse()
        {
            EcoLamp lamp = new EcoLamp();
            lamp.SwitchOnOff();
            lamp.SwitchOnOff();
            Assert.False(lamp.IsOn);
        }




       

    }
}
