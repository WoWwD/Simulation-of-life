using SimulatorOfLive.Logic.Abstract_model;

namespace SimulatorOfLive.Logic.Model.Cell
{
    public class HerbivoreMediumCell: FormOfCell
    {
        private byte _HitPoint = 2;
        private int _CountOfEating = 0;
        private bool _PathIsClear = true;
        public override byte RegionOfEating { get { return Speed; } }
        public override bool PathIsClear { get { return _PathIsClear; } set { _PathIsClear = value; } }
        public override byte HitPoint { get { return _HitPoint; } set { _HitPoint = value; } }
        public override int CountOfEating { get { return _CountOfEating; } set { _CountOfEating = value; } }
        public override byte Speed { get { return 8; } }
        public override int Overview { get { return 32; } }
        public override byte Width { get { return 8; } }
        public override byte Height { get { return 8; } }
        public override int X { get; set; }
        public override int Y { get; set; }
        public HerbivoreMediumCell(int X, int Y) : base(X, Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
