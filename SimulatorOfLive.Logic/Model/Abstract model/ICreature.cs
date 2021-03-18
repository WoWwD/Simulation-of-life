using SimulationOfLife.Logic.Model.Abstract_model;

namespace SimulationOfLife.Logic.Model
{
    /* Интерфейс описывает какое-либо существо */
    public interface ICreature
    {
        string ID { get; set; } // уникальный идентификатор 
        byte Speed { get; } // скорость 
        byte Overview { get; } // обзор 
        byte RegionOfEating { get; } // область поедания 
        int CountOfEating { get; set; } // количество съеденного
        int X { get; set; } // расположение на оси X
        int Y { get; set; } // расположение на оси Y
        bool IsEvolution(); // эволюция 
        void Move(int MaxWidthField, int MaxHeightField, int DirectionOfMove); // движение
        bool Eating(int HitPointTarget); // поедание объектов в симуляции
        int IsTargetInOverview(int XTarget, int YTarget); // поиск цели в области обзора существа
        bool IsTargetInRegionOfEating(int XTarget, int YTarget); // поиск цели в области поедания существа
    }
}