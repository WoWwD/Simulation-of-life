using SimulatorOfLive.Logic.Abstract_model;
using SimulatorOfLive.Logic.Model;
using SimulatorOfLive.Logic.Model.Cell;
using System;
using System.Collections.Generic;

namespace SimulatorOfLive.Logic.Controller
{
    public class Controller
    {
        public int SpeedOfGame = 0;
        public List<FormOfCell> cells = new List<FormOfCell>();
        public List<Eat> eat = new List<Eat>();
        public Controller()
        {

        }
        public void MoveCells(int MaxWidthField, int MaxHeightField)
        {
            foreach (FormOfCell cell in cells)
            {
                cell.Move(MaxWidthField, MaxHeightField, SpeedOfGame);
            }
        }
        public void AddFirstCells(int count, int MaxWidthField, int MaxHeightField)
        {
            Random rnd = new Random();
            int a;
            for (int i = 0; i < count; i++)
            {
                a = rnd.Next(20);
                if (a == 1)
                {
                    cells.Add(new HerbivoreLowCell(rnd.Next(MaxWidthField), rnd.Next(MaxHeightField)));
                }
                cells.Add(new CarnivorousLowCell(rnd.Next(MaxWidthField), rnd.Next(MaxHeightField)));
            }
        }
        public int EditSpeedOfGame(int speedofgame)
        {
            SpeedOfGame = speedofgame;
            return SpeedOfGame;
        }
        public void AddEat(int MaxWidthField, int MaxHeightField)
        {
            Random rnd = new Random();
            int a;
            a = rnd.Next(100);
            if (a == 1)
            {
                eat.Add(new Eat(rnd.Next(MaxWidthField), rnd.Next(MaxHeightField)));
            }
        }
        public void Eating() 
        {
            int viewRight, viewLeft, viewUp, viewDown;
            foreach (var cell in cells.ToArray())
            {
                viewRight = cell.X + cell.RegionOfEating;
                viewLeft = cell.X - cell.RegionOfEating;
                viewUp = cell.Y + cell.RegionOfEating;
                viewDown = cell.Y - cell.RegionOfEating;
                if (cell is HerbivoreLowCell || cell is HerbivoreMediumCell || cell is HerbivoreHighCell)
                {
                    foreach (var e in eat.ToArray())
                    {
                        if (e.X <= viewRight && e.X >= viewLeft && e.Y <= viewUp && e.Y >= viewDown)
                        {
                            cell.X = e.X;
                            cell.Y = e.Y;
                            cell.CountOfEating++;
                            eat.RemoveAll(c => c == e);
                            break;
                        }
                    }
                    continue;
                }
                if (cell is CarnivorousLowCell || cell is CarnivorousMediumCell || cell is CarnivorousHighCell)
                {
                    foreach (var targetToEat in cells.ToArray())
                    {
                        if (targetToEat.X == cell.X && targetToEat.Y == cell.Y || targetToEat is HerbivoreLowCell || targetToEat is HerbivoreMediumCell || targetToEat is HerbivoreHighCell)
                        {
                            continue;
                        }
                        if (targetToEat.X <= viewRight && targetToEat.X >= viewLeft && targetToEat.Y <= viewUp && targetToEat.Y >= viewDown)
                        {
                            cell.X = targetToEat.X;
                            cell.Y = targetToEat.Y;
                            targetToEat.HP--;
                            cell.CountOfEating++;
                            if (targetToEat.HP <= 0)
                            {
                                cells.RemoveAll(c => c == targetToEat);
                            }
                            break;
                        }
                    }
                }
            }
        }
        public void Evolution()
        {
            Random rnd = new Random();
            int a, b, X, Y;
            foreach (var cell in cells.ToArray())
            { 
                if (cell is CarnivorousLowCell)
                {
                    if (cell.CountOfEating >= 5)
                    {
                        a = rnd.Next(100);
                        if (a == 1)
                        {
                            X = cell.X;
                            Y = cell.Y;
                            cells.RemoveAll(c => c == cell);
                            cells.Add(new CarnivorousMediumCell(X, Y));
                        }
                    }
                }
                if (cell is CarnivorousMediumCell)
                {
                    if (cell.CountOfEating >= 4)
                    {
                        b = rnd.Next(100);
                        if (b == 1)
                        {
                            X = cell.X;
                            Y = cell.Y;
                            cells.RemoveAll(c => c == cell);
                            cells.Add(new CarnivorousHighCell(X, Y));
                        }
                    }
                    
                }
                if (cell is HerbivoreLowCell)
                {
                    if (cell.CountOfEating >= 3)
                    {
                        a = rnd.Next(10);
                        if (a == 1)
                        {
                            X = cell.X;
                            Y = cell.Y;
                            cells.RemoveAll(c => c == cell);
                            cells.Add(new HerbivoreMediumCell(X, Y));
                        }
                    }
                }
                if (cell is HerbivoreMediumCell)
                {
                    if (cell.CountOfEating >= 3)
                    {
                        a = rnd.Next(10);
                        if (a == 1)
                        {
                            X = cell.X;
                            Y = cell.Y;
                            cells.RemoveAll(c => c == cell);
                            cells.Add(new HerbivoreHighCell(X, Y));
                        }
                    }
                }
            }
        }
        //public void AddingDeletingCellsThroughMouse(int MaxWidthField, int MaxHeightField, List<FormOfCell> cells)
        //{
        //    cells.Add(new CarnivorousLowCell(MaxWidthField, MaxHeightField));
        //}
    }
}