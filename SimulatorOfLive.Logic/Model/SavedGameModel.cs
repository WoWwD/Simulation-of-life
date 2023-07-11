using SimulationOfLife.Logic.Abstract_model;
using SimulationOfLife.Logic.Model.Food;
using System.Collections.Generic;

namespace SimulatorOfLive.Logic.Model
{
    public class SavedGameModel
    {
        public List<CellModel> cells;
        public List<FoodModel> food;
    }
}
