using SimulatorOfLive.Logic.Abstract_model;

namespace SimulatorOfLive.Logic.Model.Cell
{
    public class HerbivoreMediumCell: FormOfCell
    {
        private byte _HitPoint = 6;
        private int _CountOfEating = 0;
        private bool _PathIsClear = true;
        public override byte RegionOfEating => (byte)(Speed / 2);
        public override bool PathIsClear { get { return _PathIsClear; } set { _PathIsClear = value; } }
        public override byte HitPoint { get { return _HitPoint; } set { _HitPoint = value; } }
        public override int CountOfEating { get { return _CountOfEating; } set { _CountOfEating = value; } }
        public override byte Speed => 4;
        public override int Overview => 48;
        public override byte Width => 7;
        public override byte Height => 7;
        public override bool IsEvolution()
        {
            if (CountOfEating >= SettingsGame.CountOfEatForEvolutionHerbivoreMediumCell)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public HerbivoreMediumCell() { }
        public HerbivoreMediumCell(int X, int Y, string ID) : base(X, Y, ID)
        {
            this.X = X;
            this.Y = Y;
            this.ID = ID;
        }
    }
}
