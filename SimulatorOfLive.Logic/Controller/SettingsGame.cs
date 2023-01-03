using System;

namespace SimulationOfLife.Logic.Model
{
    public static class SettingsGame
    {
        public const int CountOfCells = 750;
        public const int AmountOfCycles = 2000;

        #region Эволюция клеток
        #region Шанс эволюции
        public const int ChanceOfEvolutionCarnivorousLowCell = 10; 
        public const int ChanceOfEvolutionCarnivorousMediumCell = 10; 
        public const int ChanceOfEvolutionCarnivorousHighCell = 228; 

        public const int ChanceOfEvolutionHerbivoreLowCell = 10; 
        public const int ChanceOfEvolutionHerbivoreMediumCell = 10; 
        public const int ChanceOfEvolutionHerbivoreHighCell = 228;

        public const int ChanceOfEvolutionOmnivoreLowCell = 10; 
        public const int ChanceOfEvolutionOmnivoreMediumCell = 10;                                                    
        public const int ChanceOfEvolutionOmnivoreHighCell = 228;
        #endregion
        #region Количество еды для эволюции
        public const int CountOfEatForEvolutionCarnivorousLowCell = 4;
        public const int CountOfEatForEvolutionCarnivorousMediumCell = 5;
        public const int CountOfEatForEvolutionCarnivorousHighCell = 228;  

        public const int CountOfEatForEvolutionHerbivoreLowCell = 3;
        public const int CountOfEatForEvolutionHerbivoreMediumCell = 4;
        public const int CountOfEatForEvolutionHerbivoreHighCell = 228; 

        public const int CountOfEatForEvolutionOmnivoreLowCell = 4;
        public const int CountOfEatForEvolutionOmnivoreMediumCell = 5;
        public const int CountOfEatForEvolutionOmnivoreHighCell = 228;
        #endregion
        #endregion
        public const int CountOfEatForDivision = 2;
        #region Еда
        public const int LimitOfFood = 150; // Предел еды, после которого она удаляется с поля
        public const byte ChanceOfAddFood = 20; // Вероятность добавления еды на поле
        public const byte ChanceOfDeleteFood = 30; // Вероятность удаления еды с поля в течение игры
        #endregion
        public const int ChanceOfDefense = 10; // Шанс травоядной клетки нанести урон вражеской клетке
        public const int ChanceOfDivision = 5; // Шанс деления клетки

        public const int SpeedOfGame = 10; // Скорость игры. Чем больше, тем медленнее.

        public const double CountOfCarnivoriusCell = 0.4; // Доля (% от общего количества клеток) плотоядных клеток в начале
        public const double CountOfHerbivoreCells = 0.4; // Доля (% от общего количества клеток) травоядных клеток в начале
        public const double CountOfOmnivoreCell = 0.2; // Доля (% от общего количества клеток) всеядных клеток в начале
    }
}