using BlaisePascal.SmartHouse.Domain.LockableDevices.CctvDevice;
using BlaisePascal.SmartHouse.Domain.LockableDevices.CctvDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.LockableDevices.CCTVUses.Command
{
    public class SetModeCCTVCommand
    {
        private readonly ICCTVRepsotitory _cctvRepository;

        public SetModeCCTVCommand(ICCTVRepsotitory cctvRepsotitory)
        {
            _cctvRepository = cctvRepsotitory;
        }

        public void Execute(Guid id, CCTVMode mode)
        {
            CCTV cctv = _cctvRepository.GetById(id);
            if (cctv != null)
            {
                cctv.SetMode(mode);
                _cctvRepository.Update(cctv);
            }
        }
    }
}
