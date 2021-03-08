using SimulatorOfLive.Logic.Abstract_model;
using SimulatorOfLive.Logic.Model;
using SimulatorOfLive.Logic.Model.Cell;
using SimulatorOfLive.Logic.Model.Eat;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace SimulatorOfLive.Logic.Controller
{
    [XmlInclude(typeof(Eat))]
    public class Controller
    {
        public static Random rnd = new Random();
        public List<FormOfCell> cells;
        public List<Eat> eat;
        public void StartNewGame()
        {
            cells = new List<FormOfCell>();
            eat = new List<Eat>();
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
        public void MoveCells(int MaxWidthField, int MaxHeightField)
        {
            foreach (var cell in cells)
            {
                cell.Move(MaxWidthField, MaxHeightField, SettingsGame.rnd.Next(SettingsGame.SpeedOfGame));
            }
        }
        public void Eating(int MaxWidthField, int MaxHeightField)
        {
            int index;
            foreach (var cell in cells.ToArray())
            {
                foreach (var target in cells.ToArray())
                {
                    if (cell == target || cell.ID == target.ID)
                    {
                        continue;
                    }
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
                        //        var r = cell.Damage(enemy);
                        //        if (r == true)
                        //        {
                        //            break;
                        //        }
                        //    }
                        //}
                        //foreach (var e in eat.ToArray())
                        //{
                        //    var r = cell.Eat(MaxWidthField, MaxHeightField, e);
                        //    if (r == true)
                        //    {
                        //        index = eat.LastIndexOf(e);
                        //        eat.RemoveAt(index);
                        //    }
                        //}
                    }
                    #endregion

                    #region Плотоядные
                    if (cell is CarnivorousLowCell || cell is CarnivorousMediumCell || cell is CarnivorousHighCell)
                    {
                        var r = cell.Eat(MaxWidthField, MaxHeightField, target);
                        if (r == true)
                        {
                            index = cells.LastIndexOf(target);
                            cells.RemoveAt(index);
                        }
                    }
                    #endregion

                    #region Всеядные
                    if (cell is OmnivoreLowCell || cell is OmnivoreMediumCell || cell is OmnivoreHighCell)
                    {
                        var r = cell.Eat(MaxWidthField, MaxHeightField, target);
                        if (r == true)
                        {
                            index = cells.LastIndexOf(target);
                            cells.RemoveAt(index);
                        }
                        //foreach (var e in eat.ToArray())
                        //{
                        //    var r = cell.Eat(MaxWidthField, MaxHeightField, e);
                        //    if (r == true)
                        //    {
                        //        index = eat.LastIndexOf(e);
                        //        eat.RemoveAt(index);
                        //    }
                        //}
                    }
                    #endregion
                }
            }
        }
        public void Evolution()
        {
            foreach (FormOfCell cell in cells.ToArray())
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
        }
        public void AddEat(int MaxWidthField, int MaxHeightField)
        {
            if (rnd.Next(20) == 1)
            {
                eat.Add(new Eat(rnd.Next(MaxWidthField), rnd.Next(MaxHeightField)));
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
        public void Run(int MaxWidthField, int MaxHeightField)
        {
            foreach (var cell in cells)
            {
                if (cell is HerbivoreLowCell || cell is HerbivoreMediumCell || cell is HerbivoreHighCell)
                {
                    foreach (var enemy in cells)
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
        public void AddCellsThroughMouse(int X, int Y)
        {
            cells.Add(new HerbivoreLowCell(X, Y, SettingsGame.guid.ToString()));
        }
        public void AddEatThroughMouse(int X, int Y)
        {
            eat.Add(new Eat(X, Y));
        }
        public void DeleteCells()
        {
            cells.Clear();
        }
        public void Serializable()
        {
            var cell = new XmlSerializer(typeof(List<FormOfCell>));
            using (var file = new FileStream("SaveGame.xml", FileMode.Create))
            {
                cell.Serialize(file, cells);
            }
        }
        public void DeSerializable()
        {
            StartNewGame();
            var list1 = new XmlSerializer(typeof(List<FormOfCell>));
            using (var file = new FileStream("SaveGame.xml", FileMode.Open))
            {
                var deser1 = list1.Deserialize(file) as List<FormOfCell>;
                foreach (var c in deser1)
                {
                    cells.Add(c);
                }
            }
        }
    }
}