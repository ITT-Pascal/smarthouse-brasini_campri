using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Device;

namespace BlaisePascal.SmartHouse.Domain.DoorDevice
{
    public class Door:AbstractDevice
    {
        public DoorStatus DoorStatus { get;private set; }
        public DoorLockingStatus LockingStatus { get;private set; }
 

        

        public Door(string name):base(name)
        {
            DoorStatus = DoorStatus.Closed;
            LockingStatus = DoorLockingStatus.Unlocked;
            Status = DeviceStatus.On;
        }

        public Door(Guid Id, string name): base(Id, name)
        {
            DoorStatus = DoorStatus.Closed;
            LockingStatus = DoorLockingStatus.Unlocked;
            Status = DeviceStatus.On;
        }

        public void OpenTheDoor()
        {
            OnValidator();
            if (DoorStatus == DoorStatus.Closed && LockingStatus == DoorLockingStatus.Unlocked)
                DoorStatus = DoorStatus.Open;

            else
                throw new Exception("cannot open the door");
            LastModifiedAtUtc = DateTime.Now;

        }

        public void CloseTheDoor()
        {
            OnValidator();
            DoorStatus = DoorStatus.Closed;
            LastModifiedAtUtc = DateTime.Now;
        }

        public void LockTheDoor()
        {
            OnValidator();
            if (LockingStatus == DoorLockingStatus.Unlocked && DoorStatus == DoorStatus.Closed)
            {
                LockingStatus = DoorLockingStatus.Locked;
            }
            else
                throw new Exception("cannot lock the door");
            LastModifiedAtUtc = DateTime.Now;
        }

        public void UnlockTheDoor()
        {
            OnValidator();
            if (LockingStatus == DoorLockingStatus.Locked)
                LockingStatus = DoorLockingStatus.Unlocked;
            else
                throw new Exception("cannot unlock the door");
            LastModifiedAtUtc = DateTime.Now;
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
            LastModifiedAtUtc = DateTime.Now;
        }
    }
}