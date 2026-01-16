using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.LockableDevices.DoorDevice
{
    public interface ILockable
    {
        void Lock(string key);
        void Unlock(string key);
    }
}
