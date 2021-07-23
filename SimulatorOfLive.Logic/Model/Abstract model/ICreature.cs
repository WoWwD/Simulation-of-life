namespace SimulationOfLife.Logic.Model
{
    /* Интерфейс описывает какое-либо существо */
    public interface ICreature
    {
        int X { get; set; }
        int Y { get; set; }
        string ID { get; set; } // уникальный идентификатор 
        byte Speed { get; } // скорость 
        byte Overview { get; } // обзор 
        byte RegionOfEating { get; } // область поедания 
        int CountOfEating { get; set; } // количество съеденного
        bool IsEvolution(); // эволюция 
        void Move(int MaxWidthField, int MaxHeightField, int DirectionOfMove); // движение
        bool Eating(int HitPointTarget); // поедание объектов в симуляции
        int IsTargetInOverview(int XTarget, int YTarget); // поиск цели в области обзора существа
        bool IsTargetInRegionOfEating(int XTarget, int YTarget); // поиск цели в области поедания существа
    }
}