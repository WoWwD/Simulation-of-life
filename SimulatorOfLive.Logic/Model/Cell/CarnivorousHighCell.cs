using SimulatorOfLive.Logic.Abstract_model;

namespace SimulatorOfLive.Logic.Model
{
    public class CarnivorousHighCell : FormOfCell
    {
        public CarnivorousHighCell() { }
        public CarnivorousHighCell(int X, int Y, int Speed = 2, int RegionOfEating = 14, int Width = 10, int Height = 10, int CountOfEating = 0) 
            : base(Speed, RegionOfEating, Width, Height, X, Y, CountOfEating)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
