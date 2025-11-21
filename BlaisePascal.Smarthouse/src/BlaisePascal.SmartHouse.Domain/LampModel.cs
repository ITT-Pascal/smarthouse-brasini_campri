using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public abstract class LampModel
    {
        //Properties
        public DeviceStatus Status { get; protected set; } = DeviceStatus.Unkwnown;
        public int Brightness { get; protected set; }
        public Guid ID { get; protected set; }
        public string Name { get; protected set; }
        public DateTime CreatedAtUtc { get; protected set; }
        public DateTime LastModifiedAtUtc { get; protected set; }

        public abstract int MaxBrightness { get; }
        public abstract int MinBrightness { get; }


        //Methods
        public void Toggle()
        {
            if (Status == DeviceStatus.Off)
                Status = DeviceStatus.On;
            else if (Status == DeviceStatus.On)
                Status = DeviceStatus.Off;
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        public void SwitchOn()
        {
            if (Status == DeviceStatus.On)
                throw new Exception("The Lamp is already on");
            Status = DeviceStatus.On;
        }

        public void SwitchOff()
        {
            if (Status == DeviceStatus.Off)
                throw new Exception("The lamp is already off");
            Status = DeviceStatus.Off;
        }

        public void IncreaseBrightness()
        {
            if (Status == DeviceStatus.Off)
                throw new Exception("Cannot increase brightness: the lamp is off");
            Brightness = Math.Min(Brightness + 1, MaxBrightness);
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        public  void DecreaseBrightness()
        {
            if (Status == DeviceStatus.Off)
                throw new Exception("Cannot decrease brightness: the lamp is off");
            Brightness = Math.Max(Brightness - 1, MinBrightness);
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        public void ChangeBrightness(int brightness)
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
