using SimulatorOfLive.Logic.Abstract_model;
using SimulatorOfLive.Logic.Model;
using SimulatorOfLive.Logic.Model.Cell;
using System;
using System.Collections.Generic;

namespace SimulatorOfLive.Logic.Controller
{
    public class Controller
    {
        public const int ChanceOfPursuit = 1000;
        public Random rnd = new Random();
        public const int SpeedOfGame = 9;
        public List<FormOfCell> cells = new List<FormOfCell>();
        public List<FormOfCell> copycells = new List<FormOfCell>();
        public List<Eat> eat = new List<Eat>();
        
        public void MoveCells(int MaxWidthField, int MaxHeightField)
        {
            foreach (FormOfCell cell in cells)
            {
                cell.Move(MaxWidthField, MaxHeightField, rnd.Next(SpeedOfGame));
            }
        }
        public void AddFirstCells(int count, int MaxWidthField, int MaxHeightField)
        {
            int a;
            for (int i = 0; i < count; i++)
            {
                a = rnd.Next(10);
                if (a == 1)
                {
                    cells.Add(new HerbivoreLowCell(rnd.Next(MaxWidthField), rnd.Next(MaxHeightField)));
                    continue;
                }
                cells.Add(new CarnivorousLowCell(rnd.Next(MaxWidthField), rnd.Next(MaxHeightField)));
            }
        }
        public void AddEat(int MaxWidthField, int MaxHeightField)
        {
            if (rnd.Next(30) == 1)
            {
                eat.Add(new Eat(rnd.Next(MaxWidthField), rnd.Next(MaxHeightField)));
            }
        }
        public void Eating()
        {
            int viewRight, viewLeft, viewUp, viewDown, RegionOfEatingLeft, RegionOfEatingRight, RegionOfEatingUp, RegionOfEatingDown;
            foreach (var cell in cells.ToArray())
            {
                RegionOfEatingRight = cell.X + cell.RegionOfEating;
                RegionOfEatingLeft = cell.X - cell.RegionOfEating;
                RegionOfEatingUp = cell.Y - cell.RegionOfEating;
                RegionOfEatingDown = cell.Y + cell.RegionOfEating;
                viewRight = cell.X + cell.Overview;
                viewLeft = cell.X - cell.Overview;
                viewUp = cell.Y - cell.Overview;
                viewDown = cell.Y + cell.Overview;

                #region Травоядные
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
                            if (e.X >= cell.X && e.X <= RegionOfEatingRight) 
                            {
                                //cell.X = e.X;
                                //cell.Y = e.Y;
                                eat.RemoveAll(c => c == e);
                                cell.CountOfEating++;
                                cell.PathIsClear = true;
                                break;
                            }
                            else
                            {
                                cell.X += cell.Speed;
                                cell.PathIsClear = false;
                                break;
                            }
                        }
                        /* цель слева на одной высоте */
                        else if (e.X <= cell.X &&  e.X >= viewLeft && e.Y == cell.Y)
                        {
                            if (e.X <= cell.X && e.X >= RegionOfEatingLeft) // e.X == cell.X
                            {
                                //cell.X = e.X;
                                //cell.Y = e.Y;
                                eat.RemoveAll(c => c == e);
                                cell.CountOfEating++;
                                cell.PathIsClear = true;
                                break;
                            }
                            else
                            {
                                cell.X -= cell.Speed;
                                cell.PathIsClear = false;
                                break;
                            } 
                        }
                        /* цель снизу на одной ширине */
                        else if (e.Y >= cell.Y && e.Y <= viewDown && e.X == cell.X)
                        {
                            if (e.Y >= cell.Y && e.Y <= RegionOfEatingDown) // e.Y == cell.Y
                            {
                                //cell.X = e.X;
                                //cell.Y = e.Y;
                                eat.RemoveAll(c => c == e);
                                cell.CountOfEating++;
                                cell.PathIsClear = true;
                                break;
                            }
                            else
                            {
                                cell.Y += cell.Speed;
                                cell.PathIsClear = false;
                                break;
                            }
                        }
                        /* цель сверху на одной ширине */
                        else if (e.Y <= cell.Y && e.Y >= viewUp && e.X == cell.X)
                        {
                            if (e.Y <= cell.Y && e.Y >= RegionOfEatingUp) // e.Y == cell.Y
                            {
                                //cell.X = e.X;
                                //cell.Y = e.Y;
                                eat.RemoveAll(c => c == e);
                                cell.CountOfEating++;
                                cell.PathIsClear = true;
                                break;
                            }
                            else
                            {
                                cell.Y -= cell.Speed;
                                cell.PathIsClear = false;
                                break;
                            }  
                        }
                        /* цель в первой четверти */
                        else if ((e.X >= cell.X && e.X <= viewRight) && (e.Y <= cell.Y && e.Y >= viewUp))
                        {
                            if ((e.X >= cell.X && e.X <= RegionOfEatingRight) && (e.Y <= cell.Y && e.Y >= RegionOfEatingUp)) // (e.X == cell.X) && (e.Y == cell.Y)
                            {
                                //cell.X = e.X;
                                //cell.Y = e.Y;
                                eat.RemoveAll(c => c == e);
                                cell.CountOfEating++;
                                cell.PathIsClear = true;
                                break;
                            }
                            else
                            {
                                cell.X += cell.Speed;
                                cell.Y -= cell.Speed;
                                cell.PathIsClear = false;
                                break;
                            }       
                        }
                        /* цель во второй четверти */
                        else if ((e.X <= cell.X && e.X >= viewLeft) && (e.Y <= cell.Y && e.Y >= viewUp))
                        {
                            if ((e.X <= cell.X && e.X >= RegionOfEatingLeft) && (e.Y <= cell.Y && e.Y >= RegionOfEatingUp)) // (e.X == cell.X) && (e.Y == cell.Y)
                            {
                                //cell.X = e.X;
                                //cell.Y = e.Y;
                                eat.RemoveAll(c => c == e);
                                cell.CountOfEating++;
                                cell.PathIsClear = true;
                                break;
                            }
                            else
                            {
                                cell.X -= cell.Speed;
                                cell.Y -= cell.Speed;
                                cell.PathIsClear = false;
                                break;
                            }   
                        }
                        /* цель в третьей четверти */
                        else if ((e.X <= cell.X && e.X >= viewLeft) && (e.Y >= cell.Y && e.Y <= viewDown))
                        {
                            if ((e.X <= cell.X && e.X >= RegionOfEatingLeft) && (e.Y >= cell.Y && e.Y <= RegionOfEatingDown)) // (e.X == cell.X) && (e.Y == cell.Y)
                            {
                                //cell.X = e.X;
                                //cell.Y = e.Y;
                                eat.RemoveAll(c => c == e);
                                cell.CountOfEating++;
                                cell.PathIsClear = true;
                                break;
                            }
                            else
                            {
                                cell.X -= cell.Speed;
                                cell.Y += cell.Speed;
                                cell.PathIsClear = false;
                                break;
                            }        
                        }
                        /* цель в четвертой четверти */
                        else if ((e.X >= cell.X && e.X <= viewRight) && (e.Y >= cell.Y && e.Y <= viewDown))
                        {
                            if ((e.X >= cell.X && e.X <= RegionOfEatingRight) && (e.Y >= cell.Y && e.Y <= RegionOfEatingDown)) // (e.X == cell.X) && (e.Y == cell.Y)
                            {
                                //cell.X = e.X;
                                //cell.Y = e.Y;
                                eat.RemoveAll(c => c == e);
                                cell.CountOfEating++;
                                cell.PathIsClear = true;
                                break;
                            }
                            else
                            {
                                cell.X += cell.Speed;
                                cell.Y += cell.Speed;
                                cell.PathIsClear = false;
                                break;
                            } 
                        }  
                    }
                }
                #endregion

                #region Плотоядные
                if (cell is CarnivorousLowCell || cell is CarnivorousMediumCell || cell is CarnivorousHighCell)
                {
                    foreach (var targetToEat in cells.ToArray())
                    {
                        if (targetToEat == cell || targetToEat is HerbivoreLowCell || targetToEat is HerbivoreMediumCell || targetToEat is HerbivoreHighCell)
                        {
                            continue;
                        }
                        /* цель справа на одной высоте */
                        else if (targetToEat.X >= cell.X && targetToEat.X <= viewRight && targetToEat.Y == cell.Y)
                        {
                            if (targetToEat.X >= cell.X && targetToEat.X <= RegionOfEatingRight)
                            {
                                if (targetToEat.HitPoint <= 0)
                                {
                                    cells.RemoveAll(c => c == targetToEat);
                                    cell.CountOfEating++;
                                }
                                else
                                {
                                    targetToEat.HitPoint--;
                                }
                            }
                            else
                            {
                                if(rnd.Next(ChanceOfPursuit) == 1)
                                {
                                    cell.X += cell.Speed;
                                    cell.PathIsClear = false;
                                    break;
                                }
                            }
                        }
                        /* цель слева на одной высоте */
                        else if (targetToEat.X <= cell.X && targetToEat.X >= viewLeft && targetToEat.Y == cell.Y)
                        {
                            if (targetToEat.X <= cell.X && targetToEat.X >= RegionOfEatingLeft) 
                            {
                                if (targetToEat.HitPoint <= 0)
                                {
                                    cells.RemoveAll(c => c == targetToEat);
                                    cell.CountOfEating++;
                                }
                                else
                                {
                                    targetToEat.HitPoint--;
                                }
                            }
                            else
                            {
                                if (rnd.Next(ChanceOfPursuit) == 1)
                                {
                                    cell.X -= cell.Speed;
                                    cell.PathIsClear = false;
                                    break;
                                }
                            }
                        }
                        /* цель снизу на одной ширине */
                        else if (targetToEat.Y >= cell.Y && targetToEat.Y <= viewDown && targetToEat.X == cell.X)
                        {
                            if (targetToEat.Y >= cell.Y && targetToEat.Y <= RegionOfEatingDown) 
                            {
                                if (targetToEat.HitPoint <= 0)
                                {
                                    cells.RemoveAll(c => c == targetToEat);
                                    cell.CountOfEating++;
                                }
                                else
                                {
                                    targetToEat.HitPoint--;
                                }
                            }
                            else
                            {
                                if (rnd.Next(ChanceOfPursuit) == 1)
                                {
                                    cell.Y += cell.Speed;
                                    cell.PathIsClear = false;
                                    break;
                                }
                                
                            }
                        }
                        /* цель сверху на одном X */
                        else if (targetToEat.Y <= cell.Y && targetToEat.Y >= viewUp && targetToEat.X == cell.X)
                        {
                            if (targetToEat.Y <= cell.Y && targetToEat.Y >= RegionOfEatingUp)
                            {
                                if (targetToEat.HitPoint <= 0)
                                {
                                    cells.RemoveAll(c => c == targetToEat);
                                    cell.CountOfEating++;
                                }
                                else
                                {
                                    targetToEat.HitPoint--;
                                }
                            }
                            else
                            {
                                if (rnd.Next(ChanceOfPursuit) == 1)
                                {
                                    cell.Y -= cell.Speed;
                                    cell.PathIsClear = false;
                                    break;
                                }
                            }
                        }
                        /* цель в первой четверти */
                        else if ((targetToEat.X >= cell.X && targetToEat.X <= viewRight) && (targetToEat.Y <= cell.Y && targetToEat.Y >= viewUp))
                        {
                            if ((targetToEat.X >= cell.X && targetToEat.X <= RegionOfEatingRight) && (targetToEat.Y <= cell.Y && targetToEat.Y >= RegionOfEatingUp))
                            {
                                if (targetToEat.HitPoint <= 0)
                                {
                                    cells.RemoveAll(c => c == targetToEat);
                                    cell.CountOfEating++;
                                }
                                else
                                {
                                    targetToEat.HitPoint--;
                                }
                            }
                            else
                            {
                                if (rnd.Next(ChanceOfPursuit) == 1)
                                {
                                    cell.X += cell.Speed;
                                    cell.Y -= cell.Speed;
                                    cell.PathIsClear = false;
                                    break;
                                }
                                
                            }
                        }
                        /* цель во второй четверти */
                        else if ((targetToEat.X <= cell.X && targetToEat.X >= viewLeft) && (targetToEat.Y <= cell.Y && targetToEat.Y >= viewUp))
                        {
                            if ((targetToEat.X <= cell.X && targetToEat.X >= RegionOfEatingLeft) && (targetToEat.Y <= cell.Y && targetToEat.Y >= RegionOfEatingUp)) 
                            {
                                if (targetToEat.HitPoint <= 0)
                                {
                                    cells.RemoveAll(c => c == targetToEat);
                                    cell.CountOfEating++;
                                }
                                else
                                {
                                    targetToEat.HitPoint--;
                                }
                            }
                            else
                            {
                                if (rnd.Next(ChanceOfPursuit) == 1)
                                {
                                    cell.X -= cell.Speed;
                                    cell.Y -= cell.Speed;
                                    cell.PathIsClear = false;
                                    break;
                                }
                                
                            }
                        }
                        /* цель в третьей четверти */
                        else if ((targetToEat.X <= cell.X && targetToEat.X >= viewLeft) && (targetToEat.Y >= cell.Y && targetToEat.Y <= viewDown))
                        {
                            if ((targetToEat.X <= cell.X && targetToEat.X >= RegionOfEatingLeft) && (targetToEat.Y >= cell.Y && targetToEat.Y <= RegionOfEatingDown)) 
                            {
                                if (targetToEat.HitPoint <= 0)
                                {
                                    cells.RemoveAll(c => c == targetToEat);
                                    cell.CountOfEating++;
                                }
                                else
                                {
                                    targetToEat.HitPoint--;
                                }
                            }
                            else
                            {
                                if (rnd.Next(ChanceOfPursuit) == 1)
                                {
                                    cell.X -= cell.Speed;
                                    cell.Y += cell.Speed;
                                    cell.PathIsClear = false;
                                    break;
                                }
                            }
                        }
                        /* цель в четвертой четверти */
                        else if ((targetToEat.X >= cell.X && targetToEat.X <= viewRight) && (targetToEat.Y >= cell.Y && targetToEat.Y <= viewDown))
                        {
                            if ((targetToEat.X >= cell.X && targetToEat.X <= RegionOfEatingRight) && (targetToEat.Y >= cell.Y && targetToEat.Y <= RegionOfEatingDown)) 
                            {
                                if (targetToEat.HitPoint <= 0)
                                {
                                    cells.RemoveAll(c => c == targetToEat);
                                    cell.CountOfEating++;
                                }
                                else
                                {
                                    targetToEat.HitPoint--;
                                }
                            }
                            else
                            {
                                if (rnd.Next(ChanceOfPursuit) == 1)
                                {
                                    cell.X += cell.Speed;
                                    cell.Y += cell.Speed;
                                    cell.PathIsClear = false;
                                    break;
                                }
                            }
                        }
                    }
                }
                #endregion
            }
        }
        public void Evolution()
        {
            Random rnd = new Random();
            int X, Y;
            foreach (var cell in cells.ToArray())
            {
                if (cell is CarnivorousLowCell)
                {
                    if (cell.CountOfEating >= 2)
                    {
                        if (rnd.Next(10) == 1)
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
                        if (rnd.Next(10) == 1)
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
                        if (rnd.Next(10) == 1)
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
                        if (rnd.Next(10) == 1)
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
        public void AddCellsThroughMouse(int X, int Y)
        {
            cells.Add(new CarnivorousLowCell(X, Y));
        }
        public void AddEatThroughMouse(int X, int Y)
        {
            eat.Add(new Eat(X, Y));
        }
    }
}