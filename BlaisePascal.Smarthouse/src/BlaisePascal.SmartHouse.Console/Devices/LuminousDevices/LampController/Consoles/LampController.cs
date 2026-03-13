using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.LampUses.Commands;
using BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.LampUses.Dto;
using BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.LampUses.Queries;
using BlaisePascal.SmartHouse.Domain.abstraction;
using BlaisePascal.SmartHouse.Domain.LuminousDevices;
using BlaisePascal.SmartHouse.Domain.LuminousDevices.Repository;


namespace BlaisePascal.SmartHouse.Consoles.Devices.LuminousDevices.LampController
{
    public class LampController
    {
        private readonly ILampRepository _repository;

        public LampController(ILampRepository repository)
        {
            _repository = repository;
        }

        
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

        private LampDto SelectLamp()
        {
            List<LampDto> lamps = new GetAllLampsQuery(_repository).Execute();

            if (lamps.Count == 0)
            {
                Console.WriteLine("No lamps available");
                return null;
            }

            Console.Write("Lamp number: ");
            int index;

            if (!int.TryParse(Console.ReadLine(), out index))
            {
                Console.WriteLine("Invalid number");
                return null;
            }

            if (index < 1 || index > lamps.Count)
            {
                Console.WriteLine("Lamp not found");
                return null;
            }

            return lamps[index - 1];
        }

        

        public void IncreaseLampBrightness()
        {
            LampDto lamp = SelectLamp();
            if (lamp == null) return;
            try
            {
                new IncreaseBrightnessLampCommand(_repository).Execute(lamp.Id);
                Console.WriteLine("Brightness decreased!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return;
            }
        }

        public void DecreaseLampBrightness()
        {
            LampDto lamp = SelectLamp();
            if (lamp == null) return;
            try 
            {
                new DecreaseBrightnessLampCommand(_repository).Execute(lamp.Id);
                Console.WriteLine("Brightness decreased!");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return;
            }
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

        public void ChangeLampBrightness()
        {
            LampDto lamp = SelectLamp();
            if (lamp == null) return;
            Console.Write($"Enter new brightness ({Brightness.Min}-{Brightness.Max}): ");
           
            if(!int.TryParse(Console.ReadLine(), out int newBrightness) )
            {
                Console.WriteLine($"Invalid brightness value.");
                return;
            }
            try
            {
                new ChangeBrightnessLampCommand(_repository).Execute(lamp.Id, newBrightness);
                Console.WriteLine("Brightness changed!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return;
            }
        }

        public static void ShowLampMenu()
        {
            Console.WriteLine("LAMP CONTROLLER");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("1. Add lamp");
            Console.WriteLine("2. Remove lamp");
            Console.WriteLine("3. Increase brightness");
            Console.WriteLine("4. Decrease brightness");
            Console.WriteLine("5. Change brightness");
            Console.WriteLine("6. Switch on");
            Console.WriteLine("7. Switch off");
            Console.WriteLine("0. Back");

        }
    }
}


