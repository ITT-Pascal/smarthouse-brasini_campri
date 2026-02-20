using BlaisePascal.SmartHouse.Domain.LockableDevices.DoorDevice;
using BlaisePascal.SmartHouse.Domain.LockableDevices.DoorDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.LockableDevices.DoorUses.Queries
{
    public class GetAllDoorQuery
    {
            private readonly IDoorRepository _doorRepository;
    
            public GetAllDoorQuery(IDoorRepository doorRepository)
            {
                _doorRepository = doorRepository;
            }

            public List<Door> Execute()
            {
                return _doorRepository.GetAll();
            }
    }
}
