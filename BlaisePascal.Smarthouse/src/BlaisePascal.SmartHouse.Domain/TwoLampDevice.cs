using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class TwoLampDevice
    {
        //Properties
        public LampModel Lamp1 { get; private set; }
        public LampModel Lamp2 { get; private set; }

        //Constructor
        public TwoLampDevice(LampModel lamp1, LampModel lamp2)
        {
            Lamp1 = lamp1;
            Lamp2 = lamp2;
        }


        //Methods
        public void SwitchOneLamp(Guid Id)
        {
            if(Lamp1.ID == Id)
            {
                Lamp1.SwitchOnOff();
            }
            else if(Lamp2.ID == Id)
            {
                Lamp2.SwitchOnOff();
            }
        }

        public void SwitchOneLamp(string name)
        {
            if (Lamp1.Name == name)
            {
                Lamp1.SwitchOnOff();
            }
            else if (Lamp2.Name == name)
            {
                Lamp2.SwitchOnOff();
            }
        }

        public void TurnBothOn()
        {
            if (Lamp1.Status == DeviceStatus.Off)
                Lamp1.SwitchOnOff();
            if (Lamp2.Status == DeviceStatus.Off)
                Lamp2.SwitchOnOff();
        }

        public void TurnBothOff()
        {
            if (Lamp1.Status == DeviceStatus.On)
                Lamp1.SwitchOnOff();
            if (Lamp2.Status == DeviceStatus.On)
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

        public void IncreaseOneBrightness(Guid Id)
        {
            if (Lamp1.ID == Id)
            {
                Lamp1.IncreaseBrightness();
            }
            else if (Lamp2.ID == Id)
            {
                Lamp2.IncreaseBrightness();
            }
        }

        public void IncreaseOneBrightness(string name)
        {
            if (Lamp1.Name == name)
            {
                Lamp1.IncreaseBrightness();
            }
            else if (Lamp2.Name == name)
            {
                Lamp2.IncreaseBrightness();
            }
        }

        public void DecreaseOneBrightness(Guid Id)
        {
            if (Lamp1.ID == Id)
            {
                Lamp1.DecreaseBrightness();
            }
            else if (Lamp2.ID == Id)
            {
                Lamp2.DecreaseBrightness();
            }
        }

        public void DecreaseOneBrightness(string name)
        {
            if (Lamp1.Name == name)
            {
                Lamp1.IncreaseBrightness();
            }
            else if (Lamp2.Name == name)
            {
                Lamp2.IncreaseBrightness();
            }
        }

        public void ChangeOneBrightness(Guid Id, int newBrightness)
        {
            if (Lamp1.ID == Id)
                Lamp1.ChangeBrightness(newBrightness);
            else if (Lamp2.ID == Id)
                Lamp2.ChangeBrightness(newBrightness);
        }

        public void ChangeOneBrightness(string name, int newBrightness)
        {
            if (Lamp1.Name == name)
                Lamp1.ChangeBrightness(newBrightness);
            else if (Lamp2.Name == name)
                Lamp2.ChangeBrightness(newBrightness);
        }
    }
}
