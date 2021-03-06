using SimulatorOfLive.Logic.Abstract_model;

namespace SimulatorOfLive.Logic.Model
{
    public class HerbivoreLowCell : FormOfCell
    {
        private byte _HitPoint = 4;
        private int _CountOfEating = 0;
        private bool _PathIsClear = true;
        public override byte RegionOfEating => (byte)(Speed / 2);
        public override bool PathIsClear { get { return _PathIsClear; } set { _PathIsClear = value; } }
        public override byte HitPoint { get { return _HitPoint; } set { _HitPoint = value; } }
        public override int CountOfEating { get { return _CountOfEating; } set { _CountOfEating = value; } }
        public override byte Speed => 6;
        public override int Overview => 24;
        public override byte Width => 5;
        public override byte Height => 5;
        public override bool IsEvolution()
        {
            if (CountOfEating >= SettingsGame.CountOfEatForEvolutionHerbivoreLowCell)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public HerbivoreLowCell() { }
        public HerbivoreLowCell(int X, int Y, string ID) : base(X, Y, ID)
        {
            this.X = X;
            this.Y = Y;
            this.ID = ID;
        }
    }
}
