using BlaisePascal.SmartHouse.Domain.LockableDevices.DoorDevice;
using BlaisePascal.SmartHouse.Domain.LockableDevices.DoorDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.LockableDevices.DoorUses.Queries
{
    public class GetDoorByIdQuery
    {
        private readonly IDoorRepository _doorRepository;
        public GetDoorByIdQuery(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }
        public Door Execute(Guid id)
        {
            return _doorRepository.GetById(id);
        }
    }
}
