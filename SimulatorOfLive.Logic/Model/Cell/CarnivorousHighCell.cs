using SimulatorOfLive.Logic.Abstract_model;

namespace SimulatorOfLive.Logic.Model
{
    public class CarnivorousHighCell: FormOfCell
    {
        private byte _HP = 4;
        private int _CountOfEating;
        public override byte HP { get { return _HP; } set { _HP = value; } }
        public override int CountOfEating { get { return _CountOfEating; } set { _CountOfEating = value; } }
        public override int Speed { get { return 2; } }
        public override int RegionOfEating { get { return 3; } }
        public override int Width { get { return 10; } }
        public override int Height { get { return 10; } }
        public override int X { get; set; }
        public override int Y { get; set; }

        public CarnivorousHighCell(int X, int Y) : base(X, Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
