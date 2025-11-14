using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class LampsRow
    {
        //Properties
        public List<LampModel> Lamps { get; private set; }
        
        //Constructor
        public LampsRow(string name)
        {
            Lamps = new List<LampModel>();
            
        }

        /*public LampsRow(int numLamp, string name)
        {
            Lamps = new List<LampModel>();
            for (int i = 0; i < numLamp; i++)
            {

                Lamps.Add(new Lamp());
            }
            
        }*/

        //Methods
        public void AddLamp(LampModel lamp)
        {
            Lamps.Add(lamp);
        }


        public void SwitchAllOn()
        {
            for (int i = 0; i < Lamps.Count; i++)
            {
                if (!Lamps[i].IsOn)
                    Lamps[i].SwitchOnOff();

            }
        }

        public void SwitchAllOff()
        {
            for (int i = 0; i < Lamps.Count; i++)
            {
                if (Lamps[i].IsOn)
                    Lamps[i].SwitchOnOff();
            }
        }

        public void SwitchOneLampOnOff(Guid id)
        {
            for (int i = 0; i < Lamps.Count; i++)
            {
                if (Lamps[i].ID == id)
                {
                    Lamps[i].SwitchOnOff();
                }
            }
        }

        

        public void IncreaseAllBrightness()
        {
            for (int i = 0; i < Lamps.Count; i++)
            {
                Lamps[i].IncreaseBrightness();
            }
        }

        public void DecreaseeAllBrightness()
        {
            for (int i = 0; i < Lamps.Count; i++)
            {
                Lamps[i].DecreaseBrightness();
            }
        }

        public void ChangeOneLampBrightness(Guid id, int newBrightness)
        {
            for (int i = 0; i < Lamps.Count; i++)
            {
                if (Lamps[i].ID == id)
                    Lamps[i].ChangeBrightness(newBrightness);
            }
        }

        public void RemoveLampInPoosition(int position)
        {
            if(position >= 0 && position < Lamps.Count)
                Lamps.RemoveAt(position);
        }

    }
}

