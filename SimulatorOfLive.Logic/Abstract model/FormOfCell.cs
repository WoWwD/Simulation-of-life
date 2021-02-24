using System.Collections.Generic;

namespace SimulatorOfLive.Logic.Abstract_model
{
    public abstract class FormOfCell
    {
        public int Speed { get; set; } // скорость передвижения клетки
        public int Overview { get; set; } // обзор клетки
        public int Width { get; set; } // ширина клетки
        public int Height { get; set; } // высота клетки
        public int X { get; set; } // расположение клетки по оси X
        public int Y { get; set; } // расположение клетки по оси Y
        //public abstract void Move<T>(int MaxWidthField, int MaxHeightField, int maxvaluespeed, List<T> cells) where T : FormOfCell;
        public FormOfCell(int Speed, int Overview, int Width, int Height, int X, int Y)
        {
            this.Speed = Speed;
            this.Overview = Overview;
            this.Width = Width;
            this.Height = Height;
            this.X = X;
            this.Y = Y;
        }
    }
}