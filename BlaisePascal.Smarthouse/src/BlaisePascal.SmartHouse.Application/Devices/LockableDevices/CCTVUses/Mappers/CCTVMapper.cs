using BlaisePascal.SmartHouse.Application.Devices.Abstraction.Mappers;
using BlaisePascal.SmartHouse.Application.Devices.LockableDevices.CCTVUses.Dto;
using BlaisePascal.SmartHouse.Domain.LockableDevices;
using BlaisePascal.SmartHouse.Domain.LockableDevices.CctvDevice;


namespace BlaisePascal.SmartHouse.Application.Devices.LockableDevices.CCTVUses.Mappers
{
    public class CCTVMapper
    {
        public static AirConditionerDto ToDto(CCTV cctv)
        {
            return new AirConditionerDto
            {
                Name = cctv.Name.String,
                Id = cctv.Id,
                Status = DeviceStatusMappers.ToDto(cctv.Status),
                LockingStatus = LockingStatusMapper.ToDto(cctv.LockingStatus),
                Password = cctv.Password?.Key ?? "NoPassword",
                IsRecording = cctv.isRecording,
                Mode = CCTVModeMapper.ToDto(cctv.Mode),
                CreatedAtUtc = cctv.CreatedAtUtc,
                LastModifiedAtUtc = cctv.LastModifiedAtUtc
            };
        }

        public static CCTV ToDomain(AirConditionerDto cctvDto)
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
