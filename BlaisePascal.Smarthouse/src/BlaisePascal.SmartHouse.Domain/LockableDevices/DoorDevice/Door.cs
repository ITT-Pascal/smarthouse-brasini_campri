using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Device;

namespace BlaisePascal.SmartHouse.Domain.LockableDevices.DoorDevice
{
    public class Door:AbstractDevice, IOpenable, ILockable
    {
        public DoorStatus DoorStatus { get;private set; }
        public LockingStatus LockingStatus { get;private set; }
        public Password Password { get;private set; }
        private bool PasswordSetted => Password != null && !string.IsNullOrWhiteSpace(Password.Key);



        public Door(string name):base(name)
        {
            DoorStatus = DoorStatus.Closed;
            LockingStatus = LockingStatus.Unlocked;
            Status = DeviceStatus.On;
        }

        public Door(Guid Id, string name): base(Id, name)
        {
            DoorStatus = DoorStatus.Closed;
            LockingStatus = LockingStatus.Unlocked;
            Status = DeviceStatus.On;
        }

        public void Open()
        {
            OnValidator();
            if (DoorStatus == DoorStatus.Closed && LockingStatus == LockingStatus.Unlocked)
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

        public void Lock(string key)
        {
            OnValidator();

            bool noPassword = !PasswordSetted;
            bool correctPassword = PasswordSetted && Password.Key == key;

            if (LockingStatus == LockingStatus.Unlocked &&
                DoorStatus == DoorStatus.Closed &&
                (noPassword || correctPassword))
            {
                LockingStatus = LockingStatus.Locked;
            }
            else
            {
                throw new Exception("cannot lock the door");
            }

            LastModifiedAtUtc = DateTime.Now;
        }


        public void Unlock(string key)
        {
            OnValidator();

            bool noPassword = !PasswordSetted;
            bool correctPassword = PasswordSetted && Password.Key == key;

            if (LockingStatus == LockingStatus.Locked &&
                (noPassword || correctPassword))
            {
                LockingStatus = LockingStatus.Unlocked;
            }
            else
            {
                throw new Exception("cannot unlock the door");
            }

            LastModifiedAtUtc = DateTime.Now;
        }


        public void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password cannot be empty or whitespace");
            Password = Password.Create(password);
            LastModifiedAtUtc = DateTime.UtcNow;
        }


    }
}