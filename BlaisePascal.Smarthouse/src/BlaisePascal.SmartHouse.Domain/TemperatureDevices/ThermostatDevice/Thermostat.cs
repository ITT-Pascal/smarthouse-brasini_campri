using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Device;

namespace BlaisePascal.SmartHouse.Domain.TemperatureDevices.ThermostatDevice
{
    public class Thermostat: AbstractDevice, ITemperatureModifier
    {
            public double DefaultTemperature { get; private set; }
            public double MinTemperature { get; private set; }
            public double MaxTemperature { get; private set; }
            public int TemperatureStep { get; private set; }
            public DegreeMode DegreeMode { get; private set; }
            public Degree TemperatureToReach { get; private set; }


            //Constructor
            public Thermostat(string name) : base(name)
            {
                DefaultTemperature = 20;
                TemperatureToReach = Degree.Create(DefaultTemperature);
                DegreeMode = DegreeMode.Celsius;
                MaxTemperature = 40;
                MinTemperature = 5;
                TemperatureStep = 1;
            }

            public Thermostat(Guid guid, string name) : base(guid, name)
            {
                DefaultTemperature = 20;
                TemperatureToReach = Degree.Create(DefaultTemperature);
                DegreeMode = DegreeMode.Celsius;
                MaxTemperature = 40;
                MinTemperature = 5;
                TemperatureStep = 1;
            }

            
            public void SetTemperatureToReach(double temperature)
            {
                OnValidator();
                if (temperature < MinTemperature || temperature > MaxTemperature)
                    throw new ArgumentOutOfRangeException($"Temperatere must be between {MinTemperature} and {MaxTemperature}");
                TemperatureToReach = Degree.Create(temperature);
                LastModifiedAtUtc = DateTime.Now;
            }

            public void IncreaseTemperatureToReach()
            {
                OnValidator();
                TemperatureToReach = Degree.Create(Math.Min(TemperatureStep + TemperatureToReach.Value, MaxTemperature));
                LastModifiedAtUtc = DateTime.Now;
            }
            public void DecreaseTemperatureToReach()
            {
                OnValidator();
                TemperatureToReach = Degree.Create(Math.Max(TemperatureToReach.Value - TemperatureStep, MinTemperature));
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
                TemperatureToReach = Degree.Create( DegreeConverter.Converter(DegreeMode, TemperatureToReach.Value));
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
                TemperatureToReach = Degree.Create( DegreeConverter.Converter(DegreeMode, TemperatureToReach.Value));
                LastModifiedAtUtc = DateTime.Now;
            }
    }
}
