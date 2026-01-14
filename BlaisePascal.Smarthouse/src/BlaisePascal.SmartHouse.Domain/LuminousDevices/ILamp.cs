using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.LuminousDevices
{
    public interface ILamp
    {
        void IncreaseBrightness();
        void DecreaseBrightness();
        void ChangeBrightness(int brightness);
    }
}
