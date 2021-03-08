
using SimulatorOfLive.Logic.Abstract_model;

namespace SimulatorOfLive.Logic.Model.Abstract_model
{
    public interface IObject
    {
        /* Интерфейс описывает любой объект в симуляции */
        byte HitPoint { get; set; } // количество жизней
        int X { get; set; } // расположение объекта на оси X
        int Y { get; set; } // расположение объекта на оси Y
        void GetDamage(); // получение урона 
    }
}