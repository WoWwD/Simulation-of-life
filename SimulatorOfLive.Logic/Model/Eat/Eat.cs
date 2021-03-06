namespace SimulatorOfLive.Logic.Model.Eat
{
    public class Eat
    {
        public byte Width => 2; // ширина 
        public byte Height => 2;   // высота 
        public int X { get; } // расположение по оси X
        public int Y { get; } // расположение по оси Y
        public Eat() { }
        public Eat(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
