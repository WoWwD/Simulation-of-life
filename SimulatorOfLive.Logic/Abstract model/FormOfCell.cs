namespace SimulatorOfLive.Logic.Abstract_model
{
    public abstract class FormOfCell
    {
        public abstract int Speed { get; set; } // скорость передвижения клетки
        public abstract int Overview { get; set; } // обзор клетки
        public abstract int Width { get; set; } // ширина клетки
        public abstract int Height { get; set; } // высота клетки
        public abstract int X { get; set; } // расположение клетки по оси X
        public abstract int Y { get; set; } // расположение клетки по оси Y
        public FormOfCell(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}