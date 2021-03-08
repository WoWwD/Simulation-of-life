
using SimulatorOfLive.Logic.Abstract_model;

namespace SimulatorOfLive.Logic.Model.Abstract_model
{
    public interface ILocation
    {
        /* Интерфейс описывает любой объект в симуляции */
        int X { get; set; } // расположение объекта на оси X
        int Y { get; set; } // расположение объекта на оси Y
    }
}