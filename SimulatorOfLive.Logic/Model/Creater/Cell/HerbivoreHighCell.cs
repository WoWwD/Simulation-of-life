﻿using SimulatorOfLive.Logic.Abstract_model;

namespace SimulatorOfLive.Logic.Model.Cell
{
    public class HerbivoreHighCell: FormOfCell
    {
        private byte _HitPoint = 4;
        private int _CountOfEating = 0;
        private bool _PathIsClear = true;
        public override byte RegionOfEating => Speed;
        public override bool PathIsClear { get { return _PathIsClear; } set { _PathIsClear = value; } }
        public override byte HitPoint { get { return _HitPoint; } set { _HitPoint = value; } }
        public override int CountOfEating { get { return _CountOfEating; } set { _CountOfEating = value; } }
        public override byte Speed => 4;
        public override int Overview => 64;
        public override byte Width => 8;
        public override byte Height => 8;
        public HerbivoreHighCell(int X, int Y, string ID) : base(X, Y, ID)
        {
            this.X = X;
            this.Y = Y;
            this.ID = ID;
        }
    }
}