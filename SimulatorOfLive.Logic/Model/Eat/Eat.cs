using SimulatorOfLive.Logic.Model.Abstract_model;

namespace SimulatorOfLive.Logic.Model.Eat
{
    public class Eat: ILocation
    {
        private byte _HitPoint = 1;
        public byte HitPoint { get { return _HitPoint; } set { _HitPoint = value; } }
        public byte Width => 2;  // ширина 
        public byte Height => 2; // высота 
        public int X { get ; set ; }
        public int Y { get ; set ; }
        public Eat() { }
        public Eat(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
