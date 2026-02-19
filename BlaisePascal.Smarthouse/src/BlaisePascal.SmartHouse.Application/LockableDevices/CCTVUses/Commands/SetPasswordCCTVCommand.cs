using BlaisePascal.SmartHouse.Domain.LockableDevices.CctvDevice;
using BlaisePascal.SmartHouse.Domain.LockableDevices.CctvDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.LockableDevices.CCTVUses.Command
{
    public class SetPasswordCCTVCommand
    {
        private readonly ICCTVRepsotitory _cctvRepository;

        public SetPasswordCCTVCommand(ICCTVRepsotitory cctvRepsotitory)
        {
            _cctvRepository = cctvRepsotitory;
        }

        public void Execute(Guid id, string password)
        {
            CCTV cctv = _cctvRepository.GetById(id);
            if (cctv != null)
            {
                cctv.SetPassword(password);
                _cctvRepository.Update(cctv);
            }
        }
    }
}
