using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.TemperatureDevices
{
    public record GradeRecord
    {
        public double Value { get; }
        public double MaxValue{ get; } = 40.0;
        public double MinValue { get; } = 0.0;
        public double DefaultValue { get; } = 20.0;
        private GradeRecord(double value)
        {
            Value = Math.Clamp(value, MinValue, MaxValue);
        }
        public static GradeRecord Create(double value)
        {
            return new GradeRecord(value);
        }


    }
}
