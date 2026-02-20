using BlaisePascal.SmartHouse.Domain.LockableDevices.CctvDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Abstraction.Mappers
{
    public class CCTVModeMapper
    {
        public static string ToDto(CCTVMode mode)
        {
            return mode switch
            {
                CCTVMode.NoMode => "NOMODE",
                CCTVMode.Night => "NIGHT",
                CCTVMode.Normal => "NORMAL"
            };
        }

        public static CCTVMode ToDomain(string mode)
        {
            return mode switch
            {
                "NOMODE" => CCTVMode.NoMode,
                "NIGHT" => CCTVMode.Night,
                "NORMAL" => CCTVMode.Normal,
            };
        }
    }
}
