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
            public int TemperatureStep { get; private set; }
            public DegreeMode DegreeMode { get; private set; }
            public Degree Temperature { get; private set; }


            //Constructor
            public Thermostat(string name) : base(name)
            {
                DefaultTemperature = 20;
                DegreeMode = DegreeMode.Celsius;
                TemperatureStep = 1;
                Temperature = Degree.Create(DefaultTemperature, 5, 40);
            }

            public Thermostat(Guid guid, string name) : base(guid, name)
            {
                DefaultTemperature = 20;
                DegreeMode = DegreeMode.Celsius;
                TemperatureStep = 1;
                Temperature = Degree.Create(DefaultTemperature, 5, 40);
            }

            
            public void SetTemperatureToReach(double temperature)
            {
                OnValidator();
                Temperature = Degree.Create(temperature, Temperature.Min, Temperature.Max);
                LastModifiedAtUtc = DateTime.Now;
            }

            public void IncreaseTemperatureToReach()
            {
                OnValidator();
                Temperature = Degree.Create(TemperatureStep + Temperature.Value, Temperature.Min, Temperature.Max);
                LastModifiedAtUtc = DateTime.Now;
            }
            public void DecreaseTemperatureToReach()
            {
                OnValidator();
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
