using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Device;

namespace BlaisePascal.SmartHouse.Domain.LuminousDevices
{
    public class EcoLamp: LampModel
    {
        //Const
        private const int EcoMax = 5;
        private const int EcoMin = 1;
        private const int DefaultAutoOffMinutes = 10;
        private const int MinAutoOffMinutes = 1;

        //Properties
        public override int MaxBrightness => EcoMax;
        public override int MinBrightness => EcoMin;
        
        private DateTime? autoOffAtUtc;


        //Constructor
        public EcoLamp(string name ): base( name ) { }
        

        public EcoLamp(Guid newID, string name): base( newID, name ) { }

        public override void TurnOn()
        {
            base.TurnOn();
            autoOffAtUtc = DateTime.UtcNow.AddMinutes(DefaultAutoOffMinutes);
        }
        
        public override void TurnOff()
        {
            base.TurnOff();
            autoOffAtUtc = null;
        }
        public override void ChangeBrightness(int value)
        {
            base.ChangeBrightness(value);
            ResetAutoOffIfNeeded();
        }

        public override void DecreaseBrightness()
        {
            base.DecreaseBrightness();
            ResetAutoOffIfNeeded();
        }

        public override void IncreaseBrightness()
        {
            base.IncreaseBrightness();
            ResetAutoOffIfNeeded();
        }

        public void CheckAutoOff()
        {
            if (Status == DeviceStatus.On &&
                autoOffAtUtc.HasValue &&
                DateTime.UtcNow >= autoOffAtUtc.Value)
            {
                TurnOff();
            }
        }

        private void ResetAutoOffIfNeeded()
        {
            if (autoOffAtUtc.HasValue)
                autoOffAtUtc = DateTime.UtcNow.AddMinutes(DefaultAutoOffMinutes);
        }

        

    }
}
