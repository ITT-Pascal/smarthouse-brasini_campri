using BlaisePascal.SmartHouse.Application.Devices.Abstraction.Mappers;
using BlaisePascal.SmartHouse.Application.Devices.TermostatDevices.AirConditionerUses.Dto;
using BlaisePascal.SmartHouse.Domain.LockableDevices.CctvDevice;
using BlaisePascal.SmartHouse.Domain.TemperatureDevices.AirConditionerDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.TermostatDevices.AirConditionerUses.Mapper
{
    public class AirConditionerMapper
    {
        public static AirConditionerDto ToDto(AirConditioner cond)
        {
            return new AirConditionerDto
            {
                Name = cond.Name.String,
                Id = cond.Id,
                Status = DeviceStatusMappers.ToDto(cond.Status),
                AirMode = AirModeMapper.ToDto(cond.Mode),
                Temperature = cond.Temperature.Value,
                DegreeMode = DegreeModeMapper.ToDto(cond.DegreeMode),
                CreatedAtUtc = cond.CreatedAtUtc,
                LastModifiedAtUtc = cond.LastModifiedAtUtc
            };
        }

        public static AirConditioner ToDomain(AirConditionerDto dto)
        {
            return new AirConditioner
            (
                dto.Name,
                dto.Id,
                DeviceStatusMappers.ToDomain(dto.Status),
                AirModeMapper.ToDomain(dto.AirMode),
                dto.Temperature,
                DegreeModeMapper.ToDomain(dto.DegreeMode),
                dto.CreatedAtUtc,
                dto.LastModifiedAtUtc
            );
        }
    }
}
