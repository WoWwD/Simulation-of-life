using SimulatorOfLive.Logic.Abstract_model;
using System;
using System.Collections.Generic;

namespace SimulatorOfLive.Logic.Model
{
    public class LowCell: FormOfCell
    {
        public LowCell(int X, int Y, int Speed = 6, int Overview = 6, int Width = 6, int Height = 6) : base (Speed, Overview, Width, Height, X, Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}