using SimulatorOfLive.Logic.Abstract_model;

namespace SimulatorOfLive.Logic.Model
{
    public class HighCell: FormOfCell
    {
        public override int Speed { get; set; }
        public override int Overview { get; set; }
        public override int Width { get; set; }
        public override int Height { get; set; }
        public override int X { get; set; }
        public override int Y { get; set; }
        public HighCell(int X, int Y) : base(X, Y)
        {
            Speed = 7;     // переделать
            Overview = 30; // переделать
            Width = 11;
            Height = 11;
        }
    }
}
