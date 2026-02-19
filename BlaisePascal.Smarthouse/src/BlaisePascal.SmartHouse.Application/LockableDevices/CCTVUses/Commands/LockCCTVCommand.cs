using BlaisePascal.SmartHouse.Domain.LockableDevices.CctvDevice;
using BlaisePascal.SmartHouse.Domain.LockableDevices.CctvDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.LockableDevices.CCTVUses.Command
{
    public class LockCCTVCommand
    {
        private readonly ICCTVRepsotitory _cctvRepository;

        public LockCCTVCommand(ICCTVRepsotitory cctvRepsotitory)
        {
            _cctvRepository = cctvRepsotitory;
        }

        public void Execute(Guid id, string key)
        {
            CCTV cctv = _cctvRepository.GetById(id);
            if (cctv != null)
            {
                cctv.Lock(key);
                _cctvRepository.Update(cctv);
            }
        }
    }
}
