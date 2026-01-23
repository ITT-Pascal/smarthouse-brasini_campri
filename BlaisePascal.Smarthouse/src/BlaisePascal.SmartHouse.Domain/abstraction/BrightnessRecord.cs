using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.abstraction
{
    public record BrightnessRecord
    {
        public int Value { get; }

        public const int Max = 10;
        public const int Min = 1;

        public BrightnessRecord(int v)
        {
            if (v >= Min && v <= Max)
                Value = v;
            else if (v < Min)
                Value = Min;
            else
                Value = Max;
        }
    }
}
