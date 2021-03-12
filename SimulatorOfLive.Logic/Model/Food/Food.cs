using SimulatorOfLive.Logic.Model.Abstract_model;

namespace SimulatorOfLive.Logic.Model.Food
{
    public class Food: IFood
    {
        public byte Width => 2;  
        public byte Height => 2; 
        public int X { get ; set ; }
        public int Y { get ; set ; }
        public Food() { }
        public Food(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
