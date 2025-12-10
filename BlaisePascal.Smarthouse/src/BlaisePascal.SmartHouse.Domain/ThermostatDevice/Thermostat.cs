using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Device;

namespace BlaisePascal.SmartHouse.Domain.ThermostatDevice
{
    public class Thermostat: AbstractDevice
    {
            public int DefaultTemperature { get; private set; }
            public int MinTemperature { get; private set; }
            public int MaxTemperature { get; private set; }
            public int TemperatureStep { get; private set; }
            public GradeMode GradeMode { get; private set; }
            public int TemperatureToReach { get; private set; }


            //Constructor
            public Thermostat(string name) : base(name)
            {
                TemperatureToReach = DefaultTemperature;
                GradeMode = GradeMode.Celsius;
                MaxTemperature = 40;
                MinTemperature = 5;
                DefaultTemperature = 20;
                TemperatureStep = 1;
            }

            public Thermostat(Guid guid, string name) : base(guid, name)
            {
                TemperatureToReach = DefaultTemperature;
                GradeMode = GradeMode.Celsius;
                MaxTemperature = 40;
                MinTemperature = 5;
                DefaultTemperature = 20;
                TemperatureStep = 1;
            }

            private void Converter(GradeMode mode)
            {
                if(GradeMode == GradeMode.Celsius)
                { 
                    MaxTemperature = (int)(MaxTemperature * 9 / 5) + 32;
                    MinTemperature = (int)(MinTemperature * 9 / 5) + 32;
                    TemperatureToReach = (int)(TemperatureToReach * 9 / 5) + 32;
                }
                else
                {
                MaxTemperature = (int)(MaxTemperature - 32) * 5 / 9;
                MinTemperature = (int)(MinTemperature - 32) * 5 / 9;
                TemperatureToReach = (int)(TemperatureToReach - 32) * 5 / 9;
                }
            }
            public void SetTemperatureToReach(int temperature)
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
            Converter(GradeMode);
                LastModifiedAtUtc = DateTime.Now;
            }

           public void SetCelsiusMode()
           {
                OnValidator();
                if (GradeMode == GradeMode.Celsius)
                    throw new Exception("The mode is already Celsius");
                GradeMode = GradeMode.Celsius;
                Converter(GradeMode);
                LastModifiedAtUtc = DateTime.Now;
           }







    }
}
