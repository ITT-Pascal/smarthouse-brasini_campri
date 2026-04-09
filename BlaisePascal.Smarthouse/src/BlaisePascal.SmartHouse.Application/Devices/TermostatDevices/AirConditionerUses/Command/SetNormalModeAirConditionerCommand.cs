using BlaisePascal.SmartHouse.Domain.TemperatureDevices.AirConditionerDevice;
using BlaisePascal.SmartHouse.Domain.TemperatureDevices.AirConditionerDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.TermostatDevices.AirConditionerUses.Command
{
    public class SetNormalModeAirConditionerCommand
    {
        private readonly IAirConditionerRepository _repository;

        public SetNormalModeAirConditionerCommand(IAirConditionerRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id)
        {
            AirConditioner cond = _repository.GetById(id);
            if (cond != null)
            {
                cond.SetNormalMode();
                _repository.Update(cond);
            }
        }
    }
}
