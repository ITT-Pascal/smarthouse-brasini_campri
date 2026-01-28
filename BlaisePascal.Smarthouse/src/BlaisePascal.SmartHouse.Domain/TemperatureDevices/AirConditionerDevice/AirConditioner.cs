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
        public Degree TemperatureToReach { get; private set; }
        public AirMode Mode { get; private set; }
        public DegreeMode DegreeMode { get; private set; }

        //Constructor
        public AirConditioner(Guid Id,string name): base(Id,name)
        {
            TemperatureToReach = Degree.Create(DefaultTemperature);
            Mode = AirMode.NoMode;
            DegreeMode = DegreeMode.Celsius;
        }

        public AirConditioner(string name): base(name)
        {
            TemperatureToReach = Degree.Create(DefaultTemperature);
            Mode = AirMode.NoMode;
            DegreeMode = DegreeMode.Celsius;
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
            TemperatureToReach = Degree.Create(value);
            LastModifiedAtUtc = DateTime.Now;
        }

        public void IncreaseTemperatureToReach()
        {
            OnValidator();
            if (Mode == AirMode.Dry || Mode == AirMode.Fan)
                throw new Exception($"Cannot change degrees in mode {Mode}");
            if (TemperatureStep + TemperatureToReach.Value <= MaxTemperature)
            {
                TemperatureToReach = Degree.Create(TemperatureToReach.Value + TemperatureStep);
            }
            else
                TemperatureToReach = Degree.Create(MaxTemperature);
            LastModifiedAtUtc = DateTime.Now;
        }

        public void DecreaseTemperatureToReach()
        {
            OnValidator();
            if (Mode == AirMode.Dry || Mode == AirMode.Fan)
                throw new Exception($"Cannot change degrees in mode {Mode}");
            if (TemperatureToReach.Value - TemperatureStep >= MinTemperature)
            {
                TemperatureToReach = Degree.Create(TemperatureToReach.Value + TemperatureStep);
            }
            else
                TemperatureToReach = Degree.Create(MinTemperature);
            LastModifiedAtUtc = DateTime.Now;
        }

        public void SetFahrenheitMode()
        {
            OnValidator();
            if (DegreeMode == DegreeMode.Fahrenheit)
                throw new Exception("The mode is already Fahrenheit");
            DegreeMode = DegreeMode.Fahrenheit;
            MinTemperature = DegreeConverter.Converter(DegreeMode, MinTemperature);
            MaxTemperature = DegreeConverter.Converter(DegreeMode, MaxTemperature);
            TemperatureToReach = Degree.Create(DegreeConverter.Converter(DegreeMode, TemperatureToReach.Value));
            LastModifiedAtUtc = DateTime.Now;
        }

        public void SetCelsiusMode()
        {
            OnValidator();
            if (DegreeMode == DegreeMode.Celsius)
                throw new Exception("The mode is already Celsius");
            DegreeMode = DegreeMode.Celsius;
            MinTemperature = DegreeConverter.Converter(DegreeMode, MinTemperature);
            MaxTemperature = DegreeConverter.Converter(DegreeMode, MaxTemperature);
            TemperatureToReach = Degree.Create(DegreeConverter.Converter(DegreeMode, TemperatureToReach.Value));
            LastModifiedAtUtc = DateTime.Now;
        }
    }
}
