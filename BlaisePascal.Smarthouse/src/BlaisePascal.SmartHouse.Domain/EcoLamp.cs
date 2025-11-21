using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class EcoLamp: LampModel
    {
        //Const
        private const int EcoMax = 5;
        private const int EcoMin = 1;

        //Properties
        public override int MaxBrightness => EcoMax;
        public override int MinBrightness => EcoMin;


        //Constructor
        public EcoLamp(string name )
        {
            Status = DeviceStatus.Off;
            Brightness = MaxBrightness;
            ID = Guid.NewGuid();
            Name = name;
            CreatedAtUtc = DateTime.UtcNow;
        }

        public EcoLamp(Guid newID, string name)
        {
            Status = DeviceStatus.Off;
            Brightness = MaxBrightness;
            ID = newID;
            Name = name;
            CreatedAtUtc = DateTime.UtcNow;
        }

    }
}
