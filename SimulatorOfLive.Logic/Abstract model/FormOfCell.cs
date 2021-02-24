namespace SimulatorOfLive.Logic.Abstract_model
{
    public abstract class FormOfCell
    {
        public long Id { get; set; }
        public long CountOfEating { get; set; }
        public int Speed { get; set; } // скорость передвижения клетки
        public int RegionOfEating { get; set; } // Область приема пищи
        public int Width { get; set; } // ширина клетки
        public int Height { get; set; } // высота клетки
        public int X { get; set; } // расположение клетки по оси X
        public int Y { get; set; } // расположение клетки по оси Y
        //public abstract void Move<T>(int MaxWidthField, int MaxHeightField, int maxvaluespeed, List<T> cells) where T : FormOfCell;
        public FormOfCell(long Id, int Speed, int RegionOfEating, int Width, int Height, int X, int Y, int CountOfEating)
        {
            this.Id = Id;
            this.Speed = Speed;
            this.RegionOfEating = RegionOfEating;
            this.Width = Width;
            this.Height = Height;
            this.X = X;
            this.Y = Y;
            this.CountOfEating = CountOfEating;
        }
    }
}