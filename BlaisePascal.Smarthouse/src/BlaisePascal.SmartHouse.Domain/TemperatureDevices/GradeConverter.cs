using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.TemperatureDevices
{
    public static class GradeConverter
    {
        public static double Converter(GradeMode mode, double value)
        {
            if (mode == GradeMode.Celsius)
                value = value * 9 / 5 + 32; 
            else
                value = (value - 32) * 5 / 9;

            return value;
        }
    }
}
