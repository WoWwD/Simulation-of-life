using SimulatorOfLive.Logic.Abstract_model;
using System;
using System.Collections.Generic;

namespace SimulatorOfLive.Logic.Model
{
    public class MediumCell : FormOfCell
    {
        public MediumCell(int X, int Y, int Speed = 4, int Overview = 8, int Width = 8, int Height = 8) : base(Speed, Overview, Width, Height, X, Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}