using SimulationOfLife.Logic.Abstract_model;
using SimulationOfLife.Logic.Model;
using SimulationOfLife.Logic.Model.Abstract_model;
using SimulationOfLife.Logic.Model.Cell;
using SimulationOfLife.Logic.Model.Food;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace SimulationOfLife.Logic.Controller
{
    [XmlInclude(typeof(Food))]
    public class Controller
    {
        private static Random rnd = new Random();
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
            int DirectionOfMove;
            foreach (var cell in cells)
            {
                if (cell is HerbivoreLowCell || cell is HerbivoreMediumCell || cell is HerbivoreHighCell)
                {
                    DirectionOfMove = 0;
                    SearchEnemyForRun(ref DirectionOfMove, cell, true);
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
                if (cell is HerbivoreLowCell || cell is HerbivoreMediumCell || cell is HerbivoreHighCell || cell is OmnivoreLowCell || cell is OmnivoreMediumCell || cell is OmnivoreHighCell)
                {
                    DirectionOfMove = 0;
                    SearchOfTargetForPursuit(ref DirectionOfMove, cell, true);
                    if (DirectionOfMove != 0)
                    {
                        cell.Move(MaxWidthField, MaxHeightField, DirectionOfMove);
                        continue;
                    }
                    else
                    {
                        cell.Move(MaxWidthField, MaxHeightField, SettingsGame.rnd.Next(SettingsGame.SpeedOfGame));
                        continue;
                    }
                }
                DirectionOfMove = 0;
                SearchOfTargetForPursuit(ref DirectionOfMove, cell);
                if (DirectionOfMove != 0)
                {
                    cell.Move(MaxWidthField, MaxHeightField, DirectionOfMove);
                    continue;
                }
                else
                {
                    cell.Move(MaxWidthField, MaxHeightField, SettingsGame.rnd.Next(SettingsGame.SpeedOfGame));
                    continue;
                }
            }
        }
        public void AddFirstCells(int count, int MaxWidthField, int MaxHeightField)
        {
            int a;
            for (int i = 0; i < SettingsGame.CountOfCells; i++)
            {
                a = SettingsGame.rnd.Next(1, 4);
                if (a == 1)
                {
                    for (int c = 0; c < count * SettingsGame.CountOfCarnivoriusCell;)
                    {
                        cells.Add(new CarnivorousLowCell(SettingsGame.rnd.Next(MaxWidthField), SettingsGame.rnd.Next(MaxHeightField), SettingsGame.GetID().ToString()));
                        break;
                    }
                }
                if (a == 2)
                {
                    for (int h = 0; h < count * SettingsGame.CountOfHerbivoreCells;)
                    {
                        cells.Add(new HerbivoreLowCell(SettingsGame.rnd.Next(MaxWidthField), SettingsGame.rnd.Next(MaxHeightField), SettingsGame.GetID().ToString()));
                        break;
                    }
                }
                if (a == 3)
                {
                    for (int o = 0; o < count * SettingsGame.CountOfOmnivoreCell;)
                    {
                        cells.Add(new OmnivoreLowCell(SettingsGame.rnd.Next(MaxWidthField), SettingsGame.rnd.Next(MaxHeightField), SettingsGame.GetID().ToString()));
                        break;
                    }
                }
            }
        }
        private bool SearchOfTargetForPursuit<T>(ref int DirectionOfMove, T cell) where T : ICreature
        {   
            foreach (var target in cells)
            {
                int result = cell.IsTargetInOverview(target.X, target.Y);
                if (result != 0 && cell.ID != target.ID)
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
            return false;
        }
        private bool SearchOfTargetForPursuit<T>(ref int DirectionOfMove, T cell, bool a = true) where T : ICreature
        {
            foreach (var target in food)
            {
                int result = cell.IsTargetInOverview(target.X, target.Y);
                if (result != 0)
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
            return false;
        }
        private bool SearchEnemyForRun<T>(ref int DirectionOfMove, T cell, bool a = true) where T : ICreature
        {
            foreach (var target in food)
            {
                int result = cell.IsTargetInOverview(target.X, target.Y);
                if (result != 0)
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
            return false;
        }
        private object SearchOfTargetForEating<T>(T cell) where T : ICreature
        {
            bool result;
            foreach (var target in cells)
            {
                result = cell.IsTargetInRegionOfEating(target.X, target.Y);
                if (result == true && cell.ID != target.ID)
                {
                    result = cell.Eating(target);
                    if (result == true)
                    {
                        int index = cells.LastIndexOf(target);
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
        private object SearchOfTargetForEating<T>(T cell, bool a = true) where T : ICreature
        {
            bool result;
            foreach (var target in food)
            {
                result = cell.IsTargetInRegionOfEating(target.X, target.Y);
                if (result == true)
                {
                    result = cell.Eating(target);
                    if (result == true)
                    {
                        int index = food.LastIndexOf(target);
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
                if(cell is CarnivorousLowCell || cell is CarnivorousMediumCell || cell is CarnivorousHighCell || cell is OmnivoreLowCell || cell is OmnivoreMediumCell || cell is OmnivoreHighCell)
                {
                    result = SearchOfTargetForEating(cell);
                    if (result != null)
                    {
                        cells.RemoveAt((int)result);
                    }
                }
                if (cell is HerbivoreLowCell || cell is HerbivoreMediumCell || cell is HerbivoreHighCell || cell is OmnivoreLowCell || cell is OmnivoreMediumCell || cell is OmnivoreHighCell)
                {
                    result = SearchOfTargetForEating(cell, true);
                    if (result != null)
                    {
                        food.RemoveAt((int)result);
                    }
                }
            }
        }
        public void Evolution()
        {
            foreach (var cell in cells.ToArray())
            {
                if (cell is CarnivorousLowCell)
                {
                    var r = cell.IsEvolution();
                    if (r == true)
                    {
                        cells.Add(new CarnivorousMediumCell(cell.X, cell.Y, cell.ID));
                        cells.RemoveAll(c => c == cell);
                    }
                }
                if (cell is CarnivorousMediumCell)
                {
                    var r = cell.IsEvolution();
                    if (r == true)
                    {
                        cells.Add(new CarnivorousHighCell(cell.X, cell.Y, cell.ID));
                        cells.RemoveAll(c => c == cell);
                    }
                }
                if (cell is HerbivoreLowCell)
                {
                    var r = cell.IsEvolution();
                    if (r == true)
                    {
                        cells.Add(new HerbivoreMediumCell(cell.X, cell.Y, cell.ID));
                        cells.RemoveAll(c => c == cell);
                    }
                }
                if (cell is HerbivoreMediumCell)
                {
                    var r = cell.IsEvolution();
                    if (r == true)
                    {
                        cells.Add(new HerbivoreHighCell(cell.X, cell.Y, cell.ID));
                        cells.RemoveAll(c => c == cell);
                    }
                }
                if (cell is OmnivoreLowCell)
                {
                    var r = cell.IsEvolution();
                    if (r == true)
                    {
                        cells.Add(new OmnivoreMediumCell(cell.X, cell.Y, cell.ID));
                        cells.RemoveAll(c => c == cell);
                    }
                }
                if (cell is OmnivoreMediumCell)
                {
                    var r = cell.IsEvolution();
                    if (r == true)
                    {
                        cells.Add(new OmnivoreHighCell(cell.X, cell.Y, cell.ID));
                        cells.RemoveAll(c => c == cell);
                    }
                }
            }
        }
        public void AddFood(int MaxWidthField, int MaxHeightField)
        {
            if (rnd.Next(20) == 1)
            {
                food.Add(new Food(rnd.Next(MaxWidthField), rnd.Next(MaxHeightField)));
            }
            if (rnd.Next(30) == 1)
            {
                if (food.Count != 0)
                {
                    food.RemoveAt(rnd.Next(food.Count));
                }
            }
        }
        public bool Division()
        {
            if (cells != null)
            {
                for (int i = SettingsGame.RndNumber(cells.Count); ;)
                {
                    if (cells[i].CountOfEating >= 1)
                    {
                        var result = cells[i].IsDivision();
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

                    }
                    break;
                }
            }
            return false;
        }
        public void AddCellsThroughMouse(int X, int Y)
        {
            cells.Add(new HerbivoreHighCell(X, Y, SettingsGame.GetID().ToString()));
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
    }
}