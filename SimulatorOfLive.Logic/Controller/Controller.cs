using SimulatorOfLive.Logic.Abstract_model;
using SimulatorOfLive.Logic.Model;
using SimulatorOfLive.Logic.Model.Abstract_model;
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
        public static Random rnd = new Random();
        public List<FormOfCell> cells;
        public List<Food> food;
        Lists lists;
        //public List<object> objects;
        public void StartNewGame()
        {
            cells = new List<FormOfCell>();
            food = new List<Food>();
            //objects = new List<object>();
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
                        cell.Move(MaxWidthField, MaxHeightField, SettingsGame.rnd.Next(SettingsGame.SpeedOfGame));
                        continue;
                    }
                    if (cell is HerbivoreLowCell || cell is HerbivoreMediumCell || cell is HerbivoreHighCell ||
                    cell is OmnivoreLowCell || cell is OmnivoreMediumCell || cell is OmnivoreHighCell)
                    {
                        foreach (var e in food)
                        {
                            cell.Move(MaxWidthField, MaxHeightField, SettingsGame.rnd.Next(SettingsGame.SpeedOfGame), e.X, e.Y);
                            break;
                        }
                    }
                    if (target is HerbivoreLowCell || target is HerbivoreMediumCell || target is HerbivoreHighCell)
                    {
                        cell.Move(MaxWidthField, MaxHeightField, SettingsGame.rnd.Next(SettingsGame.SpeedOfGame));
                        break;
                    }
                    cell.Move(MaxWidthField, MaxHeightField, SettingsGame.rnd.Next(SettingsGame.SpeedOfGame), target.X, target.Y);
                    break;
                }
            }
        }
        public void Eating()
        {
            int index;
            foreach (var cell in cells.ToArray())
            {
                #region Травоядные
                if (cell is HerbivoreLowCell || cell is HerbivoreMediumCell || cell is HerbivoreHighCell)
                {
                    //if (SettingsGame.rnd.Next(50000) == 1)
                    //{
                    //    foreach (var enemy in cells.ToArray())
                    //    {
                    //        if (enemy.ID == cell.ID)
                    //        {
                    //            continue;
                    //        }
                    //        var r = cell.Eat(enemy);
                    //        if (r == true)
                    //        {
                    //            break;
                    //        }
                    //    }
                    //}
                    foreach (var e in food.ToArray())
                    {
                        var r = cell.Eating(e.X, e.Y);
                        if (r == true)
                        {
                            index = food.LastIndexOf(e);
                            food.RemoveAt(index);
                            break;
                        }
                    }
                }
                #endregion

                #region Плотоядные
                if (cell is CarnivorousLowCell || cell is CarnivorousMediumCell || cell is CarnivorousHighCell)
                {
                    foreach (var target in cells.ToArray())
                    {
                        if (cell.ID == target.ID)
                        {
                            continue;
                        }
                        var result = cell.Eating(target);
                        if (result == true)
                        {
                            index = cells.LastIndexOf(target);
                            cells.RemoveAt(index);
                            break;
                        }
                    }
                }
                #endregion

                #region Всеядные
                if (cell is OmnivoreLowCell || cell is OmnivoreMediumCell || cell is OmnivoreHighCell)
                {
                    foreach (var target in cells.ToArray())
                    {
                        if (cell.ID == target.ID)
                        {
                            continue;
                        }
                        var result = cell.Eating(target);
                        if (result == true)
                        {
                            index = cells.LastIndexOf(target);
                            cells.RemoveAt(index);
                            break;
                        }
                    }
                    foreach (var e in food.ToArray())
                    {
                        var r = cell.Eating(e.X, e.Y);
                        if (r == true)
                        {
                            index = food.LastIndexOf(e);
                            food.RemoveAt(index);
                            break;
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
                    var r = cell.IsEvolution();
                    if (r == true)
                    {
                        if (SettingsGame.rnd.Next(SettingsGame.ChanceOfEvolutionCarnivorousLowCell) == 1)
                        {
                            cells.Add(new CarnivorousMediumCell(cell.X, cell.Y, cell.ID));
                            cells.RemoveAll(c => c == cell);
                        }
                    }
                }
                if (cell is CarnivorousMediumCell)
                {
                    var r = cell.IsEvolution();
                    if (r == true)
                    {
                        if (SettingsGame.rnd.Next(SettingsGame.ChanceOfEvolutionCarnivorousMediumCell) == 1)
                        {
                            cells.Add(new CarnivorousHighCell(cell.X, cell.Y, cell.ID));
                            cells.RemoveAll(c => c == cell);
                        }
                    }

                }
                if (cell is HerbivoreLowCell)
                {
                    var r = cell.IsEvolution();
                    if (r == true)
                    {
                        if (SettingsGame.rnd.Next(SettingsGame.ChanceOfEvolutionHerbivoreLowCell) == 1)
                        {
                            cells.Add(new HerbivoreMediumCell(cell.X, cell.Y, cell.ID));
                            cells.RemoveAll(c => c == cell);
                        }
                    }
                }
                if (cell is HerbivoreMediumCell)
                {
                    var r = cell.IsEvolution();
                    if (r == true)
                    {
                        if (SettingsGame.rnd.Next(SettingsGame.ChanceOfEvolutionHerbivoreMediumCell) == 1)
                        {
                            cells.Add(new HerbivoreHighCell(cell.X, cell.Y, cell.ID));
                            cells.RemoveAll(c => c == cell);
                        }
                    }
                }
                if (cell is OmnivoreLowCell)
                {
                    var r = cell.IsEvolution();
                    if (r == true)
                    {
                        if (SettingsGame.rnd.Next(SettingsGame.ChanceOfEvolutionOmnivoreLowCell) == 1)
                        {
                            cells.Add(new OmnivoreMediumCell(cell.X, cell.Y, cell.ID));
                            cells.RemoveAll(c => c == cell);
                        }
                    }
                }
                if (cell is OmnivoreMediumCell)
                {
                    var r = cell.IsEvolution();
                    if (r == true)
                    {
                        if (SettingsGame.rnd.Next(SettingsGame.ChanceOfEvolutionOmnivoreMediumCell) == 1)
                        {
                            cells.Add(new OmnivoreHighCell(cell.X, cell.Y, cell.ID));
                            cells.RemoveAll(c => c == cell);
                        }
                    }
                }
            }


            //foreach (var cell in cells.ToArray())
            //{
            //    var cell = obj as FormOfCell;
            //    if (cell is CarnivorousLowCell)
            //    {
            //        var r = cell.IsEvolution();
            //        if (r == true)
            //        {
            //            if (SettingsGame.rnd.Next(SettingsGame.ChanceOfEvolutionCarnivorousLowCell) == 1)
            //            {
            //                objects.Add(new CarnivorousMediumCell(cell.X, cell.Y, cell.ID));
            //                objects.RemoveAll(c => c == cell);
            //            }
            //        }
            //    }
            //    if (cell is CarnivorousMediumCell)
            //    {
            //        var r = cell.IsEvolution();
            //        if (r == true)
            //        {
            //            if (SettingsGame.rnd.Next(SettingsGame.ChanceOfEvolutionCarnivorousMediumCell) == 1)
            //            {
            //                objects.Add(new CarnivorousHighCell(cell.X, cell.Y, cell.ID));
            //                objects.RemoveAll(c => c == cell);
            //            }
            //        }

            //    }
            //    if (cell is HerbivoreLowCell)
            //    {
            //        var r = cell.IsEvolution();
            //        if (r == true)
            //        {
            //            if (SettingsGame.rnd.Next(SettingsGame.ChanceOfEvolutionHerbivoreLowCell) == 1)
            //            {
            //                objects.Add(new HerbivoreMediumCell(cell.X, cell.Y, cell.ID));
            //                objects.RemoveAll(c => c == cell);
            //            }
            //        }
            //    }
            //    if (cell is HerbivoreMediumCell)
            //    {
            //        var r = cell.IsEvolution();
            //        if (r == true)
            //        {
            //            if (SettingsGame.rnd.Next(SettingsGame.ChanceOfEvolutionHerbivoreMediumCell) == 1)
            //            {
            //                objects.Add(new HerbivoreHighCell(cell.X, cell.Y, cell.ID));
            //                objects.RemoveAll(c => c == cell);
            //            }
            //        }
            //    }
            //    if (cell is OmnivoreLowCell)
            //    {
            //        var r = cell.IsEvolution();
            //        if (r == true)
            //        {
            //            if (SettingsGame.rnd.Next(SettingsGame.ChanceOfEvolutionOmnivoreLowCell) == 1)
            //            {
            //                objects.Add(new OmnivoreMediumCell(cell.X, cell.Y, cell.ID));
            //                objects.RemoveAll(c => c == cell);
            //            }
            //        }
            //    }
            //    if (cell is OmnivoreMediumCell)
            //    {
            //        var r = cell.IsEvolution();
            //        if (r == true)
            //        {
            //            if (SettingsGame.rnd.Next(SettingsGame.ChanceOfEvolutionOmnivoreMediumCell) == 1)
            //            {
            //                objects.Add(new OmnivoreHighCell(cell.X, cell.Y, cell.ID));
            //                objects.RemoveAll(c => c == cell);
            //            }
            //        }
            //    }
            //}
        }
        public void AddFood(int MaxWidthField, int MaxHeightField)
        {
            if (rnd.Next(30) == 1)
            {
                food.Add(new Food(rnd.Next(MaxWidthField), rnd.Next(MaxHeightField)));
            }
        }
        public bool Division()
        {
            for (int i = SettingsGame.RndNumber(cells.Count); ;)
            {
                if (cells[i].CountOfEating >= 1)
                {
                    if (cells[i] is CarnivorousLowCell)
                    {
                        if (SettingsGame.RndNumber(SettingsGame.ChanceOfDivision) == 1)
                        {
                            cells.Add(new CarnivorousLowCell(cells[i].X, cells[i].Y, cells[i].ID));
                            return true;
                        }
                    }
                    if (cells[i] is CarnivorousMediumCell)
                    {
                        if (SettingsGame.RndNumber(SettingsGame.ChanceOfDivision) == 1)
                        {
                            cells.Add(new CarnivorousMediumCell(cells[i].X, cells[i].Y, cells[i].ID));
                            return true;
                        }
                    }
                    if (cells[i] is CarnivorousHighCell)
                    {
                        if (SettingsGame.RndNumber(SettingsGame.ChanceOfDivision) == 1)
                        {
                            cells.Add(new CarnivorousHighCell(cells[i].X, cells[i].Y, cells[i].ID));
                            return true;
                        }
                    }
                    if (cells[i] is HerbivoreLowCell)
                    {
                        if (SettingsGame.RndNumber(SettingsGame.ChanceOfDivision) == 1)
                        {
                            cells.Add(new HerbivoreLowCell(cells[i].X, cells[i].Y, cells[i].ID));
                            return true;
                        }
                    }
                    if (cells[i] is HerbivoreMediumCell)
                    {
                        if (SettingsGame.RndNumber(SettingsGame.ChanceOfDivision) == 1)
                        {
                            cells.Add(new HerbivoreMediumCell(cells[i].X, cells[i].Y, cells[i].ID));
                            return true;
                        }
                    }
                    if (cells[i] is HerbivoreHighCell)
                    {
                        if (SettingsGame.RndNumber(SettingsGame.ChanceOfDivision) == 1)
                        {
                            cells.Add(new HerbivoreHighCell(cells[i].X, cells[i].Y, cells[i].ID));
                            return true;
                        }
                    }
                    if (cells[i] is OmnivoreLowCell)
                    {
                        if (SettingsGame.RndNumber(SettingsGame.ChanceOfDivision) == 1)
                        {
                            cells.Add(new OmnivoreLowCell(cells[i].X, cells[i].Y, cells[i].ID));
                            return true;
                        }
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
                        if (SettingsGame.RndNumber(SettingsGame.ChanceOfDivision) == 1)
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
        //public void Run(int MaxWidthField, int MaxHeightField)
        //{
        //    foreach (var cell in cells)
        //    {
        //        if (cell is HerbivoreLowCell || cell is HerbivoreMediumCell || cell is HerbivoreHighCell)
        //        {
        //            foreach (var enemy in cells)
        //            {
        //                if (enemy is HerbivoreLowCell || enemy is HerbivoreMediumCell || enemy is HerbivoreHighCell || cell.ID == enemy.ID)
        //                {
        //                    continue;
        //                }
        //                if (SettingsGame.rnd.Next(SettingsGame.ChanceOfRun) == 1)
        //                {
        //                    cell.Run(MaxWidthField, MaxHeightField, enemy);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            continue;
        //        }
        //    }
        //}
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
            StartNewGame();
            var objects = new XmlSerializer(typeof(Lists));
            using (var file = new FileStream("SaveGame.xml", FileMode.Open))
            {
                var deser = objects.Deserialize(file) as Lists;
                cells = lists.cells;
                food = lists.food;
            }
        }
    }
}