using System.ComponentModel.DataAnnotations;

namespace BlaisePascal.SmartHouse.Domain
{
    public class Lamp: LampModel
    {
        const int MinBrightness = 1;
        const int MaxBrightness = 10;

     
       

        //Constructor
        public Lamp()
        {
            IsOn = false;
            Brightness = MaxBrightness;
            ID = Guid.NewGuid();
        }
        public Lamp(string name)
        {
            IsOn = false;
            Brightness = MaxBrightness;
            ID = Guid.NewGuid();
            Name = name;
        }

        public Lamp(Guid newID, string name)
        {
            IsOn = false;
            Brightness = MaxBrightness;
            ID = newID;
            Name = name;
        }

        //Methods
        public override void SwitchOnOff()
        {
            IsOn = !IsOn;
        }

        public override void IncreaseBrightness()
        {
            Brightness = Math.Min(Brightness + 1, MaxBrightness);         
        }

        public override void DecreaseBrightness()
        {            
            Brightness = Math.Max(Brightness - 1, MinBrightness);
        }

        public override void ChangeBrightness(int brightness)
        {
            if(brightness > MinBrightness &&  brightness < MaxBrightness)
            {
                Brightness = brightness;
            } else
            {
                throw new ArgumentOutOfRangeException($"Brightness cannot be below {MinBrightness} or above {MaxBrightness}");
            }
        }
    }
}