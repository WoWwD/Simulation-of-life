using SimulatorOfLive.Logic.Abstract_model;

namespace SimulatorOfLive.Logic.Model
{
    public class CarnivorousLowCell: FormOfCell
    {
        public CarnivorousLowCell() { }
        public CarnivorousLowCell(int X, int Y, int Speed = 6, int RegionOfEating = 3, int Width = 6, int Height = 6, int CountOfEating = 0) 
            : base (Speed, RegionOfEating, Width, Height, X, Y, CountOfEating)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}