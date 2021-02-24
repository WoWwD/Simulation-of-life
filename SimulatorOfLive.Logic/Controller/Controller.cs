using SimulatorOfLive.Logic.Abstract_model;
using SimulatorOfLive.Logic.Model;
using System;
using System.Collections.Generic;

namespace SimulatorOfLive.Logic.Controller
{
    public class Controller
    {
        public int SpeedOfGame;
        public List<FormOfCell> cells = new List<FormOfCell>();
        public Controller()
        {

        }
        public void Move<T>(int MaxWidthField, int MaxHeightField, int SpeedOfGame, List<T> cells) where T: FormOfCell // public void Move<T>(int MaxWidthField, int MaxHeightField, int maxvaluespeed, List<T> cells) where T: FormOfCell
        {
            Random rnd = new Random();
            int directionOfMove;
            for (int i = 0; i < cells.Count; i++)
            {
                directionOfMove = rnd.Next(0, SpeedOfGame);
                /* Движение вправо */
                if (directionOfMove == 1)
                {
                    cells[i].X += cells[i].Speed;
                    if (cells[i].X >= MaxWidthField)
                    {
                        cells[i].X -= cells[i].Speed;
                    }
                }
                /* Движение влево */
                if (directionOfMove == 2)
                {
                    cells[i].X -= cells[i].Speed;
                    if (cells[i].X <= 0)
                    {
                        cells[i].X += cells[i].Speed;
                    }
                }
                /* Движение вниз */
                if (directionOfMove == 3)
                {
                    cells[i].Y += cells[i].Speed;
                    if (cells[i].Y >= MaxHeightField)
                    {
                        cells[i].Y -= cells[i].Speed;
                    }
                }
                /* Движение вверх */
                if (directionOfMove == 4)
                {
                    cells[i].Y -= cells[i].Speed;
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
                cells.Add(new LowCell(i, rnd.Next(MaxWidthField), rnd.Next(MaxHeightField))); 
            }
        }
        public void DeleteAllCells(List<FormOfCell> cells)
        {
            for (int i = 0; i < cells.Count; i++)
            {
                cells.RemoveAt(i);
            }
        }
        public int EditSpeedOfGame(int speedofgame)
        {
            SpeedOfGame = speedofgame;
            return SpeedOfGame;
        }
        public void Eating<T>(List<T> cells) where T: FormOfCell
        {
            int viewRight, viewLeft, viewUp, viewDown;
            foreach (var cell in cells.ToArray())
            {
                viewRight = cell.X + cell.RegionOfEating;
                viewLeft = cell.X - cell.RegionOfEating;
                viewUp = cell.Y + cell.RegionOfEating;
                viewDown = cell.Y - cell.RegionOfEating;
                foreach (var targetToEat in cells)
                {
                    if (targetToEat.X == cell.X && targetToEat.Y == cell.Y)
                    {
                        continue;
                    }
                    if (targetToEat.X <= viewRight && targetToEat.X >= viewLeft && targetToEat.Y <= viewUp && targetToEat.Y >= viewDown)
                    {
                        cell.X = targetToEat.X;
                        cell.Y = targetToEat.Y;
                        cells.RemoveAll(c => c == targetToEat);
                        cell.CountOfEating++;
                        break;
                    }
                }
            }
        }
        public void UpLevelOfCells(List<FormOfCell> cells)
        {
            for (int i = 0; i < cells.Count; i++)
            {
                if (cells[i] is LowCell)
                {
                    if (cells[i].CountOfEating == 3)
                    {
                        cells.Add(new MediumCell(cells[i].Id, cells[i].X, cells[i].Y));
                        cells.RemoveAt(i);
                    }
                }
                if (cells[i] is MediumCell)
                {
                    if (cells[i].CountOfEating == 4)
                    {
                        cells.Add(new HighCell(cells[i].Id, cells[i].X, cells[i].Y));
                        cells.RemoveAt(i);
                    }
                }
            }
            
        }
    }
}