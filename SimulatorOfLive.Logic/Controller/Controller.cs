using SimulatorOfLive.Logic.Abstract_model;
using SimulatorOfLive.Logic.Model;
using SimulatorOfLive.Logic.Model.Cell;
using SimulatorOfLive.Logic.Model.Food;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace SimulatorOfLive.Logic.Controller
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
            cells = new List<FormOfCell>();
            food = new List<Food>();
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
        public void Move(int MaxWidthField, int MaxHeightField)
        {
            foreach (var cell in cells)
            {
                foreach (var target in cells)
                {
                    if (cell.ID == target.ID)
                    {
                        continue;
                    }
                    if (cell is CarnivorousLowCell || cell is CarnivorousMediumCell || cell is CarnivorousHighCell ||
                        cell is OmnivoreLowCell || cell is OmnivoreMediumCell || cell is OmnivoreHighCell)
                    {
                        cell.Move(MaxWidthField, MaxHeightField, SettingsGame.rnd.Next(SettingsGame.SpeedOfGame), target.X, target.Y);
                        break;
                    }
                    if (cell is HerbivoreLowCell || cell is HerbivoreMediumCell || cell is HerbivoreHighCell)
                    {
                        cell.Run(MaxWidthField, MaxHeightField, target.X, target.Y);
                        break;
                    }
                }
                foreach (var target in food)
                {
                    if (cell is HerbivoreLowCell || cell is HerbivoreMediumCell || cell is HerbivoreHighCell ||
                        cell is OmnivoreLowCell || cell is OmnivoreMediumCell || cell is OmnivoreHighCell)
                    {
                        cell.Move(MaxWidthField, MaxHeightField, SettingsGame.rnd.Next(SettingsGame.SpeedOfGame), target.X, target.Y);
                        break;
                    }
                }
                if (food.Count == 0 /*|| cells.Count == 1*/)
                {
                    cell.Move(MaxWidthField, MaxHeightField, SettingsGame.rnd.Next(SettingsGame.SpeedOfGame), 0, 0);
                }
            }
        }
        public void Eating()
        {
            foreach (var cell in cells.ToArray())
            {
                foreach (var target in cells.ToArray())
                {
                    if (cell.ID == target.ID)
                    {
                        continue;
                    }
                    if (cell is CarnivorousLowCell || cell is CarnivorousMediumCell || cell is CarnivorousHighCell || cell is OmnivoreLowCell || cell is OmnivoreMediumCell || cell is OmnivoreHighCell)
                    {
                        var result = cell.Eating(target);
                        if (result == true)
                        {
                            cells.RemoveAll(c => c == target);
                            break;
                        }
                    }
                    if (cell is HerbivoreLowCell || cell is HerbivoreMediumCell || cell is HerbivoreHighCell)
                    {
                        if (target is CarnivorousLowCell || target is CarnivorousMediumCell || target is CarnivorousHighCell || target is OmnivoreLowCell || target is OmnivoreMediumCell || target is OmnivoreHighCell)
                        {
                            if (SettingsGame.rnd.Next(SettingsGame.ChanceOfDefense) == 1)
                            {
                                var result = cell.Eating(target);
                                if (result == true)
                                {
                                    cells.RemoveAll(c => c == target);
                                    break;
                                }
                            }
                        }
                    }
                }
                foreach (var target in food.ToArray())
                {
                    if (cell is HerbivoreLowCell || cell is HerbivoreMediumCell || cell is HerbivoreHighCell || cell is OmnivoreLowCell || cell is OmnivoreMediumCell || cell is OmnivoreHighCell)
                    {
                        var result = cell.Eating(target);
                        if (result == true)
                        {
                            food.RemoveAll(c => c == target);
                            break;
                        }
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
            if (rnd.Next(30) == 1)
            {
                food.Add(new Food(rnd.Next(MaxWidthField), rnd.Next(MaxHeightField)));
            }
            if (rnd.Next(40) == 1)
            {
                if (food.Count != 0)
                {
                    food.RemoveAt(rnd.Next(food.Count));
                }
            }
        }
        public bool Division()
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
            return false;
        }
        public void AddCellsThroughMouse(int X, int Y)
        {
            cells.Add(new HerbivoreLowCell(X, Y, SettingsGame.GetID().ToString()));
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