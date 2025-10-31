﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class EcoLamp: LampModel
    {
        const int MinBrightness = 1;
        const int MaxBrightness = 5;

        public EcoLamp()
        {
            IsOn = false;
            Brightness = MaxBrightness;

        }
        public override void SwitchOnOff()
        {
            IsOn = !IsOn;
        }
        public override void IncreaseBrightness()
        {
            Brightness = Math.Min(Brightness + 1, MaxBrightness);
        }

        public override void DecreaseBrightness()
        {
            Brightness = Math.Max(Brightness - 1, MinBrightness);
        }
        public override void ChangeBrightness(int brightness)
        {
            if (brightness > MinBrightness && brightness < MaxBrightness)
            {
                Brightness = brightness;
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Brightness cannot be below {MinBrightness} or above {MaxBrightness}" );
            }
        }
    }
}
