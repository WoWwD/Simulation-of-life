using SimulationOfLife.Logic.Abstract_model;

namespace SimulationOfLife.Logic.Model.Cell
{
    public class OmnivoreHighCell: FormOfCell
    {
        private byte _HitPoint = 10;
        private int _CountOfEating = 0;
        public override byte RegionOfEating => (byte)(Speed / 2);
        public override byte HitPoint { get { return _HitPoint; } set { _HitPoint = value; } }
        public override int CountOfEating { get { return _CountOfEating; } set { _CountOfEating = value; } }
        public override byte Speed => 2;
        public override byte Overview => 64;
        public override byte Width => 9;
        public override byte Height => 9;
        public override bool IsEvolution()
        {
            if (CountOfEating >= SettingsGame.CountOfEatForEvolutionOmnivoreHighCell)
            {
                if (SettingsGame.RndNumber(SettingsGame.ChanceOfEvolutionOmnivoreHighCell) == 1)
                {
                    return true;
                }
            }
            return false;
        }
        public OmnivoreHighCell() { }
        public OmnivoreHighCell(int X, int Y, string ID) : base(X, Y, ID)
        {
            this.X = X;
            this.Y = Y;
            this.ID = ID;
        }
    }
}
