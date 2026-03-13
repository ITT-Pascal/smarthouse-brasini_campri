using BlaisePascal.SmartHouse.Application.Devices.LockableDevices.CCTVUses.Commands;
using BlaisePascal.SmartHouse.Application.Devices.LockableDevices.CCTVUses.Dto;
using BlaisePascal.SmartHouse.Application.Devices.LockableDevices.CCTVUses.Queries;
using BlaisePascal.SmartHouse.Domain.LockableDevices.CctvDevice;
using BlaisePascal.SmartHouse.Domain.LockableDevices.CctvDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Consoles.Devices.LockableDevices.CCTVController
{
    public class CCTVController
    {
        private readonly ICCTVRepository _repository;

        public CCTVController(ICCTVRepository repository)
        {
            _repository = repository;
        }

        public void AddCCTV()
        {
            Console.Write("CCTV name: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Invalid name");
                return;
            }

            new AddCCTVCommand(_repository).Execute(name);
            Console.WriteLine("CCTV added!");
        }

        public void ShowCCTVs()
        {
            List<CCTVDto> cctvs = new GetAllCCTVQuery(_repository).Execute();

            Console.WriteLine("CCTVS: ");
            Console.WriteLine("--------------------------------------------");

            if(cctvs.Count == 0)
            {
                Console.WriteLine("No cctvs available");
                return;
            }

            for(int i=0; i<cctvs.Count; i++)
            {
                CCTVDto cctv = cctvs[i];
                Console.WriteLine($"{i + 1}. {cctv.Name}\n{cctv}");
            }
        }

        private CCTVDto SelectCCTV()
        {
            List<CCTVDto> cctvs = new GetAllCCTVQuery(_repository).Execute();

            if (cctvs.Count == 0)
            {
                Console.WriteLine("No CCTVs available");
                return null;
            }

            Console.Write("CCTV number: ");
            int index;

            if (!int.TryParse(Console.ReadLine(), out index))
            {
                Console.WriteLine("Invalid number");
                return null;
            }

            if (index < 1 || index > cctvs.Count)
            {
                Console.WriteLine("Lamp not found");
                return null;
            }

            return cctvs[index - 1];
        }

        public void RemoveCCTV()
        {
            CCTVDto cctv = SelectCCTV();

            if (cctv == null) return;

            new RemoveCCTVCommand(_repository).Execute(cctv.Id);
            Console.WriteLine("CCTV removed!");
        }

        public void SetNightMode()
        {
            CCTVDto cctv = SelectCCTV();

            if (cctv == null) return;
            try
            {
                new SetNightModeCCTVCommand(_repository).Execute(cctv.Id);
                Console.WriteLine("Night mode setted!");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return;
            }
            
        }

        public void SetNormalMode()
        {
            CCTVDto cctv = SelectCCTV();

            if (cctv == null) return;

            try
            {
                new SetNormalModeCCTVCommand(_repository).Execute(cctv.Id);
                Console.WriteLine("Normal mode setted!");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return;
            }
        }

        public void SetMode()
        {
            CCTVDto cctv = SelectCCTV();
            if (cctv == null) return;

            Console.Write("Enter mode(Night-Normal): ");

            if (!CCTVMode.TryParse(Console.ReadLine(), out CCTVMode mode))
            {
                Console.WriteLine($"Invalid mode.");
                return;
            }

            try
            {
                new SetModeCCTVCommand(_repository).Execute(cctv.Id, mode);
                Console.WriteLine("Mode setted!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return;
            }
            
        }

        public void StartRecording()
        {
            CCTVDto cctv = SelectCCTV();
            if (cctv == null) return;

            try
            {
                new StartRecordingCCTVCommand(_repository).Execute(cctv.Id);
                Console.WriteLine("Started recording!");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return;
            }
        }

        public void StopRecording()
        {
            CCTVDto cctv = SelectCCTV();
            if (cctv == null) return;

            try
            {
                new StopRecordingCCTVCommand(_repository).Execute(cctv.Id);
                Console.WriteLine("Stopped recording!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return;
            }
           
        }

        public void SwitchOn()
        {
            CCTVDto cctv = SelectCCTV();
            if (cctv == null) return;

            try
            {
                new SwitchOnCCTVCommand(_repository).Execute(cctv.Id);
                Console.WriteLine("Switched on!");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return;
            }
        }

        public void SwitchOff()
        {
            CCTVDto cctv = SelectCCTV();
            if (cctv == null) return;

            try
            {
                new SwitchOffCCTVCommand(_repository).Execute(cctv.Id);
                Console.WriteLine("Switched off!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return;
            }  
        }

        public void Toggle()
        {
            CCTVDto cctv = SelectCCTV();
            if (cctv == null) return;

            new ToggleCCTVCommand(_repository).Execute(cctv.Id);
            Console.WriteLine($"Toggled to {cctv.Status}!");
        }

        public void Lock()
        {
            CCTVDto cctv = SelectCCTV();
            if (cctv == null) return;

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            try
            {
                new LockCCTVCommand(_repository).Execute(cctv.Id, password);
                Console.WriteLine("CCTV locked!");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return;
            }
        }

        public void Unlock()
        {
            CCTVDto cctv = SelectCCTV();
            if (cctv == null) return;

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();
            
            try
            {
                new UnlockCCTVCommand(_repository).Execute(cctv.Id, password);
                Console.WriteLine("CCTV unlocked!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return;
            }
        }

        public void SetPassword()
        {
            CCTVDto cctv = SelectCCTV();
            if (cctv == null) return;

            Console.Write("Enter new password: ");
            string password = Console.ReadLine();

            try
            {
                new SetPasswordCCTVCommand(_repository).Execute(cctv.Id, password);
                Console.WriteLine("Password setted!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return;
            }
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
    }
}
