using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.abstraction;
using BlaisePascal.SmartHouse.Domain.Device;

namespace BlaisePascal.SmartHouse.Domain.LuminousDevices
{
    public abstract class LampModel: AbstractDevice, ILuminous
    {
        //Properties
        public Brightness Brightness { get; protected set; }
       
        //Constructor
        protected LampModel() { }
        protected LampModel(string name):base(name)
        {
            Brightness = Brightness.Create(Brightness.Min);
        }
        protected LampModel(Guid Id, string name): base(Id, name)
        {
            Brightness = Brightness.Create(Brightness.Min);
        }
        protected LampModel(string name, Guid id, DeviceStatus status, DateTime created, DateTime modified, int brightness): base(name, id, status, created, modified)
        {
            Brightness = Brightness.Create(brightness);
        }

        //Methods
        public virtual void IncreaseBrightness()
        {
            if (Status == DeviceStatus.Off)
                throw new Exception("Cannot increase brightness: the lamp is off");
            int newValue = Brightness.Value + 1;
            Brightness = Brightness.Create(newValue);
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        public  virtual void DecreaseBrightness()
        {
            if (Status == DeviceStatus.Off)
                throw new Exception("Cannot decrease brightness: the lamp is off");
            int newValue = Brightness.Value - 1;
            Brightness = Brightness.Create(newValue);
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        public virtual void ChangeBrightness(int brightness)
        {
            if (Status == DeviceStatus.Off)
                throw new Exception("Cannot change brightness: the lamp is off");
            if (brightness > Brightness.Min && brightness < Brightness.Max)
            {
                Brightness = Brightness.Create(brightness);
                LastModifiedAtUtc = DateTime.UtcNow;
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Brightness cannot be below {Brightness.Min} or above {Brightness.Max}");
            }
        }


    }
}
