using SimulatorOfLive.Logic.Abstract_model;
using SimulatorOfLive.Logic.Controller.Creatures;
using SimulatorOfLive.Logic.Model;
using SimulatorOfLive.Logic.Model.Cell;
using System;
using System.Collections.Generic;

namespace SimulatorOfLive.Logic.Controller
{
    public class Controller
    {
        public static Random rnd = new Random();
        public Cell<FormOfCell> cells= new Cell<FormOfCell>();
        public List<Eat> eat = new List<Eat>();
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
        public void AddCellsThroughMouse(int X, int Y)
        {
            cells.AddCell(new CarnivorousLowCell(X, Y, SettingsGame.guid.ToString()));
        }
        public void AddEatThroughMouse(int X, int Y)
        {
            eat.Add(new Eat(X, Y));
        }
    }
}