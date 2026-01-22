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
    public class MatrixLedTests
    {
        [Fact]
        public void TurnAllOn_AllLightsAreOn()
        {
            //Arrange
            MatrixLed led = new MatrixLed(5, 5);
            //Act
            led.TurnAllOn();
            //Assert
            for(int r=0; r<led.Rows; r++)
            {
                for(int c = 0; c<led.Columns; c++)
                {
                    Assert.Equal(DeviceStatus.On, led.Matrix[r, c].Status);
                }
            }
        }
        [Fact]
        public void TurnAllOff_AllLightsAreOff()
        {
            //Arrange
            MatrixLed led = new MatrixLed(5, 5);
            //Act
            led.TurnAllOn();
            led.TurnAllOff();
            //Assert
            for (int r = 0; r < led.Rows; r++)
            {
                for (int c = 0; c < led.Columns; c++)
                {
                    Assert.Equal(DeviceStatus.Off, led.Matrix[r, c].Status);
                }
            }
        }
        [Fact]
        public void TurnRawOn_TheRawSelectedTurnsOn()
        {
            //Arrange
            MatrixLed led = new MatrixLed(5, 5);
            //Act
            led.TurnRowOn(2);
            //Assert
            for (int c = 0; c < led.Columns; c++)
            {
                Assert.Equal(DeviceStatus.On, led.Matrix[2,c].Status);
            }
            Assert.Equal(DeviceStatus.Off, led.Matrix[0, 0].Status);
        }
        [Fact]
        public void TurnRawOff_TheRawSelectedTurnsOff()
        {
            //Arrange
            MatrixLed led = new MatrixLed(5, 5);
            //Act
            led.TurnAllOn();
            led.TurnRowOff(2);
            //Assert
            for (int c = 0; c < led.Columns; c++)
            {
                Assert.Equal(DeviceStatus.Off, led.Matrix[2, c].Status);
            }
            Assert.Equal(DeviceStatus.On, led.Matrix[0, 0].Status);
        }
        [Fact]
        public void TurnColumnOn_TheColumnSelectedTurnsOn()
        {
            //Arrange
            MatrixLed led = new MatrixLed(5, 5);
            //Act
            led.TurnColumnOn(2);
            //Assert
            for (int r = 0; r < led.Rows; r++)
            {
                Assert.Equal(DeviceStatus.On, led.Matrix[r,2].Status);
            }
            Assert.Equal(DeviceStatus.Off, led.Matrix[0, 0].Status);
        }
        [Fact]
        public void TurnColumnOff_TheColumnSelectedTurnsOff()
        {
            //Arrange
            MatrixLed led = new MatrixLed(5, 5);
            //Act
            led.TurnAllOn();
            led.TurnColumnOff(2);
            //Assert
            for (int r = 0; r < led.Rows; r++)
            {
                Assert.Equal(DeviceStatus.Off, led.Matrix[r, 2].Status);
            }
            Assert.Equal(DeviceStatus.On, led.Matrix[0, 0].Status);
        }
        [Fact]
        public void IncreaseAllBrightess_AllBrightnessUpBy1()
        {
            //Arrange
            MatrixLed led = new MatrixLed(2,2);
            //Act
            led.TurnAllOn();
            led.IncreaseAllBrightness();
            //Assert
            for (int r = 0; r < led.Rows; r++)
            {
                for (int c = 0; c < led.Columns; c++)
                {
                    Assert.Equal(new BrightnessRecord(2), led.Matrix[r, c].Brightness);
                }
            }
        }
        [Fact]
        public void DecreaseAllBrightess_AllBrightnessDownBy1()
        {
            //Arrange
            MatrixLed led = new MatrixLed(2, 2);
            //Act
            led.TurnAllOn();
            led.IncreaseAllBrightness();
            led.DecreaseAllBrightness();
            //Assert
            for (int r = 0; r < led.Rows; r++)
            {
                for (int c = 0; c < led.Columns; c++)
                {
                    Assert.Equal(new BrightnessRecord(1), led.Matrix[r, c].Brightness);
                }
            }
        }
    }
}
