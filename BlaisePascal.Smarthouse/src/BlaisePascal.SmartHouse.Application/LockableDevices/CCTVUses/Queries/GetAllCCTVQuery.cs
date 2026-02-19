using BlaisePascal.SmartHouse.Domain.LockableDevices.CctvDevice;
using BlaisePascal.SmartHouse.Domain.LockableDevices.CctvDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.LockableDevices.CCTVUses.Queries
{
    public class GetAllCCTVQuery
    {
        private readonly ICCTVRepsotitory _cctvRepository;

        public GetAllCCTVQuery(ICCTVRepsotitory cctvRepsotitory)
        {
            _cctvRepository = cctvRepsotitory;
        }

        public List<CCTV> Execute()
        {
            return _cctvRepository.GetAll();
        }
    }
}
