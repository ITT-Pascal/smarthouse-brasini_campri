using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class AirConditioner
    {
        //Const
        private const double DefultDegrees = 20.0;
        private const double MaxDegrees = 27.0;
        private const double MinDegrees = 16.0;
        private const double DegreeStep = 0.5;

        //Properties
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public DeviceStatus Status { get; private set; }
        public double? Degrees { get; private set; }
        public AirMode Mode { get; private set; }

        //Constructor
        public AirConditioner()
        {
            Status = DeviceStatus.Off;
            Degrees = null;
            Mode = AirMode.NoMode;
        }

        public AirConditioner(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
            Status = DeviceStatus.Off;
            Degrees = null;
            Mode = AirMode.NoMode;
        }
        
        //Private Methods
        /// <summary>
        /// Check if Device is On
        /// </summary>
        /// <exception cref="Exception"></exception>
        private void OnValidator()
        {
            if (Status == DeviceStatus.Off)
                throw new Exception("The conditioner is off");
        }


        //Methods
        public void SwitchOn()
        {
            if (Status == DeviceStatus.On)
                throw new Exception("The conditioner is already On");
            Status = DeviceStatus.On;
            Mode = AirMode.Normal;
            Degrees = DefultDegrees;
        }

        public void SwitchOff()
        {
            if (Status == DeviceStatus.Off)
                throw new Exception("The conditioner is already off");
            Status = DeviceStatus.Off;
            Mode = AirMode.NoMode;
            Degrees = null;
        }

        public void SetFanMode()
        {
            OnValidator();
            if (Mode == AirMode.Fan)
                throw new Exception("The mode is already Fan");
            Mode = AirMode.Fan;
        }

        public void SetNormalMode()
        {
            OnValidator();
            if (Mode == AirMode.Normal)
                throw new Exception("The mode is already Normal");
            Mode = AirMode.Normal;
        }

        public void SetDryMode()
        {
            OnValidator();
            if (Mode == AirMode.Dry)
                throw new Exception("The mode is already Dry");
            Mode = AirMode.Dry;
        }

        public void SetMode(AirMode mode)
        {
            OnValidator();
            if (Mode == mode)
                throw new ArgumentException($"The mode is already: {Mode}");
            Mode = mode;
        }


        public void SetDegrees(int value)
        {
            if (value < MinDegrees || value > MaxDegrees)
                throw new ArgumentOutOfRangeException($"Cannot set degrees to {value}: out of range");
            OnValidator();
            if (Mode == AirMode.Dry || Mode == AirMode.Fan)
                throw new Exception($"Cannot change degrees in mode {Mode}");
            Degrees = value;
        }

        public void IncreaseDegrees()
        {
            OnValidator();
            if (Mode == AirMode.Dry || Mode == AirMode.Fan)
                throw new Exception($"Cannot change degrees in mode {Mode}");
            if (DegreeStep + Degrees <= MaxDegrees)
            {
                Degrees += DegreeStep;
            }
            else
                Degrees = MaxDegrees;
        }

        public void DecreaseDegrees()
        {
            OnValidator();
            if (Mode == AirMode.Dry || Mode == AirMode.Fan)
                throw new Exception($"Cannot change degrees in mode {Mode}");
            if (Degrees - DegreeStep >= MinDegrees)
            {
                Degrees -= DegreeStep;
            }
            else
                Degrees = MinDegrees;
        }


    }
}
