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
        public void switchOnOff()
        {
            if(IsOn) 
                IsOn = false;
            else
                IsOn = true;
        }

        public void increaseBrightness()
        {
            Brightness = Math.Min(Brightness ++, MaxBrightness);         
        }

        public void decreaseBirghtness()
        {
            Brightness = Math.Max(Brightness --, MinBrightness);
        }
    }
}