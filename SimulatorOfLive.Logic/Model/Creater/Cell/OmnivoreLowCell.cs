using SimulatorOfLive.Logic.Abstract_model;
using System;

namespace SimulatorOfLive.Logic.Model.Cell
{
    public class OmnivoreLowCell: FormOfCell
    {
        private byte _HitPoint = 6;
        private int _CountOfEating = 0;
        public override byte RegionOfEating => (byte)(Speed / 2);
        public override byte HitPoint { get { return _HitPoint; } set { _HitPoint = value; } }
        public override int CountOfEating { get { return _CountOfEating; } set { _CountOfEating = value; } }
        public override byte Speed => 6;
        public override byte Overview => 12;
        public override byte Width => 5;
        public override byte Height => 5;
        public override bool IsEvolution()
        {
            if (CountOfEating >= SettingsGame.CountOfEatForEvolutionOmnivoreLowCell)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public OmnivoreLowCell() { }
        public OmnivoreLowCell(int X, int Y, string ID) : base(X, Y, ID)
        {
            this.X = X;
            this.Y = Y;
            this.ID = ID;
        }
    }
}