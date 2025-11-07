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
            lampsrow.AddLamp(new EcoLamp());
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
                Assert.True(lampsrow.Lamps[i].IsOn);
            }
        }
    }
}
