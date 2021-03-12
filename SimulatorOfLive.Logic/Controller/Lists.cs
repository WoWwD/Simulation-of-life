using SimulatorOfLive.Logic.Abstract_model;
using SimulatorOfLive.Logic.Model.Food;
using System.Collections.Generic;
namespace SimulatorOfLive.Logic.Controller
{
    /* Временное хранение списков объектов для их сериализации/десериализации */
    public class Lists
    {
        public List<FormOfCell> cells;
        public List<Food> food;
    }
}
