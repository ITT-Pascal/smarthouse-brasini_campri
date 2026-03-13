using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.TemperatureDevices
{
    public record Degree
    {
        public double Value { get; }
        public double Max { get;  }
        public double Min { get; }

        private Degree(double value,double min, double max)
        {
            if (max > min)
            {
                Max = max;
                Min = min;
            }
            else
            {
                throw new ArgumentException("Invalid values");
            }
            Value = Math.Clamp(value, min, max);
            
        }
        public static Degree Create(double value, double min, double max)
        {
            return new Degree(value, min, max);
        }
    }
}
