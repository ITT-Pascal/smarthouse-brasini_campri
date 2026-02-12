using BlaisePascal.SmartHouse.Domain.TemperatureDevices.AirConditionerDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.TemperatureDevices.ThermostatDevice.Repository
{
    public interface IThermostatRepository
    {
        void Add(Thermostat thermostat);
        void Update(Thermostat thermostat);
        void Remove(Guid id);
        Thermostat GetById(Guid id);
        List<Thermostat> GetAll();
    }
}
