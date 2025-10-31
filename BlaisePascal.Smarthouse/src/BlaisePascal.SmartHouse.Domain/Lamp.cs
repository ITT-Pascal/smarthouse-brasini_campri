using System.ComponentModel.DataAnnotations;

namespace BlaisePascal.SmartHouse.Domain
{
    public class Lamp
    {
        const int MinBrightness = 1;
        const int MaxBrightness = 10;

        //Properties
        public bool IsOn { get; private set; }
        public int Brightness { get; private set; }

        //Constructor
        public Lamp()
        {
            IsOn = false;
            Brightness = MaxBrightness;
        }

        //Methods
        public void SwitchOnOff()
        {
            if(IsOn) 
                IsOn = false;
            else
                IsOn = true;
        }

        public void IncreaseBrightness()
        {
            Brightness = Math.Min(Brightness + 1, MaxBrightness);         
        }

        public void DecreaseBrightness()
        {            
            Brightness = Math.Max(Brightness - 1, MinBrightness);
        }

        public void ChangeBrightness(int brightness)
        {
            if(brightness > MinBrightness &&  brightness < MaxBrightness)
            {
                Brightness = brightness;
            } else
            {
                throw new ArgumentOutOfRangeException("Brightness cannot be below 1 or over 10 ");
            }
        }
    }
}