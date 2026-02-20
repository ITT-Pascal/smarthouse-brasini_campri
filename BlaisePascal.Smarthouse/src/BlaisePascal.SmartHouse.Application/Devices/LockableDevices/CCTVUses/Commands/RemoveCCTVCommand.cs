using BlaisePascal.SmartHouse.Domain.LockableDevices.CctvDevice;
using BlaisePascal.SmartHouse.Domain.LockableDevices.CctvDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.LockableDevices.CCTVUses.Commands
{
    public class RemoveCCTVCommand
    {
        private readonly ICCTVRepsotitory _cctvRepository;

        public RemoveCCTVCommand(ICCTVRepsotitory cctvRepository)
        {
            _cctvRepository = cctvRepository;
        }

        public void Execute(Guid id)
        {
            _cctvRepository.Remove(id);
        }
    }
}
