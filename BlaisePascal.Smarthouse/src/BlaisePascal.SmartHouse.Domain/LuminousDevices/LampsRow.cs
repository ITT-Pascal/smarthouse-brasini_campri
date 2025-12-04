using BlaisePascal.SmartHouse.Domain.Device;

namespace BlaisePascal.SmartHouse.Domain.LuminousDevices
{
    public class LampsRow
    {
        



        //Properties
        public List<LampModel> Lamps { get; private set; }
        
        //Constructor
        public LampsRow()
        {
            Lamps = new List<LampModel>();
            
        }

        public LampsRow(int numLamp)
        {
            Lamps = new List<LampModel>();
            for (int i = 0; i < numLamp; i++)
            {

                Lamps.Add(new Lamp($"Lamp{i + 1}"));
            }
            
        }

        //Methods
        public void AddLamp(LampModel lamp)
        {
            Lamps.Add(lamp);
        }


        public void SwitchAllOn()
        {
            for (int i = 0; i < Lamps.Count; i++)
            {
                if (Lamps[i].Status == DeviceStatus.Off)
                    Lamps[i].Toggle();

            }
        }

        public void SwitchAllOff()
        {
            for (int i = 0; i < Lamps.Count; i++)
            {
                if (Lamps[i].Status == DeviceStatus.On)
                    Lamps[i].Toggle();
            }
        }

        public void ToggleOneLamp(Guid id)
        {
            for (int i = 0; i < Lamps.Count; i++)
            {
                if (Lamps[i].Id == id)
                {
                    Lamps[i].Toggle();
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
                if (Lamps[i].Id == id)
                    Lamps[i].ChangeBrightness(newBrightness);
            }
        }

        public void RemoveLampInPoosition(int position)
        {
            if(position >= 0 && position < Lamps.Count)
                Lamps.RemoveAt(position);
        }

        public LampModel? FindLampWithMaxBrightness()
        {
            LampModel? maxLamp = null;
            int maxBrightness = 0;

            foreach(LampModel l in Lamps)
            {
                if(maxBrightness < l.Brightness)
                {
                    maxBrightness = l.Brightness;
                    maxLamp = l;
                }
            }

            return maxLamp;
        }

        public LampModel? FindLampWithMinBrightness()
        {
            LampModel? minLamp = null;
            int minBrightness = 0;

            foreach(LampModel l in Lamps)
            {
                if(minBrightness == 0 || minBrightness > l.Brightness)
                {
                    minBrightness = l.Brightness;
                    minLamp = l;
                }
            }

            return minLamp;
        }

        public List<LampModel> FindLampsByIntensityRange(int min, int max)
        {
            List<LampModel> lamps = new List<LampModel>();

            foreach(LampModel l in Lamps)
            {
                if(l.Brightness >= min && l.Brightness <= max)
                {
                    lamps.Add(l);
                }
            }

            return lamps;
        }

        public List<LampModel> FindAllOn()
        {
            List<LampModel> lamps = new List<LampModel>();

            foreach(LampModel l in Lamps)
            {
                if(l.Status == DeviceStatus.On)
                {
                    lamps.Add(l);
                }
            }

            return lamps;
        }

        public List<LampModel> FindAllOff()
        {
            List<LampModel> lamps = new List<LampModel>();

            foreach(LampModel l in Lamps)
            {
                if(l.Status == DeviceStatus.Off)
                {
                    lamps.Add(l);
                }
            }

            return lamps;
        }

        public LampModel? FindLampById(Guid id)
        {
            LampModel? lamp = null;
            foreach(LampModel l in Lamps)
            {
                if(l.Id == id)
                {
                    lamp = l;
                }
            }

            return lamp;
        }

        public List<LampModel> SortByBrightness(bool descending)
        {
            List<LampModel> sortedLamps = new List<LampModel>();
            LampModel? lampToRemove = null;

            if (descending)
            {
                while(Lamps.Count != 0)
                {
                    lampToRemove = FindLampWithMaxBrightness();
                    sortedLamps.Add(lampToRemove);
                }
            }
            else
            {
                while(Lamps.Count != 0)
                {
                    lampToRemove = FindLampWithMinBrightness();
                    sortedLamps.Add(lampToRemove);
                }
            }
            return sortedLamps;
        }


    }
}

