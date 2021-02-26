namespace SimulatorOfLive.Logic.Model
{
    public class Eat
    {
        public int Width { get { return 3; } } // ширина 
        public int Height { get { return 3; } } // высота 
        public int X { get; set; } // расположение по оси X
        public int Y { get; set; } // расположение по оси Y
        public Eat (int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}