using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class LampsRowTest
    {
        [Fact]
        public void Constructor_WhenCreateNewLampsRow_ItIsEmpty()
        {
            //Arrange & Act
            LampsRow lampsRow = new LampsRow();
            //Assert
            Assert.Empty(lampsRow.Lamps);
        }

        [Fact]
        public void Constructor_WhenCreateNewLampsRowWith4Lamps_ItHas4NormalLamps()
        {
            //Arrange & Act
            LampsRow lampsrow = new LampsRow(4);
            //Assert
            Assert.Equal(4, lampsrow.Lamps.Count);
        }

        [Fact]
        public void AddLamp_WhenANewEcoLampIsAdded_ItIsAddedInTheFirstFreePosition()
        {
            //Arrange
            LampsRow lampsrow = new LampsRow();
            //Act
            lampsrow.AddLamp(new EcoLamp("a"));
            //Assert
            Assert.Equal(1, lampsrow.Lamps.Count);
        }

        [Fact]
        public void SwitchAllOn_AfterTurningAllOn_EveryLampIsOn()
        {
            //Arrange
            LampsRow lampsrow = new LampsRow(5);
            //Act
            lampsrow.SwitchAllOn();
            //Assert
            for (int i = 0; i < lampsrow.Lamps.Count; i++)
            {
                Assert.Equal(DeviceStatus.On, lampsrow.Lamps[i].Status);
            }
        }

        [Fact]
        public void SwitchAllOff_AfterTurningAllOff_EveryLampISOff()
        {
            //Arrange
            LampsRow lampsrow = new LampsRow(5);
            //Act
            lampsrow.SwitchAllOn();
            lampsrow.SwitchAllOff();
            //Assert
            for(int i = 0; i < lampsrow.Lamps.Count; i++)
            {
                Assert.Equal(DeviceStatus.Off, lampsrow.Lamps[i].Status);
            }
        }

        [Fact]
        public void SwitchOneLampOnOff_WhenChosenLampIsOff_ItTurnsOn()
        {
            //Arrange
            LampsRow lampsrow = new LampsRow(5);
            //Act
            lampsrow.ToggleOneLamp(lampsrow.Lamps[2].ID);
            //Assert
            Assert.Equal(DeviceStatus.On, lampsrow.Lamps[2].Status);
        }

        [Fact]
        public void SwitchOneLampOnOff_WhenChosenLampIsOn_ItTurnsOff()
        {
            //Arrange
            LampsRow lampsrow = new LampsRow(5);
            //Act
            lampsrow.SwitchAllOn();
            lampsrow.ToggleOneLamp(lampsrow.Lamps[2].ID);
            //Assert
            Assert.Equal(DeviceStatus.Off, lampsrow.Lamps[2].Status);
        }

        [Fact]
        public void IncreaseAllBrightness_WhenAllBrightnessAreNotTheMax_TheyIncreaseByOne()
        {
            //Arrange
            LampsRow lampsrow = new LampsRow(5);
            //Act
            lampsrow.DecreaseeAllBrightness();
            lampsrow.DecreaseeAllBrightness();
            lampsrow.IncreaseAllBrightness();
            //Assert
            for(int i = 0; i < lampsrow.Lamps.Count; i++)
            {
                Assert.Equal(9, lampsrow.Lamps[i].Brightness);
            }
        }

        [Fact]
        public void IncreaseAllBrightness_WhenAllBrightnessAreMax_TheyDoNotIncrease()
        {
            //Arrange
            LampsRow lampsrow = new LampsRow(5);
            //Act
            lampsrow.IncreaseAllBrightness();
            //Assert
            for(int i = 0; i < lampsrow.Lamps.Count; i++)
            {
                Assert.Equal(10, lampsrow.Lamps[i].Brightness);
            }
        }

        [Fact]
        public void IncreaseAllBrightness_WhenLastLampBrightnessIsTheOnlyOneNotMax_OnlyLastLampIncreases()
        {
            //Arrange
            LampsRow lampsrow = new LampsRow(5);
            //Act
            lampsrow.ChangeOneLampBrightness(lampsrow.Lamps[4].ID, 8);
            lampsrow.IncreaseAllBrightness();
            //Assert
            for(int i = 0; i < lampsrow.Lamps.Count - 1; i++)
            {
                Assert.Equal(10, lampsrow.Lamps[i].Brightness);
            }
            Assert.Equal(9, lampsrow.Lamps[4].Brightness);
        }

        [Fact]
        public void DecreaseAllBrightness_WhenAllLampsBrightnessAreNotMin_TheyAllDecrease()
        {
            //Arrange
            LampsRow lampsrow = new LampsRow(5);
            //Act
            lampsrow.DecreaseeAllBrightness();
            //Assert
            for (int i = 0; i < lampsrow.Lamps.Count; i++)
            {
                Assert.Equal(9, lampsrow.Lamps[i].Brightness);
            }
        }

        [Fact]
        public void DecreaseAllBrightness_WhenAllBrightnessAreMin_TheyDoNotDecrease()
        {
            //Arrange
            LampsRow lampsrow = new LampsRow(5);
            //Act
            for(int i = 0; i < 11; i++)
            {
                lampsrow.DecreaseeAllBrightness();
            }
            //Assert
            for (int i = 0; i < lampsrow.Lamps.Count; i++)
            {
                Assert.Equal(1, lampsrow.Lamps[i].Brightness);
            }
        }

        [Fact]
        public void DecreaseAllBrightness_WhenLastLampBrightnessIsTheOnlyOneNotMin_OnlyLastLampDecreases()
        {
            //Arrange
            LampsRow lampsrow = new LampsRow(5);
            //Act
            for (int i = 0; i < 11; i++)
            {
                lampsrow.DecreaseeAllBrightness();
            }
            lampsrow.ChangeOneLampBrightness(lampsrow.Lamps[4].ID, 6);
            lampsrow.DecreaseeAllBrightness();
            //Assert
            for (int i = 0; i < lampsrow.Lamps.Count - 1; i++)
            {
                Assert.Equal(1, lampsrow.Lamps[i].Brightness);
            }
            Assert.Equal(5, lampsrow.Lamps[4].Brightness);
        }

        [Fact]
        public void ChangeOneLampBrightness_WhenChangingOneLampBrightness_OnlyThatLampChanges()
        {
            //Arrange
            LampsRow lampsrow = new LampsRow(5);
            //Act
            lampsrow.ChangeOneLampBrightness(lampsrow.Lamps[4].ID, 3);
            //Assert
            Assert.Equal(3, lampsrow.Lamps[4].Brightness);
            for (int i = 0; i < lampsrow.Lamps.Count - 1; i++)
            {
                Assert.Equal(10, lampsrow.Lamps[i].Brightness);
            }
        }

        [Fact]
        public void ChangeOneLampBrightness_WhenChangingBrightnessToAnIncorrectValue_ThrowsOutOfRangeException()
        {
            //Arrange
            LampsRow lampsrow = new LampsRow(5);
            //Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => lampsrow.ChangeOneLampBrightness(lampsrow.Lamps[0].ID,11));
        }
    }
}
