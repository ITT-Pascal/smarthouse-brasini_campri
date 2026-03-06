using BlaisePascal.SmartHouse.Consoles.Devices.LuminousDevices.LampController;
using BlaisePascal.SmartHouse.Domain.LuminousDevices.Repository;
using BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Lightning.Lamps.InMemory;
using BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Lightning.Lamps.Json;

class Program
{
    static void Main()
    {
        ILampRepository repository = new InMemoryLampRepository();
        LampController controller = new LampController(repository);

        bool exit = false;

        Dictionary<string, Action> actions = new Dictionary<string, Action>()
        {
            {"1", controller.AddLamp},
            {"2", controller.RemoveLamp},
            {"3", controller.IncreaseLampBrightness},
            {"4", controller.DecreaseLampBrightness},
            {"5", controller.ChangeLampBrightness},
            {"6", controller.SwitchOnLamp},
            {"7", controller.SwitchOffLamp}
        };


        while (!exit)
        {
            Console.Clear();
            controller.ShowLamps();
            ShowLampMenu();


            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            Console.WriteLine();

            if (actions.ContainsKey(choice))
            {
                actions[choice].Invoke();
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
        Console.WriteLine("0. Exit");
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
        Console.WriteLine("0. Exit");
    }
}
