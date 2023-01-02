using SimulationOfLife.Logic.Abstract_model;
using SimulationOfLife.Logic.Model;
using SimulationOfLife.Logic.Model.Abstract_model;
using SimulationOfLife.Logic.Model.Cell;
using SimulationOfLife.Logic.Model.Food;
using SimulatorOfLive.Logic.Services;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SimulationOfLife.Logic.Controller
{
    [XmlInclude(typeof(Food))]
    public class Controller
    {
        public int AmountOfDeaths, AmountOfCycles, AmountOfEvolution, AmountOfDivision;
        public List<FormOfCell> cells;
        public List<Food> food;
        public SerializationService serializationService;
        public Statistics statistics;
        public Controller()
        {
            serializationService = new SerializationService();
            cells = new List<FormOfCell>();
            food = new List<Food>();
            statistics = new Statistics();
        }
        #region Поведение клеток
        public void Move(int MaxWidthField, int MaxHeightField)
        {
            int DirectionOfMove = 0;
            foreach (var cell in cells)
            {
                if (cell is CarnivorousLowCell || cell is CarnivorousMediumCell || cell is CarnivorousHighCell)
                {
                    SearchOfTarget(ref DirectionOfMove, cell, cells);
                    if (DirectionOfMove != 0)
                    {
                        cell.Move(MaxWidthField, MaxHeightField, DirectionOfMove);
                        continue;
                    }
                    else
                    {
                        cell.Move(MaxWidthField, MaxHeightField, SettingsGame.RndNumber(SettingsGame.SpeedOfGame));
                        continue;
                    }
                }
                if (cell is HerbivoreLowCell || cell is HerbivoreMediumCell || cell is HerbivoreHighCell)
                {
                    SearchOfTarget(ref DirectionOfMove, cell, cells);
                    if (DirectionOfMove != 0)
                    {
                        if (DirectionOfMove == 1)
                        {
                            cell.Move(MaxWidthField, MaxHeightField, 3);
                            continue;
                        }
                        if (DirectionOfMove == 2)
                        {
                            cell.Move(MaxWidthField, MaxHeightField, 4);
                            continue;
                        }
                        if (DirectionOfMove == 3)
                        {
                            cell.Move(MaxWidthField, MaxHeightField, 1);
                            continue;
                        }
                        if (DirectionOfMove == 4)
                        {
                            cell.Move(MaxWidthField, MaxHeightField, 2);
                            continue;
                        }
                        if (DirectionOfMove == 5)
                        {
                            cell.Move(MaxWidthField, MaxHeightField, 7);
                            continue;
                        }
                        if (DirectionOfMove == 6)
                        {
                            cell.Move(MaxWidthField, MaxHeightField, 8);
                            continue;
                        }
                        if (DirectionOfMove == 7)
                        {
                            cell.Move(MaxWidthField, MaxHeightField, 5);
                            continue;
                        }
                        if (DirectionOfMove == 8)
                        {
                            cell.Move(MaxWidthField, MaxHeightField, 6);
                            continue;
                        }
                    }
                    else
                    {
                        SearchOfTarget(ref DirectionOfMove, cell, food);
                        if (DirectionOfMove != 0)
                        {
                            cell.Move(MaxWidthField, MaxHeightField, DirectionOfMove);
                            continue;
                        }
                        else
                        {
                            cell.Move(MaxWidthField, MaxHeightField, SettingsGame.RndNumber(SettingsGame.SpeedOfGame));
                            continue;
                        }
                    }
                }
                if (cell is OmnivoreLowCell || cell is OmnivoreMediumCell || cell is OmnivoreHighCell)
                {
                    int rnd = SettingsGame.RndNumber(2);
                    if (rnd == 0)
                    {
                        SearchOfTarget(ref DirectionOfMove, cell, cells);
                        if (DirectionOfMove != 0)
                        {
                            cell.Move(MaxWidthField, MaxHeightField, DirectionOfMove);
                            continue;
                        }
                        else
                        {
                            cell.Move(MaxWidthField, MaxHeightField, SettingsGame.RndNumber(SettingsGame.SpeedOfGame));
                            continue;
                        }
                    }
                    if (rnd == 1)
                    {
                        SearchOfTarget(ref DirectionOfMove, cell, food);
                        if (DirectionOfMove != 0)
                        {
                            cell.Move(MaxWidthField, MaxHeightField, DirectionOfMove);
                            continue;
                        }
                        else
                        {
                            cell.Move(MaxWidthField, MaxHeightField, SettingsGame.RndNumber(SettingsGame.SpeedOfGame));
                            continue;
                        }
                    }
                }
            }
        }
        private bool SearchOfTarget<C, T>(ref int DirectionOfMove, C creature, List<T> targets) where C : ICreature where T : IObject
        {
            int result;
            foreach (var target in targets)
            {
                result = creature.IsTargetInOverview(target.X, target.Y);
                if (result != 0 && creature.ID != target.ID)
                {
                    DirectionOfMove = result;
                    return true;
                }
                else
                {
                    DirectionOfMove = 0;
                    return false;
                }
            }
            DirectionOfMove = 0;
            return false;
        }
        private object SearchOfTargetForEating<C, T>(C creature, List<T> targets) where C : ICreature where T : IObject
        {
            bool result;
            foreach (var target in targets)
            {
                result = creature.IsTargetInRegionOfEating(target.X, target.Y);
                if (result == true && creature.ID != target.ID)
                {
                    result = creature.Eating(target.HitPoint);
                    if (result == true)
                    {
                        AmountOfDeaths++;
                        int index = targets.LastIndexOf(target);
                        return index;
                    }
                    else
                    {
                        target.Damage();
                        return null;
                    }
                }
            }
            return null;
        }
        public void Eating()
        {
            object result;
            foreach (var cell in cells.ToArray())
            {
                if (cell is CarnivorousLowCell || cell is CarnivorousMediumCell || cell is CarnivorousHighCell)
                {
                    result = SearchOfTargetForEating(cell, cells);
                    if (result != null)
                    {
                        cells.RemoveAt((int)result);
                    }
                }
                if (cell is HerbivoreLowCell || cell is HerbivoreMediumCell || cell is HerbivoreHighCell)
                {
                    if (SettingsGame.RndNumber(SettingsGame.ChanceOfDefense) == 1)
                    {
                        result = SearchOfTargetForEating(cell, cells);
                        if (result != null)
                        {
                            cells.RemoveAt((int)result);
                        }
                    }
                    else
                    {
                        result = SearchOfTargetForEating(cell, food);
                        if (result != null)
                        {
                            food.RemoveAt((int)result);
                        }
                    }
                }
                if (cell is OmnivoreLowCell || cell is OmnivoreMediumCell || cell is OmnivoreHighCell)
                {
                    result = SearchOfTargetForEating(cell, food);
                    if (result != null)
                    {
                        food.RemoveAt((int)result);
                    }
                    else
                    {
                        result = SearchOfTargetForEating(cell, cells);
                        if (result != null)
                        {
                            cells.RemoveAt((int)result);
                        }
                    }
                }
            }
        }
        public void Evolution()
        {
            foreach (var cell in cells.ToArray())
            {
                if (cell.IsEvolution() == true)
                {
                    AmountOfEvolution++;
                    if (cell is CarnivorousLowCell)
                    {
                        cells.Add(new CarnivorousMediumCell(cell.X, cell.Y, cell.ID));
                        cells.RemoveAll(c => c == cell);
                    }
                    if (cell is CarnivorousMediumCell)
                    {
                        cells.Add(new CarnivorousHighCell(cell.X, cell.Y, cell.ID));
                        cells.RemoveAll(c => c == cell);
                    }
                    if (cell is HerbivoreLowCell)
                    {
                        cells.Add(new HerbivoreMediumCell(cell.X, cell.Y, cell.ID));
                        cells.RemoveAll(c => c == cell);
                    }
                    if (cell is HerbivoreMediumCell)
                    {
                        cells.Add(new HerbivoreHighCell(cell.X, cell.Y, cell.ID));
                        cells.RemoveAll(c => c == cell);
                    }
                    if (cell is OmnivoreLowCell)
                    {
                        cells.Add(new OmnivoreMediumCell(cell.X, cell.Y, cell.ID));
                        cells.RemoveAll(c => c == cell);
                    }
                    if (cell is OmnivoreMediumCell)
                    {
                        cells.Add(new OmnivoreHighCell(cell.X, cell.Y, cell.ID));
                        cells.RemoveAll(c => c == cell);
                    }
                }
            }
        }
        private void AddCell<T>(T cell) where T : FormOfCell 
        { 
            cells.Add(cell); 
        }
        public bool Division()
        {
            if (cells != null && cells.Count != 0)
            {
                foreach (var cell in cells.ToArray())
                {
                    if (cell.IsDivision() == true)
                    {
                        AmountOfDivision++;
                        AddCell(cell);
                        return true;
                    }
                    break;
                }  
            }
            return false;
        }
        #endregion
        public void AddFirstCells(int count, int MaxWidthField, int MaxHeightField)
        {
            for (int c = 0; c < count * SettingsGame.CountOfCarnivoriusCell; c++)
            {
                cells.Add(new CarnivorousLowCell(SettingsGame.RndNumber(MaxWidthField), SettingsGame.RndNumber(MaxHeightField), SettingsGame.GetID().ToString()));
            }
            for (int h = 0; h < count * SettingsGame.CountOfHerbivoreCells; h++)
            {
                cells.Add(new HerbivoreLowCell(SettingsGame.RndNumber(MaxWidthField), SettingsGame.RndNumber(MaxHeightField), SettingsGame.GetID().ToString()));
            }
            for (int o = 0; o < count * SettingsGame.CountOfOmnivoreCell; o++)
            {
                cells.Add(new OmnivoreLowCell(SettingsGame.RndNumber(MaxWidthField), SettingsGame.RndNumber(MaxHeightField), SettingsGame.GetID().ToString()));
            }
            /* перемешивание значений в списке */
            for (int i = cells.Count - 1; i >= 1; i--)
            {
                int j = SettingsGame.RndNumber(i + 1);
                var temp = cells[j];
                cells[j] = cells[i];
                cells[i] = temp;
            }
        }
        public void AddFood(int MaxWidthField, int MaxHeightField)
        {
            if (food.Count >= SettingsGame.LimitOfFood)
            {
                food.RemoveAt(SettingsGame.RndNumber(SettingsGame.LimitOfFood));
            }
            else
            {
                if (SettingsGame.RndNumber(SettingsGame.ChanceOfAddFood) == 1)
                {
                    food.Add(new Food(SettingsGame.RndNumber(MaxWidthField), SettingsGame.RndNumber(MaxHeightField), "food"));
                }
                if (SettingsGame.RndNumber(SettingsGame.ChanceOfDeleteFood) == 1 && food.Count != 0)
                {
                    food.RemoveAt(SettingsGame.RndNumber(food.Count));
                }
            }
        }
        public void Cycle(int MaxWidthField, int MaxHeightField)
        {
            AddFood(MaxWidthField, MaxHeightField);
            Move(MaxWidthField, MaxHeightField);
            Eating();
            Division();
            Evolution();
            AmountOfCycles++;
        }
    }
}