using SimulatorOfLive.Logic.Abstract_model;

namespace SimulatorOfLive.Logic.Model
{
    public class HerbivoreLowCell : FormOfCell
    {
        private byte _HP = 2;
        private int _CountOfEating;
        public override byte HP { get { return _HP; } set { _HP = value; } }
        public override int CountOfEating { get { return _CountOfEating; } set { _CountOfEating = value; } }
        public override int Speed { get { return 8; } }
        public override int RegionOfEating { get { return 8; } }
        public override int Width { get { return 6; } }
        public override int Height { get { return 6; } }
        public override int X { get; set; }
        public override int Y { get; set; }
        public HerbivoreLowCell(int X, int Y) : base(X, Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
