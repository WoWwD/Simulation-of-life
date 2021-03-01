using SimulatorOfLive.Logic.Abstract_model;
using SimulatorOfLive.Logic.Model;
using SimulatorOfLive.Logic.Model.Cell;
using System.Collections.Generic;

namespace SimulatorOfLive.Logic.Controller.Creatures
{
    public class Cell<T> where T: FormOfCell
    {
        public List<T> cells;
        public Cell()
        {
            cells = new List<T>();
        }
        public void Eating(int MaxWidthField, int MaxHeightField, List<Eat> eat) 
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
                        /* цель справа на одной высоте */
                        if (e.X >= cell.X && e.X <= viewRight && e.Y == cell.Y)
                        {
                            if (e.X >= cell.X && e.X <= RegionOfEatingRight)
                            {
                                eat.RemoveAll(c => c == e);
                                cell.Eating();
                                cell.PathIsClear = true;
                                break;
                            }
                            else
                            {
                                cell.Move(MaxWidthField, MaxHeightField, 1);
                                cell.PathIsClear = false;
                                break;
                            }
                        }
                        /* цель слева на одной высоте */
                        if (e.X <= cell.X && e.X >= viewLeft && e.Y == cell.Y)
                        {
                            if (e.X <= cell.X && e.X >= RegionOfEatingLeft)
                            {
                                eat.RemoveAll(c => c == e);
                                cell.Eating();
                                cell.PathIsClear = true;
                                break;
                            }
                            else
                            {
                                cell.Move(MaxWidthField, MaxHeightField, 2);
                                cell.PathIsClear = false;
                                break;
                            }
                        }
                        /* цель снизу на одной ширине */
                        if (e.Y >= cell.Y && e.Y <= viewDown && e.X == cell.X)
                        {
                            if (e.Y >= cell.Y && e.Y <= RegionOfEatingDown)
                            {
                                eat.RemoveAll(c => c == e);
                                cell.Eating();
                                cell.PathIsClear = true;
                                break;
                            }
                            else
                            {
                                cell.Move(MaxWidthField, MaxHeightField, 3);
                                cell.PathIsClear = false;
                                break;
                            }
                        }
                        /* цель сверху на одной ширине */
                        if (e.Y <= cell.Y && e.Y >= viewUp && e.X == cell.X)
                        {
                            if (e.Y <= cell.Y && e.Y >= RegionOfEatingUp)
                            {
                                eat.RemoveAll(c => c == e);
                                cell.Eating();
                                cell.PathIsClear = true;
                                break;
                            }
                            else
                            {
                                cell.Move(MaxWidthField, MaxHeightField, 4);
                                cell.PathIsClear = false;
                                break;
                            }
                        }
                        /* цель в первой четверти */
                        if ((e.X >= cell.X && e.X <= viewRight) && (e.Y <= cell.Y && e.Y >= viewUp))
                        {
                            if ((e.X >= cell.X && e.X <= RegionOfEatingRight) && (e.Y <= cell.Y && e.Y >= RegionOfEatingUp))
                            {
                                eat.RemoveAll(c => c == e);
                                cell.Eating();
                                cell.PathIsClear = true;
                                break;
                            }
                            else
                            {
                                cell.Move(MaxWidthField, MaxHeightField, 5);
                                cell.PathIsClear = false;
                                break;
                            }
                        }
                        /* цель во второй четверти */
                        if ((e.X <= cell.X && e.X >= viewLeft) && (e.Y <= cell.Y && e.Y >= viewUp))
                        {
                            if ((e.X <= cell.X && e.X >= RegionOfEatingLeft) && (e.Y <= cell.Y && e.Y >= RegionOfEatingUp))
                            {
                                eat.RemoveAll(c => c == e);
                                cell.Eating();
                                cell.PathIsClear = true;
                                break;
                            }
                            else
                            {
                                cell.Move(MaxWidthField, MaxHeightField, 6);
                                cell.PathIsClear = false;
                                break;
                            }
                        }
                        /* цель в третьей четверти */
                        if ((e.X <= cell.X && e.X >= viewLeft) && (e.Y >= cell.Y && e.Y <= viewDown))
                        {
                            if ((e.X <= cell.X && e.X >= RegionOfEatingLeft) && (e.Y >= cell.Y && e.Y <= RegionOfEatingDown))
                            {
                                eat.RemoveAll(c => c == e);
                                cell.Eating();
                                cell.PathIsClear = true;
                                break;
                            }
                            else
                            {
                                cell.Move(MaxWidthField, MaxHeightField, 7);
                                cell.PathIsClear = false;
                                break;
                            }
                        }
                        /* цель в четвертой четверти */
                        if ((e.X >= cell.X && e.X <= viewRight) && (e.Y >= cell.Y && e.Y <= viewDown))
                        {
                            if ((e.X >= cell.X && e.X <= RegionOfEatingRight) && (e.Y >= cell.Y && e.Y <= RegionOfEatingDown))
                            {
                                eat.RemoveAll(c => c == e);
                                cell.Eating();
                                cell.PathIsClear = true;
                                break;
                            }
                            else
                            {
                                cell.Move(MaxWidthField, MaxHeightField, 8);
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
                        if (targetToEat.X >= cell.X && targetToEat.X <= viewRight && targetToEat.Y == cell.Y)
                        {
                            if (targetToEat.X >= cell.X && targetToEat.X <= RegionOfEatingRight)
                            {
                                if (targetToEat.HitPoint <= 0)
                                {
                                    cells.RemoveAll(c => c == targetToEat);
                                    cell.Eating();
                                }
                                else
                                {
                                    targetToEat.ReceiveDamage();
                                }
                            }
                            else
                            {
                                if (SettingsGame.rnd.Next(SettingsGame.ChanceOfPursuit) == 1)
                                {
                                    cell.Move(MaxWidthField, MaxHeightField, 1);
                                    cell.PathIsClear = false;
                                    break;
                                }
                            }
                        }
                        /* цель слева на одной высоте */
                        if (targetToEat.X <= cell.X && targetToEat.X >= viewLeft && targetToEat.Y == cell.Y)
                        {
                            if (targetToEat.X <= cell.X && targetToEat.X >= RegionOfEatingLeft)
                            {
                                if (targetToEat.HitPoint <= 0)
                                {
                                    cells.RemoveAll(c => c == targetToEat);
                                    cell.Eating();
                                }
                                else
                                {
                                    targetToEat.ReceiveDamage();
                                }
                            }
                            else
                            {
                                if (SettingsGame.rnd.Next(SettingsGame.ChanceOfPursuit) == 1)
                                {
                                    cell.Move(MaxWidthField, MaxHeightField, 2);
                                    cell.PathIsClear = false;
                                    break;
                                }
                            }
                        }
                        /* цель снизу на одной ширине */
                        if (targetToEat.Y >= cell.Y && targetToEat.Y <= viewDown && targetToEat.X == cell.X)
                        {
                            if (targetToEat.Y >= cell.Y && targetToEat.Y <= RegionOfEatingDown)
                            {
                                if (targetToEat.HitPoint <= 0)
                                {
                                    cells.RemoveAll(c => c == targetToEat);
                                    cell.Eating();
                                }
                                else
                                {
                                    targetToEat.ReceiveDamage();
                                }
                            }
                            else
                            {
                                if (SettingsGame.rnd.Next(SettingsGame.ChanceOfPursuit) == 1)
                                {
                                    cell.Move(MaxWidthField, MaxHeightField, 3);
                                    cell.PathIsClear = false;
                                    break;
                                }

                            }
                        }
                        /* цель сверху на одном X */
                        if (targetToEat.Y <= cell.Y && targetToEat.Y >= viewUp && targetToEat.X == cell.X)
                        {
                            if (targetToEat.Y <= cell.Y && targetToEat.Y >= RegionOfEatingUp)
                            {
                                if (targetToEat.HitPoint <= 0)
                                {
                                    cells.RemoveAll(c => c == targetToEat);
                                    cell.Eating();
                                }
                                else
                                {
                                    targetToEat.ReceiveDamage();
                                }
                            }
                            else
                            {
                                if (SettingsGame.rnd.Next(SettingsGame.ChanceOfPursuit) == 1)
                                {
                                    cell.Move(MaxWidthField, MaxHeightField, 4);
                                    cell.PathIsClear = false;
                                    break;
                                }
                            }
                        }
                        /* цель в первой четверти */
                        if ((targetToEat.X >= cell.X && targetToEat.X <= viewRight) && (targetToEat.Y <= cell.Y && targetToEat.Y >= viewUp))
                        {
                            if ((targetToEat.X >= cell.X && targetToEat.X <= RegionOfEatingRight) && (targetToEat.Y <= cell.Y && targetToEat.Y >= RegionOfEatingUp))
                            {
                                if (targetToEat.HitPoint <= 0)
                                {
                                    cells.RemoveAll(c => c == targetToEat);
                                    cell.Eating();
                                }
                                else
                                {
                                    targetToEat.ReceiveDamage();
                                }
                            }
                            else
                            {
                                if (SettingsGame.rnd.Next(SettingsGame.ChanceOfPursuit) == 1)
                                {
                                    cell.Move(MaxWidthField, MaxHeightField, 5);
                                    cell.PathIsClear = false;
                                    break;
                                }

                            }
                        }
                        /* цель во второй четверти */
                        if ((targetToEat.X <= cell.X && targetToEat.X >= viewLeft) && (targetToEat.Y <= cell.Y && targetToEat.Y >= viewUp))
                        {
                            if ((targetToEat.X <= cell.X && targetToEat.X >= RegionOfEatingLeft) && (targetToEat.Y <= cell.Y && targetToEat.Y >= RegionOfEatingUp))
                            {
                                if (targetToEat.HitPoint <= 0)
                                {
                                    cells.RemoveAll(c => c == targetToEat);
                                    cell.Eating();
                                }
                                else
                                {
                                    targetToEat.ReceiveDamage();
                                }
                            }
                            else
                            {
                                if (SettingsGame.rnd.Next(SettingsGame.ChanceOfPursuit) == 1)
                                {
                                    cell.Move(MaxWidthField, MaxHeightField, 6);
                                    cell.PathIsClear = false;
                                    break;
                                }

                            }
                        }
                        /* цель в третьей четверти */
                        if ((targetToEat.X <= cell.X && targetToEat.X >= viewLeft) && (targetToEat.Y >= cell.Y && targetToEat.Y <= viewDown))
                        {
                            if ((targetToEat.X <= cell.X && targetToEat.X >= RegionOfEatingLeft) && (targetToEat.Y >= cell.Y && targetToEat.Y <= RegionOfEatingDown))
                            {
                                if (targetToEat.HitPoint <= 0)
                                {
                                    cells.RemoveAll(c => c == targetToEat);
                                    cell.Eating();
                                }
                                else
                                {
                                    targetToEat.ReceiveDamage();
                                }
                            }
                            else
                            {
                                if (SettingsGame.rnd.Next(SettingsGame.ChanceOfPursuit) == 1)
                                {
                                    cell.Move(MaxWidthField, MaxHeightField, 7);
                                    cell.PathIsClear = false;
                                    break;
                                }
                            }
                        }
                        /* цель в четвертой четверти */
                        if ((targetToEat.X >= cell.X && targetToEat.X <= viewRight) && (targetToEat.Y >= cell.Y && targetToEat.Y <= viewDown))
                        {
                            if ((targetToEat.X >= cell.X && targetToEat.X <= RegionOfEatingRight) && (targetToEat.Y >= cell.Y && targetToEat.Y <= RegionOfEatingDown))
                            {
                                if (targetToEat.HitPoint <= 0)
                                {
                                    cells.RemoveAll(c => c == targetToEat);
                                    cell.Eating();
                                }
                                else
                                {
                                    targetToEat.ReceiveDamage();
                                }
                            }
                            else
                            {
                                if (SettingsGame.rnd.Next(SettingsGame.ChanceOfPursuit) == 1)
                                {
                                    cell.Move(MaxWidthField, MaxHeightField, 8);
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
            int X, Y;
            foreach (var cell in cells.ToArray())
            {
                if (cell is CarnivorousLowCell)
                {
                    if (cell.CountOfEating >= 2)
                    {
                        if (SettingsGame.rnd.Next(SettingsGame.ChanceOfEvolutionCarnivorousLowCell) == 1)
                        {
                            X = cell.X;
                            Y = cell.Y;
                            cells.RemoveAll(c => c == cell);
                            AddCell(new CarnivorousMediumCell(X, Y));
                        }
                    }
                }
                if (cell is CarnivorousMediumCell)
                {
                    if (cell.CountOfEating >= 4)
                    {
                        if (SettingsGame.rnd.Next(SettingsGame.ChanceOfEvolutionCarnivorousMediumCell) == 1)
                        {
                            X = cell.X;
                            Y = cell.Y;
                            cells.RemoveAll(c => c == cell);
                            AddCell(new CarnivorousHighCell(X, Y));
                        }
                    }

                }
                if (cell is HerbivoreLowCell)
                {
                    if (cell.CountOfEating >= 3)
                    {
                        if (SettingsGame.rnd.Next(SettingsGame.ChanceOfEvolutionHerbivoreLowCell) == 1)
                        {
                            X = cell.X;
                            Y = cell.Y;
                            cells.RemoveAll(c => c == cell);
                            AddCell(new HerbivoreMediumCell(X, Y));
                        }
                    }
                }
                if (cell is HerbivoreMediumCell)
                {
                    if (cell.CountOfEating >= 3)
                    {
                        if (SettingsGame.rnd.Next(SettingsGame.ChanceOfEvolutionHerbivoreMediumCell) == 1)
                        {
                            X = cell.X;
                            Y = cell.Y;
                            cells.RemoveAll(c => c == cell);
                            AddCell(new HerbivoreHighCell(X, Y));
                        }
                    }
                }
            }
        }
        public void AddCell(FormOfCell item)
        {
            cells.Add((T)item);
        }
        public void Move(int MaxWidthField, int MaxHeightField)
        {
            foreach (FormOfCell cell in cells)
            {
                cell.Move(MaxWidthField, MaxHeightField, SettingsGame.rnd.Next(SettingsGame.SpeedOfGame));
            }
        }
        public void AddFirstCells(int count, int MaxWidthField, int MaxHeightField)
        {
            int a;
            for (int i = 0; i < count; i++)
            {
                a = SettingsGame.rnd.Next(10);
                if (a == 1)
                {
                    AddCell(new HerbivoreLowCell(SettingsGame.rnd.Next(MaxWidthField), SettingsGame.rnd.Next(MaxHeightField)));
                    continue;
                }
                AddCell(new CarnivorousLowCell(SettingsGame.rnd.Next(MaxWidthField), SettingsGame.rnd.Next(MaxHeightField)));
            }
        }
    }
}