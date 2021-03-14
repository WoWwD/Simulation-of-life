using SimulationOfLife.Logic.Abstract_model;

namespace SimulationOfLife.Logic.Model
{
    public class HerbivoreLowCell : FormOfCell
    {
        private byte _HitPoint = 6;
        private int _CountOfEating = 0;
        public override byte RegionOfEating => (byte)(Speed / 2);
        public override byte HitPoint { get { return _HitPoint; } set { _HitPoint = value; } }
        public override int CountOfEating { get { return _CountOfEating; } set { _CountOfEating = value; } }
        public override byte Speed => 6;
        public override byte Overview => 24;
        public override byte Width => 5;
        public override byte Height => 5;
        public override bool IsEvolution()
        {
            if (CountOfEating >= SettingsGame.CountOfEatForEvolutionHerbivoreLowCell)
            {
                if (SettingsGame.rnd.Next(SettingsGame.ChanceOfEvolutionHerbivoreLowCell) == 1)
                {
                    return true;
                }
            }
            return false;
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
