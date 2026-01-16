using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Device;

namespace BlaisePascal.SmartHouse.Domain.DoorDevice
{
    public class Door:AbstractDevice, IOpenable, ILockable
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

        public void Open()
        {
            OnValidator();
            if (DoorStatus == DoorStatus.Closed && LockingStatus == DoorLockingStatus.Unlocked)
                DoorStatus = DoorStatus.Open;

            else
                throw new Exception("cannot open the door");
            LastModifiedAtUtc = DateTime.Now;

        }

        public void Close()
        {
            OnValidator();
            DoorStatus = DoorStatus.Closed;
            LastModifiedAtUtc = DateTime.Now;
        }

        public void Lock()
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

        public void Unlock()
        {
            OnValidator();
            if (LockingStatus == DoorLockingStatus.Locked)
                LockingStatus = DoorLockingStatus.Unlocked;
            else
                throw new Exception("cannot unlock the door");
            LastModifiedAtUtc = DateTime.Now;
        }

        
    }
}