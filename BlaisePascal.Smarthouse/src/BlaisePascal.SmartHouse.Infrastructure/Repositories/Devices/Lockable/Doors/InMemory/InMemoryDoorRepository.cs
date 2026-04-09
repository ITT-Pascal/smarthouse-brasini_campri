
using BlaisePascal.SmartHouse.Domain.LockableDevices.DoorDevice;
using BlaisePascal.SmartHouse.Domain.LockableDevices.DoorDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Lockable.Doors.InMemory
{
    public class InMemoryDoorRepository : IDoorRepository
    {
        private readonly List<Door> _doors;
        public InMemoryDoorRepository()
        {
            _doors = new List<Door>()
            {
                new Door("Door1")
            };
        }
        public List<Door> GetAll()
        {
            return _doors;
        }

        public Door GetById(Guid id)
        {
            return _doors.First(l => l.Id == id);
        }

        public void Add(Door door)
        {
            if (door == null)
                throw new ArgumentNullException(nameof(door));
            _doors.Add(door);
        }

        public void Remove(Guid id)
        {
            Door door = GetById(id);
            if (door != null)
                _doors.Remove(door);
        }

        public void Update(Door door)
        {
            //Todo: implement update logic
        }
    }
}
