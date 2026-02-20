using BlaisePascal.SmartHouse.Application.Devices.LockableDevices.CCTVUses.Dto;
using BlaisePascal.SmartHouse.Application.Devices.LockableDevices.CCTVUses.Mappers;
using BlaisePascal.SmartHouse.Domain.LockableDevices.CctvDevice;
using BlaisePascal.SmartHouse.Domain.LockableDevices.CctvDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.LockableDevices.CCTVUses.Queries
{
    public class GetAllCCTVQuery
    {
        private readonly ICCTVRepsotitory _cctvRepository;

        public GetAllCCTVQuery(ICCTVRepsotitory cctvRepsotitory)
        {
            _cctvRepository = cctvRepsotitory;
        }

        public List<CCTVDto> Execute()
        {
            List<CCTVDto> result = new List<CCTVDto>();

            foreach(CCTV c in _cctvRepository.GetAll())
            {
                result.Add(CCTVMapper.ToDto(c));
            }

            return result;
        }
    }
}
