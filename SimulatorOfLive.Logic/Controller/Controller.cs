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
            int overviewright, overviewleft, overviewup, overviewdown, a;
            for (int i = 0; i < lowcells.Count; i++)
            {
                overviewleft = lowcells[i].X - lowcells[i].Speed;
                overviewright = lowcells[i].X + lowcells[i].Speed;
                overviewdown = lowcells[i].Y - lowcells[i].Speed;
                overviewup = lowcells[i].Y + lowcells[i].Speed;
                a = rnd.Next(0, maxvaluespeed);
                if (a == 1)
                {
                    lowcells[i].X += lowcells[i].Speed;
                    if (overviewright >= MaxWidth)
                    {
                        lowcells[i].Speed *= -1;
                        lowcells[i].X += lowcells[i].Speed;
                    }
                }
                if (a == 2)
                {
                    lowcells[i].X -= lowcells[i].Speed;
                    if (overviewleft <= 0)
                    {
                        lowcells[i].Speed *= 1;
                        lowcells[i].X += lowcells[i].Speed;
                    }
                }
                if (a == 3)
                {
                    lowcells[i].Y += lowcells[i].Speed;
                    if (overviewdown >= MaxHeight)
                    {
                        lowcells[i].Speed *= -1;
                        lowcells[i].X += lowcells[i].Speed;
                    }
                }
                if (a == 4)
                {
                    lowcells[i].Y -= lowcells[i].Speed;
                    if (overviewup <= 0)
                    {
                        lowcells[i].Speed *= 1;
                        lowcells[i].X += lowcells[i].Speed;
                    }
                }
                /* Удаление клеток */
                if (lowcells[i].X < 0 || lowcells[i].X > MaxWidth || lowcells[i].Y < 0 || lowcells[i].Y > MaxHeight)
                {
                    lowcells.RemoveAll(c => c == lowcells[i]);
                }
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