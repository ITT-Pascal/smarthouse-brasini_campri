using BlaisePascal.SmartHouse.Domain.LockableDevices.CctvDevice;
using BlaisePascal.SmartHouse.Domain.LockableDevices.CctvDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.LockableDevices.CCTVUses.Queries
{
    public class GetCCTVByIdQuery
    {
        private readonly ICCTVRepsotitory _cctvRepository;

        public GetCCTVByIdQuery(ICCTVRepsotitory cctvRepository)
        {
            _cctvRepository = cctvRepository;
        }

        public CCTV Execute(Guid id)
        {
            return _cctvRepository.GetById(id);
        }
    }
}
