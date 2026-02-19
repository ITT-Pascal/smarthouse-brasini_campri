using BlaisePascal.SmartHouse.Domain.LuminousDevices.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.LuminousDevices.LampUses.Commands
{
    public class RemoveLampCommand
    {
        private readonly ILampRepository _lampRepository;

        public RemoveLampCommand(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public void Execute(Guid id)
        {
            _lampRepository.Remove(id);
        }
    }
}
