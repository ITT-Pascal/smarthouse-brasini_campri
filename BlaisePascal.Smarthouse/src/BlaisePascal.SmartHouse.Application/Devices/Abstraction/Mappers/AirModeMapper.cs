using BlaisePascal.SmartHouse.Domain.TemperatureDevices.AirConditionerDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Abstraction.Mappers
{
    public class AirModeMapper
    {
        public static string ToDto(AirMode mode)
        {
            return mode switch
            {
                AirMode.NoMode => "NOMODE",
                AirMode.Normal => "NORMAL",
                AirMode.Fan => "FAN",
                AirMode.Dry => "DRY",
                _ => "UNKNOWN"
            };
        }

        public static AirMode ToDomain(string mode)
        {
            return mode switch
            {
                "NOMODE" => AirMode.NoMode,
                "NORMAL" => AirMode.Normal,
                "FAN" => AirMode.Fan,
                "DRY" => AirMode.Dry
            };
        }
    }
}
