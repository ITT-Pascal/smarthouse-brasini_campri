using BlaisePascal.SmartHouse.Domain.LockableDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.TermostatDevices.AirConditionerUses.Dto
{
    public class AirConditionerDto
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public string Status { get; set; }
        public double Temperature { get; set; }
        public string AirMode { get; set; }
        public string DegreeMode { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime LastModifiedAtUtc { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} \n | Status: {Status} | Temperature: {Temperature} | AirMode: {AirMode} | DegreeMode: {DegreeMode} | Created At: {CreatedAtUtc} | Modified At: {LastModifiedAtUtc} \n";
        }
    }
}
