using BlaisePascal.SmartHouse.Application.Devices.Abstraction.Mappers;
using BlaisePascal.SmartHouse.Application.Devices.LockableDevices.CCTVUses.Dto;
using BlaisePascal.SmartHouse.Domain.LockableDevices;
using BlaisePascal.SmartHouse.Domain.LockableDevices.CctvDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.LockableDevices.CCTVUses.Mappers
{
    public class CCTVMapper
    {
        public static CCTVDto ToDto(CCTV cctv)
        {
            return new CCTVDto
            {
                Name = cctv.Name.String,
                Id = cctv.Id,
                Status = DeviceStatusMappers.ToDto(cctv.Status),
                LockingStatus = LockingStatusMapper.ToDto(cctv.LockingStatus),
                Password = cctv.Password.Key,
                IsRecording = cctv.isRecording,
                Mode = CCTVModeMapper.ToDto(cctv.Mode),
                CreatedAtUtc = cctv.CreatedAtUtc,
                LastModifiedAtUtc = cctv.LastModifiedAtUtc
            };
        }

        public static CCTV ToDomain(CCTVDto cctvDto)
        {
            return new CCTV
                (
                    cctvDto.Name,
                    cctvDto.Id,
                    DeviceStatusMappers.ToDomain(cctvDto.Status),
                    CCTVModeMapper.ToDomain(cctvDto.Mode),
                    cctvDto.IsRecording,
                    LockingStatusMapper.ToDomain(cctvDto.LockingStatus),
                    cctvDto.Password,
                    cctvDto.CreatedAtUtc,
                    cctvDto.LastModifiedAtUtc
                );
        }
    }
}
