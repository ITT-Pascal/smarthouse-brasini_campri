using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.TemperatureDevices
{
    public static class DegreeConverter
    {
        public static double Converter(DegreeMode mode, double value)
        {
            if (mode == DegreeMode.Celsius)
                value = value * 9 / 5 + 32; 
            else
                value = (value - 32) * 5 / 9;

            return value;
        }
    }
}
