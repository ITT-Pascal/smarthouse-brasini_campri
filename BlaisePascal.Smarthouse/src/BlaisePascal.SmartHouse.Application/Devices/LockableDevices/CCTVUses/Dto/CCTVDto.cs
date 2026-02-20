using BlaisePascal.SmartHouse.Domain.LockableDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.LockableDevices.CCTVUses.Dto
{
    public class CCTVDto
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public string Status { get; set; }
        public string Mode { get; set; }
        public string LockingStatus { get; set; }
        public bool IsRecording { get; set; }
        public string Password { get; set; }
        public bool PasswordSetted => !string.IsNullOrWhiteSpace(Password);
        public DateTime CreatedAtUtc { get; set; }
        public DateTime LastModifiedAtUtc { get; set; }
    }
}
