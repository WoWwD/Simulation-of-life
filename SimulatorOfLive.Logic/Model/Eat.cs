namespace SimulatorOfLive.Logic.Model
{
    public class Eat
    {
        public int Width { get; set; } // ширина 
        public int Height { get; set; } // высота 
        public int X { get; set; } // расположение по оси X
        public int Y { get; set; } // расположение по оси Y
        public Eat(int X, int Y, int Width = 3, int Height = 3)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
        }
    }
}