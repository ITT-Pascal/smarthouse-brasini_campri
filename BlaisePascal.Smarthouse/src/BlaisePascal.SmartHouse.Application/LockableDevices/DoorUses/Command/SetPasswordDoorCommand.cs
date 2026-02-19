using BlaisePascal.SmartHouse.Domain.LockableDevices.DoorDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.LockableDevices.DoorUses.Command
{
    public class SetPassworDoorCommand
    {
        private readonly IDoorRepository _doorRepository;

        public SetPassworDoorCommand(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public void Execute(Guid id, string newPassword)
        {
            var door = _doorRepository.GetById(id);
            if (door != null)
            {
                door.SetPassword(newPassword);
                _doorRepository.Update(door);
            }
        }
    }
}
