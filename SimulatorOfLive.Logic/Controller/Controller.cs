using SimulatorOfLive.Logic.Abstract_model;
using SimulatorOfLive.Logic.Model;
using SimulatorOfLive.Logic.Model.Cell;
using System;
using System.Collections.Generic;

namespace SimulatorOfLive.Logic.Controller
{
    //if (cell is HerbivoreLowCell || cell is HerbivoreMediumCell || cell is HerbivoreHighCell)
    //{
    //    foreach (var e in eat.ToArray())
    //    {
    //        if (e.X <= viewRight && e.X >= viewLeft && e.Y <= viewUp && e.Y >= viewDown)
    //        {
    //            cell.X = e.X;
    //            cell.Y = e.Y;
    //            cell.CountOfEating++;
    //            eat.RemoveAll(c => c == e);
    //            break;
    //        }
    //    }
    //    continue;
    //}
    public class Controller
    {
        public Random rnd = new Random();
        public int SpeedOfGame;
        public List<FormOfCell> cells = new List<FormOfCell>();
        public List<FormOfCell> copycells = new List<FormOfCell>();
        public List<Eat> eat = new List<Eat>();
        
        public void MoveCells(int MaxWidthField, int MaxHeightField)
        {
            int a;
            foreach (FormOfCell cell in cells)
            {
                a = rnd.Next(SpeedOfGame);
                cell.Move(MaxWidthField, MaxHeightField, a);
            }
        }
        public void AddFirstCells(int count, int MaxWidthField, int MaxHeightField)
        {
            Random rnd = new Random();
            int a;
            for (int i = 0; i < count; i++)
            {
                a = rnd.Next(5);
                if (a == 1)
                {
                    cells.Add(new HerbivoreLowCell(rnd.Next(MaxWidthField), rnd.Next(MaxHeightField)));
                    continue;
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
            a = rnd.Next(75);
            if (a == 1)
            {
                eat.Add(new Eat(rnd.Next(MaxWidthField), rnd.Next(MaxHeightField)));
            }
        }
        public void Eating()
        {
            
            int viewRight, viewLeft, viewUp, viewDown, RegionOfEatingLeft, RegionOfEatingRight, RegionOfEatingUp, RegionOfEatingDown, a;
            foreach (var cell in cells.ToArray())
            {
                //RegionOfEatingRight = cell.X + cell.RegionOfEating;
                //RegionOfEatingLeft = cell.X - cell.RegionOfEating;
                //RegionOfEatingUp = cell.Y - cell.RegionOfEating;
                //RegionOfEatingDown = cell.Y + cell.RegionOfEating;
                viewRight = cell.X + cell.Overview;
                viewLeft = cell.X - cell.Overview;
                viewUp = cell.Y - cell.Overview;
                viewDown = cell.Y + cell.Overview;
                if (cell is HerbivoreLowCell || cell is HerbivoreMediumCell || cell is HerbivoreHighCell)
                {
                    foreach (var e in eat.ToArray())
                    {
                        if (eat == null)
                        {
                            continue;
                        }
                        /* цель справа на одной высоте */
                        else if (e.X >= cell.X && e.X <= viewRight && e.Y == cell.Y)
                        {
                            if (e.X == cell.X) // e.X >= cell.X && e.X <= RegionOfEatingRight
                            {
                                //cell.X = e.X;
                                //cell.Y = e.Y;
                                eat.RemoveAll(c => c == e);
                                cell.CountOfEating++;
                                cell.PathIsClear = true;
                                
                            }
                            else
                            {
                                cell.X += cell.Speed;
                                cell.PathIsClear = false;
                            }
                            
                        }
                        /* цель слева на одной высоте */
                        else if (e.X <= cell.X &&  e.X >= viewLeft && e.Y == cell.Y)
                        {
                            if (e.X == cell.X) // e.X <= cell.X && e.X >= RegionOfEatingLeft
                            {
                                //cell.X = e.X;
                                //cell.Y = e.Y;
                                eat.RemoveAll(c => c == e);
                                cell.CountOfEating++;
                                cell.PathIsClear = true;
                                
                            }
                            else
                            {
                                cell.X -= cell.Speed;
                                cell.PathIsClear = false;
                            }
                            
                        }
                        /* цель снизу на одной ширине */
                        else if (e.Y >= cell.Y && e.Y <= viewDown && e.X == cell.X)
                        {
                            if (e.Y == cell.Y) // e.Y >= cell.Y && e.Y <= RegionOfEatingDown
                            {
                                //cell.X = e.X;
                                //cell.Y = e.Y;
                                eat.RemoveAll(c => c == e);
                                cell.CountOfEating++;
                                cell.PathIsClear = true;
                                
                            }
                            else
                            {
                                cell.Y += cell.Speed;
                                cell.PathIsClear = false;
                            }
                            
                        }
                        /* цель сверху на одном X */
                        else if (e.Y <= cell.Y && e.Y >= viewUp && e.X == cell.X)
                        {
                            if (e.Y == cell.Y) // e.Y <= cell.Y && e.Y >= RegionOfEatingUp
                            {
                                //cell.X = e.X;
                                //cell.Y = e.Y;
                                eat.RemoveAll(c => c == e);
                                cell.CountOfEating++;
                                cell.PathIsClear = true;
                                
                            }
                            else
                            {
                                cell.Y -= cell.Speed;
                                cell.PathIsClear = false;
                            }
                            
                        }
                        /* цель в первой четверти */
                        else if ((e.X >= cell.X && e.X <= viewRight) && (e.Y <= cell.Y && e.Y >= viewUp))
                        {
                            if ((e.X == cell.X) && (e.Y == cell.Y)) // (e.X >= cell.X && e.X <= RegionOfEatingRight) && (e.Y <= cell.Y && e.Y >= RegionOfEatingUp)
                            {
                                //cell.X = e.X;
                                //cell.Y = e.Y;
                                eat.RemoveAll(c => c == e);
                                cell.CountOfEating++;
                                cell.PathIsClear = true;
                                
                            }
                            else
                            {
                                cell.X += cell.Speed;
                                cell.Y -= cell.Speed;
                                cell.PathIsClear = false;
                            }
                            
                        }
                        /* цель во второй четверти */
                        else if ((e.X <= cell.X && e.X >= viewLeft) && (e.Y <= cell.Y && e.Y >= viewUp))
                        {
                            if ((e.X == cell.X) && (e.Y == cell.Y)) // (e.X <= cell.X && e.X >= RegionOfEatingLeft) && (e.Y <= cell.Y && e.Y >= RegionOfEatingUp)
                            {
                                //cell.X = e.X;
                                //cell.Y = e.Y;
                                eat.RemoveAll(c => c == e);
                                cell.CountOfEating++;
                                cell.PathIsClear = true;
                                
                            }
                            else
                            {
                                cell.X -= cell.Speed;
                                cell.Y -= cell.Speed;
                                cell.PathIsClear = false;
                            }
                            
                        }
                        /* цель в третьей четверти */
                        else if ((e.X <= cell.X && e.X >= viewLeft) && (e.Y >= cell.Y && e.Y <= viewDown))
                        {
                            if ((e.X == cell.X) && (e.Y == cell.Y)) // (e.X <= cell.X && e.X >= RegionOfEatingLeft) && (e.Y >= cell.Y && e.Y <= RegionOfEatingDown)
                            {
                                //cell.X = e.X;
                                //cell.Y = e.Y;
                                eat.RemoveAll(c => c == e);
                                cell.CountOfEating++;
                                cell.PathIsClear = true;
                                
                            }
                            else
                            {
                                cell.X -= cell.Speed;
                                cell.Y += cell.Speed;
                                cell.PathIsClear = false;
                            }
                            
                        }
                        /* цель в четвертой четверти */
                        else if ((e.X >= cell.X && e.X <= viewRight) && (e.Y >= cell.Y && e.Y <= viewDown))
                        {
                            if ((e.X == cell.X) && (e.Y == cell.Y)) // (e.X <= cell.X && e.X >= RegionOfEatingLeft) && (e.Y <= RegionOfEatingDown && e.Y <= cell.Y)
                            {
                                //cell.X = e.X;
                                //cell.Y = e.Y;
                                eat.RemoveAll(c => c == e);
                                cell.CountOfEating++;
                                cell.PathIsClear = true;
                                
                            }
                            else
                            {
                                cell.X += cell.Speed;
                                cell.Y += cell.Speed;
                                cell.PathIsClear = false;
                            }
                            
                        }
                        
                        
                    }
                }
                #region плотоядные
                //if (cell is CarnivorousLowCell || cell is CarnivorousMediumCell || cell is CarnivorousHighCell)
                //{
                //    foreach (var targetToEat in copycells.ToArray())
                //    {
                //        if (targetToEat == cell || targetToEat is HerbivoreLowCell || targetToEat is HerbivoreMediumCell || targetToEat is HerbivoreHighCell)
                //        {
                //            continue;
                //        }
                //        // targetToEat.X <= viewRight && targetToEat.X >= viewLeft && targetToEat.Y <= viewUp && targetToEat.Y >= viewDown
                //        /* цель справа на одном Y */
                //        else if (targetToEat.X <= viewRight && targetToEat.X >= cell.X && targetToEat.Y == cell.Y)
                //        {
                //            if (targetToEat.X <= RegionOfEatingRight && targetToEat.X >= cell.X) // cell.X == targetToEat.X && cell.Y == targetToEat.Y
                //            {
                //                if (targetToEat.HP <= 0)
                //                {
                //                    //cell.X = targetToEat.X;
                //                    //cell.Y = targetToEat.Y;
                //                    cells.RemoveAll(c => c == targetToEat);

                //                }
                //                else
                //                {
                //                    targetToEat.HP--;
                //                    cell.CountOfEating++;
                //                }
                //            }
                //            else
                //            {
                //                //a = rnd.Next(100);
                //                //if (a == 1)
                //                //{
                //                //    cell.X += cell.Speed;
                //                //}

                //            }
                //        }
                //        /* цель слева на одном Y */
                //        else if (targetToEat.X <= viewLeft && targetToEat.X <= cell.X && targetToEat.Y == cell.Y)
                //        {

                //            if (targetToEat.X <= RegionOfEatingLeft && targetToEat.X <= cell.X) // cell.X == targetToEat.X && cell.Y == targetToEat.Y
                //            {
                //                if (targetToEat.HP <= 0)
                //                {
                //                    //cell.X = targetToEat.X;
                //                    //cell.Y = targetToEat.Y;
                //                    cells.RemoveAll(c => c == targetToEat);

                //                }
                //                else
                //                {
                //                    targetToEat.HP--;
                //                    cell.CountOfEating++;
                //                }
                //            }
                //            else
                //            {
                //                //a = rnd.Next(100);
                //                //if (a == 1)
                //                //{
                //                //    cell.X -= cell.Speed;
                //                //}

                //            }

                //        }
                //        /* цель снизу на одном X */
                //        else if (targetToEat.Y <= viewDown && targetToEat.Y <= cell.Y && targetToEat.X == cell.X)
                //        {
                //            if (targetToEat.Y <= RegionOfEatingDown && targetToEat.Y <= cell.Y) // cell.X == targetToEat.X && cell.Y == targetToEat.Y
                //            {
                //                if (targetToEat.HP <= 0)
                //                {
                //                    //cell.X = targetToEat.X;
                //                    //cell.Y = targetToEat.Y;
                //                    cells.RemoveAll(c => c == targetToEat);

                //                }
                //                else
                //                {
                //                    targetToEat.HP--;
                //                    cell.CountOfEating++;
                //                }
                //            }
                //            else
                //            {
                //                //a = rnd.Next(100);
                //                //if (a == 1)
                //                //{
                //                //    cell.Y += cell.Speed;
                //                //}

                //            }
                //        }
                //        /* цель сверху на одном X */
                //        else if (targetToEat.Y <= viewUp && targetToEat.Y >= cell.Y && targetToEat.X == cell.X)
                //        {
                //            if (targetToEat.Y <= RegionOfEatingUp && targetToEat.Y >= cell.Y) // cell.X == targetToEat.X && cell.Y == targetToEat.Y
                //            {
                //                if (targetToEat.HP <= 0)
                //                {
                //                    //cell.X = targetToEat.X;
                //                    //cell.Y = targetToEat.Y;
                //                    cells.RemoveAll(c => c == targetToEat);

                //                }
                //                else
                //                {
                //                    targetToEat.HP--;
                //                    cell.CountOfEating++;
                //                }
                //            }
                //            else
                //            {
                //                //a = rnd.Next(100);
                //                //if (a == 1)
                //                //{
                //                //    cell.Y -= cell.Speed;
                //                //}

                //            }
                //        }
                //        /* цель в первой четверти */
                //        else if ((targetToEat.X <= viewRight && targetToEat.X >= cell.X) && (targetToEat.Y <= viewUp && targetToEat.Y >= cell.Y))
                //        {
                //            if ((targetToEat.X <= RegionOfEatingRight && targetToEat.X >= cell.X) && (targetToEat.Y <= RegionOfEatingUp && targetToEat.Y >= cell.Y)) // cell.X == targetToEat.X && cell.Y == targetToEat.Y
                //            {
                //                if (targetToEat.HP <= 0)
                //                {
                //                    //cell.X = targetToEat.X;
                //                    //cell.Y = targetToEat.Y;
                //                    cells.RemoveAll(c => c == targetToEat);

                //                }
                //                else
                //                {
                //                    targetToEat.HP--;
                //                    cell.CountOfEating++;
                //                }
                //            }
                //            else
                //            {
                //                //a = rnd.Next(100);
                //                //if (a == 1)
                //                //{
                //                //    cell.X += cell.Speed;
                //                //    cell.Y -= cell.Speed;
                //                //}

                //            }
                //        }
                //        /* цель во второй четверти */
                //        else if ((targetToEat.X <= viewLeft && targetToEat.X <= cell.X) && (targetToEat.Y <= viewUp && targetToEat.Y >= cell.Y))
                //        {
                //            if ((targetToEat.X <= RegionOfEatingLeft && targetToEat.X <= cell.X) && (targetToEat.Y <= RegionOfEatingUp && targetToEat.Y >= cell.Y)) // cell.X == targetToEat.X && cell.Y == targetToEat.Y
                //            {
                //                if (targetToEat.HP <= 0)
                //                {
                //                    //cell.X = targetToEat.X;
                //                    //cell.Y = targetToEat.Y;
                //                    cells.RemoveAll(c => c == targetToEat);

                //                }
                //                else
                //                {
                //                    targetToEat.HP--;
                //                    cell.CountOfEating++;
                //                }
                //            }
                //            else
                //            {
                //                //a = rnd.Next(100);
                //                //if (a == 1)
                //                //{
                //                //    cell.X -= cell.Speed;
                //                //    cell.Y += cell.Speed;
                //                //}

                //            }
                //        }
                //        /* цель в третьей четверти */
                //        else if ((targetToEat.X <= viewLeft && targetToEat.X <= cell.X) && (targetToEat.Y <= viewDown && targetToEat.Y <= cell.Y))
                //        {
                //            if ((targetToEat.X <= RegionOfEatingLeft && targetToEat.X <= cell.X) && (targetToEat.Y <= RegionOfEatingDown && targetToEat.Y <= cell.Y)) // cell.X == targetToEat.X && cell.Y == targetToEat.Y
                //            {
                //                if (targetToEat.HP <= 0)
                //                {
                //                    //cell.X = targetToEat.X;
                //                    //cell.Y = targetToEat.Y;
                //                    cells.RemoveAll(c => c == targetToEat);

                //                }
                //                else
                //                {
                //                    targetToEat.HP--;
                //                    cell.CountOfEating++;
                //                }
                //            }
                //            else
                //            {
                //                //a = rnd.Next(100);
                //                //if (a == 1)
                //                //{
                //                //    cell.X -= cell.Speed;
                //                //    cell.Y -= cell.Speed;
                //                //}

                //            }
                //        }
                //        /* цель в четвертой четверти */
                //        else if ((targetToEat.X <= viewRight && targetToEat.X >= cell.X) && (targetToEat.Y <= viewDown && targetToEat.Y <= cell.Y))
                //        {
                //            if ((targetToEat.X <= RegionOfEatingLeft && targetToEat.X >= cell.X) && (targetToEat.Y <= RegionOfEatingDown && targetToEat.Y <= cell.Y)) // cell.X == targetToEat.X && cell.Y == targetToEat.Y
                //            {
                //                if (targetToEat.HP <= 0)
                //                {
                //                    //cell.X = targetToEat.X;
                //                    //cell.Y = targetToEat.Y;
                //                    cells.RemoveAll(c => c == targetToEat);

                //                }
                //                else
                //                {
                //                    targetToEat.HP--;
                //                    cell.CountOfEating++;
                //                }
                //            }
                //            else
                //            {
                //                //a = rnd.Next(100);
                //                //if (a == 1)
                //                //{
                //                //    cell.X += cell.Speed;
                //                //    cell.Y += cell.Speed;
                //                //}

                //            }
                //        }
                //        else
                //        {
                //            break;
                //        }

                //    }

                //}
                #endregion

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
        public void CopyingList()
        {
            copycells.Clear();
            foreach(var cell in cells)
            {
                copycells.Add(cell);
            }
            cells.Clear();
        }
        public void AddingDeletingCellsThroughMouse(int MaxWidthField, int MaxHeightField, List<FormOfCell> cells)
        {
            cells.Add(new HerbivoreLowCell(MaxWidthField, MaxHeightField));
        }
    }
}