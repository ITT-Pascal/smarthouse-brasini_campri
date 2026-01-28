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

        private GradeRecord(double value)
        {
            Value = value;
        }
        public static GradeRecord Create(double value)
        {
            return new GradeRecord(value);
        }


    }
}
