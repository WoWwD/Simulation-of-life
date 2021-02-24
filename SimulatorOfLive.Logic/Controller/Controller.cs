using SimulatorOfLive.Logic.Abstract_model;
using SimulatorOfLive.Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimulatorOfLive.Logic.Controller
{
    public class Controller
    {
        public List<FormOfCell> cells = new List<FormOfCell>();
        public Controller()
        {

        }
        public void Move<T>(int MaxWidthField, int MaxHeightField, int maxvaluespeed, List<T> cells) where T: FormOfCell // public void Move<T>(int MaxWidthField, int MaxHeightField, int maxvaluespeed, List<T> cells) where T: FormOfCell
        {
            Random rnd = new Random();
            int directionOfMove;
            for (int i = 0; i < cells.Count; i++)
            {
                directionOfMove = rnd.Next(0, maxvaluespeed);
                /* Движение вправо */
                if (directionOfMove == 1)
                {
                    cells[i].X += cells[i].Speed;
                    KillCell(MaxWidthField,MaxHeightField, cells);
                    if (cells[i].X >= MaxWidthField)
                    {
                        cells[i].X -= cells[i].Speed;
                    }
                }
                /* Движение влево */
                if (directionOfMove == 2)
                {
                    cells[i].X -= cells[i].Speed;
                    KillCell(MaxWidthField, MaxHeightField, cells);
                    if (cells[i].X <= 0)
                    {
                        cells[i].X += cells[i].Speed;
                    }
                }
                /* Движение вниз */
                if (directionOfMove == 3)
                {
                    cells[i].Y += cells[i].Speed;
                    KillCell(MaxWidthField, MaxHeightField, cells);
                    if (cells[i].Y >= MaxHeightField)
                    {
                        cells[i].Y -= cells[i].Speed;
                    }
                }
                /* Движение вверх */
                if (directionOfMove == 4)
                {
                    cells[i].Y -= cells[i].Speed;
                    KillCell(MaxWidthField, MaxHeightField, cells);
                    if (cells[i].Y <= 0)
                    {
                        cells[i].Y += cells[i].Speed;
                    }
                }
                /* Движение по диагонали вверх + вправо */
                if (directionOfMove == 5)
                {
                    cells[i].X += cells[i].Speed;
                    cells[i].Y -= cells[i].Speed;
                    KillCell(MaxWidthField, MaxHeightField, cells);
                    if (cells[i].X >= MaxWidthField || cells[i].Y <= 0)
                    {
                        cells[i].X -= cells[i].Speed;
                        cells[i].Y += cells[i].Speed;
                    }
                }
                /* Движение по диагонали вниз + влево */
                if (directionOfMove == 6)
                {
                    cells[i].X -= cells[i].Speed;
                    cells[i].Y += cells[i].Speed;
                    KillCell(MaxWidthField, MaxHeightField, cells);
                    if (cells[i].X <= 0 || cells[i].Y >= MaxHeightField)
                    {
                        cells[i].X += cells[i].Speed;
                        cells[i].Y -= cells[i].Speed;
                    }
                }
                /* Движение по диагонали вверх + влево */
                if (directionOfMove == 7)
                {
                    cells[i].X -= cells[i].Speed;
                    cells[i].Y -= cells[i].Speed;
                    KillCell(MaxWidthField, MaxHeightField, cells);
                    if (cells[i].X <= 0 || cells[i].Y <= 0)
                    {
                        cells[i].X += cells[i].Speed;
                        cells[i].Y += cells[i].Speed;
                    }
                }
                /* Движение по диагонали вниз + вправо */
                if (directionOfMove == 8)
                {
                    cells[i].X += cells[i].Speed;
                    cells[i].Y += cells[i].Speed;
                    KillCell(MaxWidthField, MaxHeightField, cells);
                    if (cells[i].X >= MaxWidthField || cells[i].Y >= MaxHeightField)
                    {
                        cells[i].X -= cells[i].Speed;
                        cells[i].Y -= cells[i].Speed;
                    }
                }
                /* Удаление клетки, вышедшей за поле, с каким-либо шансом */
            }
        }
        public void AddFirstCells(int count, int MaxWidthField, int MaxHeightField, List<FormOfCell> cells)
        {
            Random rnd = new Random();
            for (int i = 0; i < count; i++)
            {
                cells.Add(new LowCell(rnd.Next(MaxWidthField), rnd.Next(MaxHeightField))); 
            }
        }
        public void KillCell<T>(int MaxWidthField, int MaxHeightField, List<T> cells) where T: FormOfCell
        {
            Random rnd = new Random();
            int killCell;
            for (int i = 0; i < cells.Count; i++)
            {
                if (cells[i].X < 0 || cells[i].X > MaxWidthField || cells[i].Y < 0 || cells[i].Y > MaxHeightField)
                {
                    killCell = rnd.Next(0, 1000); // шанс 1:1000
                    if (killCell == 1)
                    {
                        cells.RemoveAt(i);
                        break;
                    }
                }
            }
        }
        public void AddMediumCells()
        {
            Random rnd = new Random();
            int X, Y,rndNumber = rnd.Next(0,500);
            if (rndNumber == 1)
            {
                for (int i = 0; i < cells.Count; i++)
                {
                    if (i == 66)
                    {
                        X = cells[i].X;
                        Y = cells[i].Y;
                        cells.RemoveAll(c => c == cells[i]);
                        cells.Add(new MediumCell(X, Y));
                    }
                }
            }
        }
        public void AddHighCells()
        {
            Random rnd = new Random();
            int X, Y, rndNumber = rnd.Next(0, 1000);
            if (rndNumber == 1)
            {
                for (int i = 0; i < cells.Count; i++)
                {
                    if (i == 99)
                    {
                        X = cells[i].X;
                        Y = cells[i].Y;
                        cells.RemoveAll(c => c == cells[i]);
                        cells.Add(new HighCell(X, Y));
                    }
                }
            }
        }

    }
}