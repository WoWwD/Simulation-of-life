using SimulationOfLife.Logic.Abstract_model;
using SimulationOfLife.Logic.Model.Cell;
using SimulationOfLife.Logic.Model;
using SimulationOfLife.Logic.Model.Food;
using System.Collections.Generic;
using System;

namespace SimulatorOfLive.Logic.Controller
{
    public class ObjectController
    {
        public List<CellModel> cells;
        public List<FoodModel> food;
        private Guid guid;
        private Random rnd;
        public ObjectController()
        {
            cells = new List<CellModel>();
            food = new List<FoodModel>();
            rnd = new Random();
            guid = Guid.NewGuid();
        }
        private object GetID() => guid = Guid.NewGuid();
        public void AddFirstCells(int count, int MaxWidthField, int MaxHeightField)
        {
            for (int c = 0; c < count * SettingsGame.CountOfCarnivoriusCell; c++)
            {
                cells.Add(
                    new CarnivorousLowCell(rnd.Next(MaxWidthField), rnd.Next(MaxHeightField), GetID().ToString())
                );
            }
            for (int h = 0; h < count * SettingsGame.CountOfHerbivoreCells; h++)
            {
                cells.Add(
                    new HerbivoreLowCell(rnd.Next(MaxWidthField), rnd.Next(MaxHeightField), GetID().ToString())
                );
            }
            for (int o = 0; o < count * SettingsGame.CountOfOmnivoreCell; o++)
            {
                cells.Add(
                    new OmnivoreLowCell(rnd.Next(MaxWidthField), rnd.Next(MaxHeightField), GetID().ToString())
                );
            }

            for (int i = cells.Count - 1; i >= 1; i--)
            {
                int j = rnd.Next(i + 1);
                var temp = cells[j];
                cells[j] = cells[i];
                cells[i] = temp;
            }
        }
        public void AddFood(int MaxWidthField, int MaxHeightField)
        {
            if (food.Count >= SettingsGame.FoodLimit)
            {
                food.RemoveAt(rnd.Next(SettingsGame.FoodLimit));
            }
            else
            {
                if (rnd.Next(SettingsGame.ChanceOfAddingFood) == 1)
                {
                    food.Add(new FoodModel(rnd.Next(MaxWidthField), rnd.Next(MaxHeightField), "food"));
                }
                if (rnd.Next(SettingsGame.ChanceOfDeletingFood) == 1 && food.Count != 0)
                {
                    food.RemoveAt(rnd.Next(food.Count));
                }
            }
        }
    }
}
