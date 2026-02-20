using BlaisePascal.SmartHouse.Application.Devices.Abstraction.Mappers;
using BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.LampUses.Dto;
using BlaisePascal.SmartHouse.Domain.abstraction;
using BlaisePascal.SmartHouse.Domain.LuminousDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.LampUses.Mappers
{
    public class LampMapper
    {
        public static LampDto ToDto(Lamp lamp)
        {
            return new LampDto
            {
                Name = lamp.Name.String,
                Status = DeviceStatusMappers.ToDto(lamp.Status),
                Brightness = lamp.Brightness.Value,
                Id = lamp.Id,
                CreatedAtUtc = lamp.CreatedAtUtc,
                LastModifiedAtUtc = lamp.LastModifiedAtUtc
            };
        }

        public static Lamp ToDomain(LampDto lampDto)
        {
            return new Lamp
                (
                    lampDto.Name,
                    lampDto.Id,
                    DeviceStatusMappers.ToDomain(lampDto.Status),
                    lampDto.CreatedAtUtc,
                    lampDto.LastModifiedAtUtc,
                    lampDto.Brightness
                );
        }
    }
}
