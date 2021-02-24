using SimulatorOfLive.Logic.Abstract_model;
using System;
using System.Collections.Generic;

namespace SimulatorOfLive.Logic.Model
{
    public class HighCell : FormOfCell
    {
        public HighCell(int X, int Y, int Speed = 2, int Overview = 10, int Width = 10, int Height = 10) : base(Speed, Overview, Width, Height, X, Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
