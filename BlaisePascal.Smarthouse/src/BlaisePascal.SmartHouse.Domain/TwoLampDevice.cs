using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class TwoLampDevice
    {
        //Attributes
        public LampModel Lamp1 { get; private set; }
        public LampModel Lamp2 { get; private set; }

        //Constructor
        public TwoLampDevice(LampModel lamp1, LampModel lamp2)
        {
            Lamp1 = lamp1;
            Lamp2 = lamp2;
        }


        //Methods
        public void SwitchOneLamp(int lamp)
        {
            if(lamp == 1)
            {
                Lamp1.SwitchOnOff();
            }
            else if(lamp == 2)
            {
                Lamp2.SwitchOnOff();
            }
        }

        public void TurnBothOn()
        {
            if (!Lamp1.IsOn)
                Lamp1.SwitchOnOff();
            if (!Lamp2.IsOn)
                Lamp2.SwitchOnOff();
        }

        public void TurnBothOff()
        {
            if (Lamp1.IsOn)
                Lamp1.SwitchOnOff();
            if (Lamp2.IsOn)
                Lamp2.SwitchOnOff();
        }

        public void IncreaseBothBrightness()
        {
            Lamp1.IncreaseBrightness();
            Lamp2.IncreaseBrightness();
        }

        public void DecreaseBothBrightness()
        {
            Lamp1.DecreaseBrightness();
            Lamp2.DecreaseBrightness();
        }

        public void IncreaseOneBrightness(int lamp)
        {
            if (lamp == 1)
            {
                Lamp1.IncreaseBrightness();
            }
            else if (lamp == 2)
            {
                Lamp2.IncreaseBrightness();
            }
        }

        public void DecreaseOneBrightness(int lamp)
        {
            if (lamp == 1)
            {
                Lamp1.DecreaseBrightness();
            }
            else if (lamp == 2)
            {
                Lamp2.DecreaseBrightness();
            }
        }

        public void ChangeOneBrightness(int lamp, int newBrightness)
        {
            if (lamp == 1)
                Lamp1.ChangeBrightness(newBrightness);
            else if (lamp == 2)
                Lamp2.ChangeBrightness(newBrightness);
        }
    }
}
