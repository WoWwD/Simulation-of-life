using SimulationOfLife.Logic.Abstract_model;
using SimulationOfLife.Logic.Model;
using SimulationOfLife.Logic.Model.Abstract_model;
using SimulationOfLife.Logic.Model.Cell;
using SimulationOfLife.Logic.Model.Food;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace SimulationOfLife.Logic.Controller
{
    [XmlInclude(typeof(Food))]
    public class Controller
    {
        public Dictionary<string, int> dict = new Dictionary<string, int>();
        public List<FormOfCell> cells;
        public List<Food> food;
        Lists lists;
        public void StartNewGame()
        {
            SettingsGame.CountOfCells = 500;
            cells = new List<FormOfCell>();
            food = new List<Food>();
        }
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
        private bool SearchOfTarget<C,T>(ref int DirectionOfMove, C creature, List<T> targets) where C : ICreature where T : IObject
        {
            int result;
            foreach (var target in targets)
            {
                result = creature.IsTargetInOverview(target.X, target.Y);
                if (result != 0 && (object)creature != (object)target)
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
        private object SearchOfTargetForEating<C,T>(C creature, List<T> targets) where C : ICreature where T : IObject
        {
            bool result;
            foreach (var target in targets)
            {
                result = creature.IsTargetInRegionOfEating(target.X, target.Y);
                if (result == true && (object)creature != (object)target)
                {
                    result = creature.Eating(target.HitPoint);
                    if (result == true)
                    {
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
                if(cell is CarnivorousLowCell || cell is CarnivorousMediumCell || cell is CarnivorousHighCell)
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
            bool result;
            foreach (var cell in cells.ToArray())
            {
                result = cell.IsEvolution();
                if (cell is CarnivorousLowCell)
                {
                    if (result == true)
                    {
                        cells.Add(new CarnivorousMediumCell(cell.X, cell.Y, cell.ID));
                        cells.RemoveAll(c => c == cell);
                    }
                }
                if (cell is CarnivorousMediumCell)
                {
                    if (result == true)
                    {
                        cells.Add(new CarnivorousHighCell(cell.X, cell.Y, cell.ID));
                        cells.RemoveAll(c => c == cell);
                    }
                }
                if (cell is HerbivoreLowCell)
                {
                    if (result == true)
                    {
                        cells.Add(new HerbivoreMediumCell(cell.X, cell.Y, cell.ID));
                        cells.RemoveAll(c => c == cell);
                    }
                }
                if (cell is HerbivoreMediumCell)
                {
                    if (result == true)
                    {
                        cells.Add(new HerbivoreHighCell(cell.X, cell.Y, cell.ID));
                        cells.RemoveAll(c => c == cell);
                    }
                }
                if (cell is OmnivoreLowCell)
                {
                    if (result == true)
                    {
                        cells.Add(new OmnivoreMediumCell(cell.X, cell.Y, cell.ID));
                        cells.RemoveAll(c => c == cell);
                    }
                }
                if (cell is OmnivoreMediumCell)
                {
                    if (result == true)
                    {
                        cells.Add(new OmnivoreHighCell(cell.X, cell.Y, cell.ID));
                        cells.RemoveAll(c => c == cell);
                    }
                }
            }
        }
        public void AddFood(int MaxWidthField, int MaxHeightField)
        {
            if (SettingsGame.RndNumber(20) == 1)
            {
                food.Add(new Food(SettingsGame.RndNumber(MaxWidthField), SettingsGame.RndNumber(MaxHeightField)));
            }
            if (SettingsGame.RndNumber(40) == 1 && food.Count != 0)
            {
                food.RemoveAt(SettingsGame.RndNumber(food.Count));
            }
            if (food.Count > 150)
            {
                if (SettingsGame.RndNumber(10) == 1 && food.Count != 0)
                {
                    food.RemoveAt(SettingsGame.RndNumber(food.Count));
                }
            }
        }
        public bool Division()
        {
            if (cells != null && cells.Count != 0)
            {
                for (int i = SettingsGame.RndNumber(cells.Count); ;)
                {
                    bool result = cells[i].IsDivision();
                    if (result == true)
                    {
                        if (cells[i] is CarnivorousLowCell)
                        {
                            cells.Add(new CarnivorousLowCell(cells[i].X, cells[i].Y, cells[i].ID));
                            return true;
                        }
                        if (cells[i] is CarnivorousMediumCell)
                        {
                            cells.Add(new CarnivorousMediumCell(cells[i].X, cells[i].Y, cells[i].ID));
                            return true;
                        }
                        if (cells[i] is CarnivorousHighCell)
                        {
                            cells.Add(new CarnivorousHighCell(cells[i].X, cells[i].Y, cells[i].ID));
                            return true;
                        }
                        if (cells[i] is HerbivoreLowCell)
                        {
                            cells.Add(new HerbivoreLowCell(cells[i].X, cells[i].Y, cells[i].ID));
                            return true;
                        }
                        if (cells[i] is HerbivoreMediumCell)
                        {
                            cells.Add(new HerbivoreMediumCell(cells[i].X, cells[i].Y, cells[i].ID));
                            return true;
                        }
                        if (cells[i] is HerbivoreHighCell)
                        {
                            cells.Add(new HerbivoreHighCell(cells[i].X, cells[i].Y, cells[i].ID));
                            return true;
                        }
                        if (cells[i] is OmnivoreLowCell)
                        {
                            cells.Add(new OmnivoreLowCell(cells[i].X, cells[i].Y, cells[i].ID));
                            return true;
                        }
                        if (cells[i] is OmnivoreMediumCell)
                        {
                            if (SettingsGame.RndNumber(SettingsGame.ChanceOfDivision) == 1)
                            {
                                cells.Add(new OmnivoreMediumCell(cells[i].X, cells[i].Y, cells[i].ID));
                                return true;
                            }
                        }
                        if (cells[i] is OmnivoreHighCell)
                        {
                            cells.Add(new OmnivoreHighCell(cells[i].X, cells[i].Y, cells[i].ID));
                            return true;
                        }
                    }
                    break;
                }
            }
            return false;
        }
        public void AddCellsThroughMouse(int X, int Y)
        {
            cells.Add(new CarnivorousMediumCell(X, Y, SettingsGame.GetID().ToString()));
        }
        public void AddEatThroughMouse(int X, int Y)
        {
            food.Add(new Food(X, Y));
        }
        public void Serializable()
        {
            lists = new Lists();
            lists.cells = cells;
            lists.food = food;
            var objects = new XmlSerializer(typeof(Lists));
            using (var file = new FileStream("SaveGame.xml", FileMode.Create))
            {
                objects.Serialize(file, lists);
            }
        }
        public void DeSerializable()
        {
            lists = new Lists();
            StartNewGame();
            var objects = new XmlSerializer(typeof(Lists));
            using (var file = new FileStream("SaveGame.xml", FileMode.Open))
            {
                var deser = objects.Deserialize(file) as Lists;
                cells = deser.cells;
                food = deser.food;
            }
            SettingsGame.CountOfCells = cells.Count;
        }
        public string CountingDivisions()
        {
            int count = 0;
            string name = "no value";
            dict.Clear();
            foreach (var cell in cells)
            {
                if (dict.ContainsKey(cell.ID))
                {
                    dict[cell.ID]++;
                }
                else
                {
                    dict.Add(cell.ID, 1);
                }
            }
            foreach (var cell in dict)
            {
                if (cell.Value > count)
                {
                    count = cell.Value;
                    name = cell.Key;
                }
            }
            return $"Наибольшее количество живых потомков у \"{name}\" : {count}";
        }
        public void IsInZone(int MaxWidthField, int MaxHeightField)
        {
            foreach (var cell in cells.ToArray())
            {
                if (cell.X >= MaxWidthField || cell.Y >= MaxHeightField)
                {
                    int index = cells.LastIndexOf(cell);
                    cells.RemoveAt(index);
                }
            }
        }
    }
}