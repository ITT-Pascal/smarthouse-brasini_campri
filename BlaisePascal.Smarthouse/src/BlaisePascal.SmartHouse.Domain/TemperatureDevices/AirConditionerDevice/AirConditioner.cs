using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Device;

namespace BlaisePascal.SmartHouse.Domain.TemperatureDevices.AirConditionerDevice
{
    public class AirConditioner: AbstractDevice, ITemperatureModifier
    {
        //Const
        private double DefaultTemperature = 20.0;
        private double MaxTemperature = 27.0;
        private double MinTemperature = 16.0;
        private double TemperatureStep = 0.5;

        //Properties
        public GradeRecord TemperatureToReach { get; private set; }
        public AirMode Mode { get; private set; }
        public GradeMode GradeMode { get; private set; }

        //Constructor
        public AirConditioner(Guid Id,string name): base(Id,name)
        {
            TemperatureToReach = GradeRecord.Create(DefaultTemperature);
            Mode = AirMode.NoMode;
            GradeMode = GradeMode.Celsius;
        }

        public AirConditioner(string name): base(name)
        {
            TemperatureToReach = GradeRecord.Create(DefaultTemperature);
            Mode = AirMode.NoMode;
            GradeMode = GradeMode.Celsius;
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

        public void SetTemperatureToReach(double value)
        {
            if (value < MinTemperature || value > MaxTemperature)
                throw new ArgumentOutOfRangeException($"Cannot set degrees to {value}: out of range");
            OnValidator();
            if (Mode == AirMode.Dry || Mode == AirMode.Fan)
                throw new Exception($"Cannot change degrees in mode {Mode}");
            TemperatureToReach = GradeRecord.Create(value);
            LastModifiedAtUtc = DateTime.Now;
        }

        public void IncreaseTemperatureToReach()
        {
            OnValidator();
            if (Mode == AirMode.Dry || Mode == AirMode.Fan)
                throw new Exception($"Cannot change degrees in mode {Mode}");
            if (TemperatureStep + TemperatureToReach.Value <= MaxTemperature)
            {
                TemperatureToReach = GradeRecord.Create(TemperatureToReach.Value + TemperatureStep);
            }
            else
                TemperatureToReach = GradeRecord.Create(MaxTemperature);
            LastModifiedAtUtc = DateTime.Now;
        }

        public void DecreaseTemperatureToReach()
        {
            OnValidator();
            if (Mode == AirMode.Dry || Mode == AirMode.Fan)
                throw new Exception($"Cannot change degrees in mode {Mode}");
            if (TemperatureToReach.Value - TemperatureStep >= MinTemperature)
            {
                TemperatureToReach = GradeRecord.Create(TemperatureToReach.Value + TemperatureStep);
            }
            else
                TemperatureToReach = GradeRecord.Create(MinTemperature);
            LastModifiedAtUtc = DateTime.Now;
        }

        public void SetFahrenheitMode()
        {
            OnValidator();
            if (GradeMode == GradeMode.Fahrenheit)
                throw new Exception("The mode is already Fahrenheit");
            GradeMode = GradeMode.Fahrenheit;
            MinTemperature = GradeConverter.Converter(GradeMode, MinTemperature);
            MaxTemperature = GradeConverter.Converter(GradeMode, MaxTemperature);
            TemperatureToReach = GradeRecord.Create(GradeConverter.Converter(GradeMode, TemperatureToReach.Value));
            LastModifiedAtUtc = DateTime.Now;
        }

        public void SetCelsiusMode()
        {
            OnValidator();
            if (GradeMode == GradeMode.Celsius)
                throw new Exception("The mode is already Celsius");
            GradeMode = GradeMode.Celsius;
            MinTemperature = GradeConverter.Converter(GradeMode, MinTemperature);
            MaxTemperature = GradeConverter.Converter(GradeMode, MaxTemperature);
            TemperatureToReach = GradeRecord.Create(GradeConverter.Converter(GradeMode, TemperatureToReach.Value));
            LastModifiedAtUtc = DateTime.Now;
        }
    }
}
