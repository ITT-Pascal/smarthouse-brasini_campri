using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.TemperatureDevices
{
    public interface ITemperatureDevices
    {
        void SetTemperatureToReach(double temperature);
        void IncreaseTemperatureToReach();
        void DecreaseTemperatureToReach();
        void SetFahrenheitMode();
        void SetCelsiusMode();
    }
}
