using System;

namespace SimulationOfLife.Logic.Model
{
    public static class SettingsGame
    {
        private static readonly Random rnd = new Random();
        public static Guid guid = Guid.NewGuid();
        public static int CountOfCells = 500;
        public static int AmountOfCycles = 1000;

        #region Эволюция клеток
        #region Шанс эволюции
        public static int ChanceOfEvolutionCarnivorousLowCell = 10; 
        public static int ChanceOfEvolutionCarnivorousMediumCell = 10; 
        public static int ChanceOfEvolutionCarnivorousHighCell = 228; 
        public static int ChanceOfEvolutionHerbivoreLowCell = 10; 
        public static int ChanceOfEvolutionHerbivoreMediumCell = 10; 
        public static int ChanceOfEvolutionHerbivoreHighCell = 228;
        public static int ChanceOfEvolutionOmnivoreLowCell = 10; 
        public static int ChanceOfEvolutionOmnivoreMediumCell = 10;                                                    
        public static int ChanceOfEvolutionOmnivoreHighCell = 228;
        #endregion
        #region Количество еды для эволюции
        public static int CountOfEatForEvolutionCarnivorousLowCell = 4;
        public static int CountOfEatForEvolutionCarnivorousMediumCell = 5;
        public static int CountOfEatForEvolutionCarnivorousHighCell = 228;  

        public static int CountOfEatForEvolutionHerbivoreLowCell = 3;
        public static int CountOfEatForEvolutionHerbivoreMediumCell = 4;
        public static int CountOfEatForEvolutionHerbivoreHighCell = 228; 

        public static int CountOfEatForEvolutionOmnivoreLowCell = 4;
        public static int CountOfEatForEvolutionOmnivoreMediumCell = 5;
        public static int CountOfEatForEvolutionOmnivoreHighCell = 228;
        #endregion
        #endregion
        public static int CountOfEatForDivision = 2;
        #region Еда
        public static int LimitOfFood = 150; // Предел еды, после которого она удаляется с поля
        public static byte ChanceOfAddFood = 20; // Вероятность добавления еды на поле
        public static byte ChanceOfDeleteFood = 30; // Вероятность удаления еды с поля в течение игры
        #endregion
        public static int ChanceOfDefense = 10; // Шанс травоядной клетки нанести урон вражеской клетке
        public static int ChanceOfDivision = 10; // Шанс деления клетки

        public static int SpeedOfGame = 10; // Скорость игры. Чем больше, тем медленнее.

        public static double CountOfCarnivoriusCell = 0.4; // Доля (% от общего количества клеток) плотоядных клеток в начале
        public static double CountOfHerbivoreCells = 0.4; // Доля (% от общего количества клеток) травоядных клеток в начале
        public static double CountOfOmnivoreCell = 0.2; // Доля (% от общего количества клеток) всеядных клеток в начале
        public static object GetID() 
        {
            return guid = Guid.NewGuid();
        }
        public static int RndNumber(int param)
        {
            return rnd.Next(param);
        }
    }
}