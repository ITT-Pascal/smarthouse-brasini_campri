using BlaisePascal.SmartHouse.Domain.LockableDevices.CctvDevice;
using BlaisePascal.SmartHouse.Domain.LockableDevices.CctvDevice.Repository;
using BlaisePascal.SmartHouse.Domain.LockableDevices.DoorDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Lockable.CCTVs.InMemory
{
    public class InMemoryCCTVRepository: ICCTVRepository
    {
        private readonly List<CCTV> _cctvs;

        public InMemoryCCTVRepository()
        {
            _cctvs = new List<CCTV>() 
            { 
                new CCTV("CCTV1")
            };
        }

        public List<CCTV> GetAll()
        {
            return _cctvs;
        }

        public CCTV GetById(Guid id)
        {
            return _cctvs.First(c => c.Id == id);
        }

        public void Add(CCTV cctv)
        {
            if (cctv == null)
                throw new ArgumentNullException(nameof(cctv));
            _cctvs.Add(cctv);
        }

        public void Remove(Guid id)
        {
            CCTV cctv = GetById(id);
            if (cctv != null)
                _cctvs.Remove(cctv);
        }

        public void Update(CCTV cctv)
        {
            //To do: implement update logic
        }
    }
}
