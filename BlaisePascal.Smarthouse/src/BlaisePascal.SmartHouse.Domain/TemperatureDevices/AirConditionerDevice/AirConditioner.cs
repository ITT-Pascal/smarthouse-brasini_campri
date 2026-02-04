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
        private double TemperatureStep = 0.5;

        //Properties
        public Degree Temperature { get; private set; }
        public AirMode Mode { get; private set; }
        public DegreeMode DegreeMode { get; private set; }

        //Constructor
        public AirConditioner(Guid Id,string name): base(Id,name)
        {
            Temperature = Degree.Create(DefaultTemperature, 16.0, 27.0);
            Mode = AirMode.NoMode;
            DegreeMode = DegreeMode.Celsius;
        }

        public AirConditioner(string name): base(name)
        {
            Temperature = Degree.Create(DefaultTemperature, 16.0, 27.0);
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
            OnValidator();
            if (Mode == AirMode.Dry || Mode == AirMode.Fan)
                throw new Exception($"Cannot change degrees in mode {Mode}");
            Temperature = Degree.Create(value, Temperature.Min, Temperature.Max);
            LastModifiedAtUtc = DateTime.Now;
        }

        public void IncreaseTemperatureToReach()
        {
            OnValidator();
            if (Mode == AirMode.Dry || Mode == AirMode.Fan)
                throw new Exception($"Cannot change degrees in mode {Mode}");
                
            Temperature = Degree.Create(Temperature.Value + TemperatureStep, Temperature.Min, Temperature.Max);
            LastModifiedAtUtc = DateTime.Now;
        }

        public void DecreaseTemperatureToReach()
        {
            OnValidator();
            if (Mode == AirMode.Dry || Mode == AirMode.Fan)
                throw new Exception($"Cannot change degrees in mode {Mode}");
            Temperature = Degree.Create(Temperature.Value - TemperatureStep, Temperature.Min, Temperature.Max);
            LastModifiedAtUtc = DateTime.Now;
        }

        public void SetFahrenheitMode()
        {
            OnValidator();
            if (DegreeMode == DegreeMode.Fahrenheit)
                throw new Exception("The mode is already Fahrenheit");
            DegreeMode = DegreeMode.Fahrenheit;
            Temperature = Degree.Create(DegreeConverter.Converter(DegreeMode, Temperature.Value), DegreeConverter.Converter(DegreeMode, Temperature.Min), DegreeConverter.Converter(DegreeMode, Temperature.Max));
            LastModifiedAtUtc = DateTime.Now;
        }

        public void SetCelsiusMode()
        {
            OnValidator();
            if (DegreeMode == DegreeMode.Celsius)
                throw new Exception("The mode is already Celsius");
            DegreeMode = DegreeMode.Celsius;
            Temperature = Degree.Create(DegreeConverter.Converter(DegreeMode, Temperature.Value), DegreeConverter.Converter(DegreeMode, Temperature.Min), DegreeConverter.Converter(DegreeMode, Temperature.Max));
            LastModifiedAtUtc = DateTime.Now;
        }
    }
}
