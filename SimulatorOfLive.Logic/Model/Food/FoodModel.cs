using SimulationOfLife.Logic.Model.Abstract_model;

namespace SimulationOfLife.Logic.Model.Food
{
    public class FoodModel: IObject
    {
        private byte _HitPoint = 1;
        public byte HitPoint { get { return _HitPoint; } set { _HitPoint = value; } }
        public byte Width => 2;  
        public byte Height => 2; 
        public int X { get ; set ; }
        public int Y { get ; set ; }
        public string ID { get; set; }
        public FoodModel() { }
        public FoodModel(int X, int Y, string ID)
        {
            this.X = X;
            this.Y = Y;
            this.ID = ID;
        }
        public void Damage() => HitPoint--;
    }
}
