using BlaisePascal.SmartHouse.Application.Devices.TermostatDevices.AirConditionerUses.Dto;
using BlaisePascal.SmartHouse.Application.Devices.TermostatDevices.AirConditionerUses.Mapper;
using BlaisePascal.SmartHouse.Domain.TemperatureDevices.AirConditionerDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.TermostatDevices.AirConditionerUses.Query
{
    public class GetAirConditionerById
    {
        private readonly IAirConditionerRepository _repository;

        public GetAirConditionerById(IAirConditionerRepository repository)
        {
            _repository = repository;
        }

        public AirConditionerDto Execute(Guid id)
        {
            return AirConditionerMapper.ToDto(_repository.GetById(id));
        }
    }
}
