using SimulatorOfLive.Logic.Abstract_model;

namespace SimulatorOfLive.Logic.Model.Cell
{
    public class HerbivoreMediumCell: FormOfCell
    {
        private byte _HP = 2;
        private int _CountOfEating = 0;
        private bool _PathIsClear = true;
        public override bool PathIsClear { get { return _PathIsClear; } set { _PathIsClear = value; } }
        public override byte RegionOfEating { get { return 1; } }
        public override byte HP { get { return _HP; } set { _HP = value; } }
        public override int CountOfEating { get { return _CountOfEating; } set { _CountOfEating = value; } }
        public override byte Speed { get { return 10; } }
        public override int Overview { get { return 20; } }
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
