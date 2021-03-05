﻿using SimulatorOfLive.Logic.Model;
using System.Collections.Generic;

namespace SimulatorOfLive.Logic.Abstract_model
{
    public abstract class FormOfCell
    {
        public string ID { get; set; } // уникальный идентификатор клетки
        public abstract byte RegionOfEating { get; } // область поедания
        public abstract bool PathIsClear { get; set; } // свободен ли путь для клетки
        public abstract byte HitPoint { get; set; } // количество жизней
        public abstract int CountOfEating { get; set; } // счётчик съеденной еды
        public abstract byte Speed { get; } // скорость передвижения клетки
        public abstract int Overview { get; } // обзор клетки
        public abstract byte Width { get; } // ширина клетки
        public abstract byte Height { get; } // высота клетки
        public int X { get; set; } // расположение клетки по оси X
        public int Y { get; set; } // расположение клетки по оси Y
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
            else
            {
                PathIsClear = true;
            }
            
        } // движение клетки
        public virtual bool Eating<T>(int MaxWidthField, int MaxHeightField, T cell) where T: FormOfCell
        {
            int viewRight, viewLeft, viewUp, viewDown, RegionOfEatingLeft, RegionOfEatingRight, RegionOfEatingUp, RegionOfEatingDown;
            RegionOfEatingRight = X + RegionOfEating;
            RegionOfEatingLeft = X - RegionOfEating;
            RegionOfEatingUp = Y - RegionOfEating;
            RegionOfEatingDown = Y + RegionOfEating;
            viewRight = X + Overview;
            viewLeft = X - Overview;
            viewUp = Y - Overview;
            viewDown = Y + Overview;
            /* цель справа на одной высоте */
            if (cell.X >= X && cell.X <= viewRight && cell.Y == Y)
            {
                if (cell.X >= X && cell.X <= RegionOfEatingRight)
                {
                    if (cell.HitPoint <= 0)
                    {
                        CountOfEating++;
                        return true;
                    }
                    else
                    {
                        cell.HitPoint--;
                    }
                }
                else
                {
                    Pursuit(MaxWidthField, MaxHeightField, 1);
                }
            }
            /* цель слева на одной высоте*/
            if (cell.X <= X && cell.X >= viewLeft && cell.Y == Y)
            {
                if (cell.X <= X && cell.X >= RegionOfEatingLeft)
                {
                    if (cell.HitPoint <= 0)
                    {
                        CountOfEating++;
                        return true;
                    }
                    else
                    {
                        cell.HitPoint--;
                    }
                }
                else
                {
                    Pursuit(MaxWidthField, MaxHeightField, 2);
                }
            }
            /* цель снизу на одной ширине */
            if (cell.Y >= Y && cell.Y <= viewDown && cell.X == X)
            {
                if (cell.Y >= Y && cell.Y <= RegionOfEatingDown)
                {
                    if (cell.HitPoint <= 0)
                    {
                        CountOfEating++;
                        return true;
                    }
                    else
                    {
                        cell.HitPoint--;
                    }
                }
                else
                {
                    Pursuit(MaxWidthField, MaxHeightField, 3);
                }
            }
            /* цель сверху на одной ширине */
            if (cell.Y <= Y && cell.Y >= viewUp && cell.X == X)
            {
                if (cell.Y <= Y && cell.Y >= RegionOfEatingUp)
                {
                    if (cell.HitPoint <= 0)
                    {
                        CountOfEating++;
                        return true;
                    }
                    else
                    {
                        cell.HitPoint--;
                    }
                }
                else
                {
                    Pursuit(MaxWidthField, MaxHeightField, 4);
                }
            }
            /* цель в первой четверти */
            if ((cell.X >= X && cell.X <= viewRight) && (cell.Y <= Y && cell.Y >= viewUp))
            {
                if ((cell.X >= X && cell.X <= RegionOfEatingRight) && (cell.Y <= Y && cell.Y >= RegionOfEatingUp))
                {
                    if (cell.HitPoint <= 0)
                    {
                        CountOfEating++;
                        return true;
                    }
                    else
                    {
                        cell.HitPoint--;
                    }
                }
                else
                {
                    Pursuit(MaxWidthField, MaxHeightField, 5);
                }
            }
            /* цель во второй четверти */
            if ((cell.X <= X && cell.X >= viewLeft) && (cell.Y <= Y && cell.Y >= viewUp))
            {
                if ((cell.X <= X && cell.X >= RegionOfEatingLeft) && (cell.Y <= Y && cell.Y >= RegionOfEatingUp))
                {
                    if (cell.HitPoint <= 0)
                    {
                        CountOfEating++;
                        return true;
                    }
                    else
                    {
                        cell.HitPoint--;
                    }
                }
                else
                {
                    Pursuit(MaxWidthField, MaxHeightField, 6);
                }
            }
            /* цель в третьей четверти */
            if ((cell.X <= X && cell.X >= viewLeft) && (cell.Y >= Y && cell.Y <= viewDown))
            {
                if ((cell.X <= X && cell.X >= RegionOfEatingLeft) && (cell.Y >= Y && cell.Y <= RegionOfEatingDown))
                {
                    if (cell.HitPoint <= 0)
                    {
                        CountOfEating++;
                        return true;
                    }
                    else
                    {
                        cell.HitPoint--;
                    }
                }
                else
                {
                    Pursuit(MaxWidthField, MaxHeightField, 7);
                }
            }
            /* цель в четвертой четверти */
            if ((cell.X >= X && cell.X <= viewRight) && (cell.Y >= Y && cell.Y <= viewDown))
            {
                if ((cell.X >= X && cell.X <= RegionOfEatingRight) && (cell.Y >= Y && cell.Y <= RegionOfEatingDown))
                {
                    if (cell.HitPoint <= 0)
                    {
                        CountOfEating++;
                        return true;
                    }
                    else
                    {
                        cell.HitPoint--;
                    }
                }
                else
                {
                    Pursuit(MaxWidthField, MaxHeightField, 8);
                }
            }
            return false;
        }
        public virtual void Pursuit(int MaxWidthField, int MaxHeightField, int DirectionOfMove)
        {
            if (SettingsGame.rnd.Next(SettingsGame.ChanceOfPursuit) == 1)
            {
                Move(MaxWidthField, MaxHeightField, DirectionOfMove);
                PathIsClear = false;
            }
        }
        public FormOfCell(int X, int Y, string ID)
        {
            this.X = X;
            this.Y = Y;
            this.ID = ID;
        }
    }
}