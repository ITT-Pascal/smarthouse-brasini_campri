using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.LuminousDevices
{
    public class MatrixLed
    {
        //Properties
        public LampModel[,] Matrix { get; private set; }
        public int Raws { get; private set; }
        public int Columns { get; private set; }

        //Constructor
        public MatrixLed() { }

        public MatrixLed(int raws, int columns)
        {
            Matrix = new LampModel[raws, columns];
            for(int r=0; r<raws; r++)
            {
                for(int c=0; c<columns; c++)
                {
                    Matrix[r, c] = new Lamp($"Lamp({r},{c}");
                }
            }
            Raws = raws;
            Columns = columns;
        }

        public MatrixLed(LampModel[,] m)
        {
            Matrix = m;
        }

        //Methods
        public void TurnAllOn()
        {
            for (int r = 0; r <Raws; r++)
            {
                for (int c = 0; c <Columns; c++)
                {
                    if (Matrix[r, c].Status != Device.DeviceStatus.On)
                        Matrix[r, c].TurnOn();
                }
            }
        }

        public void TurnAllOff()
        {
            for (int r = 0; r < Raws; r++)
            {
                for (int c = 0; c < Columns; c++)
                {
                    if (Matrix[r, c].Status != Device.DeviceStatus.Off)
                        Matrix[r, c].TurnOff();
                }
            }
        }

        public void TurnRawOn(int rawIdx)
        {
            for(int c=0; c<Columns; c++)
            {
                if (Matrix[rawIdx, c].Status != Device.DeviceStatus.On)
                    Matrix[rawIdx, c].TurnOn();
            }
        }

        public void TurnRawOff(int rawIdx)
        {
            for (int c = 0; c < Columns; c++)
            {
                if (Matrix[rawIdx, c].Status != Device.DeviceStatus.Off)
                    Matrix[rawIdx, c].TurnOff();
            }
        }

        public void TurnColumnOn(int colIdx)
        {
            for (int r = 0; r<Raws; r++)
            {
                if (Matrix[r, colIdx].Status != Device.DeviceStatus.On)
                    Matrix[r,colIdx].TurnOn();
            }
        }

        public void TurnColumnOff(int colIdx)
        {
            for (int r = 0; r <Raws ; r++)
            {
                if (Matrix[r, colIdx].Status != Device.DeviceStatus.Off)
                    Matrix[r, colIdx].TurnOff();
            }
        }

        public void IncreaseAllBrightness()
        {
            for (int r = 0; r < Raws; r++)
            {
                for (int c = 0; c < Columns; c++)
                {
                    Matrix[r, c].IncreaseBrightness();
                }
            }
        }

        public void DecreaseAllBrightness()
        {
            for (int r = 0; r < Raws; r++)
            {
                for (int c = 0; c < Columns; c++)
                {
                    Matrix[r, c].DecreaseBrightness();
                }
            }
        }
    }
}
