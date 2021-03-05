using SimulatorOfLive.Logic.Abstract_model;
using SimulatorOfLive.Logic.Controller.Creatures;
using SimulatorOfLive.Logic.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace SimulatorOfLive.Logic.Controller
{
    public class Controller
    {
        public static Random rnd = new Random();
        public Cell<FormOfCell> cells;
        public List<Eat> eat = new List<Eat>();
        public void StartNewGame()
        {
            cells = new Cell<FormOfCell>();
        }
        public void AddFirstCells(int count, int MaxWidthField, int MaxHeightField)
        {
            cells.AddFirstCells(count, MaxWidthField, MaxHeightField);
        }
        public void MoveCells(int MaxWidthField, int MaxHeightField)
        {
            cells.Move(MaxWidthField, MaxHeightField);
        }
        public void Eating(int MaxWidthField, int MaxHeightField)
        {
            cells.Eating(MaxWidthField, MaxHeightField, eat);
        }
        public void EvolutionCells()
        {
            cells.Evolution();
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
            var r = cells.Division();
            if (r == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Run(int MaxWidthField, int MaxHeightField)
        {
            cells.Run(MaxWidthField, MaxHeightField);
        }
        public void AddCellsThroughMouse(int X, int Y)
        {
            cells.AddCell(new HerbivoreLowCell(X, Y, SettingsGame.guid.ToString()));
        }
        public void AddEatThroughMouse(int X, int Y)
        {
            eat.Add(new Eat(X, Y));
        }
        public void DeleteCells()
        {
            cells.cells.Clear();
        }
        public void Serializable()
        {
            var xml = new XmlSerializer(typeof(Cell<FormOfCell>));
            using (var file = new FileStream("SaveGame.xml", FileMode.Create))
            {
                xml.Serialize(file, cells);
            }
        }
        public void DeSerializable()
        {
            StartNewGame();
            var xml = new XmlSerializer(typeof(Cell<FormOfCell>));
            using (var file = new FileStream("SaveGame.xml", FileMode.Open))
            {
                var deser = xml.Deserialize(file) as Cell<FormOfCell>;
                foreach (var cell in deser.cells)
                {
                    cells.AddCell(cell);
                }
            }
        }
    }
}