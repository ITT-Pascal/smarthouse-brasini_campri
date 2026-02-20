using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.LampUses.Dto
{
    public class LampDto
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public int Brightness { get; set; }
        public Guid Id { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime LastModifiedAtUtc { get; set; }
    }
}
