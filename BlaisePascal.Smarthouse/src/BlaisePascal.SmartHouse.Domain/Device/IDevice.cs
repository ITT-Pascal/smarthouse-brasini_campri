using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Device
{
    public interface IDevice
    {
        void TurnOn();
        void TurnOff();
        void Toggle();
        void OnValidator();
    }
}
