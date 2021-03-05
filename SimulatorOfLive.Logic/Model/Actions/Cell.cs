using SimulatorOfLive.Logic.Abstract_model;
using SimulatorOfLive.Logic.Model;
using SimulatorOfLive.Logic.Model.Cell;
using System.Collections.Generic;

namespace SimulatorOfLive.Logic.Controller.Creatures
{
    public class Cell<T> where T : FormOfCell
    {
        public List<T> cells;
        public Cell()
        {
            cells = new List<T>();
        }
        public void Eating(int MaxWidthField, int MaxHeightField, List<Eat> eat)
        {
            int viewRight, viewLeft, viewUp, viewDown, RegionOfEatingLeft, RegionOfEatingRight, RegionOfEatingUp, RegionOfEatingDown, index;
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
                    //foreach (var e in eat.ToArray())
                    //{
                    //    /* цель справа на одной высоте */
                    //    if (e.X >= cell.X && e.X <= viewRight && e.Y == cell.Y)
                    //    {
                    //        if (e.X >= cell.X && e.X <= RegionOfEatingRight)
                    //        {
                    //            eat.RemoveAll(c => c == e);
                    //            cell.Eating();
                    //            cell.PathIsClear = true;
                    //            break;

                    //        }
                    //        else
                    //        {
                    //            cell.Move(MaxWidthField, MaxHeightField, 1);
                    //            cell.PathIsClear = false;
                    //            break;
                    //        }
                    //    }
                    //    /* цель слева на одной высоте */
                    //    if (e.X <= cell.X && e.X >= viewLeft && e.Y == cell.Y)
                    //    {
                    //        if (e.X <= cell.X && e.X >= RegionOfEatingLeft)
                    //        {
                    //            eat.RemoveAll(c => c == e);
                    //            cell.Eating();
                    //            cell.PathIsClear = true;
                    //            break;
                    //        }
                    //        else
                    //        {
                    //            cell.Move(MaxWidthField, MaxHeightField, 2);
                    //            cell.PathIsClear = false;
                    //            break;
                    //        }
                    //    }
                    //    /* цель снизу на одной ширине */
                    //    if (e.Y >= cell.Y && e.Y <= viewDown && e.X == cell.X)
                    //    {
                    //        if (e.Y >= cell.Y && e.Y <= RegionOfEatingDown)
                    //        {
                    //            eat.RemoveAll(c => c == e);
                    //            cell.Eating();
                    //            cell.PathIsClear = true;
                    //            break;
                    //        }
                    //        else
                    //        {
                    //            cell.Move(MaxWidthField, MaxHeightField, 3);
                    //            cell.PathIsClear = false;
                    //            break;
                    //        }
                    //    }
                    //    /* цель сверху на одной ширине */
                    //    if (e.Y <= cell.Y && e.Y >= viewUp && e.X == cell.X)
                    //    {
                    //        if (e.Y <= cell.Y && e.Y >= RegionOfEatingUp)
                    //        {
                    //            eat.RemoveAll(c => c == e);
                    //            cell.Eating();
                    //            cell.PathIsClear = true;
                    //            break;
                    //        }
                    //        else
                    //        {
                    //            cell.Move(MaxWidthField, MaxHeightField, 4);
                    //            cell.PathIsClear = false;
                    //            break;
                    //        }
                    //    }
                    //    /* цель в первой четверти */
                    //    if ((e.X >= cell.X && e.X <= viewRight) && (e.Y <= cell.Y && e.Y >= viewUp))
                    //    {
                    //        if ((e.X >= cell.X && e.X <= RegionOfEatingRight) && (e.Y <= cell.Y && e.Y >= RegionOfEatingUp))
                    //        {
                    //            eat.RemoveAll(c => c == e);
                    //            cell.Eating();
                    //            cell.PathIsClear = true;
                    //            break;
                    //        }
                    //        else
                    //        {
                    //            cell.Move(MaxWidthField, MaxHeightField, 5);
                    //            cell.PathIsClear = false;
                    //            break;
                    //        }
                    //    }
                    //    /* цель во второй четверти */
                    //    if ((e.X <= cell.X && e.X >= viewLeft) && (e.Y <= cell.Y && e.Y >= viewUp))
                    //    {
                    //        if ((e.X <= cell.X && e.X >= RegionOfEatingLeft) && (e.Y <= cell.Y && e.Y >= RegionOfEatingUp))
                    //        {
                    //            eat.RemoveAll(c => c == e);
                    //            cell.Eating();
                    //            cell.PathIsClear = true;
                    //            break;
                    //        }
                    //        else
                    //        {
                    //            cell.Move(MaxWidthField, MaxHeightField, 6);
                    //            cell.PathIsClear = false;
                    //            break;
                    //        }
                    //    }
                    //    /* цель в третьей четверти */
                    //    if ((e.X <= cell.X && e.X >= viewLeft) && (e.Y >= cell.Y && e.Y <= viewDown))
                    //    {
                    //        if ((e.X <= cell.X && e.X >= RegionOfEatingLeft) && (e.Y >= cell.Y && e.Y <= RegionOfEatingDown))
                    //        {
                    //            eat.RemoveAll(c => c == e);
                    //            cell.Eating();
                    //            cell.PathIsClear = true;
                    //            break;
                    //        }
                    //        else
                    //        {
                    //            cell.Move(MaxWidthField, MaxHeightField, 7);
                    //            cell.PathIsClear = false;
                    //            break;
                    //        }
                    //    }
                    //    /* цель в четвертой четверти */
                    //    if ((e.X >= cell.X && e.X <= viewRight) && (e.Y >= cell.Y && e.Y <= viewDown))
                    //    {
                    //        if ((e.X >= cell.X && e.X <= RegionOfEatingRight) && (e.Y >= cell.Y && e.Y <= RegionOfEatingDown))
                    //        {
                    //            eat.RemoveAll(c => c == e);
                    //            cell.Eating();
                    //            cell.PathIsClear = true;
                    //            break;
                    //        }
                    //        else
                    //        {
                    //            cell.Move(MaxWidthField, MaxHeightField, 8);
                    //            cell.PathIsClear = false;
                    //            break;
                    //        }
                    //    }
                    //}
                }
                #endregion

                #region Плотоядные
                if (cell is CarnivorousLowCell || cell is CarnivorousMediumCell || cell is CarnivorousHighCell)
                {
                    foreach(var targetToEat in cells.ToArray())
                    {
                        if (targetToEat.ID == cell.ID)
                        {
                            continue;
                        }
                        var r = cell.Eating(MaxWidthField, MaxHeightField, targetToEat);
                        if (r == true)
                        {
                            index = cells.LastIndexOf(targetToEat);
                            cells.RemoveAt(index);
                        }
                    }
                }
                #endregion

                #region Всеядные
                if (cell is OmnivoreLowCell || cell is OmnivoreMediumCell || cell is OmnivoreHighCell)
                {
                    foreach (var targetToEat in cells.ToArray())
                    {
                        if (targetToEat.ID == cell.ID)
                        {
                            continue;
                        }
                        var r = cell.Eating(MaxWidthField, MaxHeightField, targetToEat);
                        if (r == true)
                        {
                            index = cells.LastIndexOf(targetToEat);
                            cells.RemoveAt(index);
                        }
                    }
                    //foreach (var e in eat.ToArray())
                    //{
                    //    /* цель справа на одной высоте */
                    //    if (e.X >= cell.X && e.X <= viewRight && e.Y == cell.Y)
                    //    {
                    //        if (e.X >= cell.X && e.X <= RegionOfEatingRight)
                    //        {
                    //            eat.RemoveAll(c => c == e);
                    //            cell.Eating();
                    //            cell.PathIsClear = true;
                    //            break;

                    //        }
                    //        else
                    //        {
                    //            cell.Move(MaxWidthField, MaxHeightField, 1);
                    //            cell.PathIsClear = false;
                    //            break;
                    //        }
                    //    }
                    //    /* цель слева на одной высоте */
                    //    if (e.X <= cell.X && e.X >= viewLeft && e.Y == cell.Y)
                    //    {
                    //        if (e.X <= cell.X && e.X >= RegionOfEatingLeft)
                    //        {
                    //            eat.RemoveAll(c => c == e);
                    //            cell.Eating();
                    //            cell.PathIsClear = true;
                    //            break;
                    //        }
                    //        else
                    //        {
                    //            cell.Move(MaxWidthField, MaxHeightField, 2);
                    //            cell.PathIsClear = false;
                    //            break;
                    //        }
                    //    }
                    //    /* цель снизу на одной ширине */
                    //    if (e.Y >= cell.Y && e.Y <= viewDown && e.X == cell.X)
                    //    {
                    //        if (e.Y >= cell.Y && e.Y <= RegionOfEatingDown)
                    //        {
                    //            eat.RemoveAll(c => c == e);
                    //            cell.Eating();
                    //            cell.PathIsClear = true;
                    //            break;
                    //        }
                    //        else
                    //        {
                    //            cell.Move(MaxWidthField, MaxHeightField, 3);
                    //            cell.PathIsClear = false;
                    //            break;
                    //        }
                    //    }
                    //    /* цель сверху на одной ширине */
                    //    if (e.Y <= cell.Y && e.Y >= viewUp && e.X == cell.X)
                    //    {
                    //        if (e.Y <= cell.Y && e.Y >= RegionOfEatingUp)
                    //        {
                    //            eat.RemoveAll(c => c == e);
                    //            cell.Eating();
                    //            cell.PathIsClear = true;
                    //            break;
                    //        }
                    //        else
                    //        {
                    //            cell.Move(MaxWidthField, MaxHeightField, 4);
                    //            cell.PathIsClear = false;
                    //            break;
                    //        }
                    //    }
                    //    /* цель в первой четверти */
                    //    if ((e.X >= cell.X && e.X <= viewRight) && (e.Y <= cell.Y && e.Y >= viewUp))
                    //    {
                    //        if ((e.X >= cell.X && e.X <= RegionOfEatingRight) && (e.Y <= cell.Y && e.Y >= RegionOfEatingUp))
                    //        {
                    //            eat.RemoveAll(c => c == e);
                    //            cell.Eating();
                    //            cell.PathIsClear = true;
                    //            break;
                    //        }
                    //        else
                    //        {
                    //            cell.Move(MaxWidthField, MaxHeightField, 5);
                    //            cell.PathIsClear = false;
                    //            break;
                    //        }
                    //    }
                    //    /* цель во второй четверти */
                    //    if ((e.X <= cell.X && e.X >= viewLeft) && (e.Y <= cell.Y && e.Y >= viewUp))
                    //    {
                    //        if ((e.X <= cell.X && e.X >= RegionOfEatingLeft) && (e.Y <= cell.Y && e.Y >= RegionOfEatingUp))
                    //        {
                    //            eat.RemoveAll(c => c == e);
                    //            cell.Eating();
                    //            cell.PathIsClear = true;
                    //            break;
                    //        }
                    //        else
                    //        {
                    //            cell.Move(MaxWidthField, MaxHeightField, 6);
                    //            cell.PathIsClear = false;
                    //            break;
                    //        }
                    //    }
                    //    /* цель в третьей четверти */
                    //    if ((e.X <= cell.X && e.X >= viewLeft) && (e.Y >= cell.Y && e.Y <= viewDown))
                    //    {
                    //        if ((e.X <= cell.X && e.X >= RegionOfEatingLeft) && (e.Y >= cell.Y && e.Y <= RegionOfEatingDown))
                    //        {
                    //            eat.RemoveAll(c => c == e);
                    //            cell.Eating();
                    //            cell.PathIsClear = true;
                    //            break;
                    //        }
                    //        else
                    //        {
                    //            cell.Move(MaxWidthField, MaxHeightField, 7);
                    //            cell.PathIsClear = false;
                    //            break;
                    //        }
                    //    }
                    //    /* цель в четвертой четверти */
                    //    if ((e.X >= cell.X && e.X <= viewRight) && (e.Y >= cell.Y && e.Y <= viewDown))
                    //    {
                    //        if ((e.X >= cell.X && e.X <= RegionOfEatingRight) && (e.Y >= cell.Y && e.Y <= RegionOfEatingDown))
                    //        {
                    //            eat.RemoveAll(c => c == e);
                    //            cell.Eating();
                    //            cell.PathIsClear = true;
                    //            break;
                    //        }
                    //        else
                    //        {
                    //            cell.Move(MaxWidthField, MaxHeightField, 8);
                    //            cell.PathIsClear = false;
                    //            break;
                    //        }
                    //    }
                    //}
                }
                #endregion
            }
        }
        public void Evolution()
        {
            foreach (var cell in cells.ToArray())
            {
                if (cell is CarnivorousLowCell)
                {
                    if (cell.CountOfEating >= 3)
                    {
                        if (SettingsGame.rnd.Next(SettingsGame.ChanceOfEvolutionCarnivorousLowCell) == 1)
                        {
                            AddCell(new CarnivorousMediumCell(cell.X, cell.Y, cell.ID));
                            cells.RemoveAll(c => c == cell);
                        }
                    }
                }
                if (cell is CarnivorousMediumCell)
                {
                    if (cell.CountOfEating >= 4)
                    {
                        if (SettingsGame.rnd.Next(SettingsGame.ChanceOfEvolutionCarnivorousMediumCell) == 1)
                        {
                            AddCell(new CarnivorousHighCell(cell.X, cell.Y, cell.ID));
                            cells.RemoveAll(c => c == cell);
                        }
                    }

                }
                if (cell is HerbivoreLowCell)
                {
                    if (cell.CountOfEating >= 3)
                    {
                        if (SettingsGame.rnd.Next(SettingsGame.ChanceOfEvolutionHerbivoreLowCell) == 1)
                        {
                            AddCell(new HerbivoreMediumCell(cell.X, cell.Y, cell.ID));
                            cells.RemoveAll(c => c == cell);
                        }
                    }
                }
                if (cell is HerbivoreMediumCell)
                {
                    if (cell.CountOfEating >= 3)
                    {
                        if (SettingsGame.rnd.Next(SettingsGame.ChanceOfEvolutionHerbivoreMediumCell) == 1)
                        {
                            AddCell(new HerbivoreHighCell(cell.X, cell.Y, cell.ID));
                            cells.RemoveAll(c => c == cell);
                        }
                    }
                }
                if (cell is OmnivoreLowCell)
                {
                    if (cell.CountOfEating >= 4)
                    {
                        if (SettingsGame.rnd.Next(SettingsGame.ChanceOfEvolutionOmnivoreLowCell) == 1)
                        {
                            AddCell(new OmnivoreMediumCell(cell.X, cell.Y, cell.ID));
                            cells.RemoveAll(c => c == cell);
                        }
                    }
                }
                if (cell is OmnivoreMediumCell)
                {
                    if (cell.CountOfEating >= 5)
                    {
                        if (SettingsGame.rnd.Next(SettingsGame.ChanceOfEvolutionOmnivoreMediumCell) == 1)
                        {
                            AddCell(new OmnivoreHighCell(cell.X, cell.Y, cell.ID));
                            cells.RemoveAll(c => c == cell);
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
            for(int i = 0; i < SettingsGame.CountOfCells; i++)
            {
                a = SettingsGame.rnd.Next(1, 4);
                if (a == 1)
                {
                    for (int c = 0; c < count * SettingsGame.CountOfCarnivoriusCell;)
                    {
                        AddCell(new CarnivorousLowCell(SettingsGame.rnd.Next(MaxWidthField), SettingsGame.rnd.Next(MaxHeightField), SettingsGame.GetID().ToString()));
                        break;
                    }
                }
                if (a == 2)
                {
                    for (int h = 0; h < count * SettingsGame.CountOfHerbivoreCells;)
                    {
                        AddCell(new HerbivoreLowCell(SettingsGame.rnd.Next(MaxWidthField), SettingsGame.rnd.Next(MaxHeightField), SettingsGame.GetID().ToString()));
                        break;
                    }
                }
                if (a == 3)
                {
                    for (int o = 0; o < count * SettingsGame.CountOfOmnivoreCell;)
                    {
                        AddCell(new OmnivoreLowCell(SettingsGame.rnd.Next(MaxWidthField), SettingsGame.rnd.Next(MaxHeightField), SettingsGame.GetID().ToString()));
                        break;
                    }
                }
            }
        }
        public bool Division()
        {
            for (int i = SettingsGame.RndNumber(cells.Count);;)
            {
                if (cells[i].CountOfEating >= 1)
                {
                    if (cells[i] is CarnivorousLowCell)
                    {
                        if (SettingsGame.RndNumber(SettingsGame.ChanceOfDivision) == 1)
                        {
                            AddCell(new CarnivorousLowCell(cells[i].X, cells[i].Y, cells[i].ID));
                            return true;
                        }
                    }
                    if (cells[i] is CarnivorousMediumCell)
                    {
                        if (SettingsGame.RndNumber(SettingsGame.ChanceOfDivision) == 1)
                        {
                            AddCell(new CarnivorousMediumCell(cells[i].X, cells[i].Y, cells[i].ID));
                            return true;
                        }
                    }
                    if (cells[i] is CarnivorousHighCell)
                    {
                        if (SettingsGame.RndNumber(SettingsGame.ChanceOfDivision) == 1)
                        {
                            AddCell(new CarnivorousHighCell(cells[i].X, cells[i].Y, cells[i].ID));
                            return true;
                        }
                    }
                    if (cells[i] is HerbivoreLowCell)
                    {
                        if (SettingsGame.RndNumber(SettingsGame.ChanceOfDivision) == 1)
                        {
                            AddCell(new HerbivoreLowCell(cells[i].X, cells[i].Y, cells[i].ID));
                            return true;
                        }
                    }
                    if (cells[i] is HerbivoreMediumCell)
                    {
                        if (SettingsGame.RndNumber(SettingsGame.ChanceOfDivision) == 1)
                        {
                            AddCell(new HerbivoreMediumCell(cells[i].X, cells[i].Y, cells[i].ID));
                            return true;
                        }
                    }
                    if (cells[i] is HerbivoreHighCell)
                    {
                        if (SettingsGame.RndNumber(SettingsGame.ChanceOfDivision) == 1)
                        {
                            AddCell(new HerbivoreHighCell(cells[i].X, cells[i].Y, cells[i].ID));
                            return true;
                        }
                    }
                    if (cells[i] is OmnivoreLowCell)
                    {
                        if (SettingsGame.RndNumber(SettingsGame.ChanceOfDivision) == 1)
                        {
                            AddCell(new OmnivoreLowCell(cells[i].X, cells[i].Y, cells[i].ID));
                            return true;
                        }
                    }
                    if (cells[i] is OmnivoreMediumCell)
                    {
                        if (SettingsGame.RndNumber(SettingsGame.ChanceOfDivision) == 1)
                        {
                            AddCell(new OmnivoreMediumCell(cells[i].X, cells[i].Y, cells[i].ID));
                            return true;
                        }
                    }
                    if (cells[i] is OmnivoreHighCell)
                    {
                        if (SettingsGame.RndNumber(SettingsGame.ChanceOfDivision) == 1)
                        {
                            AddCell(new OmnivoreHighCell(cells[i].X, cells[i].Y, cells[i].ID));
                            return true;
                        }
                    }
                }
                break;
            }
            return false;
        }
        public void Run(int MaxWidthField, int MaxHeightField)
        {
            int viewRight, viewLeft, viewUp, viewDown;
            foreach (var cell in cells.ToArray())
            {
                viewRight = cell.X + cell.Overview;
                viewLeft = cell.X - cell.Overview;
                viewUp = cell.Y - cell.Overview;
                viewDown = cell.Y + cell.Overview;
                if (cell is HerbivoreLowCell || cell is HerbivoreMediumCell || cell is HerbivoreHighCell)
                {
                    foreach(var enemy in cells)
                    {
                        if (enemy is HerbivoreLowCell || enemy is HerbivoreMediumCell || enemy is HerbivoreHighCell || cell.ID == enemy.ID)
                        {
                            continue;
                        }
                        if (SettingsGame.rnd.Next(SettingsGame.ChanceOfRun) == 1)
                        {
                            /* враг справа на одной высоте */
                            if (enemy.X >= cell.X && enemy.X <= viewRight && enemy.Y == cell.Y)
                            {
                                cell.Move(MaxWidthField, MaxHeightField, 2);
                                break;
                            }
                            /* враг слева на одной высоте */
                            if (enemy.X <= cell.X && enemy.X >= viewLeft && enemy.Y == cell.Y)
                            {
                                cell.Move(MaxWidthField, MaxHeightField, 1);
                                break;
                            }
                            /* враг снизу на одной ширине */
                            if (enemy.Y >= cell.Y && enemy.Y <= viewDown && enemy.X == cell.X)
                            {
                                cell.Move(MaxWidthField, MaxHeightField, 4);
                                break;
                            }
                            /* враг сверху на одной ширине */
                            if (enemy.Y <= cell.Y && enemy.Y >= viewUp && enemy.X == cell.X)
                            {
                                cell.Move(MaxWidthField, MaxHeightField, 3);
                                break;
                            }
                            /* враг в первой четверти */
                            if ((enemy.X >= cell.X && enemy.X <= viewRight) && (enemy.Y <= cell.Y && enemy.Y >= viewUp))
                            {
                                cell.Move(MaxWidthField, MaxHeightField, 6);
                                break;
                            }
                            /* враг во второй четверти */
                            if ((enemy.X <= cell.X && enemy.X >= viewLeft) && (enemy.Y <= cell.Y && enemy.Y >= viewUp))
                            {
                                cell.Move(MaxWidthField, MaxHeightField, 7);
                                break;
                            }
                            /* враг в третьей четверти */
                            if ((enemy.X <= cell.X && enemy.X >= viewLeft) && (enemy.Y >= cell.Y && enemy.Y <= viewDown))
                            {
                                cell.Move(MaxWidthField, MaxHeightField, 4);
                                break;
                            }
                            /* враг в четвертой четверти */
                            if ((enemy.X >= cell.X && enemy.X <= viewRight) && (enemy.Y >= cell.Y && enemy.Y <= viewDown))
                            {
                                cell.Move(MaxWidthField, MaxHeightField, 5);
                                break;
                            }
                        }
                        break;
                    }
                }
                else
                {
                    continue;
                }
            }
        }
    }
}