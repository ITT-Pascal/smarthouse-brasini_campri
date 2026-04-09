using BlaisePascal.SmartHouse.Domain.LuminousDevices.Repository;
using BlaisePascal.SmartHouse.Domain.LuminousDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.LampUses.Dto;
using BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.LampUses.Mappers;

namespace BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.LampUses.Queries
{
    public class GetLampByIdQuery
    {
        private readonly ILampRepository _lampRepository;

        public GetLampByIdQuery(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public LampDto Execute(Guid id)
        {
            return LampMapper.ToDto(_lampRepository.GetById(id));
        }
    }
}
