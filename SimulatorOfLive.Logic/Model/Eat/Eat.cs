namespace SimulatorOfLive.Logic.Model.Eat
{
    public class Eat
    {
        private byte _HitPoint = 1;
        public byte HitPoint { get { return _HitPoint; } set { _HitPoint = value; } }
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
