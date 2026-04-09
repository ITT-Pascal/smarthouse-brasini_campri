using BlaisePascal.SmartHouse.Domain.TemperatureDevices.AirConditionerDevice;
using BlaisePascal.SmartHouse.Domain.TemperatureDevices.AirConditionerDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.TermostatDevices.AirConditionerUses.Command
{
    public class IncreaseTemperatureToReachAirConditionerCommand
    {
        private readonly IAirConditionerRepository _repository;

        public IncreaseTemperatureToReachAirConditionerCommand(IAirConditionerRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id)
        {
            AirConditioner cond = _repository.GetById(id);
            if (cond != null)
            {
                cond.IncreaseTemperatureToReach();
                _repository.Update(cond);
            }
        }
    }
}
