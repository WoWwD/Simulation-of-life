using SimulatorOfLive.Logic.Model;
using System;
using System.Collections.Generic;

namespace SimulatorOfLive.Logic.Controller
{
    public class Controller
    {
        /*Разрешение  PictureBox*/
        public List<LowCell> lowcells = new List<LowCell>();
        public Controller()
        {

        }
        public void AddCellsLow(int count, int MaxWidth, int MaxHeight)
        {
            Random rnd = new Random();
            for (int i = 0; i < count; i++)
            {
                lowcells.Add(new LowCell(rnd.Next(MaxWidth), rnd.Next(MaxHeight)));
            }
        }
        public void Move(int MaxWidth, int MaxHeight, int maxvaluespeed)
        {
            Random rnd = new Random();
            int directionOfMove;
            for (int i = 0; i < lowcells.Count; i++)
            {
                directionOfMove = rnd.Next(0, maxvaluespeed);
                /* Движение вправо */
                if (directionOfMove == 1)
                {
                    lowcells[i].X += lowcells[i].Speed;
                    if (lowcells[i].X >= MaxWidth)
                    {
                        //lowcells[i].X = rnd.Next(1, MaxWidth);
                        lowcells[i].X -= lowcells[i].Speed;
                    }
                }
                /* Движение влево */
                if (directionOfMove == 2)
                {
                    lowcells[i].X -= lowcells[i].Speed;
                    if (lowcells[i].X <= 0)
                    {
                        //lowcells[i].X = rnd.Next(1, MaxWidth);
                        lowcells[i].X += lowcells[i].Speed;
                    }
                }
                /* Движение вниз */
                if (directionOfMove == 3)
                {
                    lowcells[i].Y += lowcells[i].Speed;
                    if (lowcells[i].Y >= MaxHeight)
                    {
                        //lowcells[i].Y = rnd.Next(1, MaxHeight);
                        lowcells[i].Y -= lowcells[i].Speed;
                    }
                }
                /* Движение вверх */
                if (directionOfMove == 4)
                {
                    lowcells[i].Y -= lowcells[i].Speed;
                    if (lowcells[i].Y <= 0)
                    {
                        //lowcells[i].Y = rnd.Next(1, MaxHeight);
                        lowcells[i].Y += lowcells[i].Speed;
                    }
                }
                /* Движение по диагонали вверх + вправо */
                if (directionOfMove == 5)
                {
                    lowcells[i].X += lowcells[i].Speed;
                    lowcells[i].Y -= lowcells[i].Speed;
                    if (lowcells[i].X >= MaxWidth || lowcells[i].Y <= 0)
                    {
                        //lowcells[i].X = rnd.Next(1, MaxHeight);
                        //lowcells[i].Y = rnd.Next(1, MaxHeight);
                        lowcells[i].X -= lowcells[i].Speed;
                        lowcells[i].Y += lowcells[i].Speed;
                    }
                }
                /* Движение по диагонали вниз + влево */
                if (directionOfMove == 6)
                {
                    lowcells[i].X -= lowcells[i].Speed;
                    lowcells[i].Y += lowcells[i].Speed;
                    if (lowcells[i].X <= 0 || lowcells[i].Y >= MaxHeight)
                    {
                        //lowcells[i].X = rnd.Next(1, MaxHeight);
                        //lowcells[i].Y = rnd.Next(1, MaxHeight);
                        lowcells[i].X += lowcells[i].Speed;
                        lowcells[i].Y -= lowcells[i].Speed;
                    }
                }
                /* Движение по диагонали вверх + влево */
                if (directionOfMove == 7)
                {
                    lowcells[i].X -= lowcells[i].Speed;
                    lowcells[i].Y -= lowcells[i].Speed;
                    if (lowcells[i].X <= 0 || lowcells[i].Y <= 0)
                    {
                        //lowcells[i].X = rnd.Next(1, MaxHeight);
                        //lowcells[i].Y = rnd.Next(1, MaxHeight);
                        lowcells[i].X += lowcells[i].Speed;
                        lowcells[i].Y += lowcells[i].Speed;
                    }
                }
                /* Движение по диагонали вниз + вправо */
                if (directionOfMove == 8)
                {
                    lowcells[i].X += lowcells[i].Speed;
                    lowcells[i].Y += lowcells[i].Speed;
                    if (lowcells[i].X >= MaxWidth || lowcells[i].Y >= MaxHeight)
                    {
                        //lowcells[i].X = rnd.Next(1, MaxHeight);
                        //lowcells[i].Y = rnd.Next(1, MaxHeight);
                        lowcells[i].X -= lowcells[i].Speed;
                        lowcells[i].Y -= lowcells[i].Speed;
                    }
                }
                /* Удаление клеток */
                //if (lowcells[i].X < 0 || lowcells[i].X > MaxWidth || lowcells[i].Y < 0 || lowcells[i].Y > MaxHeight)
                //{
                //    lowcells.RemoveAll(c => c == lowcells[i]);
                //}
            }
        }
        public void Eating()
        {

        }
        public bool Detecting()
        {
            return false;
        }
    }
}