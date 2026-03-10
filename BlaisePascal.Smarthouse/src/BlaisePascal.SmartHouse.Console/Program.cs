using BlaisePascal.SmartHouse.Console.Devices.LockableDevices.CCTVController;
using BlaisePascal.SmartHouse.Console.Devices.LockableDevices.DoorController.Consoles;
using BlaisePascal.SmartHouse.Consoles.Devices.LuminousDevices.LampController;
using BlaisePascal.SmartHouse.Domain.LockableDevices.CctvDevice.Repository;
using BlaisePascal.SmartHouse.Domain.LockableDevices.DoorDevice.Repository;
using BlaisePascal.SmartHouse.Domain.LuminousDevices.Repository;
using BlaisePascal.SmartHouse.Domain.TemperatureDevices.AirConditionerDevice.Repository;
using BlaisePascal.SmartHouse.Domain.TemperatureDevices.ThermostatDevice.Repository;
using BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Lightning.Lamps.InMemory;
using BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Lockable.CCTVs.InMemory;
using BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Lockable.Doors.InMemory;

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
            Console.Write("\x1b[3J");

            Console.WriteLine("0 - Exit \n" +
                          "1 - Lamps \n" +
                          "2 - CCTVS \n" +
                          "3 - Door \n");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();
            while (!exit)
            {


                switch (choice)
                {
                    case "0":
                        exit = true;
                        break;
                    case "1":
                        lampController.ShowLamps();
                        ShowLampMenu();
                        Console.Write("Choose an option: ");
                        string lampchoice = Console.ReadLine();
                        if (Lampactions.ContainsKey(lampchoice))
                        {
                            Lampactions[choice].Invoke();
                        }
                        else if (choice == "0")
                        {
                            exit = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid option. Press any key to continue...");
                            Console.ReadKey();
                        }
                        break;
                    case "2":
                        cctvController.ShowCCTVs();
                        ShowCCTVMenu();
                        Console.Write("Choose an option: ");
                        string cctvchoice = Console.ReadLine();
                        if (CCTVactions.ContainsKey(cctvchoice))
                        {
                            CCTVactions[choice].Invoke();
                        }
                        else if (choice == "0")
                        {
                            exit = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid option. Press any key to continue...");
                            Console.ReadKey();
                        }
                        break;
                    case "3":

                        doorController.ShowDoors();
                        ShowDoorMenu();
                        Console.Write("Choose an option: ");
                        string doorchoice = Console.ReadLine();
                        if (Dooractions.ContainsKey(doorchoice))
                        {
                            Dooractions[choice].Invoke();
                        }
                        else if (choice == "0")
                        {
                            exit = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid option. Press any key to continue...");
                            Console.ReadKey();
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid option. Press any key to continue...");
                        break;
                }
            }
            Console.WriteLine("Do you want to exit the program? (y/n)");
            string exitChoice = Console.ReadLine();
            if (exitChoice.ToLower() == "y")
            {
                finished = true;
            }
            else
            {
                exit = false;
            }
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

    public static void ShowCCTVMenu()
    {
        Console.WriteLine("CCTV CONTROLLER");
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("1. Add CCTV");
        Console.WriteLine("2. Remove CCTV");
        Console.WriteLine("3. Swtich on");
        Console.WriteLine("4. Swtich off");
        Console.WriteLine("5. Toggle");
        Console.WriteLine("6. Set night mode");
        Console.WriteLine("7. Set normal mode");
        Console.WriteLine("8. Set choosed mode");
        Console.WriteLine("9. Start recording");
        Console.WriteLine("10. Stop recording");
        Console.WriteLine("11. Set password");
        Console.WriteLine("12. Lock CCTV");
        Console.WriteLine("13. Unlock CCTV");
        Console.WriteLine("0. Back");
    }

    public static void ShowDoorMenu()
    {
        Console.WriteLine("DOOR CONTROLLER");
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("1. Add door");
        Console.WriteLine("2. Remove door");
        Console.WriteLine("3. Lock door");
        Console.WriteLine("4. Unlock door");
        Console.WriteLine("5. Open Door");
        Console.WriteLine("5. Close Door");
        Console.WriteLine("7. Switch on");
        Console.WriteLine("8. Switch off");
        Console.WriteLine("9. Set Password");
        Console.WriteLine("0. Back");
    }
}
