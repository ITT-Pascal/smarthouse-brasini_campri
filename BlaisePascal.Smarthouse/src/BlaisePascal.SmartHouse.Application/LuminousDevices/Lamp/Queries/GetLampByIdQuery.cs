using BlaisePascal.SmartHouse.Domain.LuminousDevices.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.LuminousDevices.Lamp.Queries
{
    public class GetLampByIdQuery
    {
        private readonly ILampRepository _lampRepository;

        public GetLampByIdQuery(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }
    }
}
