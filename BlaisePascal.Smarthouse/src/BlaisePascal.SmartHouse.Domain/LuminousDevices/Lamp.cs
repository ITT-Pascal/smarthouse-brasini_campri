using System.ComponentModel.DataAnnotations;

namespace BlaisePascal.SmartHouse.Domain.LuminousDevices
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
        
        public Lamp(string name): base(name) { }
        

        public Lamp(Guid newID, string name): base(newID, name) { }
        
    }
}