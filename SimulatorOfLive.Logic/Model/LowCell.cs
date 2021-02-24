using SimulatorOfLive.Logic.Abstract_model;

namespace SimulatorOfLive.Logic.Model
{
    public class LowCell: FormOfCell
    {
        public LowCell(long Id, int X, int Y, int Speed = 6, int RegionOfEating = 3, int Width = 6, int Height = 6, int CountOfEating = 0) 
            : base (Id, Speed, RegionOfEating, Width, Height, X, Y, CountOfEating)
        {
            this.Id = Id;
            this.X = X;
            this.Y = Y;
        }
    }
}