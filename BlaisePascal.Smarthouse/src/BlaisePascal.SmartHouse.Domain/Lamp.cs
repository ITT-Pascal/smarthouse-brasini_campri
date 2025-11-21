using System.ComponentModel.DataAnnotations;

namespace BlaisePascal.SmartHouse.Domain
{
    public class Lamp: LampModel
    {
        //Const
        private const int LampMax = 10;
        private const int LampMin = 1;

        //Properties
        public override int MinBrightness => LampMin;
        public override int MaxBrightness => LampMax;

        //Constructor
        
        public Lamp(string name)
        {
            Status = DeviceStatus.Off;
            Brightness = MaxBrightness;
            ID = Guid.NewGuid();
            Name = name;
            CreatedAtUtc = DateTime.UtcNow;

        }

        public Lamp(Guid newID, string name)
        {
            Status = DeviceStatus.Off;
            Brightness = MaxBrightness;
            ID = newID;
            Name = name;
            CreatedAtUtc = DateTime.UtcNow;
        }
    }
}