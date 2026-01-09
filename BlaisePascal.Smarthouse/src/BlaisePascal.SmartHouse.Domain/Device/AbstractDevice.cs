using BlaisePascal.SmartHouse.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Device
{
    public abstract class AbstractDevice : IDevice
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public DeviceStatus Status { get; protected set; }
        public DateTime CreatedAtUtc { get; protected set; }
        public DateTime LastModifiedAtUtc { get; protected set; }

        protected AbstractDevice(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
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
            Name = name;
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
    }
}

