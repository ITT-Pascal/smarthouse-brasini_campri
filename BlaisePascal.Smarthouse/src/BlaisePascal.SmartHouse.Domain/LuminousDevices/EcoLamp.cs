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
        private const int DefaultAutoOffMinutes = 10;
        private const int MinAutoOffMinutes = 1;

        //Properties
        private DateTime? autoOffAtUtc;

        //Constructor
        public EcoLamp(string name ): base( name ) { }
       
        public EcoLamp(Guid newID, string name): base( newID, name ) { }

        public override void TurnOn()
        {
            base.TurnOn();
            autoOffAtUtc = DateTime.Now.AddMinutes(DefaultAutoOffMinutes);
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
                DateTime.Now >= autoOffAtUtc.Value)
            {
                TurnOff();
            }
        }

        private void ResetAutoOffIfNeeded()
        {
            if (autoOffAtUtc.HasValue)
                autoOffAtUtc = DateTime.Now.AddMinutes(DefaultAutoOffMinutes);
        }
    }
}
