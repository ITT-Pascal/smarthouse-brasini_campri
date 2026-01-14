using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Device;

namespace BlaisePascal.SmartHouse.Domain.LuminousDevices
{
    public abstract class LampModel: AbstractDevice, ILamp
    {
        //Properties
        public int Brightness { get; protected set; }
        
        public abstract int MaxBrightness { get; }
        public abstract int MinBrightness { get; }

        //Constructor
        protected LampModel(string name):base(name)
        {
            Brightness = MinBrightness; 
        }
        protected LampModel(Guid Id, string name): base(Id, name)
        {
            Brightness = MinBrightness;
        }



        //Methods

        public virtual void IncreaseBrightness()
        {
            if (Status == DeviceStatus.Off)
                throw new Exception("Cannot increase brightness: the lamp is off");
            Brightness = Math.Min(Brightness + 1, MaxBrightness);
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        public  virtual void DecreaseBrightness()
        {
            if (Status == DeviceStatus.Off)
                throw new Exception("Cannot decrease brightness: the lamp is off");
            Brightness = Math.Max(Brightness - 1, MinBrightness);
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        public virtual void ChangeBrightness(int brightness)
        {
            if (Status == DeviceStatus.Off)
                throw new Exception("Cannot change brightness: the lamp is off");
            if (brightness > MinBrightness && brightness < MaxBrightness)
            {
                Brightness = brightness;
                LastModifiedAtUtc = DateTime.UtcNow;
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Brightness cannot be below {MinBrightness} or above {MaxBrightness}");
            }
        }


    }
}
