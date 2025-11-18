using System;
using System.Collections.Generic;
using System.Linq;
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

        //Methods
        public abstract void SwitchOnOff();

        public abstract void IncreaseBrightness();

        public abstract void DecreaseBrightness();

        public abstract void ChangeBrightness(int brightness);


    }
}
