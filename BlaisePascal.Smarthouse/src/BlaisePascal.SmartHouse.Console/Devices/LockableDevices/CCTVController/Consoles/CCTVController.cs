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

            new StartRecordingCCTVCommand(_repository).Execute(cctv.Id);
            Console.WriteLine("Started recording!");
        }

        public void StopRecording()
        {
            CCTVDto cctv = SelectCCTV();
            if (cctv == null) return;

            new StopRecordingCCTVCommand(_repository).Execute(cctv.Id);
            Console.WriteLine("Stopped recording!");
        }

        public void SwitchOn()
        {
            CCTVDto cctv = SelectCCTV();
            if (cctv == null) return;

            new SwitchOnCCTVCommand(_repository).Execute(cctv.Id);
            Console.WriteLine("Switched on!");
        }

        public void SwitchOff()
        {
            CCTVDto cctv = SelectCCTV();
            if (cctv == null) return;

            new SwitchOffCCTVCommand(_repository).Execute(cctv.Id);
            Console.WriteLine("Switched off!");
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

            new LockCCTVCommand(_repository).Execute(cctv.Id, password);
            Console.WriteLine("CCTV locked!");
        }

        public void Unlock()
        {
            CCTVDto cctv = SelectCCTV();
            if (cctv == null) return;

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            new UnlockCCTVCommand(_repository).Execute(cctv.Id, password);
            Console.WriteLine("CCTV unlocked!");
        }

        public void SetPassword()
        {
            CCTVDto cctv = SelectCCTV();
            if (cctv == null) return;

            Console.Write("Enter new password: ");
            string password = Console.ReadLine();

            new SetPasswordCCTVCommand(_repository).Execute(cctv.Id, password);
        }
    }
}
