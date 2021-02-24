using SimulatorOfLive.Logic.Abstract_model;

namespace SimulatorOfLive.Logic.Model
{
    public class HerbivoreLowCell: FormOfCell
    {
        public HerbivoreLowCell() { }
        public HerbivoreLowCell(int X, int Y, int Speed = 10, int RegionOfEating = 7, int Width = 7, int Height = 7, int CountOfEating = 0)
            : base(Speed, RegionOfEating, Width, Height, X, Y, CountOfEating)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
