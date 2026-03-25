using BlaisePascal.SmartHouse.Consoles.Devices.LockableDevices.CCTVController;
using BlaisePascal.SmartHouse.Consoles.Devices.LockableDevices.DoorController.Consoles;
using BlaisePascal.SmartHouse.Consoles.Devices.LuminousDevices.LampController;
using BlaisePascal.SmartHouse.Domain.LockableDevices.CctvDevice.Repository;
using BlaisePascal.SmartHouse.Domain.LockableDevices.DoorDevice.Repository;
using BlaisePascal.SmartHouse.Domain.LuminousDevices.Repository;
using BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Lightning.Lamps.InMemory;
using BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Lockable.CCTVs.InMemory;
using BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Lockable.Doors.InMemory;
using System.Drawing;

class Program
{
    static void Main()
    {
        IDoorRepository doorRepository = new InMemoryDoorRepository();
        DoorController doorController = new DoorController(doorRepository);
        ILampRepository lampRepository = new InMemoryLampRepository();
        LampController lampController = new LampController(lampRepository);
        ICCTVRepository cctvRepository = new InMemoryCCTVRepository();
        CCTVController cctvController = new CCTVController(cctvRepository);

        Dictionary<string, Action> Lampactions = new Dictionary<string, Action>()
        {
            {"1", lampController.AddLamp},
            {"2", lampController.RemoveLamp},
            {"3", lampController.IncreaseLampBrightness},
            {"4", lampController.DecreaseLampBrightness},
            {"5", lampController.ChangeLampBrightness},
            {"6", lampController.SwitchOnLamp},
            {"7", lampController.SwitchOffLamp}
        };

        Dictionary<string, Action> CCTVactions = new Dictionary<string, Action>()
        {
            {"1", cctvController.AddCCTV},
            {"2", cctvController.RemoveCCTV},
            {"3", cctvController.SwitchOn},
            {"4", cctvController.SwitchOff},
            {"5", cctvController.Toggle},
            {"6", cctvController.SetNightMode},
            {"7", cctvController.SetNormalMode},
            {"8", cctvController.SetMode},
            {"9", cctvController.StartRecording},
            {"10", cctvController.StopRecording},
            {"11", cctvController.SetPassword},
            {"12", cctvController.Lock},
            {"13", cctvController.Unlock}
        };

        Dictionary<string, Action> Dooractions = new Dictionary<string, Action>()
        {
            {"1", doorController.AddDoor},
            {"2", doorController.RemoveDoor},
            {"3", doorController.LockDoor},
            {"4", doorController.UnlockDoor},
            {"5", doorController.OpenDoor},
            {"6", doorController.CloseDoor},
            {"7", doorController.SwitchOn},
            {"8", doorController.SwitchOff},
            {"9", doorController.SetPassword}
        };

        bool exit = false;
        bool finished = false;
        while (!finished)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("SMART HOUSE OPTIONS"); 
            Console.WriteLine("--------------------------------------------");
            Console.ResetColor();
            Console.WriteLine("0 - Exit\n1 - Lamps\n2 - CCTVS\n3 - Doors\n");
            Console.Write("Choose the devices you want to control: ");
            string choice = Console.ReadLine();

            if (choice == "0")
            {
                finished = true;
                break;
            }

            exit = false; 
            while (!exit)
            {
                switch (choice)
                {
                    case "1":
                        lampController.ShowLamps();
                        LampController.ShowLampMenu();
                        Console.Write("Choose (0 to Go Back): ");
                        string lChoice = Console.ReadLine();
                        if (lChoice == "0") exit = true;
                        else if (Lampactions.ContainsKey(lChoice)) Lampactions[lChoice].Invoke();
                        break;

                    case "2":
                        cctvController.ShowCCTVs();
                        CCTVController.ShowCCTVMenu();
                        Console.Write("Choose (0 to Go Back): ");
                        string cChoice = Console.ReadLine();
                        if (cChoice == "0") exit = true;
                        else if (CCTVactions.ContainsKey(cChoice)) CCTVactions[cChoice].Invoke();
                        break;

                    case "3":
                        doorController.ShowDoors();
                        DoorController.ShowDoorMenu();
                        Console.Write("Choose (0 to Go Back): ");
                        string dChoice = Console.ReadLine();
                        if (dChoice == "0") exit = true;
                        else if (Dooractions.ContainsKey(dChoice)) Dooractions[dChoice].Invoke();
                        break;

                    default:
                        exit = true; 
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }      
}
