using BlaisePascal.SmartHouse.Domain.abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlaisePascal.SmartHouse.Domain.Device
{
    public abstract class AbstractDevice : ISwitchable
    {
        public Guid Id { get; protected set; }
        public Name Name { get; protected set; }
        public DeviceStatus Status { get; protected set; }
        public DateTime CreatedAtUtc { get; protected set; }
        public DateTime LastModifiedAtUtc { get; protected set; }

        protected AbstractDevice(string name)
        {
            Id = Guid.NewGuid();
            Name = Name.Create(name);
            Status = DeviceStatus.Off;
            CreatedAtUtc = DateTime.Now;
            LastModifiedAtUtc = DateTime.Now;
        }
        public AbstractDevice(Guid guid, string name)
        {
            CreatedAtUtc = DateTime.UtcNow;
            LastModifiedAtUtc = DateTime.Now;
            Status = DeviceStatus.Off;
            Id = guid;
            Name = Name.Create(name);
        }
        public AbstractDevice() { }

        public AbstractDevice(string name, Guid id, DeviceStatus status, DateTime created, DateTime modified)
        {
            Name = Name.Create(name);
            Id = id;
            Status = status;
            CreatedAtUtc = created;
            LastModifiedAtUtc = modified;
        }

        //Methods
        public void OnValidator()
        {
            if (Status == DeviceStatus.Off)
                throw new Exception("The device is off");
            
        }
        public virtual void Toggle()
        {
            if (Status == DeviceStatus.On)
                TurnOff();
            else
                TurnOn();
            LastModifiedAtUtc = DateTime.Now;
        }
        public virtual void TurnOn()
        {
            if (Status == DeviceStatus.On)
                throw new Exception("The device is already on");

            Status = DeviceStatus.On;
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        public virtual void TurnOff()
        {
            if (Status == DeviceStatus.Off)
                throw new Exception("The device is already on");

            Status = DeviceStatus.Off;
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        public virtual void SetNewName(string newName)
        {
             if (newName == Name.String)
            {
                throw new Exception("name cannot be the same as the old one");
            }
            Name = Name.Create(newName);
            LastModifiedAtUtc = DateTime.Now;
        }
    }
}