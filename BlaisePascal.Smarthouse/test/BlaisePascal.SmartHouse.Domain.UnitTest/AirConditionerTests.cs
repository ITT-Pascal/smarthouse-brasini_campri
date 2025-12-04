using BlaisePascal.SmartHouse.Domain.AirConditionerDevice;
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
            AirConditioner cond = new AirConditioner("Air Conditioner");
            //Assert
            Assert.Equal(DeviceStatus.Off, cond.Status);
            Assert.Null(cond.Degrees);
            Assert.Equal(AirMode.NoMode, cond.Mode);
            
        }

        [Fact]
        public void TurnOn_WhenConditionerIsOff_ItTurnsOn()
        {
            //Arrange
            AirConditioner cond = new AirConditioner("Air Conditioner");
            //Act
            cond.TurnOn();
            //Assert
            Assert.Equal(DeviceStatus.On, cond.Status);
            Assert.Null( cond.Degrees);
            Assert.Equal(AirMode.NoMode, cond.Mode);
        }

        [Fact]
        public void TurnOn_WhenConditionerIsOn_ThrowsError()
        {
            //Arrange
            AirConditioner cond = new AirConditioner("Air Conditioner");
            //Act
            cond.TurnOn();
            //Arrange
            Assert.Throws<Exception>(() => cond.TurnOn());
        }

        [Fact]
        public void TurnOff_WhenConditionerIsOn_ItTurnsOff()
        {
            //Arrange
            AirConditioner cond = new AirConditioner("Air Conditioner");
            //Act
            cond.TurnOn();
            cond.TurnOff();
            //Assert
            Assert.Equal(DeviceStatus.Off, cond.Status);
            Assert.Equal(null, cond.Degrees);
            Assert.Equal(AirMode.NoMode, cond.Mode);
        }

        [Fact]
        public void TurnOff_WhenConditionerIsOff_ThrowsError()
        {
            //Arrange
            AirConditioner cond = new AirConditioner("Air Conditioner");
            //Act & Arrange
            Assert.Throws<Exception>(() => cond.TurnOff());
        }

        [Fact]
        public void SetNormalMode_WhenConditionerIsOff_ThrowsError()
        {
            //Arrange
            AirConditioner cond = new AirConditioner("Air Conditioner");
            //Act & Assert
            Assert.Throws<Exception>(() => cond.SetNormalMode());
        }

        [Fact]
        public void SetNormalMode_WhenModeIsNormal_ThrowsError()
        {
            //Arrange
            AirConditioner cond = new AirConditioner("Air Conditioner");
            //Act
            cond.TurnOn();
            cond.SetNormalMode();
            //Assert
            Assert.Throws<Exception>(() => cond.SetNormalMode());
        }

        [Fact]
        public void SetNormalMode_WhenModeIsNotNormal_SetIt()
        {
            //Arrange
            AirConditioner cond = new AirConditioner("Air Conditioner");
            //Act
            cond.TurnOn();
            cond.SetFanMode();
            cond.SetNormalMode();
            //Assert
            Assert.Equal(AirMode.Normal, cond.Mode);
        }

        [Fact]
        public void SetFanMode_WhenConditionerIsOff_ThrowsError()
        {
            //Arrange
            AirConditioner cond = new AirConditioner("Air Conditioner");
            //Act & Assert
            Assert.Throws<Exception>(() => cond.SetNormalMode());
        }

        [Fact]
        public void SetFanMode_WhenModeIsFan_ThrowsError()
        {
            //Arrange
            AirConditioner cond = new AirConditioner("Air Conditioner");
            //Act
            cond.TurnOn();
            cond.SetFanMode();
            //Assert
            Assert.Throws<Exception>(() => cond.SetFanMode());
        }

        [Fact]
        public void SetFanMode_WhenModeIsNotFan_SetIt()
        {
            //Arrange
            AirConditioner cond = new AirConditioner("Air Conditioner");
            //Act
            cond.TurnOn();
            cond.SetFanMode();
            //Assert
            Assert.Equal(AirMode.Fan, cond.Mode);
        }

        [Fact]
        public void SetDryMode_WhenConditionerIsOff_ThrowsError()
        {
            //Arrange
            AirConditioner cond = new AirConditioner("Air Conditioner");
            //Act & Assert
            Assert.Throws<Exception>(() => cond.SetDryMode());
        }

        [Fact]
        public void SetDryMode_WhenModeIsAlreadyDry_ThrowsError()
        {
            //Arrange
            AirConditioner cond = new AirConditioner("Air Conditioner");
            //Act
            cond.TurnOn();
            cond.SetDryMode();
            //Assert
            Assert.Throws<Exception>(() => cond.SetDryMode());
        }

        [Fact]
        public void SetDryMode_WhenModeIsNotDry_SetIt()
        {
            //Arrange
            AirConditioner cond = new AirConditioner("Air Conditioner");
            //Act
            cond.TurnOn();
            cond.SetDryMode();
            //Assert
            Assert.Equal(AirMode.Dry, cond.Mode);
        }

        [Fact]
        public void SetMode_WhenConditionerIsOff_ThrowsError()
        {
            //Arrange 
            AirConditioner cond = new AirConditioner("Air Conditioner");
            //Act & Assert
            Assert.Throws<Exception>(() => cond.SetMode(AirMode.Normal));
        }

        [Fact]
        public void SetMode_WhenModeIsAlreadyTheOneSelected_ThrowsError()
        {
            //Arrange
            AirConditioner cond = new AirConditioner("Air Conditioner");
            //Act
            cond.TurnOn();
            //Assert
            Assert.Throws<ArgumentException>(() => cond.SetMode(AirMode.NoMode));
        }

        [Fact]
        public void SetMode_WhenModeIsNotTheOneSelected_ChangesIt()
        {
            //Arrange
            AirConditioner cond = new AirConditioner("Air Conditioner");
            //Act
            cond.TurnOn();
            cond.SetMode(AirMode.Fan);
            //Assert
            Assert.Equal(AirMode.Fan, cond.Mode);
        }

        [Fact]
        public void SetDegrees_WhenConditionerIsOff_ThrowsError()
        {
            //Arrange
            AirConditioner cond = new AirConditioner("Air Conditioner");
            //Act & Assert
            Assert.Throws<Exception>(() => cond.SetDegrees(24));
        }

        [Fact]
        public void SetDegrees_WhenDegreesAreUnderMinValue_ThrowsError()
        {
            //Arrange
            AirConditioner cond = new AirConditioner("Air Conditioner");
            //Act
            cond.TurnOn();
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => cond.SetDegrees(15));
        }

        [Fact]
        public void SetDegrees_WhenDegreesAreOverMaxValue_ThrowsError()
        {
            //Arrange
            AirConditioner cond = new AirConditioner("Air Conditioner");
            //Act
            cond.TurnOn();
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => cond.SetDegrees(28));
        }

        [Fact]
        public void SetDegrees_WhenModeIsDry_CannotChangeDegrees()
        {
            //Arrange
            AirConditioner cond = new AirConditioner("Air Conditioner");
            //Act
            cond.TurnOn();
            cond.SetMode(AirMode.Dry);
            //Assert
            Assert.Throws<Exception>(() => cond.SetDegrees(20));
        }

        [Fact]
        public void SetDegrees_WhenModeIsFan_CannotChangeDegrees()
        {
            //Arrange
            AirConditioner cond = new AirConditioner("Air Conditioner");
            //Act
            cond.TurnOn();
            cond.SetMode(AirMode.Fan);
            //Assert
            Assert.Throws<Exception>(() => cond.SetDegrees(20));
        }

        [Fact]
        public void SetDegrees_WhenModeIsNormalAndDegreesAreInRange_SetToNewDegrees()
        {
            //Arrange
            AirConditioner cond = new AirConditioner("Air Conditioner");
            //Act
            cond.TurnOn();
            cond.SetDegrees(20);
            //Assert
            Assert.Equal(20, cond.Degrees);
        }


        [Fact]
        public void IncreaseDegrees_WhenConditionerIsOff_ThrowsError()
        {
            //Arrange
            AirConditioner cond = new AirConditioner("Air Conditioner");
            //Act & Assert
            Assert.Throws<Exception>(() => cond.IncreaseDegrees());
        }

        [Fact]
        public void IncreaseDegrees_WhenModeIsDry_CannotIncreaseDegrees()
        {
            //Arrange
            AirConditioner cond = new AirConditioner("Air Conditioner");
            //Act
            cond.TurnOn();
            cond.SetDryMode();
            //Assert
            Assert.Throws<Exception>(() => cond.IncreaseDegrees());
        }

        [Fact]
        public void IncreaseDegrees_WhenModeIsFan_CannotIncreaseDegrees()
        {
            //Arrange
            AirConditioner cond = new AirConditioner("Air Conditioner");
            //Act
            cond.TurnOn();
            cond.SetFanMode();
            //Assert
            Assert.Throws<Exception>(() => cond.IncreaseDegrees());
        }

        [Fact]
        public void IncreaseDegrees_WhenDegreesAreNotMax_IncreaseByHalfDegree()
        {
            //Arrange
            AirConditioner cond = new AirConditioner("Air Conditioner");
            //Act
            cond.TurnOn();
            cond.IncreaseDegrees();
            //Assert
            Assert.Equal(27, cond.Degrees);
        }

        [Fact]
        public void IncreaseDegrees_WhenDegreesAreMaxOrGetToMax_SetToMax()
        {
            //Arrange
            AirConditioner cond = new AirConditioner("Air Conditioner");
            //Act
            cond.TurnOn();
            cond.SetDegrees(27);
            cond.IncreaseDegrees();
            //Assert
            Assert.Equal(27.0, cond.Degrees);
        }

        [Fact]
        public void DecreaseDegrees_WhenConditionerIsOff_ThrowsError()
        {
            //Arrange
            AirConditioner cond = new AirConditioner("Air Conditioner");
            //Act & Assert
            Assert.Throws<Exception>(() => cond.DecreaseDegrees());
        }

        [Fact]
        public void DecreaseDegrees_WhenModeIsDry_CannotDecreaseDegrees()
        {
            //Arrange
            AirConditioner cond = new AirConditioner("Air Conditioner");
            //Act
            cond.TurnOn();
            cond.SetDryMode();
            //Assert
            Assert.Throws<Exception>(() => cond.DecreaseDegrees());
        }

        [Fact]
        public void DecreaseDegrees_WhenModeIsFan_CannotDecreaseDegrees()
        {
            //Arrange
            AirConditioner cond = new AirConditioner("Air Conditioner");
            //Act
            cond.TurnOn();
            cond.SetFanMode();
            //Assert
            Assert.Throws<Exception>(() => cond.DecreaseDegrees());
        }

        [Fact]
        public void DecreaseDegrees_WhenDegreesAreNotMax_DecraseByHalfDegree()
        {
            //Arrange
            AirConditioner cond = new AirConditioner("Air Conditioner");
            //Act
            cond.TurnOn();
            cond.DecreaseDegrees();
            //Assert
            Assert.Equal(16, cond.Degrees);
        }

        [Fact]
        public void DecreaseDegrees_WhenDegreesAreMinOrGetToMin_SetToMin()
        {
            //Arrange
            AirConditioner cond = new AirConditioner("Air Conditioner");
            //Act
            cond.TurnOn();
            cond.SetDegrees(16);
            cond.DecreaseDegrees();
            //Assert
            Assert.Equal(16.0, cond.Degrees);
        }
    }
}
