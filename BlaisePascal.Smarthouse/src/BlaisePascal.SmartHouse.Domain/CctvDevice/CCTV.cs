using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Device;

namespace BlaisePascal.SmartHouse.Domain.CctvDevice
{
    public class CCTV: AbstractDevice, ICCTV
    {
        //Properties
        public CCTVMode Mode { get; private set; }
        public bool isRecording { get; private set; }

        //Constructor
        public CCTV(string name): base(name)
        {
            Mode = CCTVMode.NoMode;
            isRecording = false;
        }
        public CCTV(string name, Guid id): base(id, name)
        {
            Mode = CCTVMode.NoMode;
            isRecording = false;
        }

        //Methods
        public override void TurnOn()
        {
            if (Status == DeviceStatus.On)
                throw new Exception("The CCTV is already on");

            Status = DeviceStatus.On;
            Mode = CCTVMode.Normal;
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        public override void TurnOff()
        {
            if (Status == DeviceStatus.Off)
                throw new Exception("The CCTV is already off");

            Status = DeviceStatus.Off;
            Mode = CCTVMode.NoMode;
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        public void SetNormalMode()
        {
            OnValidator();
            if (Mode == CCTVMode.Normal)
                throw new Exception("The mode is already normal");
            Mode = CCTVMode.Normal;
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        public void SetNightMode()
        {
            OnValidator();
            if (Mode == CCTVMode.Night)
                throw new Exception("The mode is already night");
            Mode = CCTVMode.Night;
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        public void SetMode(CCTVMode mode)
        {
            OnValidator();
            if (Mode == mode)
                throw new ArgumentException($"The mode is already {mode}");
            Mode = mode;
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        public void StartRecording()
        {
            OnValidator();
            if (isRecording)
                throw new Exception("The cctv is already recording");
            isRecording = true;
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        public void StopRecording()
        {
            OnValidator();
            if (!isRecording)
                throw new Exception("The cctv is not recording");
            isRecording = false;
            LastModifiedAtUtc = DateTime.UtcNow;
        }
    }
}
