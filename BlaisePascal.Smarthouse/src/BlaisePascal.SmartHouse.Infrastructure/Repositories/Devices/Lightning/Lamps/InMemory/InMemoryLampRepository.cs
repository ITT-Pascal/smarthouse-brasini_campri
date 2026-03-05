using BlaisePascal.SmartHouse.Domain.LuminousDevices;
using BlaisePascal.SmartHouse.Domain.LuminousDevices.Repository;

namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Lightning.Lamps.InMemory
{
    public class InMemoryLampRepository: ILampRepository
    {
        private readonly List<Lamp> _lamps;
        public InMemoryLampRepository()
        {
            _lamps = new List<Lamp>()
            {
                new Lamp("Lamp1"),
                new Lamp("Lamp2"),
                new Lamp("Lamp3")
            };
        }
        public List<Lamp> GetAll()
        {
            return _lamps;
        }

        public Lamp GetById(Guid id)
        {
            return _lamps.First(l => l.Id == id);
        }

        public void Add(Lamp lamp)
        {
            if(lamp == null)
                throw new ArgumentNullException(nameof(lamp));
            _lamps.Add(lamp);
        }

        public void Remove(Guid id)
        {
            Lamp lamp = GetById(id);
            if(lamp != null)
                _lamps.Remove(lamp);
        }

        public void Update(Lamp lamp)
        {
            //Todo: implement update logic
        }
    }
}
