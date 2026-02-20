using BlaisePascal.SmartHouse.Domain.LockableDevices.CctvDevice;
using BlaisePascal.SmartHouse.Domain.LockableDevices.CctvDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.LockableDevices.CCTVUses.Commands
{
    public class AddCCTVCommand
    {
        private readonly ICCTVRepsotitory _cctvRepository;

        public AddCCTVCommand(ICCTVRepsotitory cctvRepository)
        {
            _cctvRepository = cctvRepository;
        }

        public void Execute(string name)
        {
            _cctvRepository.Add(new CCTV(name));
        }
    }
}
