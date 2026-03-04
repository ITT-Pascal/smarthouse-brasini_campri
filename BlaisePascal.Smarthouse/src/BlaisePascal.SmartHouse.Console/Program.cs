using BlaisePascal.SmartHouse.Consoles.Devices.LuminousDevices.LampController;
using BlaisePascal.SmartHouse.Domain.LuminousDevices.Repository;
using BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Lightning.Lamps.InMemory;

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
            ShowMenu();


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

    public static void ShowMenu()
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
}
