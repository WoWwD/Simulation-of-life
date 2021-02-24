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
        public List<Eat> eat = new List<Eat>();
        public Controller()
        {

        }
        public void Move<T>(int MaxWidthField, int MaxHeightField, int SpeedOfGame, List<T> cells) where T: FormOfCell
        {
            Random rnd = new Random();
            int directionOfMove;
            foreach (var cell in cells)
            {
                directionOfMove = rnd.Next(0, SpeedOfGame);
                /* Движение вправо */
                if (directionOfMove == 1)
                {
                    cell.X += cell.Speed;
                    if (cell.X >= MaxWidthField)
                    {
                        cell.X -= cell.Speed;
                    }
                }
                /* Движение влево */
                if (directionOfMove == 2)
                {
                    cell.X -= cell.Speed;
                    if (cell.X <= 0)
                    {
                        cell.X += cell.Speed;
                    }
                }
                /* Движение вниз */
                if (directionOfMove == 3)
                {
                    cell.Y += cell.Speed;
                    if (cell.Y >= MaxHeightField)
                    {
                        cell.Y -= cell.Speed;
                    }
                }
                /* Движение вверх */
                if (directionOfMove == 4)
                {
                    cell.Y -= cell.Speed;
                    if (cell.Y <= 0)
                    {
                        cell.Y += cell.Speed;
                    }
                }
                /* Движение по диагонали вверх + вправо */
                if (directionOfMove == 5)
                {
                    cell.X += cell.Speed;
                    cell.Y -= cell.Speed;
                    if (cell.X >= MaxWidthField || cell.Y <= 0)
                    {
                        cell.X -= cell.Speed;
                        cell.Y += cell.Speed;
                    }
                }
                /* Движение по диагонали вниз + влево */
                if (directionOfMove == 6)
                {
                    cell.X -= cell.Speed;
                    cell.Y += cell.Speed;
                    if (cell.X <= 0 || cell.Y >= MaxHeightField)
                    {
                        cell.X += cell.Speed;
                        cell.Y -= cell.Speed;
                    }
                }
                /* Движение по диагонали вверх + влево */
                if (directionOfMove == 7)
                {
                    cell.X -= cell.Speed;
                    cell.Y -= cell.Speed;
                    if (cell.X <= 0 || cell.Y <= 0)
                    {
                        cell.X += cell.Speed;
                        cell.Y += cell.Speed;
                    }
                }
                /* Движение по диагонали вниз + вправо */
                if (directionOfMove == 8)
                {
                    cell.X += cell.Speed;
                    cell.Y += cell.Speed;
                    if (cell.X >= MaxWidthField || cell.Y >= MaxHeightField)
                    {
                        cell.X -= cell.Speed;
                        cell.Y -= cell.Speed;
                    }
                }
            }
                
        }
        public void AddFirstCells(int count, int MaxWidthField, int MaxHeightField, List<FormOfCell> cells)
        {
            Random rnd = new Random();
            int a;
            for (int i = 0; i < count; i++)
            {
                a = rnd.Next(0,50);
                if (a == 1)
                {
                    cells.Add(new HerbivoreLowCell(rnd.Next(MaxWidthField), rnd.Next(MaxHeightField)));
                    continue;
                }
                cells.Add(new CarnivorousLowCell(rnd.Next(MaxWidthField), rnd.Next(MaxHeightField))); 
            }
        }
        public void AddEat(int MaxWidthField, int MaxHeightField, List<Eat> eat)
        {
            Random rnd = new Random();
            int a;
            a = rnd.Next(0, 100);
            if (a == 1)
            {
                eat.Add(new Eat(rnd.Next(MaxWidthField), rnd.Next(MaxHeightField)));
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
        public void Eating() // стоит рандом на съедение клетки (1:50)
        {
            Random rnd = new Random();
            int viewRight, viewLeft, viewUp, viewDown, a;
            foreach (var cell in cells.ToArray())
            {
                viewRight = cell.X + cell.RegionOfEating;
                viewLeft = cell.X - cell.RegionOfEating;
                viewUp = cell.Y + cell.RegionOfEating;
                viewDown = cell.Y - cell.RegionOfEating;
                if (cell is HerbivoreLowCell)
                {
                    foreach (var e in eat.ToArray())
                    {
                        if (e.X <= viewRight && e.X >= viewLeft && e.Y <= viewUp && e.Y >= viewDown)
                        {
                            cell.X = e.X;
                            cell.Y = e.Y;
                            eat.RemoveAll(c => c == e);
                            cell.CountOfEating++;
                            break;
                            
                        }

                    }
                    continue;
                }
                foreach (var targetToEat in cells)
                {
                    if (targetToEat.X == cell.X && targetToEat.Y == cell.Y || targetToEat is HerbivoreLowCell)
                    {
                        continue;
                    }
                    if (targetToEat.X <= viewRight && targetToEat.X >= viewLeft && targetToEat.Y <= viewUp && targetToEat.Y >= viewDown)
                    {
                        a = rnd.Next(0, 30);
                        if(a == 1)
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
        } 
        public void EvolutionOfCells(List<FormOfCell> cells)
        {
            Random rnd = new Random();
            int a, b;
            for (int i = 0; i < cells.Count; i++)
            {
                if (cells[i] is CarnivorousLowCell)
                {
                    if (cells[i].CountOfEating == 3)
                    {
                        a = rnd.Next(0, 100);
                        if (a == 1)
                        {
                            cells.Add(new CarnivorousMediumCell(cells[i].X, cells[i].Y));
                            cells.RemoveAt(i);
                        }
                        break;
                    }
                }
                if (cells[i] is CarnivorousMediumCell)
                {
                    if (cells[i].CountOfEating == 4)
                    {
                        b = rnd.Next(0, 100);
                        if (b == 1)
                        {
                            cells.Add(new CarnivorousHighCell(cells[i].X, cells[i].Y));
                            cells.RemoveAt(i);
                        }
                        break;
                    }
                }
                if (cells[i] is HerbivoreLowCell)
                {
                    if (cells[i].CountOfEating >= 5)
                    {
                        b = rnd.Next(0, 10);
                        if (b == 1)
                        {
                            cells.Add(new HerbivoreLowCell(cells[i].X, cells[i].Y, 10, 7, 10, 10));
                            cells.RemoveAt(i);
                        }
                        break;
                    }
                }
            }
            
        }
        public void AddingDeletingCellsThroughMouse(int MaxWidthField, int MaxHeightField, List<FormOfCell> cells)
        {
            cells.Add(new CarnivorousLowCell(MaxWidthField, MaxHeightField));
        }
    }
}