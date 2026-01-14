using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Abstraction;
using BlaisePascal.SmartHouse.Domain.Device;

namespace BlaisePascal.SmartHouse.Domain.TemperatureDevices.ThermostatDevice
{
    public class Thermostat: AbstractDevice, ITemperatureDevices
    {
            public double DefaultTemperature { get; private set; }
            public double MinTemperature { get; private set; }
            public double MaxTemperature { get; private set; }
            public int TemperatureStep { get; private set; }
            public GradeMode GradeMode { get; private set; }
            public double TemperatureToReach { get; private set; }


            //Constructor
            public Thermostat(string name) : base(name)
            {
                DefaultTemperature = 20;
                TemperatureToReach = DefaultTemperature;
                GradeMode = GradeMode.Celsius;
                MaxTemperature = 40;
                MinTemperature = 5;
                TemperatureStep = 1;
            }

            public Thermostat(Guid guid, string name) : base(guid, name)
            {
                DefaultTemperature = 20;
                TemperatureToReach = DefaultTemperature;
                GradeMode = GradeMode.Celsius;
                MaxTemperature = 40;
                MinTemperature = 5;
                TemperatureStep = 1;
            }

            
            public void SetTemperatureToReach(double temperature)
            {
                OnValidator();
                if (temperature < MinTemperature || temperature > MaxTemperature)
                    throw new ArgumentOutOfRangeException($"Temperatere must be between {MinTemperature} and {MaxTemperature}");
                TemperatureToReach = temperature;
                LastModifiedAtUtc = DateTime.Now;
            }

            public void IncreaseTemperatureToReach()
            {
                OnValidator();
                TemperatureToReach = Math.Min(MaxTemperature, TemperatureToReach + TemperatureStep);
                LastModifiedAtUtc = DateTime.Now;
            }
            public void DecreaseTemperatureToReach()
            {
                OnValidator();
                TemperatureToReach = Math.Max(MinTemperature, TemperatureToReach - TemperatureStep);
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
                TemperatureToReach = GradeConverter.Converter(GradeMode, TemperatureToReach);
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
                TemperatureToReach = GradeConverter.Converter(GradeMode, TemperatureToReach);
                LastModifiedAtUtc = DateTime.Now;
            }
    }
}
