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
        public BrightnessRecord Brightness { get; protected set; }
       
        //Constructor
        protected LampModel(string name):base(name)
        {
            Brightness = new BrightnessRecord(BrightnessRecord.Min);
        }
        protected LampModel(Guid Id, string name): base(Id, name)
        {
            Brightness = new BrightnessRecord(BrightnessRecord.Min);
        }

        //Methods
        public virtual void IncreaseBrightness()
        {
            if (Status == DeviceStatus.Off)
                throw new Exception("Cannot increase brightness: the lamp is off");
            int newValue = Brightness.Value + 1;
            Brightness = new BrightnessRecord(newValue);
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        public  virtual void DecreaseBrightness()
        {
            if (Status == DeviceStatus.Off)
                throw new Exception("Cannot decrease brightness: the lamp is off");
            int newValue = Brightness.Value - 1;
            Brightness = new BrightnessRecord(newValue);
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        public virtual void ChangeBrightness(int brightness)
        {
            if (Status == DeviceStatus.Off)
                throw new Exception("Cannot change brightness: the lamp is off");
            if (brightness > BrightnessRecord.Min && brightness < BrightnessRecord.Max)
            {
                Brightness = new BrightnessRecord(brightness);
                LastModifiedAtUtc = DateTime.UtcNow;
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Brightness cannot be below {BrightnessRecord.Min} or above {BrightnessRecord.Max}");
            }
        }


    }
}
