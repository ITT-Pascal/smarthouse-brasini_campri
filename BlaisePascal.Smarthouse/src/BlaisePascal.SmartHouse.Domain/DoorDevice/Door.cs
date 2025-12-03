using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.DoorDevice
{
    public class Door
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public DoorStatus Status { get; set; }
        public DoorLockingStatus LockingStatus { get; set; }
        public DeviceStatus FunctioningStatus { get; set; }

        public Door()
        {
            Id = Guid.NewGuid();
            Status = DoorStatus.Closed;
            LockingStatus = DoorLockingStatus.Unlocked;
            FunctioningStatus = DeviceStatus.On;
        }

        public Door(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
            Status = DoorStatus.Closed;
            LockingStatus = DoorLockingStatus.Unlocked;
            FunctioningStatus = DeviceStatus.On;
        }

        private void OnValidator()
        {
            if (FunctioningStatus == DeviceStatus.Off)
                throw new Exception("The door is off");
        }
        public void OpenTheDoor()
        {
            OnValidator();
            if (Status == DoorStatus.Closed && LockingStatus == DoorLockingStatus.Unlocked)
                Status = DoorStatus.Open;

            else
                throw new Exception("cannot open the door");

        }

        public void CloseTheDoor()
        {
            OnValidator();
            Status = DoorStatus.Closed;
        }

        public void LockTheDoor()
        {
            OnValidator();
            if (LockingStatus == DoorLockingStatus.Unlocked && Status == DoorStatus.Closed)
            {
                LockingStatus = DoorLockingStatus.Locked;
            }
            else
                throw new Exception("cannot lock the door");
        }

        public void UnlockTheDoor()
        {
            OnValidator();
            if (LockingStatus == DoorLockingStatus.Locked)
                LockingStatus = DoorLockingStatus.Unlocked;
            else
                throw new Exception("cannot unlock the door");
        }

        public void TurnOff()
        {
            if (FunctioningStatus == DeviceStatus.Off)
                throw new Exception("The door is already On");
            FunctioningStatus = DeviceStatus.Off;
            LockingStatus = DoorLockingStatus.Unknown;
        }

        public void TurnOn()
        {
            if (FunctioningStatus == DeviceStatus.On)
                throw new Exception("The door is already On");
            FunctioningStatus = DeviceStatus.On;
            LockingStatus = DoorLockingStatus.Unlocked;
            Status = DoorStatus.Closed;
        }

        public void SetNewName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new Exception("name cannot be empty");
            else if (newName == Name)
            {
                throw new Exception("name cannot be the same as the old one");
            }
            Name = newName;
        }
    }
}