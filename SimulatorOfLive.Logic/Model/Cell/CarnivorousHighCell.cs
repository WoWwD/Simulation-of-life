using SimulatorOfLive.Logic.Abstract_model;

namespace SimulatorOfLive.Logic.Model
{
    public class CarnivorousHighCell: FormOfCell
    {
        private byte _HitPoint = 4;
        private int _CountOfEating = 0;
        private bool _PathIsClear = true;
        public override byte RegionOfEating { get { return Speed; } }
        public override bool PathIsClear { get { return _PathIsClear; } set { _PathIsClear = value; } }
        public override byte HitPoint { get { return _HitPoint; } set { _HitPoint = value; } }
        public override int CountOfEating { get { return _CountOfEating; } set { _CountOfEating = value; } }
        public override byte Speed { get { return 2; } }
        public override int Overview { get { return 64; } }
        public override byte Width { get { return 10; } }
        public override byte Height { get { return 10; } }
        public override int X { get; set; }
        public override int Y { get; set; }
        public CarnivorousHighCell(int X, int Y) : base(X, Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
