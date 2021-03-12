namespace SimulatorOfLive.Logic.Model
{
    public interface ICreature
    {
        /* Интерфейс, описывающий какое-либо существо */
        string ID { get; set; } // уникальный идентификатор 
        byte HitPoint { get; set; } // количество жизней
        int X { get; set; } // расположение существа на оси X
        int Y { get; set; } // расположение существа на оси Y
        byte Width { get; } // ширина (px)
        byte Height { get; } // высота (px)
        byte Speed { get; } // скорость 
        byte Overview { get; } // обзор 
        byte RegionOfEating { get; } // область поедания 
        int CountOfEating { get; set; } // количество съеденного
        void Move(int MaxWidthField, int MaxHeightField, int DirectionOfMove); // движение 
        bool IsEvolution(); // эволюция 
        //bool Eating(); // приём пищи
        void Damage(); // нанесение повреждений
    }
}