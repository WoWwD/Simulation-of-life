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
            int index;
            foreach (var cell in cells.ToArray())
            {
                #region Травоядные
                if (cell is HerbivoreLowCell || cell is HerbivoreMediumCell || cell is HerbivoreHighCell)
                {
                    foreach(var e in eat.ToArray())
                    {
                        var r = cell.Eating(MaxWidthField, MaxHeightField, e);
                        if (r == true)
                        {
                            index = eat.LastIndexOf(e);
                            eat.RemoveAt(index);
                        }
                    }
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
                    foreach (var e in eat.ToArray())
                    {
                        var r = cell.Eating(MaxWidthField, MaxHeightField, e);
                        if (r == true)
                        {
                            index = eat.LastIndexOf(e);
                            eat.RemoveAt(index);
                        }
                    }
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
                    if (cell.CountOfEating >= SettingsGame.CountOfEatForEvolutionCarnivorousLowCell)
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
                    if (cell.CountOfEating >= SettingsGame.CountOfEatForEvolutionCarnivorousMediumCell)
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
                    if (cell.CountOfEating >= SettingsGame.CountOfEatForEvolutionHerbivoreLowCell)
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
                    if (cell.CountOfEating >= SettingsGame.CountOfEatForEvolutionHerbivoreMediumCell)
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
                    if (cell.CountOfEating >= SettingsGame.CountOfEatForEvolutionOmnivoreLowCell)
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
                    if (cell.CountOfEating >= SettingsGame.CountOfEatForEvolutionOmnivoreMediumCell)
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
            foreach (var cell in cells.ToArray())
            {
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
                            cell.Run(MaxWidthField, MaxHeightField, enemy);
                        }
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