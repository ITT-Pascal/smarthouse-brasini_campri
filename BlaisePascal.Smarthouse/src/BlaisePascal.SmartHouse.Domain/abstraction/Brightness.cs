using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.abstraction
{
    public record Brightness
    {
        //Properties
        public int Value { get; }

        //Constants
        public const int Max = 10;
        public const int Min = 1;

        //Constructor
        private Brightness(int v)
        {
            if (v >= Min && v <= Max)
                Value = v;
            else if (v < Min)
                Value = Min;
            else
                Value = Max;
        }

        //Methods
        public static Brightness Create(int value) => new Brightness(value);
    }
}
