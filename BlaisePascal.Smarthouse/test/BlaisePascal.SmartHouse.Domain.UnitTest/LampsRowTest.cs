using BlaisePascal.SmartHouse.Domain.LuminousDevices;
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
            LampsRow lampsrow = new LampsRow();
            for (int i = 0; i < 4; i++)
            {
                Lamp lamp = new Lamp("A");
                lampsrow.AddLamp(lamp);
            }
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
            LampsRow lampsrow = new LampsRow();
            //Act
            for (int i = 0; i < 4; i++)
            {
                Lamp lamp = new Lamp("A");
                lampsrow.AddLamp(lamp);
            }
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
            LampsRow lampsrow = new LampsRow();
            //Act
            for (int i = 0; i < 4; i++)
            {
                Lamp lamp = new Lamp("A");
                lampsrow.AddLamp(lamp);
            }
            lampsrow.SwitchAllOn();
            lampsrow.SwitchAllOff();
            //Assert
            for (int i = 0; i < lampsrow.Lamps.Count; i++)
            {
                Assert.Equal(DeviceStatus.Off, lampsrow.Lamps[i].Status);
            }
        }

        [Fact]
        public void SwitchOneLampOnOff_WhenChosenLampIsOff_ItTurnsOn()
        {
            //Arrange
            LampsRow lampsrow = new LampsRow();
            //Act
            for (int i = 0; i < 4; i++)
            {
                Lamp lamp = new Lamp("A");
                lampsrow.AddLamp(lamp);
            }
            lampsrow.ToggleOneLamp(lampsrow.Lamps[2].Id);
            //Assert
            Assert.Equal(DeviceStatus.On, lampsrow.Lamps[2].Status);
        }

        [Fact]
        public void SwitchOneLampOnOff_WhenChosenLampIsOn_ItTurnsOff()
        {
            //Arrange
            LampsRow lampsrow = new LampsRow();
            //Act
            for (int i = 0; i < 4; i++)
            {
                Lamp lamp = new Lamp("A");
                lampsrow.AddLamp(lamp);
            }
            lampsrow.SwitchAllOn();
            lampsrow.ToggleOneLamp(lampsrow.Lamps[2].Id);
            //Assert
            Assert.Equal(DeviceStatus.Off, lampsrow.Lamps[2].Status);
        }

        [Fact]
        public void IncreaseAllBrightness_WhenAllBrightnessAreNotTheMax_TheyIncreaseByOne()
        {
            //Arrange
            LampsRow lampsrow = new LampsRow();
            //Act
            for (int i = 0; i < 5; i++)
            {
                Lamp lamp = new Lamp("A");
                lampsrow.AddLamp(lamp);
            }
            lampsrow.SwitchAllOn();
            lampsrow.IncreaseAllBrightness();
            //Assert
            for (int i = 0; i < lampsrow.Lamps.Count; i++)
            {
                Assert.Equal(2, lampsrow.Lamps[i].Brightness);
            }
        }

        [Fact]
        public void IncreaseAllBrightness_WhenAllBrightnessAreMax_TheyDoNotIncrease()
        {
            //Arrange
            LampsRow lampsrow = new LampsRow();
            //Act
            for (int i = 0; i < 5; i++)
            {
                Lamp lamp = new Lamp("A");
                lampsrow.AddLamp(lamp);
            }
            lampsrow.SwitchAllOn();
            for (int i = 0; i < 10; i++)
            {
                lampsrow.IncreaseAllBrightness();
            }
            //Assert
            for (int i = 0; i < lampsrow.Lamps.Count; i++)
            {
                Assert.Equal(10, lampsrow.Lamps[i].Brightness);
            }
        }

        [Fact]
        public void IncreaseAllBrightness_WhenLastLampBrightnessIsTheOnlyOneNotMax_OnlyLastLampIncreases()
        {
            //Arrange
            LampsRow lampsrow = new LampsRow();
            //Act
            for (int i = 0; i < 5; i++)
            {
                Lamp lamp = new Lamp("A");
                lampsrow.AddLamp(lamp);
            }
            lampsrow.SwitchAllOn();
            for (int i = 0; i < 10; i++)
            {
                lampsrow.IncreaseAllBrightness();
            }
            lampsrow.ChangeOneLampBrightness(lampsrow.Lamps[4].Id, 8);
            lampsrow.IncreaseAllBrightness();
            //Assert
            for (int i = 0; i < lampsrow.Lamps.Count - 1; i++)
            {
                Assert.Equal(10, lampsrow.Lamps[i].Brightness);
            }
            Assert.Equal(9, lampsrow.Lamps[4].Brightness);
        }

        [Fact]
        public void DecreaseAllBrightness_WhenAllLampsBrightnessAreNotMin_TheyAllDecrease()
        {
            //Arrange
            LampsRow lampsrow = new LampsRow();
            //Act
            for (int i = 0; i < 5; i++)
            {
                Lamp lamp = new Lamp("A");
                lampsrow.AddLamp(lamp);
            }
            lampsrow.SwitchAllOn();
            lampsrow.IncreaseAllBrightness();
            lampsrow.IncreaseAllBrightness();
            lampsrow.DecreaseeAllBrightness();
            //Assert
            for (int i = 0; i < lampsrow.Lamps.Count; i++)
            {
                Assert.Equal(2, lampsrow.Lamps[i].Brightness);
            }
        }

        [Fact]
        public void DecreaseAllBrightness_WhenAllBrightnessAreMin_TheyDoNotDecrease()
        {
            //Arrange
            LampsRow lampsrow = new LampsRow();
            //Act
            for (int i = 0; i < 5; i++)
            {
                Lamp lamp = new Lamp("A");
                lampsrow.AddLamp(lamp);
            }
            lampsrow.SwitchAllOn();
            for (int i = 0; i < 11; i++)
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
            LampsRow lampsrow = new LampsRow();
            //Act
            for (int i = 0; i < 5; i++)
            {
                Lamp lamp = new Lamp("A");
                lampsrow.AddLamp(lamp);
            }
            lampsrow.SwitchAllOn();
            for (int i = 0; i < 11; i++)
            {
                lampsrow.DecreaseeAllBrightness();
            }
            lampsrow.ChangeOneLampBrightness(lampsrow.Lamps[4].Id, 6);
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
            LampsRow lampsrow = new LampsRow();
            //Act
            for (int i = 0; i < 5; i++)
            {
                Lamp lamp = new Lamp("A");
                lampsrow.AddLamp(lamp);
            }
            lampsrow.SwitchAllOn();
            lampsrow.ChangeOneLampBrightness(lampsrow.Lamps[4].Id, 3);
            //Assert
            Assert.Equal(3, lampsrow.Lamps[4].Brightness);
            for (int i = 0; i < lampsrow.Lamps.Count - 1; i++)
            {
                Assert.Equal(1, lampsrow.Lamps[i].Brightness);
            }
        }

        [Fact]
        public void ChangeOneLampBrightness_WhenChangingBrightnessToAnIncorrectValue_ThrowsOutOfRangeException()
        {
            //Arrange
            LampsRow lampsrow = new LampsRow();
            for (int i = 0; i < 4; i++)
            {
                Lamp lamp = new Lamp("A");
                lampsrow.AddLamp(lamp);
            }
            //Act & Assert
            lampsrow.SwitchAllOn();
            Assert.Throws<ArgumentOutOfRangeException>(() => lampsrow.ChangeOneLampBrightness(lampsrow.Lamps[0].Id, 11));
        }

        [Fact]
        public void FindLampWithMaxBrightness_WhenThereAreNoLamps_ReturnNull()
        {
            //Arrange
            LampsRow lampsrow = new LampsRow();
            //Act & Assert
            Assert.Null(lampsrow.FindLampWithMaxBrightness());
        }

        [Fact]
        public void FindLampWithMaxBrightness_BetweenToLampWith5And6_ReturnTheSecondOne()
        {
            //Arrange
            LampsRow lampsrow = new LampsRow();
            //Act
            lampsrow.AddLamp(new Lamp("a"));
            lampsrow.AddLamp(new Lamp("b"));
            lampsrow.SwitchAllOn();
            lampsrow.ChangeOneLampBrightness(lampsrow.Lamps[0].Id, 5);
            lampsrow.ChangeOneLampBrightness(lampsrow.Lamps[1].Id, 6);
            //Assert
            Assert.Equal(lampsrow.Lamps[1], lampsrow.FindLampWithMaxBrightness());
        }

        [Fact]
        public void FindLampWithMinBrightness_WhenThereAreNoLamps_ReturnNull()
        {
            //Arrange
            LampsRow lampsrow = new LampsRow();
            //Act & Assert
            Assert.Null(lampsrow.FindLampWithMinBrightness());
        }

        [Fact]
        public void FindLampWithMinBrightness_BetweenToLampWith4And6_ReturnTheFirstOne()
        {
            //Arrange
            LampsRow lampsrow = new LampsRow();
            //Act
            lampsrow.AddLamp(new EcoLamp("a"));
            lampsrow.AddLamp(new Lamp("b"));
            lampsrow.SwitchAllOn();
            lampsrow.ChangeOneLampBrightness(lampsrow.Lamps[0].Id, 4);
            lampsrow.ChangeOneLampBrightness(lampsrow.Lamps[1].Id, 6);
            //Assert
            Assert.Equal(lampsrow.Lamps[0], lampsrow.FindLampWithMinBrightness());
        }

        [Fact]
        public void FindAllOn_WhenAllLampsAreOn_ReturnTheEntireList()
        {
            //Arrange
            LampsRow lampsrow = new LampsRow();
            //Act
            for (int i = 0; i < 5; i++)
            {
                lampsrow.AddLamp(new Lamp($"{i + 1}"));
            }
            lampsrow.SwitchAllOn();
            //Assert
            Assert.Equal(lampsrow.Lamps, lampsrow.FindAllOn());
        }

        [Fact]
        public void FindAllOn_WhenAllLampsAreOff_ReturnEmptyList()
        {
            //Arrange
            LampsRow lampsrow = new LampsRow();
            //Act
            for (int i = 0; i < 5; i++)
            {
                lampsrow.AddLamp(new Lamp($"{i + 1}"));
            }
            //Assert
            Assert.Equal(new List<LampModel>(), lampsrow.FindAllOn());
        }

        [Fact]
        public void FindAllOn_When3LampsAreOn_ReturnAListOf3Lamps()
        {
            //Arrange
            LampsRow lampsrow = new LampsRow();
            //Act
            for (int i = 0; i < 5; i++)
            {
                lampsrow.AddLamp(new Lamp($"{i + 1}"));
            }

            for (int i = 0; i < 3; i++)
            {
                lampsrow.ToggleOneLamp(lampsrow.Lamps[i].Id);
            }
            //Assert
            Assert.Equal(3, lampsrow.FindAllOn().Count);
        }

        [Fact]
        public void FindAllOff_WhenAllLampsAreOff_ReturnTheEntireList()
        {
            //Arrange
            LampsRow lampsrow = new LampsRow();
            //Act
            for (int i = 0; i < 5; i++)
            {
                lampsrow.AddLamp(new Lamp($"{i + 1}"));
            }
            //Assert
            Assert.Equal(lampsrow.Lamps, lampsrow.FindAllOff());
        }

        [Fact]
        public void FindAllOff_WhenAllLampsAreOn_ReturnEmptyList()
        {
            //Arrange
            LampsRow lampsrow = new LampsRow();
            //Act
            for (int i = 0; i < 5; i++)
            {
                lampsrow.AddLamp(new Lamp($"{i + 1}"));
            }
            lampsrow.SwitchAllOn();
            //Assert
            Assert.Equal(new List<LampModel>(), lampsrow.FindAllOff());
        }

        [Fact]
        public void FindAllOff_When3LampsAreOff_ReturnAListOf3Lamps()
        {
            //Arrange
            LampsRow lampsrow = new LampsRow();
            //Act
            for (int i = 0; i < 5; i++)
            {
                lampsrow.AddLamp(new Lamp($"{i + 1}"));
            }

            for (int i = 0; i < 2; i++)
            {
                lampsrow.ToggleOneLamp(lampsrow.Lamps[i].Id);
            }
            //Assert
            Assert.Equal(3, lampsrow.FindAllOff().Count);
        }

        [Fact]
        public void FindLampById_WhenThereIsNotALampWithTheIdSelected_ReturnNull()
        {
            //Arrange
            LampsRow lampsrow = new LampsRow();
            //Act & Assert
            Assert.Null(lampsrow.FindLampById(Guid.NewGuid()));

        }

        [Fact]
        public void FindLampById_WhenIdIsFound_ReturnTheLampWithTheId()
        {
            //Arrange
            LampsRow lampsrow = new LampsRow();
            //Act
            for (int i = 0; i < 5; i++)
            {
                lampsrow.AddLamp(new Lamp($"{i + 1}"));
            }

            //Assert
            Assert.Equal(lampsrow.Lamps[0], lampsrow.FindLampById(lampsrow.Lamps[0].Id));
        }


        [Fact]
        public void SortByBrightness_WhenThereAre3LampsAndTheSortIsDescending_SortThemStartingFromTheMaxBrightness()
        {
            //Arrange
            LampsRow lampsrow = new LampsRow();
            //Act
            for(int i = 0; i < 3; i++)
            {
                lampsrow.AddLamp(new Lamp($"{i}"));
            }
            lampsrow.SwitchAllOn();
            lampsrow.ChangeOneLampBrightness(lampsrow.Lamps[0].Id, 4);
            lampsrow.ChangeOneLampBrightness(lampsrow.Lamps[1].Id, 2);
            lampsrow.ChangeOneLampBrightness(lampsrow.Lamps[2].Id, 9);
            lampsrow.SortByBrightness(true);
            //Assert
            Assert.Equal(9, lampsrow.Lamps[0].Brightness);
            Assert.Equal(4, lampsrow.Lamps[1].Brightness);
            Assert.Equal(2, lampsrow.Lamps[2].Brightness);
        }

        [Fact]
        public void SortByBrightness_WhenThereAre3LampsAndTheSortIsNotDescending_SortThemStartingFromTheMinBrightness()
        {
            //Arrange
            LampsRow lampsrow = new LampsRow();
            //Act
            for (int i = 0; i < 3; i++)
            {
                lampsrow.AddLamp(new Lamp($"{i}"));
            }
            lampsrow.SwitchAllOn();
            lampsrow.ChangeOneLampBrightness(lampsrow.Lamps[0].Id, 4);
            lampsrow.ChangeOneLampBrightness(lampsrow.Lamps[1].Id, 2);
            lampsrow.ChangeOneLampBrightness(lampsrow.Lamps[2].Id, 9);
            lampsrow.SortByBrightness(false);
            //Assert
            Assert.Equal(2, lampsrow.Lamps[0].Brightness);
            Assert.Equal(4, lampsrow.Lamps[1].Brightness);
            Assert.Equal(9, lampsrow.Lamps[2].Brightness);
        }
    }
}




