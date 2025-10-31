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
        Lamp lamp1;
        Lamp lamp2;

        //Constructor
        public TwoLampDevice()
        {
            lamp1 = new Lamp();
            lamp2 = new Lamp();
        }

        //Methods
        public void SwitchOneLamp(int lamp)
        {
            if(lamp == 1)
            {
                lamp1.SwitchOnOff();
            }
            else if(lamp == 2)
            {
                lamp2.SwitchOnOff();
            }
        }

        public void TurnBothOn()
        {
            if (!lamp1.IsOn)
                lamp1.SwitchOnOff();
            if (!lamp2.IsOn)
                lamp2.SwitchOnOff();
        }

        public void TurnBothOff()
        {
            if (lamp1.IsOn)
                lamp1.SwitchOnOff();
            if (lamp2.IsOn)
                lamp2.SwitchOnOff();
        }

        public void IncreaseBothBrightness()
        {
            lamp1.IncreaseBrightness();
            lamp2.IncreaseBrightness();
        }

        public void DecreaseBothBrightness()
        {
            lamp1.DecreaseBrightness();
            lamp2.DecreaseBrightness();
        }

        public void IncreaseOneBrightness(int lamp)
        {
            if (lamp == 1)
            {
                lamp1.IncreaseBrightness();
            }
            else if (lamp == 2)
            {
                lamp2.IncreaseBrightness();
            }
        }

        public void DecreaseOneBrightness(int lamp)
        {
            if (lamp == 1)
            {
                lamp1.DecreaseBrightness();
            }
            else if (lamp == 2)
            {
                lamp2.DecreaseBrightness();
            }
        }

        public void ChangeOneBrightness(int lamp, int newBrightness)
        {
            if (lamp == 1)
                lamp1.ChangeBrightness(newBrightness);
            else if (lamp == 2)
                lamp2.ChangeBrightness(newBrightness);
        }
    }
}
