using BlaisePascal.SmartHouse.Domain.Device;
using BlaisePascal.SmartHouse.Domain.DoorDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.DoorDevice
{
    public class DoorTests
    {
        //TODO debug 4 tests
        [Fact]
        public void Constructor_WhenDoorIsCreated_StatusIsClosedLockingStatusIsUnlockedAndFunctioningStatusIsOn()
        {
            Door door = new Door("Front Door");
            Assert.Equal(DoorStatus.Closed, door.DoorStatus);
            Assert.Equal(DoorLockingStatus.Unlocked, door.LockingStatus);
            Assert.Equal(DeviceStatus.On, door.Status);
        }

        [Fact]
        public void OpenTheDoor_WhenDoorIsClosed_ItChangesStatusToOpen()
        {
            Door door = new Door("Front Door");
            door.OpenTheDoor();
            Assert.Equal(DoorStatus.Open, door.DoorStatus);
        }

        [Fact]
        public void CloseTheDoor_WhenDoorIsOpen_ItChangesStatusToClosed()
        {
            Door door = new Door("Front Door");
            door.OpenTheDoor();
            door.CloseTheDoor();
            Assert.Equal(DoorStatus.Closed, door.DoorStatus);
        }

        [Fact]
        public void LockTheDoor_WhenDoorIsClosed_ItChangesLockingStatusToLocked()
        {
            Door door = new Door("Front Door");
            door.LockTheDoor();
            Assert.Equal(DoorLockingStatus.Locked, door.LockingStatus);
        }

        [Fact]
        public void UnlockTheDoor_WhenDoorIsLocked_ItChangesLockingStatusToUnlocked()
        {
            Door door = new Door("Front Door");
            door.LockTheDoor();
            door.UnlockTheDoor();
            Assert.Equal(DoorLockingStatus.Unlocked, door.LockingStatus);
        }

        [Fact]
        public void OpenTheDoor_WhenDoorIsLocked_ItThrowsException()
        {
            Door door = new Door("Front Door");
            door.LockTheDoor();
            Assert.Throws<Exception>(() => door.OpenTheDoor());
        }

        [Fact]
        public void LockTheDoor_WhenDoorIsOpen_ItThrowsException()
        {
            Door door = new Door("Front Door");
            door.OpenTheDoor();
            Assert.Throws<Exception>(() => door.LockTheDoor());
        }

        [Fact]
        public void UnlockTheDoor_WhenDoorIsUnlocked_ItThrowsException()
        {
            Door door = new Door("Front Door");
            Assert.Throws<Exception>(() => door.UnlockTheDoor());
        }

        [Fact]
        public void OpenTheDoor_WhenDoorIsAlreadyOpen_ItThrowsException()
        {
            Door door = new Door("Front Door");
            door.OpenTheDoor();
            Assert.Throws<Exception>(() => door.OpenTheDoor());
        }

        [Fact]
        public void CloseTheDoor_WhenDoorIsAlreadyClosed_StatusDoesNotChange()
        {
            Door door = new Door("Front Door");
            Assert.Equal(DoorStatus.Closed, door.DoorStatus);
        }

        [Fact]
        public void LockTheDoor_WhenDoorIsAlreadyLocked_ItThrowsException()
        {
            Door door = new Door("Front Door");
            door.LockTheDoor();
            Assert.Throws<Exception>(() => door.LockTheDoor());
        }

        [Fact]
        public void TurnOn_WhenStatusIsOff_ItChangesToOn()
        {
            Door door = new Door("Front Door");
            door.TurnOff();
            door.TurnOn();
            Assert.Equal(DeviceStatus.On, door.Status);
        }

        [Fact]
        public void TurnOff_WhenStatusIsOn_ItChangesToOff()
        {
            Door door = new Door("Front Door");
            door.TurnOff();
            Assert.Equal(DeviceStatus.Off, door.Status);
        }

        [Fact]
        public void TurnOn_WhenStatusIsOn_ThrowAnException()
        {
            Door door = new Door("Front Door");
            Assert.Throws<Exception>(() => door.TurnOn());
        }

        [Fact]
        public void TurnOff_WhenStatusIsOff_StatusDoesNotChange()
        {
            Door door = new Door("Front Door");
            door.TurnOff();
            Assert.Throws<Exception>(() => door.TurnOff());
        }

        [Fact]
        public void SetNewName_WhenCalled_NameIsUpdated()
        {
            Door door = new Door("Front Door");
            door.SetNewName("Back Door");
            Assert.Equal("Back Door", door.Name);
        }

        [Fact]
        public void SetNewName_WhenNewNameIsEmpty_ThrowsException()
        {
            Door door = new Door("Front Door");
            Assert.Throws<Exception>(() => door.SetNewName(""));
        }

        [Fact]
        public void SetNewName_WhenNewNameIsNull_ThrowsException()
        {
            Door door = new Door("Front Door");
            Assert.Throws<Exception>(() => door.SetNewName(null));
        }

        [Fact]
        public void SetNewName_WhenNewNameIsTheSameAsCurrent_NameDoesNotChange()
        {
            Door door = new Door("Front Door");
            Assert.Throws<Exception>(() => door.SetNewName("Front Door"));
        }

    }
}
