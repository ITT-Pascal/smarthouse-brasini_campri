using BlaisePascal.SmartHouse.Domain.TemperatureDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Abstraction.Mappers
{
    public class DegreeModeMapper
    {
        public static string ToDto(DegreeMode mode)
        {
            return mode switch
            {
                DegreeMode.Fahrenheit => "FAHRENHEIT",
                DegreeMode.Celsius => "CELSIUS"
            };
        }

        public static DegreeMode ToDomain(string mode)
        {
            return mode switch
            {
                "FAHRENHEIT" => DegreeMode.Fahrenheit,
                "CELSIUS" => DegreeMode.Celsius
            };
        }
    }
}
