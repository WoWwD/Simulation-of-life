using SimulatorOfLive.Logic.Abstract_model;

namespace SimulatorOfLive.Logic.Model
{
    public class HighCell : FormOfCell
    {
        public HighCell(long Id, int X, int Y, int Speed = 2, int RegionOfEating = 14, int Width = 10, int Height = 10, int CountOfEating = 0) 
            : base(Id, Speed, RegionOfEating, Width, Height, X, Y, CountOfEating)
        {
            this.Id = Id;
            this.X = X;
            this.Y = Y;
        }
    }
}
