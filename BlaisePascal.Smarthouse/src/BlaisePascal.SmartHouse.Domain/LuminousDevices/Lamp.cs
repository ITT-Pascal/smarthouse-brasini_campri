using System.ComponentModel.DataAnnotations;

namespace BlaisePascal.SmartHouse.Domain.LuminousDevices
{
    public class Lamp: LampModel
    {
        //Constructor
        public Lamp(string name): base(name) { }
        
        public Lamp(Guid newID, string name): base(newID, name) { }
        
    }
}