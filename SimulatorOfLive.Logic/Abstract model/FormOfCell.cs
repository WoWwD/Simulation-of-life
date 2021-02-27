using System;

namespace SimulatorOfLive.Logic.Abstract_model
{
    public abstract class FormOfCell
    {
        public abstract bool PathIsClear { get; set; }
        public abstract byte HP { get; set; }
        public abstract int CountOfEating { get; set; } // счётчик съеденной еды
        public abstract byte Speed { get; } // скорость передвижения клетки
        public abstract int Overview { get; } // обзор клетки
        public abstract byte Width { get; } // ширина клетки
        public abstract byte Height { get; } // высота клетки
        public abstract int X { get; set; } // расположение клетки по оси X
        public abstract int Y { get; set; } // расположение клетки по оси Y
        public virtual void Move(int MaxWidthField, int MaxHeightField, int DirectionOfMove)
        {
            if (PathIsClear == true)
            {
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
                /* Движение по первой четверти */
                if (DirectionOfMove == 5)
                {
                    X += Speed;
                    Y -= Speed;
                    if (X >= MaxWidthField)
                    {
                        X -= Speed;
                    }
                    if (Y <= 0)
                    {
                        Y += Speed;
                    }
                }
                /* Движение по второй четверти */
                if (DirectionOfMove == 6)
                {
                    X -= Speed;
                    Y -= Speed;
                    if (X <= 0)
                    {
                        X += Speed;
                    }
                    if (Y >= MaxHeightField)
                    {
                        Y += Speed;
                    }
                }
                /* Движение по третьей четверти */
                if (DirectionOfMove == 7)
                {
                    X -= Speed;
                    Y += Speed;
                    if (X <= 0)
                    {
                        X += Speed;
                    }
                    if (Y <= 0)
                    {
                        Y -= Speed;
                    }
                }
                /* Движение по четвертой четверти */
                if (DirectionOfMove == 8)
                {
                    X += Speed;
                    Y += Speed;
                    if (X >= MaxWidthField)
                    {
                        X -= Speed;
                    }
                    if (Y >= MaxHeightField)
                    {
                        Y -= Speed;
                    }
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