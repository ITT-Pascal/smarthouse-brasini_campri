using BlaisePascal.SmartHouse.Application.Devices.Abstraction.Mappers;
using BlaisePascal.SmartHouse.Application.Devices.LockableDevices.DoorUses.Dto;
using BlaisePascal.SmartHouse.Domain.LockableDevices.DoorDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.LockableDevices.DoorUses.Mapper
{
    public class DoorMapper
    {
        public static DoorDto ToDto(Door door)
        {
            return new DoorDto
            {
                Id = door.Id,
                Name = door.Name.String,
                Status = door.Status.ToString(),
                LockingStatus = door.LockingStatus.ToString(),
                DoorStatus = door.DoorStatus.ToString(),
                Password = door.Password.Key,
                CreatedAtUtc = door.CreatedAtUtc,
                LastModifiedAtUtc = door.LastModifiedAtUtc
            };
        }


        public static Door ToDomain(DoorDto doorDto)
        {
            
            return new Door
            (
                doorDto.Name,
                doorDto.Id,
                DeviceStatusMappers.ToDomain(doorDto.Status),
                LockingStatusMapper.ToDomain(doorDto.LockingStatus),
                DoorStatusMapper.ToDomain(doorDto.DoorStatus),
                doorDto.Password,
                doorDto.CreatedAtUtc,
                doorDto.LastModifiedAtUtc
            );
        }
    }
}

