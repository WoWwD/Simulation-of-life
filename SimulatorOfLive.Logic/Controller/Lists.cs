using SimulationOfLife.Logic.Abstract_model;
using SimulationOfLife.Logic.Model.Food;
using System.Collections.Generic;

namespace SimulationOfLife.Logic.Controller
{
    /* Временное хранение списков объектов для их сериализации/десериализации */
    public class Lists
    {
        public List<FormOfCell> cells;
        public List<Food> food;
    }
}
