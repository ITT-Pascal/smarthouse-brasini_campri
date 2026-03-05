using System.Text.Json;
using System.IO;
using BlaisePascal.SmartHouse.Domain.LuminousDevices;
using BlaisePascal.SmartHouse.Domain.LuminousDevices.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Lightning.Lamps.Json
{
    public class JsonLampRepository : ILampRepository
    {
        private readonly string _lamps;

        public JsonLampRepository()
        {
           
            string projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\..\\"));
            _lamps = Path.Combine(projectRoot, "data", "Lamps.json");

            Directory.CreateDirectory(Path.GetDirectoryName(_lamps)!);

            if (!File.Exists(_lamps))
            {
                File.WriteAllText(_lamps, "[]");
            }
        }

        private void SaveData(List<Lamp> lamps)
        {
            string json = JsonSerializer.Serialize(lamps, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_lamps, json);
        }

        public List<Lamp> GetAll()
        {
            string json = File.ReadAllText(_lamps);
            return JsonSerializer.Deserialize<List<Lamp>>(json) ?? new List<Lamp>(); ;
        }

        public Lamp GetById(Guid id)
        {
            return GetAll().First(l => l.Id == id);
        }

        public void Add(Lamp lamp)
        {
            if (lamp == null) throw new ArgumentNullException(nameof(lamp));

            List<Lamp> lamps = GetAll();
            lamps.Add(lamp);
            SaveData(lamps);
        }

        public void Remove(Guid id)
        {
            List<Lamp> lamps = GetAll();
            Lamp lampToRemove = lamps.First(l => l.Id == id);
            if (lampToRemove != null)
            {
                lamps.Remove(lampToRemove);
                SaveData(lamps);
            }
        }

        public void Update(Lamp lamp)
        {
            List<Lamp> lamps = GetAll();
            int index = lamps.FindIndex(l => l.Id == lamp.Id);

            if (index != -1)
            {
                lamps[index] = lamp;
                SaveData(lamps);
            }
        }
    }

}
