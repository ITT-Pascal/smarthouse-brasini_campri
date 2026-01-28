using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.TemperatureDevices
{
    public record Degree
    {
        public double Value { get; }

        private Degree(double value)
        {
            Value = value;
        }
        public static Degree Create(double value)
        {
            return new Degree(value);
        }

        public void ChangeMaxValue(double value)
        {

        }


    }
}
