﻿namespace SimulatorOfLive.Logic.Model
{
    public interface ICreature
    {
        /* Интерфейс, описывающий какое-либо существо */

        string ID { get; set; } // уникальный идентификатор 
        byte HitPoint { get; set; } // количество жизней
        byte Speed { get; } // скорость 
        byte Overview { get; } // обзор 
        byte Width { get; } // ширина (px)
        byte Height { get; } // высота (px)
        byte RegionOfEating { get; } // область поедания 
        int CountOfEating { get; set; } // количество съеденного
        void Move(int MaxWidthField, int MaxHeightField, int DirectionOfMove); // движение 
        bool IsEvolution(); // эволюция 
        void GetDamage(); // получение урона 
        void Eating(); // приём пищи
    }
}