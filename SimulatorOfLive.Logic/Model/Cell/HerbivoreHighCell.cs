﻿using SimulatorOfLive.Logic.Abstract_model;

namespace SimulatorOfLive.Logic.Model.Cell
{
    public class HerbivoreHighCell: FormOfCell
    {
        private byte _HP = 2;
        private int _CountOfEating;
        public override byte RegionOfEating { get { return 1; } }
        public override byte HP { get { return _HP; } set { _HP = value; } }
        public override int CountOfEating { get { return _CountOfEating; } set { _CountOfEating = value; } }
        public override byte Speed { get { return 12; } }
        public override int Overview { get { return 24; } }
        public override byte Width { get { return 10; } }
        public override byte Height { get { return 10; } }
        public override int X { get; set; }
        public override int Y { get; set; }
        public HerbivoreHighCell(int X, int Y) : base(X, Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
