using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.AirConditionerDevice
{
    public class AirConditioner: AbstractDevice
    {
        //Const
        private const double DefaultDegrees = 20.0;
        private const double MaxDegrees = 27.0;
        private const double MinDegrees = 16.0;
        private const double DegreeStep = 0.5;

        //Properties
        public double? Degrees { get; private set; }
        public AirMode Mode { get; private set; }

        //Constructor
        public AirConditioner(Guid Id,string name): base(Id,name)
        {
            Degrees = null;
            Mode = AirMode.NoMode;
        }

        public AirConditioner(string name): base(name)
        {
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

        public void SetFanMode()
        {
            OnValidator();
            if (Mode == AirMode.Fan)
                throw new Exception("The mode is already Fan");
            Mode = AirMode.Fan;
            LastModifiedAtUtc = DateTime.Now;
        }

        public void SetNormalMode()
        {
            OnValidator();
            if (Mode == AirMode.Normal)
                throw new Exception("The mode is already Normal");
            Mode = AirMode.Normal;
            LastModifiedAtUtc = DateTime.Now;
        }

        public void SetDryMode()
        {
            OnValidator();
            if (Mode == AirMode.Dry)
                throw new Exception("The mode is already Dry");
            Mode = AirMode.Dry;
            LastModifiedAtUtc = DateTime.Now;
        }

        public void SetMode(AirMode mode)
        {
            OnValidator();
            if (Mode == mode)
                throw new ArgumentException($"The mode is already: {Mode}");
            Mode = mode;
            LastModifiedAtUtc = DateTime.Now;
        }


        public void SetDegrees(double value)
        {
            if (value < MinDegrees || value > MaxDegrees)
                throw new ArgumentOutOfRangeException($"Cannot set degrees to {value}: out of range");
            OnValidator();
            if (Mode == AirMode.Dry || Mode == AirMode.Fan)
                throw new Exception($"Cannot change degrees in mode {Mode}");
            Degrees = value;
            LastModifiedAtUtc = DateTime.Now;
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
            LastModifiedAtUtc = DateTime.Now;
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
            LastModifiedAtUtc = DateTime.Now;
        }


    }
}
