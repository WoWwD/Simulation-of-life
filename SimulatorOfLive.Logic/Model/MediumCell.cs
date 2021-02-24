using SimulatorOfLive.Logic.Abstract_model;

namespace SimulatorOfLive.Logic.Model
{
    public class MediumCell : FormOfCell
    {
        public MediumCell(long Id, int X, int Y, int Speed = 4, int RegionOfEating = 7, int Width = 8, int Height = 8, int CountOfEating = 0) 
            : base(Id, Speed, RegionOfEating, Width, Height, X, Y, CountOfEating)
        {
            this.Id = Id;
            this.X = X;
            this.Y = Y;
        }
    }
}