using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.abstraction
{
    public record BrightnessRecord(int Value, int Max = 10, int Min = 1)
    {
         
    }
    
}
