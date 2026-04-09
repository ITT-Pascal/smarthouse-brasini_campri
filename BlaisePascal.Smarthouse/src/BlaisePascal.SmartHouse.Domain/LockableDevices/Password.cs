using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.LockableDevices
{
    public record Password
    {
        public string Key { get; }
        private Password(string newkey) 
        {
            if (string.IsNullOrWhiteSpace(newkey) || newkey.Length < 8)
                throw new Exception("The Password must be at least 8 character");
            Key = newkey;
        }

        public static Password Create(string newkey)
        { 
            return new Password(newkey);
        }
    }
}
