using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class Door
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public DoorStatus Status { get; set; } = DoorStatus.Unknown;

        public Door() 
        {
            Id = Guid.NewGuid();
            Status = DoorStatus.Closed;
        }

        public Door(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
            Status = DoorStatus.Closed;
        }

        public void OpenTheDoor()
        {
            if (Status == DoorStatus.Closed)
                Status = DoorStatus.Open;
            else
                throw new Exception("cannot open the door");

        }

        public void CloseTheDoor()
        {
            if (Status == DoorStatus.Open)
                Status = DoorStatus.Closed;
            else
                throw new Exception("cannot close the door");
        }

        public void LockTheDoor()
        {
            if(!(Status == DoorStatus.Locked) && !(Status == DoorStatus.Unknown))
                Status = DoorStatus.Locked;
            else
                throw new Exception("cannot lock the door");
        }





    }
}
