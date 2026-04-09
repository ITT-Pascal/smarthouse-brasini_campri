using BlaisePascal.SmartHouse.Domain.TemperatureDevices.AirConditionerDevice;
using BlaisePascal.SmartHouse.Domain.TemperatureDevices.AirConditionerDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.TermostatDevices.AirConditionerUses.Command
{
    public class DecreaseTemperatureToReachAirConditionerCommand
    {
        private readonly IAirConditionerRepository _repository;

        public DecreaseTemperatureToReachAirConditionerCommand(IAirConditionerRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id)
        {
            AirConditioner cond = _repository.GetById(id);
            if (cond != null)
            {
                cond.DecreaseTemperatureToReach();
                _repository.Update(cond);
            }
        }
    }
}
