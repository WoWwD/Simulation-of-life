using SimulatorOfLive.Logic.Model.Abstract_model;

namespace SimulatorOfLive.Logic.Model
{
    public interface ICreature
    {
        /* Интерфейс, описывающий какое-либо существо */
        byte Width { get; } // ширина (px)
        byte Height { get; } // высота (px)
        string ID { get; set; } // уникальный идентификатор 
        byte Speed { get; } // скорость 
        byte Overview { get; } // обзор 
        byte RegionOfEating { get; } // область поедания 
        int CountOfEating { get; set; } // количество съеденного
        void Move(int MaxWidthField, int MaxHeightField, int DirectionOfMove); // движение 
        bool IsEvolution(); // эволюция 
        void Eating(); // приём пищи
    }
}