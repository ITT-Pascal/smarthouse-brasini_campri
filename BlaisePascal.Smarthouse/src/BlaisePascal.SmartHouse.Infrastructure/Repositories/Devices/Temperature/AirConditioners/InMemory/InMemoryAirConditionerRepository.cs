using BlaisePascal.SmartHouse.Domain.LockableDevices.CctvDevice;
using BlaisePascal.SmartHouse.Domain.TemperatureDevices.AirConditionerDevice;
using BlaisePascal.SmartHouse.Domain.TemperatureDevices.AirConditionerDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Temperature.AirConditioners.InMemory
{
    public class InMemoryAirConditionerRepository: IAirConditionerRepository
    {
        private readonly List<AirConditioner> _airConditioners;

        public InMemoryAirConditionerRepository()
        {
            _airConditioners = new List<AirConditioner>()
            {
                new AirConditioner("AirCond1")
            };
        }

        public void Add(AirConditioner airConditioner)
        {
            if (airConditioner == null)
                throw new ArgumentNullException(nameof(airConditioner));
            _airConditioners.Add(airConditioner);
        }

        public void Update(AirConditioner airConditioner)
        {
            //TO DO: implement logic
        }

        public void Remove(Guid id)
        {
            AirConditioner airConditioner = GetById(id);
            if (airConditioner != null)
                _airConditioners.Remove(airConditioner);
        }

        public AirConditioner GetById(Guid id)
        {
            return _airConditioners.First(c => c.Id == id);
        }

        public List<AirConditioner> GetAll()
        {
            return _airConditioners;
        }
    }
}
