using System;

namespace SimulatorOfLive.Logic.Abstract_model
{
    public abstract class FormOfCell
    {
        public static Random rnd = new Random();
        public abstract byte HP { get; set; }
        public abstract int CountOfEating { get; set; } // счётчик съеденной еды
        public abstract int Speed { get; } // скорость передвижения клетки
        public abstract int RegionOfEating { get; } // Область приема пищи
        public abstract int Width { get; } // ширина клетки
        public abstract int Height { get; } // высота клетки
        public abstract int X { get; set; } // расположение клетки по оси X
        public abstract int Y { get; set; } // расположение клетки по оси Y
        public virtual void Move(int MaxWidthField, int MaxHeightField, int SpeedOfGame)
        {
            int DirectionOfMove;
            DirectionOfMove = rnd.Next(SpeedOfGame);
            /* Движение вправо */
            if (DirectionOfMove == 1)
            {
                X += Speed;
                if (X >= MaxWidthField)
                {
                    X -= Speed;
                }
            }
            /* Движение влево */
            if (DirectionOfMove == 2)
            {
                X -= Speed;
                if (X <= 0)
                {
                    X += Speed;
                }
            }
            /* Движение вниз */
            if (DirectionOfMove == 3)
            {
                Y += Speed;
                if (Y >= MaxHeightField)
                {
                    Y -= Speed;
                }
            }
            /* Движение вверх */
            if (DirectionOfMove == 4)
            {
                Y -= Speed;
                if (Y <= 0)
                {
                    Y += Speed;
                }
            }
            /* Движение по диагонали вверх + вправо */
            if (DirectionOfMove == 5)
            {
                X += Speed;
                Y -= Speed;
                if (X >= MaxWidthField || Y <= 0)
                {
                    X -= Speed;
                    Y += Speed;
                }
            }
            /* Движение по диагонали вниз + влево */
            if (DirectionOfMove == 6)
            {
                X -= Speed;
                Y += Speed;
                if (X <= 0 || Y >= MaxHeightField)
                {
                    X += Speed;
                    Y -= Speed;
                }
            }
            /* Движение по диагонали вверх + влево */
            if (DirectionOfMove == 7)
            {
                X -= Speed;
                Y -= Speed;
                if (X <= 0 || Y <= 0)
                {
                    X += Speed;
                    Y += Speed;
                }
            }
            /* Движение по диагонали вниз + вправо */
            if (DirectionOfMove == 8)
            {
                X += Speed;
                Y += Speed;
                if (X >= MaxWidthField || Y >= MaxHeightField)
                {
                    X -= Speed;
                    Y -= Speed;
                }
            }
        }
        public FormOfCell(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}