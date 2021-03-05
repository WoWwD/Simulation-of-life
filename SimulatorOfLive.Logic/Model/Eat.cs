namespace SimulatorOfLive.Logic.Model
{
    public class Eat
    {
        public int Width => 2;  // ширина 
        public int Height => 2;  // высота 
        public int X { get; } // расположение по оси X
        public int Y { get; } // расположение по оси Y
        public Eat (int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}