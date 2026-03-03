using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.LampUses.Commands;
using BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.LampUses.Dto;
using BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.LampUses.Queries;
using BlaisePascal.SmartHouse.Domain.LuminousDevices;
using BlaisePascal.SmartHouse.Domain.LuminousDevices.Repository;

// Correggi il namespace per evitare conflitti con 'Console'
namespace BlaisePascal.SmartHouse.Consoles.Devices.LuminousDevices.LampController
{
    public class LampController
    {
        private readonly ILampRepository _repository;

        public LampController(ILampRepository repository)
        {
            _repository = repository;
        }

        // Add new lamp obj to injected specific repo
        public void AddLamp()
        {
            Console.Write("Lamp name: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Invalid name");
                return;
            }

            new AddLampCommand(_repository).Execute(name);
            Console.WriteLine("Lamp added!");
        }

        // Mostra lampade
        public void ShowLamps()
        {
            List<LampDto> lamps = new GetAllLampsQuery(_repository).Execute();

            Console.WriteLine("LAMPS:");
            Console.WriteLine("--------------------------------------------");

            if (lamps.Count == 0)
            {
                Console.WriteLine("No lamps available");
                return;
            }

            for (int i = 0; i < lamps.Count; i++)
            {
                LampDto l = lamps[i];
                Console.WriteLine($"{i + 1}. {l.Name}\n{l}");
            }
        }

        public void RemoveLamp()
        {
            LampDto lamp = SelectLamp();
            if (lamp == null) return;

            new RemoveLampCommand(_repository).Execute(lamp.Id);
            Console.WriteLine("Lamp removed!");
        }

        public LampDto SelectLamp()
        {
            List<LampDto> lamps = new GetAllLampsQuery(_repository).Execute();

            if (lamps.Count == 0) return null;

            ShowLamps();
            Console.Write("\nInserisci il numero della lampada: ");

            string risposta = Console.ReadLine();

            // Conversione da stringa a intero 
            int scelta = int.Parse(risposta);

            if (scelta > 0 && scelta <= lamps.Count)
            {
                return lamps[scelta - 1];
            }

            Console.WriteLine("Selezione non valida.");
            return null;
        }

        public void ShowMenu()
        {
            Console.WriteLine("LAMP CONTROLLER");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("1. Show lamps");
            Console.WriteLine("2. Add lamp");
            Console.WriteLine("3. Remove lamp");
            Console.WriteLine("4. Increase brightness");
            Console.WriteLine("5. Decrease brightness");
            Console.WriteLine("8. Change brightness");
            Console.WriteLine("6. Switch on");
            Console.WriteLine("7. Switch off");
            Console.WriteLine("0. Back");
        }

        public void IncreaseLampBrightness()
        {
            LampDto lamp = SelectLamp();
            if (lamp == null) return;
            new IncreaseBrightnessLampCommand(_repository).Execute(lamp.Id);
            Console.WriteLine("Brightness increased!");
        }

        public void DecreaseLampBrightness()
        {
            LampDto lamp = SelectLamp();
            if (lamp == null) return;
            new DecreaseBrightnessLampCommand(_repository).Execute(lamp.Id);
            Console.WriteLine("Brightness decreased!");
        }

        public void SwitchOnLamp()
        {
            LampDto lamp = SelectLamp();
            if (lamp == null) return;
            new SwitchOnLampCommand(_repository).Execute(lamp.Id);
            Console.WriteLine("Lamp toggled!");
        }

        public void SwitchOffLamp()
        {
            LampDto lamp = SelectLamp();
            if (lamp == null) return;
            new SwitchOffLampCommand(_repository).Execute(lamp.Id);
            Console.WriteLine("Lamp toggled!");
        }

        public void ChangeBrightnessLamp()
        {
            LampDto lamp = SelectLamp();
            if (lamp == null) return;
            Console.Write("Enter new brightness (0-100): ");
            string input = Console.ReadLine();
            // Conversione da stringa a intero
            int newBrightness = int.Parse(input);
            new ChangeBrightnessLampCommand(_repository).Execute(lamp.Id, newBrightness);
            Console.WriteLine("Brightness changed!");
        }
    }
}


