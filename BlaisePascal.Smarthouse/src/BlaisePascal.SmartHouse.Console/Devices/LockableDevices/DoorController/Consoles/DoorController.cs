using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Application.Devices.LockableDevices.CCTVUses.Commands;
using BlaisePascal.SmartHouse.Application.Devices.LockableDevices.CCTVUses.Dto;
using BlaisePascal.SmartHouse.Application.Devices.LockableDevices.DoorUses.Command;
using BlaisePascal.SmartHouse.Application.Devices.LockableDevices.DoorUses.Dto;
using BlaisePascal.SmartHouse.Application.Devices.LockableDevices.DoorUses.Queries;
using BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.LampUses.Dto;
using BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.LampUses.Queries;
using BlaisePascal.SmartHouse.Domain.LockableDevices.DoorDevice.Repository;

namespace BlaisePascal.SmartHouse.Console.Devices.LockableDevices.DoorController.Consoles
{
    public class DoorController
    {
        private readonly IDoorRepository _repository;
        public DoorController(IDoorRepository doorRepository)
        {
            _repository = doorRepository;
        }

        public void AddDoor()
        {
            System.Console.Write("Door name: ");
            string name = System.Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Invalid name");
                return;
            }

            new AddDoorCommand(_repository).Execute(name);
            System.Console.WriteLine("CCTV added!");
        }

        public void ShowDoors()
        {
            List<DoorDto> doors = new GetAllDoorQuery(_repository).Execute();
            System.Console.WriteLine("DOORS: ");
            System.Console.WriteLine("--------------------------------------------");
            if (doors.Count == 0)
            {
                System.Console.WriteLine("No doors available");
                return;
            }
            for (int i = 0; i < doors.Count; i++)
            {
                DoorDto door = doors[i];
                System.Console.WriteLine($"{i + 1}. {door.Name}/n{door}");
            }
        }

        private DoorDto SelectDoor()
        {
            List<DoorDto> doors = new GetAllDoorQuery(_repository).Execute();

            if (doors.Count == 0)
            {
                System.Console.WriteLine("No doors available");
                return null;
            }

            System.Console.Write("Door number: ");
            int index;

            if (!int.TryParse(System.Console.ReadLine(), out index))
            {
                System.Console.WriteLine("Invalid number");
                return null;
            }

            if (index < 1 || index > doors.Count)
            {
                System.Console.WriteLine("Door not found");
                return null;
            }

            return doors[index - 1];
        }

        public void SwitchOn()
        {
            DoorDto door = SelectDoor();
            if (door == null) return;

            new SwitchOnDoorCommand(_repository).Execute(door.Id);
            System.Console.WriteLine("Switched on!");
        }

        public void SwitchOff()
        {
            DoorDto door = SelectDoor();
            if (door == null) return;

            new SwitchOffDoorCommand(_repository).Execute(door.Id);
            System.Console.WriteLine("Switched off!");
        }

        public void RemoveDoor()
        {
            DoorDto door = SelectDoor();
            if (door == null) return;

            new RemoveDoorCommand(_repository).Execute(door.Id);
            System.Console.WriteLine("Door removed!");
        }

        public void CloseDoor()
        {
            DoorDto door = SelectDoor();
            if (door == null) return;

            new CloseDoorCommand(_repository).Execute(door.Id);
            System.Console.WriteLine("Door closed!");
        }

        public void OpenDoor()
        {
            DoorDto door = SelectDoor();
            if (door == null) return;

            new OpenDoorCommand(_repository).Execute(door.Id);
            System.Console.WriteLine("Door opened!");
        }

        public void LockDoor()
        {
            DoorDto door = SelectDoor();
            if (door == null) return;

            System.Console.WriteLine("Insert Password");
            string key = System.Console.ReadLine();
            new LockDoorCommand(_repository).Execute(door.Id, key);
            System.Console.WriteLine("Door locked!");
        }

        public void UnlockDoor()
        {
            DoorDto door = SelectDoor();
            if (door == null) return;

            System.Console.WriteLine("Insert Password");
            string key = System.Console.ReadLine();
            new UnlockDoorCommand(_repository).Execute(door.Id, key);
            System.Console.WriteLine("Door unlocked!");

        }

        public void SetPassword()
        {
            DoorDto door = SelectDoor();
            if (door == null) return;
            System.Console.WriteLine("Insert Password");
            string key = System.Console.ReadLine();
            if (key == door.Password)
            {
                System.Console.WriteLine("Insert new Password");
                string newkey = System.Console.ReadLine();
                new SetPassworDoorCommand(_repository).Execute(door.Id, key);
                System.Console.WriteLine("Password set!");
            }
            else
            {
                System.Console.WriteLine("Wrong password");
            }

        }
    }
}
