using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class AirConditionerTests
    {
        [Fact]
        public void Constructor_AfterCreation_AirConditionerIsOff()
        {
            //Arrange & Act
            AirConditioner cond = new AirConditioner();
            //Assert
            Assert.Equal(DeviceStatus.Off, cond.Status);
            Assert.Null(cond.Degrees);
            Assert.Equal(AirMode.NoMode, cond.Mode);
            
        }

        [Fact]
        public void SwitchOn_WhenConditionerIsOff_ItTurnsOn()
        {
            //Arrange
            AirConditioner cond = new AirConditioner();
            //Act
            cond.SwitchOn();
            //Assert
            Assert.Equal(DeviceStatus.On, cond.Status);
            Assert.Equal(20.0, cond.Degrees);
            Assert.Equal(AirMode.Normal, cond.Mode);
        }

        [Fact]
        public void SwitchOn_WhenConditionerIsOn_ThrowsError()
        {
            //Arrange
            AirConditioner cond = new AirConditioner();
            //Act
            cond.SwitchOn();
            //Arrange
            Assert.Throws<Exception>(() => cond.SwitchOn());
        }

        [Fact]
        public void SwitchOff_WhenConditionerIsOn_ItTurnsOff()
        {
            //Arrange
            AirConditioner cond = new AirConditioner();
            //Act
            cond.SwitchOn();
            cond.SwitchOff();
            //Assert
            Assert.Equal(DeviceStatus.Off, cond.Status);
            Assert.Equal(null, cond.Degrees);
            Assert.Equal(AirMode.NoMode, cond.Mode);
        }

        [Fact]
        public void SwitchOff_WhenConditionerIsOff_ThrowsError()
        {
            //Arrange
            AirConditioner cond = new AirConditioner();
            //Act & Arrange
            Assert.Throws<Exception>(() => cond.SwitchOff());
        }

        [Fact]
        public void SetNormalMode_WhenConditionerIsOff_ThrowsError()
        {
            //Arrange
            AirConditioner cond = new AirConditioner();
            //Act & Assert
            Assert.Throws<Exception>(() => cond.SetNormalMode());
        }

        [Fact]
        public void SetNormalMode_WhenModeIsNormal_ThrowsError()
        {
            //Arrange
            AirConditioner cond = new AirConditioner();
            //Act
            cond.SwitchOn();
            //Assert
            Assert.Throws<Exception>(() => cond.SetNormalMode());
        }

        [Fact]
        public void SetNormalMode_WhenModeIsNotNormal_SetIt()
        {
            //Arrange
            AirConditioner cond = new AirConditioner();
            //Act
            cond.SwitchOn();
            cond.SetFanMode();
            cond.SetNormalMode();
            //Assert
            Assert.Equal(AirMode.Normal, cond.Mode);
        }

        [Fact]
        public void SetFanMode_WhenConditionerIsOff_ThrowsError()
        {
            //Arrange
            AirConditioner cond = new AirConditioner();
            //Act & Assert
            Assert.Throws<Exception>(() => cond.SetNormalMode());
        }

        [Fact]
        public void SetFanMode_WhenModeIsFan_ThrowsError()
        {
            //Arrange
            AirConditioner cond = new AirConditioner();
            //Act
            cond.SwitchOn();
            cond.SetFanMode();
            //Assert
            Assert.Throws<Exception>(() => cond.SetFanMode());
        }

        [Fact]
        public void SetFanMode_WhenModeIsNotFan_SetIt()
        {
            //Arrange
            AirConditioner cond = new AirConditioner();
            //Act
            cond.SwitchOn();
            cond.SetFanMode();
            //Assert
            Assert.Equal(AirMode.Fan, cond.Mode);
        }


    }
}
