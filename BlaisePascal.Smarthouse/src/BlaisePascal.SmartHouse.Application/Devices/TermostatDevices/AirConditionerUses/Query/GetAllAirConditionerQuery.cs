using BlaisePascal.SmartHouse.Application.Devices.LockableDevices.CCTVUses.Dto;
using BlaisePascal.SmartHouse.Application.Devices.LockableDevices.CCTVUses.Mappers;
using BlaisePascal.SmartHouse.Application.Devices.TermostatDevices.AirConditionerUses.Dto;
using BlaisePascal.SmartHouse.Application.Devices.TermostatDevices.AirConditionerUses.Mapper;
using BlaisePascal.SmartHouse.Domain.LockableDevices.CctvDevice;
using BlaisePascal.SmartHouse.Domain.LockableDevices.CctvDevice.Repository;
using BlaisePascal.SmartHouse.Domain.TemperatureDevices.AirConditionerDevice;
using BlaisePascal.SmartHouse.Domain.TemperatureDevices.AirConditionerDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlaisePascal.SmartHouse.Application.Devices.TermostatDevices.AirConditionerUses.Query
{
    public class GetAllAirConditionerQuery
    {
        private readonly IAirConditionerRepository _repository;

        public GetAllAirConditionerQuery(IAirConditionerRepository repository)
        {
            _repository = repository;
        }

        public List<AirConditionerDto> Execute()
        {
            List<AirConditionerDto> result = new List<Dto.AirConditionerDto>();
            foreach(AirConditioner a in _repository.GetAll())
            {
                if(a != null)
                {
                    result.Add(AirConditionerMapper.ToDto(a));
                }
            }
            return result;
        }
    }
}
