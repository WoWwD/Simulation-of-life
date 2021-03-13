using SimulatorOfLive.Logic.Model.Abstract_model;

namespace SimulatorOfLive.Logic.Model
{
    /* Интерфейс описывает какое-либо существо */
    public interface ICreature
    {
        string ID { get; set; } // уникальный идентификатор 
        byte Speed { get; } // скорость 
        byte Overview { get; } // обзор 
        byte RegionOfEating { get; } // область поедания 
        int CountOfEating { get; set; } // количество съеденного
        bool IsEvolution(); // эволюция 
        bool Eating<T>(T target) where T : IObject; // поедание объектов в симуляции
        int IsTargetInOverview(int XTarget, int YTarget); // поиск цели в обзоре существа
        bool IsTargetInRegionOfEating(int XTarget, int YTarget); // поиск цели в области поедания существа
    }
}