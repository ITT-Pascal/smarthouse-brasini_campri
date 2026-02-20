using BlaisePascal.SmartHouse.Domain.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Abstraction.Mappers
{
    public class DeviceStatusMappers
    {
        public static string ToDto(DeviceStatus status)
        {
            return status switch
            {
                DeviceStatus.On => "ON",
                DeviceStatus.Off => "OFF",
                DeviceStatus.StandBy => "STANDBY",
                DeviceStatus.Error => "ERROR",
                _ => "UNKNOWN"
            };
        }

        public static DeviceStatus ToDomain(string status)
        {
            return status switch
            {
                "ON" => DeviceStatus.On,
                "OFF" => DeviceStatus.Off,
                "STANDBY" => DeviceStatus.StandBy,
                "ERROR" => DeviceStatus.Error,
                _ => DeviceStatus.Unkwnown
            };
        }
    }
}
