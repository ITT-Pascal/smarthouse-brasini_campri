using BlaisePascal.SmartHouse.Domain.TemperatureDevices.AirConditionerDevice;
using BlaisePascal.SmartHouse.Domain.TemperatureDevices.AirConditionerDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.TermostatDevices.AirConditionerUses.Command
{
    public class SetTemperatureToReachAirConditionerCommand
    {
        private readonly IAirConditionerRepository _repository;

        public SetTemperatureToReachAirConditionerCommand(IAirConditionerRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id, double temp)
        {
            AirConditioner cond = _repository.GetById(id);
            if (cond != null)
            {
                cond.SetTemperatureToReach(temp);
                _repository.Update(cond);
            }
        }
    }
}
