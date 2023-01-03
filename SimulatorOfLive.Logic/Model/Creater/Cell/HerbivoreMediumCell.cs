using SimulationOfLife.Logic.Abstract_model;

namespace SimulationOfLife.Logic.Model.Cell
{
    public class HerbivoreMediumCell: FormOfCell
    {
        private byte _HitPoint = 8;
        private int _CountOfEating = 0;
        public override byte RegionOfEating => (byte)(Speed / 2);
        public override byte HitPoint { get { return _HitPoint; } set { _HitPoint = value; } }
        public override int CountOfEating { get { return _CountOfEating; } set { _CountOfEating = value; } }
        public override byte Speed => 4;
        public override byte Overview => 48;
        public override byte Width => 7;
        public override byte Height => 7;
        public override bool IsEvolution(int chance)
        {
            if (CountOfEating >= SettingsGame.CountOfEatForEvolutionHerbivoreMediumCell && chance == 1)
            {
                return true;
            }
            return false;
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
