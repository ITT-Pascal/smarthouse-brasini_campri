using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        [Fact]
        public void SetDryMode_WhenConditionerIsOff_ThrowsError()
        {
            //Arrange
            AirConditioner cond = new AirConditioner();
            //Act & Assert
            Assert.Throws<Exception>(() => cond.SetDryMode());
        }

        [Fact]
        public void SetDryMode_WhenModeIsAlreadyDry_ThrowsError()
        {
            //Arrange
            AirConditioner cond = new AirConditioner();
            //Act
            cond.SwitchOn();
            cond.SetDryMode();
            //Assert
            Assert.Throws<Exception>(() => cond.SetDryMode());
        }

        [Fact]
        public void SetDryMode_WhenModeIsNotDry_SetIt()
        {
            //Arrange
            AirConditioner cond = new AirConditioner();
            //Act
            cond.SwitchOn();
            cond.SetDryMode();
            //Assert
            Assert.Equal(AirMode.Dry, cond.Mode);
        }

        [Fact]
        public void SetMode_WhenConditionerIsOff_ThrowsError()
        {
            //Arrange 
            AirConditioner cond = new AirConditioner();
            //Act & Assert
            Assert.Throws<Exception>(() => cond.SetMode(AirMode.Normal));
        }

        [Fact]
        public void SetMode_WhenModeIsAlreadyTheOneSelected_ThrowsError()
        {
            //Arrange
            AirConditioner cond = new AirConditioner();
            //Act
            cond.SwitchOn();
            //Assert
            Assert.Throws<ArgumentException>(() => cond.SetMode(AirMode.Normal));
        }

        [Fact]
        public void SetMode_WhenModeIsNotTheOneSelected_ChangesIt()
        {
            //Arrange
            AirConditioner cond = new AirConditioner();
            //Act
            cond.SwitchOn();
            cond.SetMode(AirMode.Fan);
            //Assert
            Assert.Equal(AirMode.Fan, cond.Mode);
        }

        [Fact]
        public void SetDegrees_WhenConditionerIsOff_ThrowsError()
        {
            //Arrange
            AirConditioner cond = new AirConditioner();
            //Act & Assert
            Assert.Throws<Exception>(() => cond.SetDegrees(24));
        }

        [Fact]
        public void SetDegrees_WhenDegreesAreUnderMinValue_ThrowsError()
        {
            //Arrange
            AirConditioner cond = new AirConditioner();
            //Act
            cond.SwitchOn();
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => cond.SetDegrees(15));
        }

        [Fact]
        public void SetDegrees_WhenDegreesAreOverMaxValue_ThrowsError()
        {
            //Arrange
            AirConditioner cond = new AirConditioner();
            //Act
            cond.SwitchOn();
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => cond.SetDegrees(28));
        }

        [Fact]
        public void SetDegrees_WhenModeIsDry_CannotChangeDegrees()
        {
            //Arrange
            AirConditioner cond = new AirConditioner();
            //Act
            cond.SwitchOn();
            cond.SetMode(AirMode.Dry);
            //Assert
            Assert.Throws<Exception>(() => cond.SetDegrees(20));
        }

        [Fact]
        public void SetDegrees_WhenModeIsFan_CannotChangeDegrees()
        {
            //Arrange
            AirConditioner cond = new AirConditioner();
            //Act
            cond.SwitchOn();
            cond.SetMode(AirMode.Fan);
            //Assert
            Assert.Throws<Exception>(() => cond.SetDegrees(20));
        }

        [Fact]
        public void SetDegrees_WhenModeIsNormalAndDegreesAreInRange_SetToNewDegrees()
        {
            //Arrange
            AirConditioner cond = new AirConditioner();
            //Act
            cond.SwitchOn();
            cond.SetDegrees(20);
            //Assert
            Assert.Equal(20, cond.Degrees);
        }


        [Fact]
        public void IncreaseDegrees_WhenConditionerIsOff_ThrowsError()
        {
            //Arrange
            AirConditioner cond = new AirConditioner();
            //Act & Assert
            Assert.Throws<Exception>(() => cond.IncreaseDegrees());
        }

        [Fact]
        public void IncreaseDegrees_WhenModeIsDry_CannotIncreaseDegrees()
        {
            //Arrange
            AirConditioner cond = new AirConditioner();
            //Act
            cond.SwitchOn();
            cond.SetDryMode();
            //Assert
            Assert.Throws<Exception>(() => cond.IncreaseDegrees());
        }

        [Fact]
        public void IncreaseDegrees_WhenModeIsFan_CannotIncreaseDegrees()
        {
            //Arrange
            AirConditioner cond = new AirConditioner();
            //Act
            cond.SwitchOn();
            cond.SetFanMode();
            //Assert
            Assert.Throws<Exception>(() => cond.IncreaseDegrees());
        }

        [Fact]
        public void IncreaseDegrees_WhenDegreesAreNotMax_IncreaseByHalfDegree()
        {
            //Arrange
            AirConditioner cond = new AirConditioner();
            //Act
            cond.SwitchOn();
            cond.IncreaseDegrees();
            //Assert
            Assert.Equal(20.5, cond.Degrees);
        }

        [Fact]
        public void IncreaseDegrees_WhenDegreesAreMaxOrGetToMax_SetToMax()
        {
            //Arrange
            AirConditioner cond = new AirConditioner();
            //Act
            cond.SwitchOn();
            cond.SetDegrees(27);
            cond.IncreaseDegrees();
            //Assert
            Assert.Equal(27.0, cond.Degrees);
        }

        [Fact]
        public void DecreaseDegrees_WhenConditionerIsOff_ThrowsError()
        {
            //Arrange
            AirConditioner cond = new AirConditioner();
            //Act & Assert
            Assert.Throws<Exception>(() => cond.DecreaseDegrees());
        }

        [Fact]
        public void DecreaseDegrees_WhenModeIsDry_CannotDecreaseDegrees()
        {
            //Arrange
            AirConditioner cond = new AirConditioner();
            //Act
            cond.SwitchOn();
            cond.SetDryMode();
            //Assert
            Assert.Throws<Exception>(() => cond.DecreaseDegrees());
        }

        [Fact]
        public void DecreaseDegrees_WhenModeIsFan_CannotDecreaseDegrees()
        {
            //Arrange
            AirConditioner cond = new AirConditioner();
            //Act
            cond.SwitchOn();
            cond.SetFanMode();
            //Assert
            Assert.Throws<Exception>(() => cond.DecreaseDegrees());
        }

        [Fact]
        public void DecreaseDegrees_WhenDegreesAreNotMax_DecraseByHalfDegree()
        {
            //Arrange
            AirConditioner cond = new AirConditioner();
            //Act
            cond.SwitchOn();
            cond.DecreaseDegrees();
            //Assert
            Assert.Equal(19.5, cond.Degrees);
        }

        [Fact]
        public void DecreaseDegrees_WhenDegreesAreMinOrGetToMin_SetToMin()
        {
            //Arrange
            AirConditioner cond = new AirConditioner();
            //Act
            cond.SwitchOn();
            cond.SetDegrees(16);
            cond.DecreaseDegrees();
            //Assert
            Assert.Equal(16.0, cond.Degrees);
        }
    }
}
