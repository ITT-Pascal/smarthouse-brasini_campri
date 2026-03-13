using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.abstraction
{
    public record Name
    {
        public string String { get; }

        private Name(string name) 
        {
            if (!string.IsNullOrWhiteSpace(name))
                String = name;
            else
                throw new ArgumentException("The name cannot be null or empty");
        }

        public static Name Create(string name) => new Name(name);
        
    }
}
